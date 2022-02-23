using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJson;
public class BattleLogic : MonoBehaviour
{
    public List<List<LuaBehavior>> SlotluaBehaviors = new List<List<LuaBehavior>>();
    [HideInInspector]
    public List<LuaBehavior> Slots = new List<LuaBehavior>();
    public static BattleLogic Instance { get; protected set; }
    [HideInInspector]
    public GameObject CurMoveActor = null;//当前移动的Actor
    [HideInInspector]
    public List<LuaBehavior> CurActorNeibourSlots = new List<LuaBehavior>(); //当前移动的Actor周围的格子
    public List<Msg.notifyBattleInfo> NotifyBattleInfos = new List<Msg.notifyBattleInfo>();//服务器通知消息列表
                                                                                           //  public Queue
    public GameObject m_MyTurn;
    public GameObject m_OtherTurn;
    public GS_SelectTarget selectTarget;
    private LogicStateMachine battleStateMachine;//战斗状态机
    public bool isMyTurn = false;
    void Awake()
    {
        transform.GetComponent<Renderer>().material.GetTexture("_MainTex");
        Instance = this;
    }
    void OnEnable()
    {
        // var ma = gameObject.GetComponent<Renderer>().materials;
        // ma.Length;
        // ma[0].CopyPropertiesFromMaterial
        EventMgr.AddEventHandler("OnPushMsg_notifyBattleInfo", NotifyBattleInfo);
    }
    void OnDisable()
    {
        EventMgr.RemoveEventHandler("OnPushMsg_notifyBattleInfo", NotifyBattleInfo);
    }
    void Start()
    {
        battleStateMachine = GetComponent<LogicStateMachine>();
    }

    float mActionTimer = 0;//动作时间
    void Update()
    {
        //判断动作时间是否大于零
        if (mActionTimer > 0)
            mActionTimer -= Time.deltaTime;
        //处理战斗消息队列
        if (NotifyBattleInfos.Count > 0 && mActionTimer <= 0)
        {
            var nextInfo = NotifyBattleInfos[0];
            if (nextInfo.battleState != "None")
            {
                gameObject.GetComponent<LogicStateMachine>().ChangeState(nextInfo.battleState);//切换战斗状态
                mActionTimer = 2f;
            }
            // //遍历战斗消息列表
            // if (nextInfo.battleMsgList.Count > 0 && selectTarget.gameObject.activeInHierarchy)
            // {
            //     var battleMsgList = nextInfo.battleMsgList[0];
            //     selectTarget.OnAttack(battleMsgList.attackId, battleMsgList.hiterId, "SelectTarget");//1.攻击方id  2.受击方id 3.选择目标状态
            //     nextInfo.battleMsgList.RemoveAt(0);
            //     mActionTimer = 2f;
            // }
            // if (nextInfo.battleMsgList.Count == 0 && nextInfo.battleReward.items.Count == 0)
            // {
            //     NotifyBattleInfos.RemoveAt(0);
            // }
        }

    }
    /// <summary>
    /// 获取战斗状态机
    /// </summary>
    /// <returns></returns>
    public LogicStateMachine GetLogicStateMachine()
    {
        return battleStateMachine;
    }
    /// <summary>
    /// 切换战斗状态
    /// </summary>
    /// <param name="state"></param>
    public void ChangeBattleState(string state)
    {
        battleStateMachine.ChangeState(state);
    }


    //服务器主动通知消息
    public void NotifyBattleInfo(object param)
    {
        if (param == null)
            return;
        var data = param as JsonObject;
        var notifyBattleInfo = MsgBase.JsonToObject<Msg.notifyBattleInfo>(data);
        for (int i = 0; i < notifyBattleInfo.battleMsgList.Count; i++)
        {
            //GameData.BattleMsgListMgr.Instance.LoadFromBattleMsgList(notifyBattleInfo.battleMsgList[i]);
        }
        NotifyBattleInfos.Add(notifyBattleInfo);//添加服务器通知消息
                                                //gameObject.GetComponent<LogicStateMachine>().ChangeState(notifyBattleInfo.battleState);
    }
    //获取周围格子
    public List<LuaBehavior> GetNeibourSlots(int centerRow, int centerCol, int range)
    {
        var returnValue = new List<LuaBehavior>();
        for (int r = centerRow - range; r <= centerRow + range; r++)
        {
            if (r < 0 || r >= Levels.LevelLoader.Instance.CurLevelConfig.RowCount)
                continue;
            for (int c = centerCol - range; c <= centerCol + range; c++)
            {
                if (c < 0 || c >= Levels.LevelLoader.Instance.CurLevelConfig.ColCount)
                    continue;
                if (r == centerRow && c == centerCol)
                    continue;
                Debug.Log(SlotluaBehaviors[r]);
                returnValue.Add(SlotluaBehaviors[r][c]);
            }
        }
        return returnValue;
    }

    //隐藏周围格子
    public void HideNeibourSlot()
    {
        if (CurActorNeibourSlots.Count == 0)
            return;
        foreach (var item in CurActorNeibourSlots)
        {
            item.gameObject.SetActive(false);
        }
        BattleLogic.Instance.CurMoveActor = null;
    }


    //查询Slot
    public LuaBehavior GetSlot(int row, int col)
    {
        if (row < 0 || col < 0)
            return null;
        if (row >= SlotluaBehaviors.Count)
            return null;
        if (col >= SlotluaBehaviors[0].Count)
            return null;
        return SlotluaBehaviors[row][col];
    }
}
