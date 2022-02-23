using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public LuaBehavior animatorController;
    public XLua.LuaFunction ActorAnimationEvent; public XLua.LuaFunction WeaponAnimationEvent;
    public XLua.LuaFunction ActorBehitAnimationEvent;
    public GameObject m_EquipmentPoint;
    public void Start()
    {
        ActorAnimationEvent = animatorController.GetValue("FireAnimationEvent") as XLua.LuaFunction;
        WeaponAnimationEvent = animatorController.GetValue("EventWeaponAnimator") as XLua.LuaFunction;
    }
    //触发动画事件
    void FireEvent(string eventName)
    {
        ActorAnimationEvent.Call(eventName);
        // animatorController.CallLuaFunction("FireAnimationEvent", eventName);
    }
    //触发武器动画事件
    void FireWeaponAnimator(string eventName)
    {
        Debug.Log("触发武器动画事件");
        GameObject mEquipParent = null;
        foreach (Transform item in m_EquipmentPoint.transform)
        {
            if (item.tag == "Equipment")
                mEquipParent = item.gameObject;
        }
        var mEquip = mEquipParent.transform.GetChild(0).gameObject;
        WeaponAnimationEvent.Call(eventName, mEquip);
    }
}