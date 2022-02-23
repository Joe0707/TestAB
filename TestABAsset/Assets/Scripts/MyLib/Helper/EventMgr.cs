using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[XLua.CSharpCallLua]
public delegate void EventCallBack(object param);
public delegate object EventCallBackWithResult(object param);

public class EventMgr : MonoBehaviour
{
    static EventMgr mInstance = null;
    static Dictionary<string, ArrayList> mEventMap = new Dictionary<string, ArrayList>();

    void Awake()
    {
        mInstance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnDestroy()
    {
        mInstance = null;
    }
    static void CreateInstance()
    {
        if (mInstance != null)
            return;
        var go = new GameObject("EventMgr");
        mInstance = go.AddComponent<EventMgr>();
    }
    public static void AddEventWithResultHandler(string eventName, EventCallBackWithResult handler)
    {
        if (!mEventMap.ContainsKey(eventName))
        {
            mEventMap[eventName] = new ArrayList();
        }
        if (mEventMap[eventName].Contains(handler) == false)
            mEventMap[eventName].Add(handler);
    }
    public static void RemoveEventWithResultHandler(string eventName, EventCallBackWithResult handler)
    {
        if (mEventMap.ContainsKey(eventName))
        {
            ArrayList arrList = mEventMap[eventName];
            if (arrList.Contains(handler))
                arrList.Remove(handler);
            if (arrList.Count == 0)
                mEventMap.Remove(eventName);
        }
    }
    public static object FireEventWithResult(string eventName, object mParam)
    {
        if (mEventMap.ContainsKey(eventName))
        {
            ArrayList arrList = mEventMap[eventName];
            for (var i = 0; i < arrList.Count; i++)
            {
                EventCallBackWithResult func = arrList[i] as EventCallBackWithResult;
                if (func != null)
                    return func(mParam);
            }
        }
        return null;
    }

    public static void AddEventHandler(string eventName, EventCallBack handler)
    {
        if (!mEventMap.ContainsKey(eventName))
        {
            mEventMap[eventName] = new ArrayList();
        }
        if (mEventMap[eventName].Contains(handler) == false)
            mEventMap[eventName].Add(handler);
    }

    public static void RemoveEventHandler(string eventName, EventCallBack handler)
    {
        if (mEventMap.ContainsKey(eventName))
        {
            ArrayList arrList = mEventMap[eventName];
            if (arrList.Contains(handler))
                arrList.Remove(handler);
            if (arrList.Count == 0)
                mEventMap.Remove(eventName);
        }
    }

    public static void FireEvent(string eventName, object mParam)
    {
        if (mEventMap.ContainsKey(eventName))
        {
            ArrayList arrList = mEventMap[eventName];
            for (var i = 0; i < arrList.Count; i++)
            {
                EventCallBack func = arrList[i] as EventCallBack;
                if (func != null)
                    func(mParam);
            }
        }
    }

    public static void DelayAction(Action action, float time)
    {
        if (mInstance == null)
        {
            return;
        }
        mInstance.StartCoroutine(mInstance._DelayAction(action, time));
    }
    IEnumerator _DelayAction(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        if (action != null)
            action();
    }

    //接收SendMessage发来的消息，转换成一个Event事件,msg=eventName&&eventParam
    public void FireEventFromMessage(string msg)
    {
        Debug.Log("!!!!!!!!!!!!!EventMgr.FireEventFromMessage:" + msg);
        try
        {
            string[] strParams = msg.Split("&&".ToCharArray());
            var eventName = strParams[0];
            var eventParam = strParams[2];
            EventMgr.FireEvent(eventName, eventParam);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    //输出当前注册的事件报告
    public static void Report()
    {
        if (mInstance == null)
            return;
        Debug.Log("EventMgr.Report count=" + mEventMap.Count);
        foreach (var pair in mEventMap)
        {
            Debug.Log("--EventName=" + pair.Key + " | count=" + pair.Value.Count);
        }
    }
}
