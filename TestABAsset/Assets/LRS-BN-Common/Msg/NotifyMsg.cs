using System.Collections.Generic;
namespace Msg {
    public class NotifySceneCycleChange : MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 场景生命周期类型枚举 EBattleSceneCycleType*/
        public int cycleType = 0;
    }
    public class NotifyActorAttrUpdate : MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 角色GID*/
        public string entityGid = "";
        /** 属性信息*/
        public AttrInfo attrInfo = new AttrInfo();
    }
    public class NotifyChangeActivityPlayer : MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 阵营类型*/
        public string campType = "";
        /** 当前回合数*/
        public int roundNum = 0;
    }
    public class NotifyBattleSettle : MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 是否胜利 1 胜利 0 失败*/
        public int isWin = 0;
        public string leaderGid = "";
        public string mvpGid = "";
        public int battleType = 0;
        /** 奖励列表*/
        public BattleReward reward = new BattleReward();
    }
    
    public class NotifyBattleOperateList: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 消息列表*/
        public List<NotifyBattleOperate> msgList = new List<NotifyBattleOperate>();
    }

    public class NotifyBattleOperate : MsgBase {
        /** 操作类型枚举 NotifyBattleOperateType*/
        public string operateType = "";
        /** 操作类型枚举对应的参数*/
        public Dictionary<string, string> operateParam = new Dictionary<string, string>();
    }



    public class NotifyBattleEvent : MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 事件类型*/
        public int eventType = 0;
        /** 事件ID*/
        public int eventId = 0;
        /** 事件类型对应的参数*/
        public Dictionary<string, object> eventParam = new Dictionary<string, object>();
    }

    /**[装备] 通知装备修改修改 (服务器返回) */
    public class notifyEquipUpdate:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 改动的装备信息列表*/
        public List<Equipment> equipList = new List<Equipment>();
        /** 删除的装备Gid列表*/
        public List<string> delGidList = new List<string>();
    }

    /**[背包道具] 通知常规道具修改 (服务器返回) */
    public class notifyCommonItemEdit:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 改动的道具信息列表*/
        public List<ItemInfo> itemList = new List<ItemInfo>();
    }
    /**通知角色技能槽修改 字典的key为槽位类型，值为技能ID，当值为-1时该槽视为置空*/
    public class notifyActorSkillSlotUpdate: MsgBase {
        public string entityGid = "";
        public Dictionary<string, int> slotUpdate = new Dictionary<string, int>();
    }

    /**通知角色技能池修改*/
    public class notifyActorSkillPoolUpdate: MsgBase {
        public string entityGid = "";
        public List<int> delList = new List<int>();
        public List<Skill> updateList = new List<Skill>();
    }

    /**通知角色等级数据修改*/
    public class notifyActorLevelUpdate: MsgBase {
        public string entityGid = "";
        public List<LvInfo> lvInfos = new List<LvInfo>();
        public int exp = 0;
        public int level = 0;
    }

    /**通知玩家当前所在商会数据更新*/
    public class notifyPlayerCurChamberOfCommerceUpdate: MsgBase {
        public ChamberOfCommerceInfo info = new ChamberOfCommerceInfo();
    }

    /**通知玩家城堡数据更新*/
    public class notifyPlayerCastleInfoUpdate: MsgBase {
        public PlayerModuleCastle info = new PlayerModuleCastle();
    }

    /**通知玩家城堡联姻结果*/
    public class notifyPlayerCastleAllianceResult: MsgBase {
        public List<CastleAllianceResult> resultList = new List<CastleAllianceResult>();
    }

    /**[角色] 添加角色消息通知(服务器返回)*/
    public class notifyAddNewActor:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /**角色信息*/
        public List<Actor> actorList = new List<Actor>();
    }

    /**[角色] 解雇角色消息通知(服务器返回)*/
    public class notifyDeleteActor:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /**角色唯一ID*/
        public List<string> actorGids = new List<string>();
    }
    /**通知玩家更新势力友好度等级*/
    public class notifyPlayerPrestigeLvUpdate: MsgBase {
        //友好度等级信息列表
        public PlayerModulePrestige info = new PlayerModulePrestige();
    }

    /**通知玩家历练随机事件*/
    public class notifyCastleTrainPracticeEvent: MsgBase {
        public CastlePracticeRunInfo info = new CastlePracticeRunInfo();
        public int eventId = 0;
    }

    /**通知玩家历练随机相亲事件*/
    public class notifyCastleTrainPracticeMarriage: MsgBase {
        public CastlePracticeRunInfo info = new CastlePracticeRunInfo();
        public Part partInfo = new Part();
        public NobilityInfo nobilityInfo = new NobilityInfo();
        public int birthTime = 0;
    }
    
    /**通知玩家任务信息更新 */
    public class notifyTaskInfoUpdate: MsgBase{
        public TaskInfo info = new TaskInfo();
    }

    /**通知玩家过期任务删除 */
    public class notifyDeleteOverdueTaskInfo: MsgBase{
        public List<string> taskGids = new List<string>();
    }

    /**通知玩家修改角色爵位*/
    public class notifyActorChangeNobility: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 角色Gid*/
        public string entityGid = "";
        /** 角色爵位信息*/
        public NobilityInfo nobilityInfo= new NobilityInfo();
    }

    /**通知玩家修改世界时间*/
    public class notifyPlayerChangeTime: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 世界时间*/
        public int worldTime = 0;
    }

    /**通知玩家开启新城市点*/
    public class notifyOpenNewMapPointInfo: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 大地图唯一ID*/
        public string mapGid = "";
        /**大地图ID*/
        public int mapId = 0;
        /**城市点唯一ID*/
        public string pointGid = "";
        /**城市点ID*/
        public int pointId = 0;
        /**城市点信息*/
        public MapPointInfo mapPointInfo = new MapPointInfo();
    }
    /**通知玩家角色待命位置信息更新*/
    public class notifyPlayerUpdateActorAwaitPosition: MsgBase {
        public string msgType = "";
        /** 角色Gid*/
        public string entityGid = "";
        /** 待命位置*/
        public int awaitPosition = 0;
    }
    /**通知玩家任务触发器信息*/
    public class notifyTaskTriggerInfo: MsgBase {
        public string msgType = "";
        /** 触发器信息*/
        public TaskTriggerInfo info  = new TaskTriggerInfo();
    }
    /**通知玩家城堡学校信息更新*/
    public class notifyPlayerCastleSchoolInfoUpdate: MsgBase {
        public string msgType = "";
        public CastleSchoolInfo info = new CastleSchoolInfo();
    }
    /**通知玩家解锁节日*/
    public class notifyUnlockFestival: MsgBase {
        public string msgType = "";
        public int festivalId = 0;
    }
    /**通知玩家某城市点任务完成删除任务ID*/
    public class notifyPlayerMapPointDeleteTaskId: MsgBase {
        public string msgType = "";
        public string mapGid = "";//地图唯一ID
        public int pointId = 0;//城市点ID
        public int taskId = 0;//任务Id
    }
    /**通知玩家改变全局特性*/
    public class notifyPlayerChangePlayerSpecial: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**玩家特性 id 到期时间*/
        public Dictionary<int, int> specialitys = new Dictionary<int, int>();
        /**删除的特性id*/
        public List<int> delIdList = new List<int>();
    }
    /**通知玩家城堡市场商品更新*/
    public class notifyPlayerCastleChamberOfCommerceGoods: MsgBase {
        public List<ChamberOfCommerceGoodsInfo> goodsList = new List<ChamberOfCommerceGoodsInfo>();
    }
    /**通知玩家角色婚姻状态修改*/
    public class notifyActorChangeMarryState: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 角色Gid*/
        public string entityGid = "";
        /** 婚姻状态*/
        public int marryState= 0;
    }

    /**通知玩家初次完成随机战斗任务*/
    public class notifyFirstCompleteRandomBattleTask: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 任务id*/
        public int taskId= 0;
    }

    /**通知在线玩家每日刷新*/
    public class notifyOnlinePlayerDailyRefresh: MsgBase {
        /** 消息类型*/
        public string msgType = "";
    }

    /**通知玩家进行婚宴*/
    public class notifyPlayerRunWedding: MsgBase {
        public string msgType = "";
        public List<WeddingInfo> infoList = new List<WeddingInfo>();
    }

    /**通知玩家某个目标数据状态变化 */
    public class notifyPlayerTargetAttainment: MsgBase {
        public string msgType = "";
        public AttainmentInfo info = new AttainmentInfo();
    }
    /**通知玩家角色特性修改*/
    public class notifyActorSpecialityUpdate: MsgBase {
        public string msgType = "";
        public string entityGid = "";
        public List<int> delList = new List<int>();
        public List<SpecialityInfo> updateList = new List<SpecialityInfo>(); 
    }
    /**通知玩家角色伤病列表更新*/
    public class notifyActorInjuryUpdate: MsgBase {
        public string msgType = "";
        public string entityGid = "";
        public List<int> delList = new List<int>();
        public List<SpecialityInfo> updateList = new List<SpecialityInfo>(); 
    }
    /**通知玩家离线*/
    public class notifyPlayerOffLine: MsgBase {
        public string msgType = "";
        public int code = 0;
    }
    /**通知玩家角色升级信息*/
    public class notifyPlayerActorUpLvInfo: MsgBase {
        public string msgType = "";
        public BattleRewardActorInfo info = new BattleRewardActorInfo();
    }
    /**通知玩家开启节日*/
    public class notifyOpenFestival: MsgBase {
        public string msgType = "";
        public List<int> festivalIds = new List<int>();
    }
    /**通知玩家改变全局属性*/
    public class notifyPlayerChangePlayerAttrs: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**玩家属性id  属性值*/
        public Dictionary<int, int> attrs = new Dictionary<int, int>();
    }
    /**通知玩家角色状态修改*/
    public class notifyActorChangeStatus: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 角色Gid*/
        public string entityGid = "";
        /** 当前状态*/
        public int status = 0;
    }
    /**通知玩家处理角色要求*/
    public class notifyPlayerProcessingActorDemand: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 需求列表*/
        public List<CorpsDemandInfo> demandList = new List<CorpsDemandInfo>();
    }
    /**通知玩家改变角色要求状态*/
    public class notifyChangeActorDemandStatus: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 角色Gid*/
        public string entityGid = "";
        /** 需求id*/
        public int demandId = 0;
        /** 当前状态*/
        public int status = 0;
    }
    /**通知玩家角色新增伤病信息*/
    public class notifyActorAddInjuryInfo: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        public int injuryListType = 0;
        public Dictionary<string, List<SpecialityInfo>> actorList = new Dictionary<string, List<SpecialityInfo>>();
    }
    /**通知玩家结算军团工资*/
    public class notifyPlayerWageSettlement: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 扣除数量*/
        public int count = 0;
    }
    /**通知玩家确认剧情进度*/
    public class notifyPlayerUnlockSceneScenario: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 扣除数量*/
        public string msg = "";
    }
    /**[城堡委托派遣] 主动通知委托任务状态变化*/
    public class notifyPlayerEntrustInfoChange: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 委托任务信息*/
        public EntrustInfo info = new EntrustInfo();
    }
    /**[城堡委托派遣] 主动通知接委托任务次数变化*/
    public class notifyPlayerChangeEntrustCount: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /** 今日接委托任务次数*/
        public int entrustCount = 0;
    }
    /**[城堡委托派遣] 主动通知删除过期或者领取奖励的委托任务*/
    public class notifyDeleteEntrustTaskInfo: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**委托任务唯一ID */
        public string entrustGid = "";
    }
    /**[城堡委托派遣] 主动通知角色派遣任务的状态变化*/
    public class notifyActorEntrustStatusChange: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**被派遣出去的角色唯一ID列表 */
        public List<string> actorGids = new List<string>();
        /**委托状态,0未派遣,1派遣 */
        public int awaitPosition = 0;
    }
    /**[城堡委托派遣] 主动通知城堡等级解锁委托任务列表*/
    public class notifyStartEntrustTaskList: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**开启的委托任务列表 */
        public List<EntrustInfo> entrustTaskList = new List<EntrustInfo>();
    }
    /**通知角色依照剧情召唤*/
    public class notifyScenarioSummonActor: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**角色信息*/
        public Team newActorInfo = new Team();
    }
    /**通知角色依照剧情从场外入场*/
    public class notifyScenarioActorEntryScene: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**角色信息*/
        public Team newActorInfo = new Team();
    }
    /**通知角色依照剧情移动*/
    public class notifyScenarioActorMove: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        public string srcGid = "";
        public int targetTileIndex = 0;
    }
    /**通知角色依照剧情使用技能*/
    public class notifyScenarioActorUseSkill: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        public string srcGid = "";
        public string targetGid = "";
        public int skillMId = 0;
        public int realDmg = 0;
        public int useType = 0;
        public int beHitType = 0;
    }
    /**通知开始执行剧情*/
    public class notifyStartScenarioTrigger: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        public string scenarioTriggerId = "";
    }
    /**通知同步执行的剧情列表*/
    public class notifySyncScenarioList: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        public List<object> notifyL = new List<object>();
    }
    /**通知玩家接收新邮件*/
    public class notifyPlayerReceiveNewMail: MsgBase {
        /** 消息类型*/
        public string msgType = "";
        /**邮件详细信息 */
        public MailInfo mail = new MailInfo();
    }
    /**通知玩家接收跑马灯消息 */
    public class notifyPlayerReceiveMarquee:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /**跑马灯mid */
        public int marqueeId = 0;
        /**消息替换内容 */
        public List<string> infoList = new List<string>();
    }
    /**通知玩家更新钻石商店数据 */
    public class notifyUpdatePlayerDiamondShopInfo:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /**商店数据*/
        public DiamondShopInfo info = new DiamondShopInfo();
    }
    /**通知玩家更新角色血脉相关数据*/
    public class notifyUpdateActorBloodInfo:MsgBase{
        /**消息类型*/
        public string msgType = "";
        public string entityGid = "";
        /**血脉数据*/
        public BloodInfo info = new BloodInfo();
    }
    /**通知玩家更新编队预设数据*/
    public class notifyUpdateBattleTeamInfo:MsgBase{
        /**消息类型*/
        public string msgType = "";
        public BattleTeamInfo info = new BattleTeamInfo();
    }
    /**[主线、支线任务]主动通知客户端主线剧情播放 */
    public class notifyPlayerTaskNextStoryInfo:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 消息列表*/
        public TaskMainStoryInfo info = new TaskMainStoryInfo();
    }
    /**通知玩家BUFF效果触发*/
    public class notifyBattleActorBuffTriggered:MsgBase{
        /**消息类型*/
        public string msgType = "";
        public string entityGid = "";
        public int buffMid = 0;
        /** 消息列表*/
        public List<NotifyBattleOperate> msgList = new List<NotifyBattleOperate>();
    }
    /**通知玩家角色夭折*/
    public class notifyActorJuvenilesDeath:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 消息列表*/
        public List<string> list = new List<string>();
    }
    /**通知玩家角色成年*/
    public class notifyActorAdult:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 消息列表*/
        public List<string> list = new List<string>();
    }
    /**通知玩家角色退休*/
    public class notifyActorRetired:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 消息列表*/
        public List<string> list = new List<string>();
    }
    /**通知玩家角色衰老死亡*/
    public class notifyActorLifeSpanEnd:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /** 消息列表*/
        public List<string> list = new List<string>();
    }
    /**通知玩家竞技场数据更新*/
    public class notifyUpdatePlayerArenaInfo:MsgBase{
        /**消息类型*/
        public string msgType = "";
        public List<int> buffList = new List<int>();
        public int useBattleNum = 0;
        public int buyBattleNum = 0;
        public int curScore = 0;
        public int curIndex = 0;
        public int seasonBattleNum = 0;
        public int lastGainArenaLvPrize = 0;
        public int winNum = 0;
        public List<int> gainBattleNumPrizeLv = new List<int>();
    }
    /**通知玩家竞技场匹配成功*/
    public class notifyUpdateArenaRandomMatch:MsgBase{
        /**消息类型*/
        public string msgType = "";
        public string corpsName = "";
        public CorpsFlagInfo flagInfo = new CorpsFlagInfo();
        public int score = 0;
        public int index = 0;
    }
    /**通知玩家竞技场席位挑战结算更新*/
    public class notifyUpdateArenaSeatSettle:MsgBase{
        /**消息类型*/
        public string msgType = "";
        public int score = 0;
        public int seatNum = 0;
    }
    /**通知玩家修改追踪任务*/
    public class notifyPlayerTrackingTask:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /**任务类型*/
        public int taskType = 0;
        /**任务唯一id*/
        public string taskGid = "";
        /**任务id*/
        public int taskId = 0;
    }
    /**通知客户端某路点上进入战斗的任务列表刷新 */
    public class notifyPointRefreshTaskGids:MsgBase{
        /**消息类型*/
        public string msgType = "";
        /**战斗点ID-任务唯一ID列表*/
        public PlayerBattlePointTaskGidsInfo info = new PlayerBattlePointTaskGidsInfo();
    }
    /**通知客户端主线、支线任务变化 */
    public class notifyMainTaskInfoUpdate: MsgBase{
        public TaskMainInfo info = new TaskMainInfo();
    }
}