using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_BattleEvent : LogicStateBase
{
    public override void OnStateEnter(object param, Action callback)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit", param);
    }
}
