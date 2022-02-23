using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GS_MyTurn : LogicStateBase
{
    // Start is called before the first frame update
    public GameObject m_MyTurnPage;
    float time;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void OnStateEnter(object param, Action callback)
    {
        // m_MyTurnPage.SetActive(true);
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        // m_MyTurnPage.SetActive(false);
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit", param);
    }
}
