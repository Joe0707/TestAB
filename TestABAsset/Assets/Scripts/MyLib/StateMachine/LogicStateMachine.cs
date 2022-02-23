using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class LogicStateMachine : MonoBehaviour
{
    //当前状态
    LogicStateBase mCurState = null;
    //状态列表
    Dictionary<string, LogicStateBase> mStateMap = new Dictionary<string, LogicStateBase>();
    [Tooltip("用于启动的状态机名称。")]
    public string mStartupStateName = "";

    protected virtual void Start()
    {
        //查找子级别的item中有没有状态机
        for (int i = 0; i < transform.childCount; i++)
        {
            var childLogic = transform.GetChild(i).GetComponent<LogicStateBase>();
            if (childLogic != null)
            {
                if (childLogic.mStateName == "")
                    childLogic.mStateName = childLogic.name;
                AddState(childLogic);
                childLogic.SetStateMachine(this);
                childLogic.gameObject.SetActive(false);
            }
        }
        if (string.IsNullOrEmpty(mStartupStateName) == false)
        {
            //启动第一个状态
            ChangeState(mStartupStateName, "");
        }
    }

    void OnDestory()
    {
        ClearAllStates();
    }

    //清除所有的状态
    public void ClearAllStates()
    {
        if (mCurState != null)
        {
            mCurState.OnStateExit(null);
        }
        mStateMap.Clear();
        mCurState = null;
    }

    //添加状态
    public void AddState(LogicStateBase state)
    {
        if (state.mStateName == "")
        {
            Debug.LogError("State must have a name!");
            return;
        }
        if (mStateMap.ContainsKey(state.mStateName) == false)
        {
            mStateMap.Add(state.mStateName, state);
            state.SetStateMachine(this);
        }
        else
            Debug.LogError("State with name " + state.mStateName + " already exist");
    }

    //移除状态
    public void RemoveState(string stateName)
    {
        if (mStateMap.ContainsKey(stateName) == true)
        {
            if (mCurState.mStateName != stateName)
                mStateMap.Remove(stateName);
            else
                Debug.LogError("Can't remove current state [" + mCurState.mStateName + "] from state machine");
        }
    }

    //查询状态 
    public LogicStateBase GetState(string stateName)
    {
        if (mStateMap.ContainsKey(stateName) == true)
            return mStateMap[stateName];
        else
            return null;
    }
    /// <summary>
    /// 获取当前状态
    /// </summary>
    /// <returns></returns>
    public LogicStateBase GetCurState()
    {
        return mCurState;
    }

    //切换状态
    public void ChangeState(string stateName, object paramToNextState = null, Action entercallback = null)
    {
        StartCoroutine(ChangeStateImpl(stateName, paramToNextState, entercallback));
    }
    IEnumerator ChangeStateImpl(string stateName, object paramToNextState, Action entercallback = null)
    {
        if (mCurState != null && stateName == mCurState.mStateName)
        {
            if (entercallback != null)
            {
                entercallback();
            }
            yield break;
        }
        yield return null;
        if (mStateMap.ContainsKey(stateName) == true)
        {
            if (mCurState != null)
            {
                mCurState.OnStateExit("");
                mCurState.gameObject.SetActive(false);
            }
            mCurState = mStateMap[stateName];
            mCurState.gameObject.SetActive(true);
            mCurState.OnStateEnter(paramToNextState, entercallback);
            Debug.Log(gameObject.name + ":ChangeState to " + stateName);
        }
        else
        {
            Debug.LogError("ChangeState:No state with name " + stateName);
        }
    }
}
