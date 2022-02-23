using UnityEngine;
using System;
//资源管理器
public class ResourceMgr : Singleton<ResourceMgr>
{
    //同步加载资源
    public GameObject LoadGameObjectResourceSync(string resourceName)
    {
        GameObject go = ResourcesManager.Instance.LoadResource<GameObject>(resourceName);
        return go;
    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return ResourcesManager.Instance.LoadResource<T>(path);
    }

    public UnityEngine.Object Load(string path, Type type)
    {
        return ResourcesManager.Instance.LoadResource(path, type);
    }

    public T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        return ResourcesManager.Instance.LoadAllResource<T>(path);
    }
}