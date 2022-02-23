using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GS_SelectTarget : LogicStateBase
{
    // Start is called before the first frame update
    public LuaBehavior m_RequestMgr;//战斗协议
    public GameObject m_Actors;//场景Actor根节点
    public BattleLogic battleLogic;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (H.IsPointerDown())
        // {
        //    //射线查询点击物体
        //    Ray ray = Camera.main.ScreenPointToRay(H.PointerPosition);
        //    RaycastHit hit = new RaycastHit();
        //    if (Physics.Raycast(ray, out hit) == false)
        //       return;
        //    if (BattleLogic.Instance.CurMoveActor == null)
        //       return;
        //    //当前移动的Actor
        //    var curMoveActor = BattleLogic.Instance.CurMoveActor.GetComponent<LuaBehavior>();
        //    var curMoveActorController = curMoveActor.gameObject.GetComponent<ActorAnimController>();
        //    var targetSlot = hit.collider.gameObject.GetComponent<LuaBehavior>(); //点中的目标格
        //    var targetActor = hit.collider.gameObject; //店中的目标角色
        //    if (targetSlot.tag == "Slot")
        //    {//点中了格子
        //       if (targetSlot.Get<GameObject>("Actor") == null)
        //       {//目标格子上没有角色
        //        //解绑当前站立的格子
        //          var curStandingSlot = BattleLogic.Instance.GetSlot(curMoveActor.Get<int>("Row"), curMoveActor.Get<int>("Col"));
        //          if (curStandingSlot != null)
        //             curStandingSlot.Set<GameObject>("Actor", null);
        //          //绑定角色到目标格
        //          curMoveActor.Set<int>("Row", targetSlot.Get<int>("Row"));
        //          curMoveActor.Set<int>("Col", targetSlot.Get<int>("Col"));
        //          targetSlot.GetComponent<LuaBehavior>().Set<GameObject>("Actor", curMoveActor.gameObject);
        //          curMoveActorController.WalkTo(hit.collider.gameObject.transform.position, null);
        //          HideNeibourSlot();
        //          //摄像机
        //          //CameraController.Instance.LookAtPos(targetSlot.transform.position, CameraController.EAltitude.Low);
        //       }
        //       else
        //       {//目标格子上有角色,攻击
        //          targetActor = targetSlot.Get<GameObject>("Actor");
        //       }
        //    }
        //    if (targetActor.tag == "Actor")
        //    {//点击Actor
        //       var targetActorBehavior = targetActor.GetComponent<LuaBehavior>();//获取目标木桩的luaBehavior组件
        //       m_RequestMgr.CallLuaFunction("SendBattlePlayRequest", curMoveActor.Get<string>("ActorGid"), targetActorBehavior.Get<string>("ActorGid"));//调用攻击协议

        //    }
        // }
    }
    void WalkAndAttackAnimator(LuaBehavior curMoveActor, LuaBehavior targetSlot, ActorAnimController srcActorController, ActorAnimController destActorController, string state)
    {
        //解绑当前站立的格子
        var curStandingSlot = BattleLogic.Instance.GetSlot(curMoveActor.Get<int>("Row"), curMoveActor.Get<int>("Col"));
        if (curStandingSlot != null)
            curStandingSlot.Set<GameObject>("Actor", null);
        srcActorController.WalkTo(targetSlot.gameObject.transform.position, () =>
        {
            srcActorController.FaceToPos(destActorController.transform.position);
            srcActorController.Attack();
            destActorController.FaceToPos(srcActorController.transform.position);
            //CameraController.Instance.Shake(0.7f);
            //if (Random.Range(0, 1.0f) > 0.2f)
            destActorController.Behit(0.75f);
            //else
            //destActorController.Die(0.75f);
            //飘字
            var targetActorBehavior = destActorController.gameObject.GetComponent<LuaBehavior>();//获取受击方的luaBehavior组件
            if (destActorController == null)
                return;
            var eff = EffectCreator.CreateEffect("TextFly");
            eff.transform.position = destActorController.transform.position + new Vector3(0, 3f, 0);
            //获取攻击返回消息字典
            //var battleMsgListDic = GameData.BattleMsgListMgr.Instance.BattleMsgListdic;
            //判断有没有当前目标ActorID
            // if (battleMsgListDic.ContainsKey(targetActorBehavior.Get<string>("ActorGid")))
            // {
            //     //获取被击血量值
            //     var hp = battleMsgListDic[targetActorBehavior.Get<string>("ActorGid")].msgValue;
            //     eff.GetComponent<TextFly>().Show("-" + hp, 0.7f);
            //     GameObject.Destroy(eff, 2f);
            // }
        });
        //绑定新的slot-actor关系
        curMoveActor.Set<int>("Row", targetSlot.Get<int>("Row"));
        curMoveActor.Set<int>("Col", targetSlot.Get<int>("Col"));
        targetSlot.Set<GameObject>("Actor", curMoveActor.gameObject);
        HideNeibourSlot(state);
    }
    //隐藏周围格子
    void HideNeibourSlot(string state = "SelectRole")
    {
        if (BattleLogic.Instance.CurActorNeibourSlots.Count == 0)
            return;
        foreach (var item in BattleLogic.Instance.CurActorNeibourSlots)
        {
            item.gameObject.SetActive(false);
        }
        BattleLogic.Instance.CurMoveActor = null;
        mStateMachine.ChangeState("PlayAnimation", state);
    }

    GameObject HiterIdActor;//受击方
    GameObject AttackActor;//攻击方

    //攻击函数
    public void OnAttack(string attackId, string hiterId, string state)
    {
        //查找攻击方的角色和受击方的角色
        for (int i = 0; i < m_Actors.transform.childCount; i++)
        {
            if (m_Actors.transform.GetChild(i).gameObject.GetComponent<LuaBehavior>().Get<string>("ActorGid") == hiterId)
                HiterIdActor = m_Actors.transform.GetChild(i).gameObject;
            if (m_Actors.transform.GetChild(i).gameObject.GetComponent<LuaBehavior>().Get<string>("ActorGid") == attackId)
                AttackActor = m_Actors.transform.GetChild(i).gameObject;
        }
        if (HiterIdActor == null || AttackActor == null)
            return;
        var targetActorBehavior = HiterIdActor.GetComponent<LuaBehavior>();//获取受击方的luaBehavior组件
        var curMoveActor = AttackActor.GetComponent<LuaBehavior>();//获取攻击方的luaBehavior组件
        var curMoveActorController = AttackActor.GetComponent<ActorAnimController>();
        //摄像机
        //CameraController.Instance.LookAtPos(HiterIdActor.transform.position, CameraController.EAltitude.Low);
        var targetActorController = HiterIdActor.gameObject.GetComponent<ActorAnimController>();
        if ((Mathf.Abs(targetActorBehavior.Get<int>("Col") - curMoveActor.Get<int>("Col")) == 1 && targetActorBehavior.Get<int>("Row") == curMoveActor.Get<int>("Row"))
        || (Mathf.Abs(targetActorBehavior.Get<int>("Row") - curMoveActor.Get<int>("Row")) == 1 && targetActorBehavior.Get<int>("Col") == curMoveActor.Get<int>("Col")))
        {//相邻格子不需要行走
            curMoveActorController.FaceToPos(HiterIdActor.transform.position);
            curMoveActorController.Attack();
            targetActorController.FaceToPos(curMoveActorController.transform.position);
            //CameraController.Instance.Shake(0.7f);
            //if (Random.Range(0, 1.0f) > 0.2f)
            targetActorController.Behit(0.75f);
            //else
            //targetActorController.Die(0.75f);
            //飘字
            var eff = EffectCreator.CreateEffect("TextFly");
            eff.transform.position = HiterIdActor.transform.position + new Vector3(0, 3f, 0);
            //获取攻击返回消息字典
            //var battleMsgListDic = GameData.BattleMsgListMgr.Instance.BattleMsgListdic;
            //判断有没有当前目标ActorID
            // if (battleMsgListDic.ContainsKey(targetActorBehavior.Get<string>("ActorGid")))
            // {
            //     //获取被击血量值
            //     var hp = battleMsgListDic[targetActorBehavior.Get<string>("ActorGid")].msgValue;
            //     eff.GetComponent<TextFly>().Show("-" + hp, 0.7f);
            //     GameObject.Destroy(eff, 2f);
            //     HideNeibourSlot(state);
            //     //动画结束
            // }
        }
        else if (Mathf.Abs(targetActorBehavior.Get<int>("Row") - curMoveActor.Get<int>("Row")) >= 1 && Mathf.Abs(targetActorBehavior.Get<int>("Col") - curMoveActor.Get<int>("Col")) >= 1)
        {//斜角位置
            if (Mathf.Abs(targetActorBehavior.Get<int>("Row") - curMoveActor.Get<int>("Row")) < Mathf.Abs(targetActorBehavior.Get<int>("Col") - curMoveActor.Get<int>("Col")))
            {
                if (targetActorBehavior.Get<int>("Row") > curMoveActor.Get<int>("Row"))
                {
                    var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row") - 1][targetActorBehavior.Get<int>("Col")];
                    WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
                }
                else
                {
                    var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row") + 1][targetActorBehavior.Get<int>("Col")];
                    WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
                }
            }
            else
            {
                if (targetActorBehavior.Get<int>("Col") > curMoveActor.Get<int>("Col"))
                {
                    var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row")][targetActorBehavior.Get<int>("Col") - 1];
                    WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
                }
                else
                {
                    var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row")][targetActorBehavior.Get<int>("Col") + 1];
                    WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
                }
            }
        }
        else if (Mathf.Abs(targetActorBehavior.Get<int>("Col") - curMoveActor.Get<int>("Col")) > 1 && targetActorBehavior.Get<int>("Row") == curMoveActor.Get<int>("Row"))
        {//同行，列数相差大于一格
            if (targetActorBehavior.Get<int>("Col") > curMoveActor.Get<int>("Col"))
            {
                var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row")][targetActorBehavior.Get<int>("Col") - 1];
                WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
            }
            else
            {
                var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row")][targetActorBehavior.Get<int>("Col") + 1];
                WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
            }
        }
        else if (Mathf.Abs(targetActorBehavior.Get<int>("Row") - curMoveActor.Get<int>("Row")) > 1 && targetActorBehavior.Get<int>("Col") == curMoveActor.Get<int>("Col"))
        {//同列，行数相差大于一格
            if (targetActorBehavior.Get<int>("Row") > curMoveActor.Get<int>("Row"))
            {
                var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row") - 1][targetActorBehavior.Get<int>("Col")];
                WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
            }
            else
            {
                var targetMoveSlot = BattleLogic.Instance.SlotluaBehaviors[targetActorBehavior.Get<int>("Row") + 1][targetActorBehavior.Get<int>("Col")];
                WalkAndAttackAnimator(curMoveActor, targetMoveSlot, curMoveActorController, targetActorController, state);
            }
        }
    }
    //跳过回合按钮
    public void OnSkipRoundBtn()
    {
        m_RequestMgr.CallLuaFunction("SendBattleRoundEnd");
    }
    public override void OnStateEnter(object param, Action callback)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateEnter", param);
    }
    public override void OnStateExit(object param)
    {
        GetComponent<LuaBehavior>().CallLuaFunction("OnStateExit", param);
    }
}
