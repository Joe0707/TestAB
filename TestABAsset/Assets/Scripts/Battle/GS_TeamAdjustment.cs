using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GS_TeamAdjustment : LogicStateBase
{
    // Start is called before the first frame update
    public GameObject m_BattleStartPage;//战斗开始状态UI
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnStateEnter(object param, Action callback)
    {
        //   m_BattleStartPage.SetActive(true);
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit");
        //   m_BattleStartPage.SetActive(false);

    }
}
