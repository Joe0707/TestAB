using System.Collections;
using System.Collections.Generic;
public class DrawInstanceManager : Singleton<DrawInstanceManager>
{
    public Dictionary<string, DrawInstanceController> dict = new Dictionary<string, DrawInstanceController>();
    public override void Init()
    {

    }

    public override void Dispose()
    {
        dict.Clear();
    }
    //添加实例化控制器
    public void AddInstanceController(string controllerName, DrawInstanceController controller)
    {
        if (dict.ContainsKey(controllerName))
        {
            dict[controllerName] = controller;
        }
        else
        {
            dict.Add(controllerName, controller);
        }
    }
    //获取实例化控制器
    public DrawInstanceController GetDrawInstanceController(string controllerName)
    {
        DrawInstanceController result = null;
        dict.TryGetValue(controllerName, out result);
        return result;
    }
}
