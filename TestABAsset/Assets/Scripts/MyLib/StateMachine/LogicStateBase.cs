using UnityEngine;
using System;
using System.Collections;


abstract public class LogicStateBase : MonoBehaviour
{
    [Tooltip("状态机名称。不填就是这个Object的名字")]
    public string mStateName = "";
    public LogicStateMachine mStateMachine = null;
    public LogicStateBase()
    {
    }
    public void SetStateMachine(LogicStateMachine machine)
    {
        mStateMachine = machine;
    }
    public virtual void OnStateEnter(object param, Action callback) { }
    public virtual void OnStateExit(object param) { }
}

