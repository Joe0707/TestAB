using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBaseTest : UIBase
{
    //UI初始化逻辑 
    protected virtual void Init()
    {
    }
    //释放资源逻辑 
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
}
