using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;//添加

public class PluginUtil {
#if UNITY_ANDROID && !UNITY_EDITOR
	static AndroidJavaClass mJavaClass = null;

#elif UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	private static extern void PLTouchFeedBack();
	[DllImport ("__Internal")]
	private static extern void PLShowReviewPanel(string appID);
#endif
    //震动
    public static void TouchFeedBack()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
		InitUtil();
		if(mJavaClass != null)
		{
			long ms = 15;
			mJavaClass.CallStatic("Vibrate", ms);
		}
#elif UNITY_IPHONE && !UNITY_EDITOR
		PLTouchFeedBack();
#else
		//Debug.Log("Touch Feedback");
#endif
    }
public static void ShowReviewPanel(string appID)
    {
#if UNITY_IPHONE && !UNITY_EDITOR
		PLShowReviewPanel(appID);
#endif
    }
    static void InitUtil()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
		if(mJavaClass == null)
		{
			//mJavaClass = new AndroidJavaClass("com.sm2g.unitypluginlib.PluginUtils");
		}
#endif
    }
}
