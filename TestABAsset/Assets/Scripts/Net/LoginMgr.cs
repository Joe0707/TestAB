using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJson;
using Newtonsoft.Json;
public class LoginMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectGate("127.0.0.1", 1001);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ConnectGate(string host, int port)
    {
        NetMgr.Disconnect();
        var data = new JsonObject();
        NetMgr.Connect(host, port, data, (success) =>
        {
            if (success == true)
            {//连接成功，发送获得Connector的请求
                var route = "gate.gateHandler.getConnector";
                var request = new Msg.getConnectorRequest();
                request.accountId = UnityEngine.SystemInfo.deviceUniqueIdentifier;
                var requestJson = request.ToJson();
                NetMgr.SendRequest(route, requestJson, (response) =>
                {
                    if (response.IsOk)
                    {//连接Connector
                        var connectorMsg = MsgBase.JsonToObject<Msg.getConnectorResponse>(response.Data);
                        ConnectConnector(connectorMsg.host, connectorMsg.port);
                        Debug.Log("获取Connector成功");
                    }
                });
            }
            else
            {//失败
                NetMgr.Disconnect();
            }
        });
    }
    //连接Connector
    void ConnectConnector(string host, int port)
    {
        //先断开当前的连接
        NetMgr.Disconnect();
        var data = new JsonObject();
        NetMgr.Connect(host, port, data, (success) =>
        {
            if (success == true)
            {//连接成功，发送登陆消息
                Debug.Log("连接Connector成功");
                //启用登陆页面
            }
            else
            {//失败
                NetMgr.Disconnect();
            }
        });
    }
}
