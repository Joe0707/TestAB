using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI基类
public class UIBase : MonoBehaviour
{
    public string mPath = "";//UI的路径
    void Awake()
    {
        Init();
    }

    void OnDestroy()
    {
        Dispose();
        UIMgr.Instance.RemoveUI(this);
    }
    //UI初始化逻辑 Awake时调用
    protected virtual void Init()
    {
    }
    //释放资源逻辑 销毁时调用
    protected virtual void Dispose()
    {
    }
    //UI暂停 本UI在堆栈中 其他UI推到栈顶时本UI调用
    public virtual void OnPause()
    {
    }
    //UI恢复 栈顶UI弹栈 本UI成为栈顶时调用
    public virtual void OnResume()
    {
    }
    //UI显示
    public virtual void Show()
    {
    }
    //UI隐藏
    public virtual void Hide()
    {
    }
    //UI推栈的时候调用 默认会进行显示 如有需要可重载
    public virtual void OnPush()
    {
        Show();
    }
    //UI弹栈的时候调用 默认会进行隐藏 如有需要可重载
    public virtual void OnPop()
    {
        Hide();
    }
}
