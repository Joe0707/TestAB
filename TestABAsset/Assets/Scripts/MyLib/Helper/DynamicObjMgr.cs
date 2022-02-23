using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//用来管理细碎的，生命周期不稳定的物体，如特效等，使用key来分组保存。方便随时查询
public class DynamicObjMgr : MonoBehaviour {

    static DynamicObjMgr mInstance = null;
    private Dictionary<string, ArrayList> objMap = new Dictionary<string, ArrayList>();

    void Awake()
    {
        mInstance = this;
    }

    public static void AddDynamicObj(string key, GameObject obj)
    {
        if (mInstance == null)
            return;
        if (false == mInstance.objMap.ContainsKey(key))
        {
            mInstance.objMap[key] = new ArrayList();
        }
        if (mInstance.objMap[key].Contains(obj) == false)
            mInstance.objMap[key].Add(obj);
    }

    public static void RemoveDynamicObj(string key, GameObject obj)
    {
        if (mInstance == null)
            return;
        if (true == mInstance.objMap.ContainsKey(key))
        {
            ArrayList arrList = mInstance.objMap[key];
            if (arrList.Contains(obj))
                arrList.Remove(obj);
            if (arrList.Count == 0)
                mInstance.objMap.Remove(key);
        }
    }

    public static ArrayList GetDynamicObjList(string key)
    {
        if (mInstance == null)
            return null;
        if (true == mInstance.objMap.ContainsKey(key))
            return mInstance.objMap[key];
        else
            return null;
    }
}
