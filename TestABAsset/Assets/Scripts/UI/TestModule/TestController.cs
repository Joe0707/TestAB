using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalDefine;
using Msg;
public class TestController : MonoSingleton<TestController>
{
    public Button m_OpenTest;//打开测试命令按钮
    public Button m_CloseTest;//关闭测试命令按钮
    public GameObject m_TestPanel;//测试面板
    public Button m_SendBtn;//发送按钮
    public InputField m_Input;//输入面板
    private string mAccountId;//账号Id
    void Awake()
    {
        m_OpenTest.onClick.AddListener(OnOpenTestClick);
        m_CloseTest.onClick.AddListener(OnCloseTestClick);
        m_SendBtn.onClick.AddListener(OnSendClick);
        EventMgr.AddEventHandler("UpdateAccount", UpdateAccount);
    }

    void OnDestroy()
    {
        EventMgr.RemoveEventHandler("UpdateAccount", UpdateAccount);
    }

    void UpdateAccount(object param)
    {
        mAccountId = param.ToString();
    }

    void OnOpenTestClick()
    {
        m_OpenTest.gameObject.SetActive(false);
        m_CloseTest.gameObject.SetActive(true);
        m_TestPanel.SetActive(true);
    }

    void OnCloseTestClick()
    {
        m_OpenTest.gameObject.SetActive(true);
        m_CloseTest.gameObject.SetActive(false);
        m_TestPanel.SetActive(false);
    }

    void OnSendClick()
    {
        //获取输入面板信息
        var message = m_Input.text;
        message = message.Trim();
        var messages = message.Split(' ');
        if (messages.Length == 0)
        {
            MessageBox.ShowOneMessage("测试命名为空");
            return;
        }
        if (string.IsNullOrEmpty(mAccountId))
        {
            MessageBox.ShowOneMessage("账号为空");
            return;
        }
        var messagetitle = messages[0];
        var dict = new Dictionary<string, string>();
        dict.Add("functionName", messagetitle);
        if (messages.Length > 1)
        {
            for (var i = 1; i < messages.Length; i += 2)
            {
                var paramName = "";
                var param = "";
                if (i < messages.Length)
                {
                    paramName = messages[i];
                }
                if (i + 1 < messages.Length)
                {
                    param = messages[i + 1];
                }
                dict.Add(paramName, param);
            }
        }
        //发送
        var route = ERoutePath.connector_gameHandler_testCommand;
        var request = new testCommandRequest();
        request.accountGid = mAccountId;
        request.data = dict;
        var requestJson = request.ToJson();
        NetMgr.SendRequest(route, requestJson, (response) =>
        {
            if (response.IsOk)
            {
                DebugUtil.DebugInfo(string.Format("测试发送成功 标题{0}", messagetitle));
            }
            else
            {
                MessageBox.ShowOneMessage("测试失败,错误码" + response.Code);
            }
        });
    }

}
