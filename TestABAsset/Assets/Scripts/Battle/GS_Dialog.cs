using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_Dialog : LogicStateBase
{
    public GameObject m_DialogPage;
    // Start is called before the first frame update
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
        m_DialogPage.SetActive(true);
    }
    public override void OnStateExit(object param)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit");
        m_DialogPage.SetActive(false);
    }
}
