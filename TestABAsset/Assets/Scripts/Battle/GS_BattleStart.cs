using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_BattleStart : LogicStateBase
{
    public GameObject m_ActorInfoPage;//战斗actor显示UI
    void Start()
    {
        //GameObject qwer = new GameObject();
        //qwer.transform.childCount
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnStateEnter(object param, Action callback)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        m_ActorInfoPage.SetActive(true);
    }
}
