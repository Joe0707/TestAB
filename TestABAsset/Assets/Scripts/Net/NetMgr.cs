using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pomelo.DotNetClient;
using SimpleJson;
using System;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
public class NetMgr : MonoBehaviour
{
    PomeloClient mPClient = new PomeloClient(); //Pomelo客户端
    static NetMgr mInstance = null;
    public NetWorkState State { get; protected set; } //网络状态
    public static string connId { get; set; } = "";//使用的Connector服务器
    public static string accountId { get; set; } = "";//快速登陆返回的accountId（账号）
    public static string LevelGId { get; set; } = "";//关卡房间唯一ID
    List<Action> mQueuedActions = new List<Action>(); //排队要放在主线程里执行的操作
    ConnectCallback mConnectCallback = null; //连接服务器的回掉(参数bool=success)
    void Awake()
    {
        mInstance = this;
    }

    void Start()
    {
        //listen on network state changed event
        mPClient.NetWorkStateChangedEvent += OnNetworkStateChanged;
    }

    void Update()
    {
        //执行队列里的操作
        while (mQueuedActions.Count > 0)
        {
            Action action = null;
            lock (mQueuedActions)
            {
                action = mQueuedActions[0];
                mQueuedActions.RemoveAt(0);
            }
            action();
        }
    }
    void OnDestroy()
    {
        //断链接
        NetMgr.Disconnect();
    }

    //在主线程执行
    void RunInMainThread(Action action)
    {
        lock (mQueuedActions)
        {
            mQueuedActions.Add(action);
        }
    }

    //连接
    [XLua.CSharpCallLua]
    public delegate void ConnectCallback(bool success);
    public static void Connect(string host, int port, JsonObject handshakeUserParams, ConnectCallback connectCallBack)
    {
        if (mInstance == null)
            return;
        mInstance.mConnectCallback = connectCallBack;
        mInstance.mPClient.initClient(host, port, () =>
        {
            //与服务器握手消息
            mInstance.mPClient.connect(handshakeUserParams, data =>
            {
                mInstance.RunInMainThread(() =>
                {
                    Debug.Log("Hand shake finished");
                    //注册服务器推送消息处理
                    mInstance.RegisterPushEventHandlers();
                    mInstance.RegisterEventHandlers();
                    if (mInstance.mConnectCallback != null)
                    {
                        mInstance.mConnectCallback(true);
                        mInstance.mConnectCallback = null;
                    }
                });
            });
        });
    }

    //断开连接
    public static void Disconnect()
    {
        if (mInstance == null)
            return;
        mInstance.mPClient.disconnect();
    }

    [XLua.CSharpCallLua]
    public delegate void OnResponse(Response response);
    //发送请求
    public static void SendRequest(string route, JsonObject msg, OnResponse callback, System.Action<string> senderror = null)
    {
        if (mInstance == null)
            return;
        try
        {
            mInstance.mPClient.request(route, msg, (data) =>
            {
                mInstance.RunInMainThread(() =>
                {
                    if (callback != null)
                        callback(new Response(data));
                });
            });
        }
        catch (System.Exception ex)
        {
            if (senderror != null)
            {
                senderror(ex.Message);
            }
        }
    }

    //发送给服务器的通知
    public static void SendNotify(string route, JsonObject msg)
    {
        if (mInstance == null)
            return;
        mInstance.mPClient.notify(route, msg);
    }

    //网络状态变更
    void OnNetworkStateChanged(NetWorkState state)
    {
        switch (state)
        {
            case NetWorkState.CLOSED:
                break;
            case NetWorkState.CONNECTING:
                break;
            case NetWorkState.CONNECTED:
                break;
            case NetWorkState.DISCONNECTED:
                // if (EditorSceneManager.GetActiveScene().name == "World" || EditorSceneManager.GetActiveScene().name == "BattlePVE")
                //     MessageBox.ShowOneMessage("已断开连接");
                break;
            case NetWorkState.TIMEOUT:
                RunInMainThread(() => { if (mConnectCallback != null) mConnectCallback(false); });
                break;
            case NetWorkState.ERROR:
                RunInMainThread(() => { if (mConnectCallback != null) mConnectCallback(false); });
                break;
        }
        State = state;
        Debug.Log("NetworkStateChanged:" + state);
        RunInMainThread(() =>
        {
            EventMgr.FireEvent("NetworkStateChanged", State);
        });
    }
    //注册推送消息处理器
    void RegisterPushEventHandlers()
    {
        Debug.Log("注册推送消息处理器");
        mPClient.on("onPushMsg", (data) =>
        {
            // Debug.Log("mPClient.on");
            if (data.ContainsKey("msgType"))
            {
                mInstance.RunInMainThread(() =>
                {
                    EventMgr.FireEvent("OnPushMsg_" + data["msgType"].ToString(), data);
                    DebugUtil.DebugInfo(data["msgType"].ToString());
                });
            }
        });
    }
    //注册事件处理器
    void RegisterEventHandlers()
    {
        Debug.Log("注册事件处理器");
        mPClient.on(SpecialEventType.Kick, (data) =>
        {
            mInstance.RunInMainThread(() =>
            {
                EventMgr.FireEvent("OnKick", data);
            });
        });
    }

    public static List<ServersData> GetServersDatas()
    {
        List<ServersData> datas = HttpPostServersData("http://121.36.54.14:3338/serverMenu", "");
        return datas;
    }

    /// <summary>
    /// 发送POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="data">请求参数</param>
    /// <returns></returns>
    public static List<ServersData> HttpPostServersData(string url, string data)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
        //字符串转换为字节码
        byte[] bs = Encoding.UTF8.GetBytes(data);
        //参数类型，这里是json类型
        //还有别的类型如"application/x-www-form-urlencoded"，不过我没用过(逃
        httpWebRequest.ContentType = "application/json";
        //参数数据长度
        httpWebRequest.ContentLength = bs.Length;
        //设置请求类型
        httpWebRequest.Method = "POST";
        //设置超时时间
        httpWebRequest.Timeout = 7000;
        //将参数写入请求地址中
        httpWebRequest.GetRequestStream().Write(bs, 0, bs.Length);
        //发送请求
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //读取返回数据
        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
        string responseContent = streamReader.ReadToEnd();
        streamReader.Close();
        httpWebResponse.Close();
        httpWebRequest.Abort();
        return JsonConvert.DeserializeObject<List<ServersData>>(responseContent);
    }

}

public class Response
{
    JsonObject mJsonData = null;
    public Response(JsonObject data)
    {
        mJsonData = data;
    }
    /// <summary>
    /// 返回码
    /// </summary>
    /// <value></value>
    public int Code
    {
        get
        {
            if (mJsonData.ContainsKey("code"))
                return Convert.ToInt32(mJsonData["code"]);
            return -1;
        }
    }

    public JsonObject Data { get { return ((JsonObject)mJsonData["data"]); } }
    //返回码是否是200
    public bool IsOk
    {
        get
        {
            if (mJsonData.ContainsKey("code") == false)
            {
                Debug.LogError("响应数据中没有状态码");
                return false;
            }
            // var obj = mJsonData["code"];

            // if (mJsonData.ContainsKey("code"))
            return Convert.ToInt32(mJsonData["code"]) == 0;
            // else
            // return false;
        }
    }

    public string GetString(string key, string defaultValue = "")
    {
        return JUtil.GetString(Data, key, defaultValue);
    }

    public int GetInt(string key, int defaultValue = 0)
    {
        return JUtil.GetInt(Data, key, defaultValue);
    }

    public uint GetUInt(string key, uint defaultValue = 0)
    {
        return JUtil.GetUInt(Data, key, defaultValue);
    }

    public short GetShort(string key, short defaultValue = 0)
    {
        return JUtil.GetShort(Data, key, defaultValue);
    }
    public ushort GetUShort(string key, ushort defaultValue = 0)
    {
        return JUtil.GetUShort(Data, key, defaultValue);
    }

    public long GetLong(string key, long defaultValue = 0)
    {
        return JUtil.GetLong(Data, key, defaultValue);
    }

    public ulong GetULong(string key, ulong defaultValue = 0)
    {
        return JUtil.GetULong(Data, key, defaultValue);
    }

    public byte GetByte(string key, byte defaultValue = 0)
    {
        return JUtil.GetByte(Data, key, defaultValue);
    }

    public object GetObject(string key, object defaultValue = null)
    {
        return JUtil.GetObject(Data, key, defaultValue);
    }

    //获得一个列表
    public object[] GetList(string key, object[] defaultValue = null)
    {
        var retValue = JUtil.GetList(Data, key, defaultValue);
        return retValue;
    }
}
