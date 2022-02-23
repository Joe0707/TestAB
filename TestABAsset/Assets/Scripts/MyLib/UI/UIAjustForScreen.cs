using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//主要处理物体在某分辨率下的偏移和缩放
public class UIAjustForScreen : MonoBehaviour
{
    //常用都屏幕比例
    public enum ECommonScreenRatio
    {
        R_3X4,//ipad(最宽)
        R_2X3,//iphone 4 (标准制作比例)
        R_10X16,//iphone 7 
        R_9X16,//小米note
        R_Mi8,//全面屏
        R_IphoneX,//最长
    }

    [Tooltip("位置偏移(谨慎和Top/Bottom/Left/Right混用)")]
    public Vector3 m_LocalPosDelta; //偏移
    [Tooltip("根据父窗口偏移量的UI模式，修改Top值")]
    public float m_TopDelta = 0f;
    [Tooltip("根据父窗口偏移量的UI模式，修改Bottom值")]
    public float m_BottomDelta = 0f;
    [Tooltip("根据父窗口偏移量的UI模式，修改Left值")]
    public float m_LeftDelta = 0f;
    [Tooltip("根据父窗口偏移量的UI模式，修改Right值")]
    public float m_RightDelta = 0f;
    [Tooltip("整体缩放值")]
    public float m_ScaleValue = 1f;//缩放值

    [Tooltip("从此分辨率起始")]
    public ECommonScreenRatio m_StartFromRatio = ECommonScreenRatio.R_2X3;
    [Tooltip("当此分辨率时，调整成设置的偏移和缩放")]
    public ECommonScreenRatio m_AtRatio = ECommonScreenRatio.R_3X4;//当屏幕高度是

    void Start()
    {
        //调整的起始比例
        var startRatio = GetRatioValue(m_StartFromRatio);
        //调整的目标比例
        var endRatio = GetRatioValue(m_AtRatio);
        //当前都屏幕比例
        var curRatio = Screen.width / (float)Screen.height;
        //当前分辨率落在起始和结束的区间的百分比	
        float percentBetweenStartAndEnd = 0f;
        if (startRatio < endRatio)
        {
            if (curRatio <= startRatio)
                percentBetweenStartAndEnd = 0;
            else if (curRatio >= endRatio)
                percentBetweenStartAndEnd = 1f;
            else
                percentBetweenStartAndEnd = (curRatio - startRatio) / (endRatio - startRatio);
        }
        else if (startRatio > endRatio)
        {
            if (curRatio <= endRatio)
                percentBetweenStartAndEnd = 1;
            else if (curRatio >= startRatio)
                percentBetweenStartAndEnd = 0f;
            else
                percentBetweenStartAndEnd = (curRatio - startRatio) / (endRatio - startRatio);
        }
        //计算位置偏移量
        var rectTransform = GetComponent<RectTransform>();
        Vector3 applyPosDelta = m_LocalPosDelta * percentBetweenStartAndEnd;
        if (rectTransform != null)
        {//UI
            rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D + applyPosDelta;
        }
        else
        {//普通物体
            transform.localPosition = transform.localPosition + applyPosDelta;
        }
        //缩放
        float applyScale = 1f;
        if (m_ScaleValue >= 1)
        {
            applyScale = 1 + (percentBetweenStartAndEnd * (m_ScaleValue - 1));
        }
        else
        {
            applyScale = 1 - (percentBetweenStartAndEnd * (1 - m_ScaleValue));
        }
        transform.localScale *= applyScale;

        //top bottom left right
        if (rectTransform != null)
        {
            if (rectTransform.anchorMax.x == 1f && rectTransform.anchorMin.x == 0f)
            {//横向
                rectTransform.offsetMin = rectTransform.offsetMin + new Vector2(percentBetweenStartAndEnd * m_LeftDelta, 0);
                rectTransform.offsetMax = rectTransform.offsetMax + new Vector2(-percentBetweenStartAndEnd * m_RightDelta, 0);
            }
            if (rectTransform.anchorMax.y == 1f && rectTransform.anchorMin.y == 0f)
            {//纵向
                rectTransform.offsetMin = rectTransform.offsetMin + new Vector2(0, percentBetweenStartAndEnd * m_BottomDelta);
                rectTransform.offsetMax = rectTransform.offsetMax + new Vector2(0, -percentBetweenStartAndEnd * m_TopDelta);
            }
        }
    }

    //根据比例枚举返回比例数值
    float GetRatioValue(ECommonScreenRatio ratio)
    {
        float retValue = 1f;
        switch (ratio)
        {
            case ECommonScreenRatio.R_2X3://ipad(最宽)
                retValue = 2f / 3f;
                break;
            case ECommonScreenRatio.R_3X4://iphone 4 (标准制作比例)
                retValue = 3f / 4f;
                break;
            case ECommonScreenRatio.R_10X16://iphone 7 
                retValue = 10f / 16f;
                break;
            case ECommonScreenRatio.R_9X16://小米note
                retValue = 9f / 16f;
                break;
            case ECommonScreenRatio.R_Mi8://全面屏
                retValue = 1080f / 2248f;
                break;
            case ECommonScreenRatio.R_IphoneX://最长
                retValue = 1125f / 2436f;
                break;
            default:
                Debug.LogError("No value returned for ratio:" + ratio.ToString());
                break;
        }
        //如果是横屏
        if (Screen.width > Screen.height)
            retValue = 1 / retValue;
        return retValue;
    }
}
