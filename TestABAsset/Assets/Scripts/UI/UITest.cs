using UnityEngine;
public class UITest : MonoBehaviour
{
    public void Test()
    {
        Transform A = null;
        //创建UI
        var abc = UIMgr.Instance.CreateOneUI("UI/Abc", A);
        //UI显示
        abc.Show();
        //UI推栈
        UIMgr.Instance.PushPanel(abc, false, true);
        //获取栈顶UI
        var topui = UIMgr.Instance.GetStackTopPanel();
        //UI弹栈
        var ui = UIMgr.Instance.PopPanel();
        //UI销毁
        GameObject.Destroy(abc);
    }
}