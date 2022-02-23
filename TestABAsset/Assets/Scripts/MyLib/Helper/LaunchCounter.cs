using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//启动计数器
public class LaunchCounter {
    static int sAppLaunchCounter = 0; //打开游戏都次数
	public static int AppLaunchTimes{get{return sAppLaunchCounter;}} //打开游戏的次数

	static int sContinuallyLaunchDays = 1; //连续登陆天数
	public static int ContinuallyLaunchDays { get{return sContinuallyLaunchDays;}} //连续登陆天数

	//从GlobalData调用
    public static void OnAppLaunched()
    {
		//登陆次数
        sAppLaunchCounter = CryptoPrefs.GetInt("sAppLaunchCounter", 0);
        sAppLaunchCounter += 1;
        CryptoPrefs.SetInt("sAppLaunchCounter", sAppLaunchCounter);
		//连续登陆天数
		//读取上次登陆游戏记录
        int year = CryptoPrefs.GetInt("LastLaunch_Year", 2000);
        int month = CryptoPrefs.GetInt("LastLaunch_Month", 1);
        int day = CryptoPrefs.GetInt("LastLaunch_Day", 1);
        System.DateTime lastLaunchDate = new System.DateTime(year, month, day);//上次启动的日期
        sContinuallyLaunchDays = CryptoPrefs.GetInt("sContinuallyLaunchDays", 1);//上次登陆到第几日
        System.DateTime now = System.DateTime.Now;
		if(year != now.Year || month != now.Month || day != now.Day)
        {//和上次登陆不是同一天了
            if ((now - lastLaunchDate).Days >= 2)
            {//隔了一天
                sContinuallyLaunchDays = 1; //重新开始记
            }
			else if((now - lastLaunchDate).Days > 0)
                sContinuallyLaunchDays++; //连续登陆+1
        }
		//保存连续登陆天数
        CryptoPrefs.SetInt("sContinuallyLaunchDays", sContinuallyLaunchDays);
		CryptoPrefs.SetInt("LastLaunch_Year", now.Year);
        CryptoPrefs.SetInt("LastLaunch_Month", now.Month);
        CryptoPrefs.SetInt("LastLaunch_Day", now.Day);
		Debug.Log("ContinuallyLaunchDays:" + sContinuallyLaunchDays);
    }
}
