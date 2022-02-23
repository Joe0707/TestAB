using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCameraCtrl : MonoBehaviour
{
    public Vector2 Margin, Smoothing;
    public BoxCollider2D Bounds;
    public WorldMap worldMap;
    private Vector3
        _min,
        _max;
    public Vector2 first = Vector2.zero;//鼠标第一次落下点
    public Vector2 second = Vector2.zero;//鼠标第二次位置（拖拽位置）
    public Vector3 vecPos = Vector3.zero;
    public bool IsNeedMove = false;//是否需要移动
    private static Dictionary<string, PointData> mPointDatas;  //城市ID->城市data
    [System.NonSerialized]
    public static GameObject MapPointParent; //路点父节点
    private void Awake()
    {
    }
    public void Start()
    {
        //Bounds.size = worldMap.GetComponent<RectTransform>().sizeDelta;
        //GetComponent<RectTransform>().sizeDelta
        //Screen.width
        _min = Bounds.bounds.min;// + new Vector3(Screen.width / 2, Screen.height, 0);//包围盒
        _max = Bounds.bounds.max;// - new Vector3(Screen.width / 2, Screen.height, 0);
        first.x = transform.position.x;//初始化
        first.y = transform.position.y;
        //进入大地图默认相机高度
        Camera.main.orthographicSize = 350;
    }

    public void MapOnDrag(Vector2 mousePos)
    {
        second = mousePos;
        Vector3 fir = first;// Camera.main.ScreenToWorldPoint(new Vector3(first.x, first.y, 0));//转换至世界坐标
        Vector3 sec = second; // Camera.main.ScreenToWorldPoint(new Vector3(second.x, second.y, 0));
        vecPos = sec - fir;//需要移动的 向量
                           //vecPos /= 10f;
        first = second;
        IsNeedMove = true;
    }

    public void Update()
    {
        if (IsNeedMove == false)
        {
            return;
        }
        var x = transform.position.x;
        var y = transform.position.y;
        vecPos *= 0.5f;
        x = x - vecPos.x;//向量偏移
        y = y - vecPos.y;

        var cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
        //保证不会移除包围盒
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void SetOrthographicSize(float value)
    {
        if (gameObject.activeInHierarchy == false)
        {
            return;
        }
        float fov = Camera.main.orthographicSize + value;
        if (fov <= 600 && fov >= 200)
        {
            Camera.main.orthographicSize = fov;
            var x = transform.position.x;
            var y = transform.position.y;
            // x = x - vecPos.x;//向量偏移
            // y = y + vecPos.y;

            var cameraHalfWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
            //保证不会移除包围盒
            x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    public static void SetCameraPos(Transform pointPos)
    {
        Camera.main.transform.position = new Vector3(pointPos.position.x, pointPos.position.y, 0);
    }

    public static PointDatas GetPointDatas()
    {
        PointDatas datas = ConfigManager.Instance.LoadJsonConfig<PointDatas>("Data/MapJson/PointDatas");
        // string json = ResourcesManager.Instance.LoadResource<TextAsset>().text;
        // PointDatas datas = JsonUtility.FromJson<PointDatas>(json);
        return datas;
    }

    public static PointTypes GetPointTypes()
    {
        PointTypes datas = ConfigManager.Instance.LoadJsonConfig<PointTypes>("Data/MapJson/PointType");
        return datas;
    }

    public static FunctionSets GetFunctionSets()
    {
        FunctionSets datas = ConfigManager.Instance.LoadJsonConfig<FunctionSets>("Data/MapJson/FunctionSet");
        return datas;
    }
    public static PointData GetPointData(string cityId)
    {
        if (mPointDatas == null)
        {
            PointDatas datas = ConfigManager.Instance.LoadJsonConfig<PointDatas>("Data/MapJson/PointDatas");
            mPointDatas = new Dictionary<string, PointData>();
            for (int i = 0; i < datas.pointDatas.Count; i++)
            {
                mPointDatas[datas.pointDatas[i].pointID] = datas.pointDatas[i];
            }
        }
        return mPointDatas[cityId];
    }
    public void PlayeCameraAnimtion(string pointID, System.Action callback)
    {
        StartCoroutine(_PlayeCameraAnimtion(pointID, callback));
    }
    float timeTakenDuringLerp = 10f;
    float _timeStartedLerping = 0;
    float mOrthographicSize = 200;
    IEnumerator _PlayeCameraAnimtion(string pointID, System.Action callback)
    {
        var pointData = GetPointData(pointID);
        Vector3 vec = new Vector3(float.Parse(pointData.x.ToString()), float.Parse(pointData.y), 0);
        var uiToWorldObj = transform.GetChild(0);
        uiToWorldObj.SetParent(MapPointParent.transform);
        uiToWorldObj.localPosition = vec;
        var positionoffsetmagnitude = (uiToWorldObj.transform.position - transform.position).magnitude;
        _timeStartedLerping = Time.time;
        while (positionoffsetmagnitude > 0.5 && Camera.main.orthographicSize - mOrthographicSize > 0.5f)
        {
            float timeSince = Time.time - _timeStartedLerping; //时间间隔
            float percentageComplete = timeSince / timeTakenDuringLerp;
            transform.position = Vector2.Lerp(transform.position, uiToWorldObj.transform.position, percentageComplete);
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, mOrthographicSize, percentageComplete);
            yield return new WaitForFixedUpdate();
            positionoffsetmagnitude = (uiToWorldObj.transform.position - transform.position).magnitude;
        }
        callback();
    }
}
