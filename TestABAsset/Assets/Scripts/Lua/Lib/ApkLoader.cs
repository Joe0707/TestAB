using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class ApkLoader : MonoBehaviour
{
    public delegate void LoadingProgressDelegate(float progress);
    public enum EState
    {
        Unchecked, //未检查
        CheckingUpates, //检查更新中
        Error, //检查失败
        Ready, //更新完毕
    }
    static ApkLoader mInstance = null;
    public static ApkLoader Instance { get { return mInstance; } }
    [HideInInspector]
    public bool IsDownloading { get; protected set; } //是否正在更新

    [HideInInspector]
    public EState State { get; protected set; } //状态
    [HideInInspector]
    public bool IsReady { get { return State == EState.Ready; } } //是否更新完毕
    string mDataRootPath = ""; //本地存储目录
    string mApkFilesPath = ""; //apk文件的目录

    [Tooltip("服务器Apk根目录地址")]
    public string m_ServerRootUrl = "";
    string mServerJsonUrl = "http://127.0.0.1:3001/apk/apkconfig.json";
    LoadingProgressDelegate mProgressDelegate = null;
    AndroidJavaClass androidJavaClass;
    AndroidJavaObject androidJavaObject;
    AndroidJavaClass customToolClass;
    AndroidJavaObject customToolObject;
    void Awake()
    {
        mDataRootPath = Application.persistentDataPath + "/" + "Apk";
        if (Application.isEditor)
            mDataRootPath = "./LuaDownloads";
        //拼接服务器的json地址
        if (m_ServerRootUrl.LastIndexOf("/") == m_ServerRootUrl.Length - 1) //如果最后一个字符是/，则去掉
            m_ServerRootUrl = m_ServerRootUrl.Substring(0, m_ServerRootUrl.Length - 1);
        mServerJsonUrl = m_ServerRootUrl + "/" + ApkJsonConfig.JsonFileName;
        mInstance = this;
        State = EState.Unchecked; //未检查
        if (Directory.Exists(mDataRootPath) == false)
        {
            Directory.CreateDirectory(mDataRootPath);
        }

#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            //获取MainActivity的实例对象
            androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
            customToolClass = new AndroidJavaClass("com.Unity.Tools.UTool"); //com.Unity.Tools 包名  UTool 类名
            customToolObject = customToolClass.CallStatic<AndroidJavaObject>("instance");
            customToolObject.Call("Init", androidJavaObject);
        }
        catch (Exception e)
        {
           
        }
 
        customToolClass = new AndroidJavaClass("com.Unity.Tools.UTool");
        customToolObject = new AndroidJavaObject("com.Unity.Tools.UTool");
        customToolObject = customToolClass.CallStatic<AndroidJavaObject>("instance");
        customToolObject.Call("Init", androidJavaObject);
#endif
    }
    //从服务器更新
    public static void UpdateFilesFromServer(LoadingProgressDelegate progressCallback)
    {
        if (mInstance == null)
            return;
        mInstance.mProgressDelegate = progressCallback;
        mInstance.StopAllCoroutines();
        mInstance.StartCoroutine(mInstance._DownloadFilesFromServer());
    }
    IEnumerator _DownloadFilesFromServer()
    {
        State = EState.CheckingUpates; //检查中
        //将Apkconfig.json的uri拆解一下 
        int idx = mServerJsonUrl.LastIndexOf("/");
        string uriLuaRoot = mServerJsonUrl.Substring(0, idx);
        string jsonconfigName = mServerJsonUrl.Substring(idx + 1);
        if (mProgressDelegate != null)
            mProgressDelegate(0);//设置进度
        //获取json文件
        string serverJsonTxt = "";
        var readResult = new ReadFileResult();
        yield return StartCoroutine(_ReadServerFile(mServerJsonUrl, readResult));
        serverJsonTxt = readResult.Content;
        if (serverJsonTxt == "")
        {
            State = EState.Error;
            if (mProgressDelegate != null)
                mProgressDelegate(-1);//通知上层
            yield break;
        }
        ApkJsonConfig serverConfig = ApkJsonConfig.FromJson(serverJsonTxt);
        if (serverConfig == null)
        {
            State = EState.Error;
            yield break;
        }
        if (mProgressDelegate != null)
            mProgressDelegate(0.1f);//设置进度
        //比对web的配置文件是否和本地版本号一致
        if (serverConfig.ApkVersion != Version.ApkVersion)
        {
            var fileUrl = m_ServerRootUrl + "/" + "LRSBN.apk";
            var apkPath = mDataRootPath + "/" + "LRSBN.apk";
            yield return _DownLoadApk(fileUrl, apkPath);
        }
        if (mProgressDelegate != null)
            mProgressDelegate(1);//设置进度
        State = EState.Ready;
    }
    //从网络读取文件内容
    class ReadFileResult { public string Content { get; set; } = ""; }
    IEnumerator _ReadServerFile(string url, ReadFileResult result)
    {
        result.Content = "";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
            result.Content = request.downloadHandler.text;
    }

    // IEnumerator _DownLoadApk(string url, byte[] result, string apkPath)
    // {
    //     UnityWebRequest request = UnityWebRequest.Get(url);
    //     yield return request.SendWebRequest();
    //     if (request.isNetworkError || request.isNetworkError)
    //     {
    //         Debug.Log(request.error);
    //     }
    //     else
    //     {
    //         result = new byte[request.downloadHandler.data.Length];
    //         result = request.downloadHandler.data;
    //         //保存
    //         WriteFile(apkPath + "/" + "LRSBN.apk", result);
    //     }
    // }
    //从网络下载apk文件
    public IEnumerator _DownLoadApk(string url, string apkPath)
    {
        WWW www = new WWW(url);
        //下载需要更新的apk
        while (true)
        {
            if (mProgressDelegate != null)
                mProgressDelegate(www.progress);//设置进度
            Debug.Log(www.progress / 1f * 100);
            if (www.isDone)
            {
                File.WriteAllBytes(apkPath, www.bytes);
                yield return new WaitForSeconds(1);
#if UNITY_ANDROID && !UNITY_EDITOR
                customToolObject.Call("installApk", apkPath);
#endif
                break;
            }
            yield return null;
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("error:" + www.error);
            yield return 0;
        }
        //将apk写入目录
        File.WriteAllBytes(apkPath, www.bytes);
    }
    //打开apk文件
    public static void OpenDirectory(string path, bool isFile = false)
    {
        if (string.IsNullOrEmpty(path)) return;
        path = path.Replace("/", "\\");
        if (isFile)
        {
            if (!File.Exists(path))
            {
                Debug.LogError("No File: " + path);
                return;
            }
            path = string.Format("/Select, {0}", path);
        }
        else
        {
            if (!Directory.Exists(path))
            {
                Debug.LogError("No Directory: " + path);
                return;
            }
        }
        //可能360不信任
        System.Diagnostics.Process.Start("LRSBN.apk", path);
    }

    void WriteFile(string filePathName, byte[] content)
    {
        var fs = new FileStream(filePathName, FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(content);
        sw.Close();
    }
    public class ApkJsonConfig
    {

        public string ApkVersion = "1.0";
        public const string JsonFileName = "apkconfig.json";
        //从Json解析
        public static ApkJsonConfig FromJson(string jsonText)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<ApkJsonConfig>(jsonText);
                if (obj == null)
                    Debug.LogError("Deserialize json data failed:" + jsonText);
                return obj;
            }
            catch (Exception e)
            {
                Debug.LogError("Deserialize json data failed:" + jsonText);
                return null;
            }
        }

        //转Json
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        //明文计算MD5
        public static string CalculateMD5(string plainTxt)
        {
            //获取加密服务  
            System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //获取要加密的字段，并转化为Byte[]数组  
            byte[] plainBytes = System.Text.Encoding.Unicode.GetBytes(plainTxt);
            //加密Byte[]数组  
            byte[] resultBytes = md5CSP.ComputeHash(plainBytes);
            //将加密后的数组转化为字段(普通加密)  
            return System.Text.Encoding.Unicode.GetString(resultBytes);
        }
    }
}
