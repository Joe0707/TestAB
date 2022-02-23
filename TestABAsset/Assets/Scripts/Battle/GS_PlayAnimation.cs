using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_PlayAnimation : LogicStateBase
{
    // Start is called before the first frame update
    string mState = "";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnStateEnter(object param, Action callback)
    {
        // mState = param;
        //CameraController.Instance.QuitManualState();
        // Invoke("QuitState", 1f);
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        //CameraController.Instance.EnterManualState();
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit", param);
    }

    void QuitState()
    {
        if (mState == "")
            mStateMachine.ChangeState("SelectRole");
        else
            mStateMachine.ChangeState(mState);
    }
}
