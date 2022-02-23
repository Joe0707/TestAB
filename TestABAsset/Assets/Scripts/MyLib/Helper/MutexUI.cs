using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//互斥窗体
public abstract class MutexUIPage : MonoBehaviour
{
    [Tooltip("自身名称")]
    public string m_PageName; 

    [Tooltip("互斥的页面名称")]
    public string[] m_MutexUIPageList;

    virtual protected void OnEnable()
    {
        EventMgr.AddEventHandler("Mutex.UIPageOpen", OnUIPageOpenEvent);
    }

    virtual protected void OnDisable()
    {
        EventMgr.RemoveEventHandler("Mutex.UIPageOpen", OnUIPageOpenEvent);
    }

    // 发送页面开启事件
    public void FireUIPageOpenEvent()
    {
        if(m_PageName != "")
            EventMgr.FireEvent("Mutex.UIPageOpen", m_PageName);
    }

    // 收到页面开启事件
    void OnUIPageOpenEvent(object param)
    {
        var eventPagename = param as string;
        foreach(var name in m_MutexUIPageList)
        {
            if(name == eventPagename)
            {
                CloseUIPageForMutexReason();
                break;
            }
        }
    }

    //因为Mutex原因关闭UI
    abstract protected void CloseUIPageForMutexReason();
}
