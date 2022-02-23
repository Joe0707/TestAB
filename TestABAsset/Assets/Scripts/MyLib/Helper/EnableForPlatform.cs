using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//仅在指定的平台才启用
public class EnableForPlatform : MonoBehaviour {

	public RuntimePlatform[] mEnablePlatforms; //可运行的平台
	[Tooltip("实验用的按钮,点选相当于平台不匹配，需要隐藏")]
	public bool m_Test = false; //实验用的按钮
	// Use this for initialization
	void Start () {
		if(IsEnabled == false|| (Application.isEditor && m_Test))
		{//隐藏此对象
			gameObject.SetActive(false);
		}
	}
	void OnEnable()
	{
        if (IsEnabled == false|| (Application.isEditor && m_Test))
		{//隐藏此对象
			gameObject.SetActive(false);
		}	
	}
	public bool IsEnabled{
        get
        {
            var curPlatform = Application.platform;
            bool enable = false;
            foreach (var p in mEnablePlatforms)
            {
                if (p == curPlatform)
                {
                    enable = true;
                    break;
                }
            }
            return enable;
        }
	}
}
