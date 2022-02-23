using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using XLua;
using System;
public enum ESlidingDirection { Horizontal, Vertical }; //滑动方向
public enum EArrangementMode { Single, Multiple }; //排列方式
//[CSharpCallLua]
public delegate void RefreshItem(int index, GameObject prefab); //(刷新下标，预制体)
//[CSharpCallLua]
public delegate bool RequestItemData(int Index);
public class ScrollViewInfiniteSliding : MonoBehaviour
{
    public int m_MaxItemPrefabNum; //Item最大数量
    int ItemNum;//item数量
    int MaxItemNum; //item最大数量
    RectTransform ContentRectTransform; //物体根节点RectTransform
    ScrollRect scrollRect; //ScrollRect组件
    float ItemHeight; //item高
    float ItemWidth; //item宽
    public float Interval; //Item间隔
    int firstIndex = 0; //开始下标索引
    int lastIndex = 0; //结尾下标索引
    public ESlidingDirection m_SlidingDirection = ESlidingDirection.Vertical; //滑动方向
    List<GameObject> Items = new List<GameObject>(); //单列预制体列表
    List<List<GameObject>> MultipleItems = new List<List<GameObject>>(); //多列预制体列表
    public RefreshItem refreshItem; //item刷新
    public RequestItemData requestItemData; //请求数据
    bool IsRequestData = true; //是否请求数据
    public EArrangementMode arrangementMode = EArrangementMode.Single; //排列方式
    int Row = 0;
    int Col = 0;
    int EndIndex = 0; //item末尾下标
    // Start is called before the first frame update
    void Awake()
    {
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    //刷新ScrollView (数据当前刷新数量，从哪个下标开始，item预制体，是否需要向服务器请求数据)
    public void RefreshScrollView(int curItemDataNum, int index, GameObject itemPrefab, bool isRequestData)
    {
        ItemNum = curItemDataNum;
        IsRequestData = isRequestData;
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnScrollMove);
        ContentRectTransform = scrollRect.content.transform.GetComponent<RectTransform>();
        ItemHeight = itemPrefab.GetComponent<RectTransform>().rect.height + Interval;
        ItemWidth = itemPrefab.GetComponent<RectTransform>().rect.width + Interval;
        if (arrangementMode == EArrangementMode.Single)
            EndIndex = ItemNum;
        else
            EndIndex = (int)Math.Ceiling(ItemNum / Math.Floor(ContentRectTransform.rect.width / ItemWidth));
        InsCountitem(itemPrefab, curItemDataNum, index);
        SetContentHeight(m_SlidingDirection, curItemDataNum);
    }
    public void OnScrollMove(Vector2 vec)
    {
        if (ItemNum <= 0)
        {
            return;
        }
        if (m_SlidingDirection == ESlidingDirection.Vertical)
        {
            //往上滑动
            while (ContentRectTransform.anchoredPosition.y > ItemHeight * (firstIndex + 1) && lastIndex != EndIndex)
            {
                if (arrangementMode == EArrangementMode.Single)
                {
                    GameObject _first = Items[0];
                    RectTransform _firstRect = _first.GetComponent<RectTransform>();
                    Items.RemoveAt(0);
                    Items.Add(_first);
                    _firstRect.anchoredPosition = new Vector2(_firstRect.anchoredPosition.x, -(lastIndex) * ItemHeight);
                    if (refreshItem != null)
                        refreshItem(lastIndex, _first);
                }
                else
                {
                    var _firstObjs = MultipleItems[0];
                    MultipleItems.RemoveAt(0);
                    MultipleItems.Add(_firstObjs);
                    for (int i = 0; i < _firstObjs.Count; i++)
                    {
                        var itemIndex = (lastIndex) * (int)Math.Floor(ContentRectTransform.rect.width / ItemWidth) + i;
                        if (itemIndex < ItemNum)
                        {
                            RectTransform _firstRect = _firstObjs[i].GetComponent<RectTransform>();
                            _firstRect.anchoredPosition = new Vector2(_firstRect.anchoredPosition.x, -ItemHeight / 2 + -ItemHeight * (lastIndex));
                            if (refreshItem != null)
                                refreshItem(itemIndex, _firstObjs[i]);
                        }
                        else
                        {
                            _firstObjs[i].SetActive(false);
                        }

                    }
                }
                firstIndex++;
                lastIndex++;
            }
            //往下滑动
            while (ContentRectTransform.anchoredPosition.y < ItemHeight * (firstIndex) && firstIndex != 0)
            {
                if (arrangementMode == EArrangementMode.Single)
                {
                    var _last = Items[Items.Count - 1];
                    var _lastRect = _last.GetComponent<RectTransform>();
                    Items.RemoveAt(Items.Count - 1);
                    Items.Insert(0, _last);
                    _lastRect.anchoredPosition = new Vector2(_lastRect.anchoredPosition.x, -(firstIndex - 1) * ItemHeight);
                    if (refreshItem != null)
                        refreshItem(firstIndex - 1, _last);
                }
                else
                {
                    var _lastObjs = MultipleItems[MultipleItems.Count - 1];
                    MultipleItems.RemoveAt(MultipleItems.Count - 1);
                    MultipleItems.Insert(0, _lastObjs);
                    for (int i = 0; i < _lastObjs.Count; i++)
                    {
                        _lastObjs[i].SetActive(true);
                        var _lastRect = _lastObjs[i].GetComponent<RectTransform>();
                        _lastRect.anchoredPosition = new Vector2(_lastRect.anchoredPosition.x, -ItemHeight / 2 + -ItemHeight * (firstIndex - 1));
                        if (refreshItem != null)
                            refreshItem((firstIndex - 1) * (int)Math.Floor(ContentRectTransform.rect.width / ItemWidth) + i, _lastObjs[i]);
                    }
                }
                firstIndex -= 1;
                lastIndex -= 1;
            }
            if (lastIndex == ItemNum && IsRequestData == true)
            {
                if (requestItemData != null)
                {
                    IsRequestData = false;
                    requestItemData((int)firstIndex);
                }

            }

        }
    }
    //创建预制体
    public void InsCountitem(GameObject itemPrefab, int itemNum, int index)
    {
        if (itemNum == 0)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].SetActive(false);
            }
            return;
        }
        else
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].SetActive(true);
            }
        }
        var needItemNum = Mathf.Ceil(Mathf.Clamp(m_MaxItemPrefabNum, 0, itemNum));
        if (arrangementMode == EArrangementMode.Single)
        {
            lastIndex = index + (int)needItemNum;
            if (Items.Count > 0)
            {
                if (Items.Count > needItemNum)
                {
                    for (int i = (int)needItemNum + 1; i < Items.Count; i++)
                    {
                        Items[i].SetActive(false);
                    }
                }
                else if (Items.Count < needItemNum)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        Items[i].SetActive(true);
                    }
                    for (int i = Items.Count; i < needItemNum; i++)
                    {
                        CreatItem(m_SlidingDirection, i, itemPrefab);
                    }
                }
                else if (Items.Count == needItemNum)
                {
                    for (int i = 0; i < Items.Count; i++)
                    {
                        Items[i].SetActive(true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < needItemNum; i++)
                {
                    CreatItem(m_SlidingDirection, i, itemPrefab);
                }
            }
        }
        else
        {
            var contentWidth = ContentRectTransform.rect.width; //获取content宽度
            lastIndex = (index + (int)needItemNum) / (int)Math.Floor(contentWidth / ItemWidth);
            if (MultipleItems.Count > 0)
            {
                var MultipleItemsNum = 0;
                for (int i = 0; i < MultipleItems.Count; i++)
                {
                    for (int j = 0; j < MultipleItems[i].Count; j++)
                    {
                        MultipleItemsNum += 1;
                    }
                }
                var itemIndex = 0;
                if (MultipleItemsNum > needItemNum)
                {
                    for (int i = 0; i < MultipleItems.Count; i++)
                    {
                        for (int j = 0; j < MultipleItems[i].Count; j++)
                        {
                            itemIndex += 1;
                            if (itemIndex >= (int)needItemNum + 1)
                            {
                                MultipleItems[i][j].SetActive(false);
                            }
                        }
                    }
                }
                else if (MultipleItemsNum < needItemNum)
                {
                    for (int i = 0; i < MultipleItems.Count; i++)
                    {
                        for (int j = 0; j < MultipleItems[i].Count; j++)
                        {
                            MultipleItems[i][j].SetActive(true);
                        }
                    }
                    for (int i = MultipleItemsNum; i < needItemNum; i++)
                    {
                        CreatItem(m_SlidingDirection, i, itemPrefab);
                    }
                }
                else if (MultipleItemsNum == needItemNum)
                {
                    for (int i = 0; i < MultipleItems.Count; i++)
                    {
                        for (int j = 0; j < MultipleItems[i].Count; j++)
                        {
                            MultipleItems[i][j].SetActive(true);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < needItemNum; i++)
                {
                    CreatItem(m_SlidingDirection, i, itemPrefab);
                }
            }
        }

        firstIndex = index;
        int ItemsIndex = 0;
        for (int i = firstIndex; i < lastIndex; i++)
        {
            if (arrangementMode == EArrangementMode.Single)
            {
                var obj = Items[ItemsIndex];
                var _rect = obj.transform.GetComponent<RectTransform>();
                _rect.anchoredPosition = new Vector2(0, -ItemHeight * i);
                //刷新数据
                if (refreshItem != null)
                    refreshItem(index, obj);
                index++;
            }
            else
            {
                var items = MultipleItems[ItemsIndex];
                for (int j = 0; j < items.Count; j++)
                {
                    var obj = items[j];
                    var _rect = obj.transform.GetComponent<RectTransform>();
                    var contentWidth = ContentRectTransform.rect.width; //获取content宽度i
                    var horizontalQuantity = Math.Floor(contentWidth / ItemWidth); //横向排列个数
                    _rect.anchoredPosition = new Vector2(ItemWidth / 2 + (contentWidth - (int)horizontalQuantity * ItemWidth) / 2 + ItemWidth * j, -ItemHeight / 2 + -ItemHeight * ItemsIndex);
                    if (refreshItem != null)
                        refreshItem(index, obj);
                    index++;
                }
            }
            ItemsIndex++;
        }
    }
    //根据滑动方向创建Item
    public void CreatItem(ESlidingDirection dir, int index, GameObject itemPrefab)
    {
        if (dir == ESlidingDirection.Vertical)
        {
            var obj = GameObject.Instantiate(itemPrefab, ContentRectTransform);
            if (arrangementMode == EArrangementMode.Single)
            {
                var _rect = obj.transform.GetComponent<RectTransform>();
                _rect.pivot = new Vector2(0.5f, 1);
                _rect.anchorMin = new Vector2(0.5f, 1);
                _rect.anchorMax = new Vector2(0.5f, 1);
                _rect.anchoredPosition = new Vector2(0, -ItemHeight * index);
                Items.Add(obj);
            }
            else
            {
                var _rect = obj.transform.GetComponent<RectTransform>();
                _rect.pivot = new Vector2(0.5f, 0.5f);
                _rect.anchorMin = new Vector2(0, 1);
                _rect.anchorMax = new Vector2(0, 1);
                var contentWidth = ContentRectTransform.rect.width; //获取content宽度
                var horizontalQuantity = Math.Floor(contentWidth / ItemWidth); //横向排列个数
                if (index % horizontalQuantity == 0)
                {
                    Col += 1;
                    Row = 0;
                    List<GameObject> items = new List<GameObject>();
                    MultipleItems.Add(items);
                }
                _rect.anchoredPosition = new Vector2(ItemWidth / 2 + (contentWidth - (int)horizontalQuantity * ItemWidth) / 2 + ItemWidth * (Row), -ItemHeight / 2 + -ItemHeight * (Col - 1));
                MultipleItems[Col - 1].Add(obj);
                Row += 1;
            }

        }
        else
        {

        }

    }
    //设置滚动条content的高度
    public void SetContentHeight(ESlidingDirection dir, int itemNum)
    {
        if (dir == ESlidingDirection.Vertical)
        {
            if (arrangementMode == EArrangementMode.Single)
            {
                ContentRectTransform.sizeDelta = new Vector2(0, itemNum * ItemHeight);
                ContentRectTransform.anchorMin = new Vector2(0, 1);
                ContentRectTransform.anchorMax = new Vector2(1, 1);
                ContentRectTransform.anchoredPosition = new Vector2(ContentRectTransform.anchoredPosition.x, firstIndex * ItemHeight);
            }
            else
            {
                var contentWidth = ContentRectTransform.rect.width; //获取content宽度
                var horizontalQuantity = Math.Floor(contentWidth / ItemWidth); //横向排列个数
                var verticalQuantity = Math.Ceiling(itemNum / horizontalQuantity); //纵向排列个数
                ContentRectTransform.sizeDelta = new Vector2(0, (float)verticalQuantity * ItemHeight);
                ContentRectTransform.anchorMin = new Vector2(0, 1);
                ContentRectTransform.anchorMax = new Vector2(1, 1);
                ContentRectTransform.anchoredPosition = new Vector2(ContentRectTransform.anchoredPosition.x, firstIndex * ItemHeight);
            }
        }
        else
        {

        }
    }
    //添加刷新item事件
    public void AddRefreshItemEvent(RefreshItem refreshItemEvent)
    {
        if (refreshItem == null)
            refreshItem += refreshItemEvent;

    }
    //添加获取数据事件
    public void AddItemDataRequestEvent(RequestItemData requestItemDataEvent)
    {
        if (requestItemData == null)
            requestItemData += requestItemDataEvent;

    }
    //刷新一组item事件
    public void AddRefreshItemsEvent()
    {

    }
}
