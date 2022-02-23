using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_OthersTurn : LogicStateBase
{
    // Start is called before the first frame update
    public GameObject m_OtherTrunPage;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void OnStateEnter(object param, Action callback)
    {
        // m_OtherTrunPage.SetActive(true);
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        // m_OtherTrunPage.SetActive(false);
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit", param);
    }
}
