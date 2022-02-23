using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using Levels;
using System;
public class GS_SelectRole : LogicStateBase
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (H.IsPointerDown())
        // {
        //    Debug.Log("点击");
        //    Ray ray = Camera.main.ScreenPointToRay(H.PointerPosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit) == false)
        //       return;
        //    if (hit.collider.gameObject.GetComponent<ActorAnimController>())
        //    {
        //       BattleLogic.Instance.CurActorNeibourSlots.Clear();
        //       BattleLogic.Instance.CurMoveActor = hit.collider.gameObject;
        //       var actor = hit.collider.gameObject.GetComponent<LuaBehavior>();
        //       var slot = actor.Get<LuaTable>("Slot");
        //       var slotconfig = slot.Get<SlotConfig>("mSlotData");
        //       var row = slotconfig.RowNumber;
        //       var col = slotconfig.ColumnNumber;
        //       // var row = actor.Get<int>("Row");
        //       // var col = actor.Get<int>("Col");
        //       BattleLogic.Instance.CurActorNeibourSlots = BattleLogic.Instance.GetNeibourSlots(row, col, 2);
        //       foreach (var item in BattleLogic.Instance.CurActorNeibourSlots)
        //       {
        //          item.gameObject.SetActive(true);
        //       }
        //       mStateMachine.ChangeState("SelectTarget");
        //    }
        // }
    }
    public override void OnStateEnter(object param, Action callback)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param, callback);
    }
    public override void OnStateExit(object param)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit", param);
    }
}
