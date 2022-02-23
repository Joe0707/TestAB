using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAjustForPlatform : MonoBehaviour {
	[Tooltip("位置偏移(谨慎和Top/Bottom/Left/Right混用)")]
	public Vector3 m_LocalPosDelta; //偏移

	[Tooltip("缩放值，用这个值乘以原始等scale")]
	public float m_ScaleValue = 1f;//缩放值
    public RuntimePlatform[] mForPlatforms; //可运行的平台

	[Tooltip("实验用的按钮,点选相当于平台匹配，需要调整")]
	public bool m_TestTrue = false; //实验用的按钮

    void Start () {
			//判断当前平台是否需要调整
			var curPlatform = Application.platform;
            bool needAjust = false;
            foreach (var p in mForPlatforms)
            {
                if (p == curPlatform)
                {
                    needAjust = true;
                    break;
            }
        }
        //需要调整
        if (needAjust || (Application.isEditor && m_TestTrue))
        {
            //计算位置偏移量
            var rectTransform = GetComponent<RectTransform>();
            if (rectTransform != null)
            {//UI
                rectTransform.anchoredPosition3D = rectTransform.anchoredPosition3D + m_LocalPosDelta;
            }
            else
            {//普通物体
                transform.localPosition = transform.localPosition + m_LocalPosDelta;
            }
            //缩放
            transform.localScale *= m_ScaleValue;
        }
    }

}
