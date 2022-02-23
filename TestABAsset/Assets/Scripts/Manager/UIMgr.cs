using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoSingleton<UIMgr>
{
    private Stack<UIBase> UIStack = new Stack<UIBase>();//UI堆栈
    private Dictionary<string, List<UIBase>> pathUIsDict = new Dictionary<string, List<UIBase>>();//UI路径和实例集合
    protected override void OnDispose()
    {
        UIStack.Clear();
        var deleteList = new List<UIBase>();
        foreach (var item in pathUIsDict)
        {
            var uis = item.Value;
            for (var i = 0; i < uis.Count; i++)
            {
                var ui = uis[i];
                if (ui != null && ui.gameObject != null)
                {
                    deleteList.Add(ui);
                }
            }
        }
        for (var i = 0; i < deleteList.Count; i++)
        {
            GameObject.Destroy(deleteList[i].gameObject);
        }
        pathUIsDict.Clear();
    }
    //检测是否是栈顶面板
    public bool CheckStackTopPanel(UIBase panel)
    {
        var result = false;
        UIBase topPanel = UIStack.Peek();
        if (topPanel == panel)
        {
            result = true;
        }
        return result;
    }

    //获取栈顶UI
    public UIBase GetStackTopPanel()
    {
        return UIStack.Peek();
    }
    /// <summary>
    /// 把UI推至UI堆栈栈顶
    /// </summary>
    /// <param name="panel">UI</param>
    /// <param name="onlyOnePanel">相同的UI是否只保留一个</param>
    /// <param name="hideOthers">是否隐藏堆栈中其他UI</param>
    /// <returns></returns>
    public UIBase PushPanel(UIBase panel, bool onlyOnePanel = true, bool hideOthers = true)
    {
        if (onlyOnePanel)
        {
            if (UIStack.Contains(panel))
            {
                DataUtil.PopStack<UIBase>(UIStack, panel);
            }
        }
        //停止上一个界面
        if (UIStack.Count > 0)
        {
            // UIBase topPanel = UIStack.Peek();
            foreach (var stackUI in UIStack)
            {
                stackUI.OnPause();
                if (hideOthers)
                {
                    stackUI.Hide();
                }
            }
        }
        UIStack.Push(panel);
        panel.transform.SetAsLastSibling();
        panel.OnPush();
        return panel;
    }
    /// <summary>
    /// 弹出栈顶UI
    /// </summary>
    /// <param name="needDestroy">是否要销毁栈顶UI</param>
    /// <returns></returns>
    public UIBase PopPanel(bool needDestroy = false)
    {
        UIBase ui = null;
        if (UIStack.Count <= 0)
        {
            return ui;
        }

        //退出栈顶面板
        ui = UIStack.Peek();
        return PopPanel(ui, needDestroy);
    }
    /// <summary>
    /// 弹出指定UI
    /// </summary>
    /// <param name="ui">指定UI</param>
    /// <param name="needDestroy">是否需要销毁该UI</param>
    /// /// <returns></returns>
    public UIBase PopPanel(UIBase ui, bool needDestroy = false)
    {
        if (UIStack.Count <= 0)
        {
            return ui;
        }
        //从栈中退出
        DataUtil.PopStack<UIBase>(UIStack, ui);
        ui.OnPop();
        if (needDestroy)
        {
            GameObject.Destroy(ui.gameObject);
        }
        //恢复上一个面板
        if (UIStack.Count > 0)
        {
            UIBase panel = UIStack.Peek();
            panel.OnResume();
        }
        return ui;
    }


    public UIBase CreateOneUI(string path, Transform parent = null)
    {
        UIBase ui = null;
        List<UIBase> uis = null;
        if (!pathUIsDict.ContainsKey(path))
        {
            uis = new List<UIBase>();
            pathUIsDict[path] = uis;
        }
        uis = pathUIsDict[path];
        var goresources = ResourceMgr.Instance.LoadGameObjectResourceSync(path);
        var go = GameObject.Instantiate(goresources, parent);
        ui = go.GetComponent<UIBase>();
        ui.mPath = path;
        uis.Add(ui);
        return ui;
    }
    //遍历删除UI 
    public void RemoveUI(UIBase ui)
    {
        string removeKey = null;
        List<UIBase> uis;
        pathUIsDict.TryGetValue(ui.mPath, out uis);
        if (uis != null && uis.Count > 0)
        {
            var removeIndex = -1;
            for (var i = 0; i < uis.Count; i++)
            {
                var item = uis[i];
                if (item == ui)
                {
                    //找到了
                    removeIndex = i;
                    break;
                }
            }
            if (removeIndex != -1)
            {
                //找到删除的了
                uis.RemoveAt(removeIndex);
                if (uis.Count == 0)
                {
                    removeKey = ui.mPath;
                }
            }
        }
        if (removeKey != null)
        {
            pathUIsDict.Remove(removeKey);
        }
    }
    //弹栈
    public static void PopStack(Stack stack, Object obj)
    {
        DataUtil.PopStack(stack, obj);
    }
}
