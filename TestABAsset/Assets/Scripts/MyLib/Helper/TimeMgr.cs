using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading; 
using System.Xml;  

public class TimeMgr : MonoBehaviour {
	public static TimeMgr mInstance = null;
	private DateTime mTime;
	private bool mTimeAvailable = false;//时间是否可以使用了
	private float timeElapsed = 0f;//读取时间后，计算走时使用的时间记录
    private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";  

	void Start () 
	{
		mInstance = this;
		//开始检查网络状态，并获取网络时间
		StartCoroutine(CheckInternetAndGetTime());
	}

	IEnumerator CheckInternetAndGetTime()
	{
        mTimeAvailable = false;
        //检查网络状态，如果没有网络，就一直等待下去
        while (Application.internetReachability == NetworkReachability.NotReachable)
            yield return new WaitForSeconds(2f);
        //有网了，启动一个线程去读网络时间
        Thread thread = new Thread(this.LoadInterNetTime);
        thread.Start();
	}

	//加在网络时间的线程(防止卡主线程）
	void LoadInterNetTime()
	{
		mTimeAvailable = false;

		//如果读不到时间，就一直读（很有可能会连不上，多试几次就能读到了）
		while(mTimeAvailable == false)
		{
			// 遍历时间服务器列表   
			try
			{
				mTime = GetNetTimeFromUrl("http://www.bing.com");
				Debug.Log("Read Time from Net:" + mTime.ToString());
			}
			catch (Exception ex)
			{
				Debug.Log("Exception:" + ex.ToString());
			}
			if(mTimeAvailable == false)
				Thread.Sleep(2);//仍然没有读到，休息一下再重新读取
		}
	}
	
	//获取某个网站GET的返回参数中的时间
	DateTime GetNetTimeFromUrl( string hUrl)  
	{  
		string datetxt = null;         //请求回应的时间  
		string[] date1 = null;         //分割后的星期和日期  
		string date2 = "";              //分割后的日期和GMT  
		string[] date3 = null;         //最终成型的日期  
		DateTime nTime  =DateTime.Now ;   
		string localtime = "";  
		string mon = "";  

		HttpWebRequest request = WebRequest.Create(hUrl) as HttpWebRequest;  
		request.Method = "GET";  
		request.UserAgent = DefaultUserAgent;  

		try  
		{  
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();  

			//获取网站回应请求的日期时间。如： Wed, 08 Feb 2012 06:34:58 GMT  
			datetxt = response.GetResponseHeader("Date");  
			//分割时间  
			date1 = datetxt.Split(',');  
		}  
		catch (Exception ex)  
		{  
			Debug.LogWarning("Unable to read Net Time");
			throw ex;
		}  
		//  
		if (date1 ==null )  
		{  
			localtime = "网络验证失败，请重新启动或检查网络设置";  
			Debug.LogWarning("Unable to read Net Time");
			mTimeAvailable = false;
		}  
		else if (date1.Length  < 1)  
		{  
			localtime = "网络验证失败，请重新启动或检查网络设置";
			Debug.LogWarning("Unable to read Net Time");
			mTimeAvailable = false;  
		} 
		else  
		{  
			//将时间中的GMT去掉  
			date2 = date1[1].Replace("GMT", "");  
				
			//如： 08 Feb 2012 06:34:58 GMT  
			date3 = date2.Split(' ');  
			//如： 08 Feb 2012 06:34:58   

			switch (date3[2])  
			{  
				case  "Jan":  
					mon = "01";  
					break;  
				case "Feb":  
					mon = "02";  
					break;  
				case "Mar":  
					mon = "03";  
					break;  
				case "Apr":  
					mon = "04";  
					break;  
				case "May":  
					mon = "05";  
					break;  
				case "Jun":  
					mon = "06";  
					break;  
				case "Jul":  
					mon = "07";  
					break;  
				case "Aug":  
					mon = "08";  
					break;  
				case "Sep":  
					mon = "09";  
					break;  
				case "Oct":  
					mon = "10";  
					break;  
				case "Nov":  
					mon = "11";  
					break;  
				case "Dec":  
					mon = "12";  
					break;  
			}  

			//最终反馈是日期和时间  
			localtime = date3[3] + "/" + mon + "/" + date3[1] + " " + date3[4];  

			//获取的协调世界时  
			DateTime sTime = Convert.ToDateTime(localtime);  

			//转换为当前计算机所处时区的时间，即东八区时间  
			nTime = TimeZone.CurrentTimeZone.ToLocalTime(sTime);  
			mTimeAvailable = true;
		} 
		return nTime;  
	}  
		
	void Update () {
		//走时
		if(mTimeAvailable == true)
		{
			timeElapsed += Time.deltaTime;
			if(timeElapsed > 1)
			{
				mTime = mTime.AddSeconds(1);
				timeElapsed -=1f;
				//Debug.Log(mTime.ToString());
			}
		}
	}
	//获取状态
	public bool IsAvailable()
	{
		return mTimeAvailable;
	}
	//获取时间
	public DateTime Now()
	{
		if(mTimeAvailable)
			return mTime;
		else
			return DateTime.MinValue;
	}
	//程序切到后台或者从后台激活
	private void OnApplicationPause( bool pause )  
	{  
		if ( pause ==false)  
		{//切到前台
            if (Application.platform == RuntimePlatform.LinuxEditor || Application.platform == RuntimePlatform.OSXEditor
                || Application.platform == RuntimePlatform.WindowsEditor)
                return;
			//重新获取网络时间
			//开始检查网络状态，并获取网络时间
			mTimeAvailable = false;
			StartCoroutine(CheckInternetAndGetTime());
		}
	}
}
