using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//Lua调用CS的工具
public class CS2LuaUtil
{
    //获取当前动画状态的标准化事件
    public static float GetAnimatorCurrentStateInfoNormalizeTime(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
    //检测动画的当前状态名
    public static bool CheckAnimatorCurrentStateName(Animator animator, string stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    //强制类型转换
    public static object CastInstance(Type t, object obj)
    {
        var result = obj;
        if (obj.GetType() != t)
        {
            result = Convert.ChangeType(obj, t);
        }
        return result;
    }
    //获得字符串物体字典
    public static Dictionary<string, object> GetStrObjDict()
    {
        return new Dictionary<string, object>();
    }

}