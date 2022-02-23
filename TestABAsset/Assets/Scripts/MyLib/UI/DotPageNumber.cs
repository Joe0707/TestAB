using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotPageNumber : MonoBehaviour {
	public Sprite m_GreenDotSprite; //亮点
	public Sprite m_GreyDotSprite; //灰点
	public float m_DotSpace = 10; //间隔
	int mCurNumber = 1; //当前数字
    public int CurNumber //当前数字
    {
        get
        {
            return mCurNumber;
        }
        set
        {
            if (m_DotImages == null)
                return;
            if (value > 0 && value <= m_DotImages.Length)
            {
                mCurNumber = value;
                UpdatePageNumber();
            }
        }
    }//当前数字
    Image[] m_DotImages = null; //点的控件列表
    void Start()
    {
    }
    public void SetMaxNumber(int maxNumber)
    {
        if (m_DotImages != null)
        {
            //先销毁现有的
            foreach (var image in m_DotImages)
            {
                GameObject.Destroy(image.gameObject);
            }
        }
		if(maxNumber <= 0)
			return;
        //创建新的点
		var dotPosSpage = m_GreyDotSprite.rect.width + m_DotSpace; //点的间隔
		float halfDotQueueLength = 0.5f * (maxNumber - 1) * dotPosSpage; //整个队列宽度的一半尺寸
        m_DotImages = new Image[maxNumber];
        for (int i = 0; i < maxNumber; i++)
        {
			var newObject = new GameObject();
			newObject.name = "Dot_" + i;
			//设定图片
			var dotImg = newObject.AddComponent<Image>();
			m_DotImages[i] = dotImg;
			dotImg.sprite = m_GreyDotSprite;
			dotImg.SetNativeSize();
			//设定层级
			newObject.transform.parent = gameObject.transform;
			newObject.transform.localScale = Vector3.one;
			//设定位置
			var rectTrans = newObject.transform as RectTransform;
            rectTrans.anchoredPosition3D = new Vector3(i * (dotPosSpage) - halfDotQueueLength, 0, 0);
        }
    }
    //更新显示
    void UpdatePageNumber()
    {
		for(int i = 0; i < m_DotImages.Length; i++)
		{
            if (i + 1 == mCurNumber) //绿点
                m_DotImages[i].sprite = m_GreenDotSprite;
            else//灰点
                m_DotImages[i].sprite = m_GreyDotSprite;
        }
    }
}
