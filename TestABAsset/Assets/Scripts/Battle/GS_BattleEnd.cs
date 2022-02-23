using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_BattleEnd : LogicStateBase
{
    // Start is called before the first frame update
    public GameObject m_BattleEndPage;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnStateEnter(object param, Action callback)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
        m_BattleEndPage.SetActive(true);
    }
    public override void OnStateExit(object param)
    {
        m_BattleEndPage.SetActive(false);
    }
}
