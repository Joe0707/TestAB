using System.Collections.Generic;
namespace Msg {
    
    /**
    * [battle服]客户端获取连接信息
    * 返回消息的data参数定义，总消息为msg:{code: 0, data:{}}
    */

    /**战前调整队员到空格子上 */
    public class battlePrePareSetActorPosition : MsgBase
    {
        /**账号唯一ID */
        public string accountGid = "";
        /**战斗唯一ID */
        public string battleGid = "";
        /** 卡牌唯一ID */
        public string actorGid = "";
        /** 要换位置index下标 */
        public int index = 0;
    }

    /** 战斗中服务器主动给客户端消息 */
    public class notifyBattleInfo : MsgBase{
        /**返回错误码 */
        public int code = 0;
        /** 消息类型*/
        public string msgType = "";
        /**子消息类型 */
        public string subMsgType = "";
        /**战斗回合数 */
        public int battleRound = 0;
        /** 战斗回合状态,None不切换状态,BattleInit战斗初始化,BattleStart战斗开始,TeamAdjustment队伍调整,MyTurn我的回合,OthersTurn别人的回合,Dialog剧情,BattleResult战斗结算,BattleEnd战斗结束*/
        public string battleState = "";
        /** 战斗结果状态, -1战前, 0战斗中, 1战斗失败, 2战斗胜利 */
        public int battleResultState = 0;
        /**战斗奖励数据 */
        public BattleReward battleReward = new BattleReward();
        /**战斗消息列表 */
        public List<BattleMsgList> battleMsgList = new List<BattleMsgList>();
    }
    /** 回合结束（客户端发送） */
    public class battleRoundEndState : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /** 进入关卡后调整队员战位 (客户端发送) */
    public class battlePrePareRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗唯一ID
        public string battleGid = "";
        //换位置队员唯一ID
        public string actorGid = "";
        //换位置队员2唯一ID
        public string actorGid2 = "";
    }
    /** 进入关卡 (客户端发送) */
    public class battleEnterRequest : MsgBase{
        //关卡ID
        public int levelId = 0;
        //账号唯一ID
        public string accountGid = "";
        //任务唯一ID
        public string taskGid = "";
        //战斗路点ID(城市点ID)
        public int pointId = 0;
    }
    /** 进入关卡 (服务器返回) */
    public class battleEnterResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗唯一ID
        public string battleGid = "";
        //战斗场景类型
        public int battleType = 0;
        //战场关卡配置ID
        public int levelId = 0;
        //当前回合数
        public int round = 0;
        //当前战场场景流程状态
        public int battleCycle = 0;
        //场景初始化参数-镜头位置
        public Dictionary<string, float> cameraPosition = new Dictionary<string, float>();
        //场景初始化参数-镜头角度
        public Dictionary<string, float> cameraRotation = new Dictionary<string, float>();
        //场景初始化参数-镜头尺寸
        public float cameraSize = 0f;
        //场景初始化参数-镜头区域配置下标
        public int edgeValueListIndex = 0;
        //场景初始化参数-BGM
        public string bgm = "";
        //当前主操作玩家GID
        public string mainPlayerGid = "";
        //怪物布局信息
        public List<Team> monsters = new List<Team>();
        //队伍布局信息
        public List<Team> teams = new List<Team>();
        //目前剧情触发器ID
        public string scenarioTriggerId = "";
        //目前剧情触发器index
        public int scenarioIndex = 0;
    }
    /** 战斗开始切换状态 (客户端发送) */
    public class battleStartRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }

    /** 战斗开始，手动操作队员移动战位 (客户端发送)*/
    public class battlePlayStateRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //卡牌唯一id
        public string actorGid = "";
        //目标格子下标index
        public int positionIndex = 0;
    }

    /** 战斗开始，手动操作队员移动战位 (服务器返回)*/
    public class battlePlayStateResponse : MsgBase{
        //返回战斗消息类型，包括战位移动
        public List<BattleMsgList> msgList = new List<BattleMsgList>();
    }

    /** 战斗开始,手动操作队员与怪物战斗 (客户端发送) */
    public class battlePlayRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //卡牌唯一ID
        public string actorGid = "";
        //怪物唯一ID
        public string monsterGid = "";
        /**攻击者落脚点 */
        public int positionIndex = -1;
    }
    /** 战斗开始后,手动操作队员与怪物战斗 (服务器返回) */
    public class battlePlayResponse : MsgBase{
        //战斗消息列表
        public List<BattleMsgList> msgList = new List<BattleMsgList>(); 
    }

    /** 战斗开始后,自己回合结束, 怪物回合返回 (服务器返回) */
    public class onAttackResponse : MsgBase{
        //消息类型
        public string msgType = "";
        //战斗状态
        public string battleState = "";
        //战斗消息列表
        public List<BattleMsgList> msgList = new List<BattleMsgList>();
    }

    /** 战斗结束 (客户端发送)*/
    public class battleEndRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /** 战斗结束 (服务器返回) */
    public class battleEndResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗奖励数据
        public List<ItemInfo> reward = new List<ItemInfo>();
    }
    /** 退出关卡（客户端发送） */
    public class battleOutRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /** 操作阶段确认（客户端发送） */
    public class battleActivityConfirmRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /** 操作阶段确认（服务器返回） */
    public class battleActivityConfirmResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /**设置角色转向角度*/
    public class battleSetActorOrientationRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        public Dictionary<string, float> orientationHash = new Dictionary<string, float>();
    }
    /**设置角色转向角度*/
    public class battleSetActorOrientationResponse : MsgBase{
    }
    /**确认解锁剧情步骤*/
    public class unlockSceneScenarioRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //下一个触发器需要的额外临时参数字典
        public Dictionary<string, object> paramList = new Dictionary<string, object>();
    }
    /**确认解锁剧情步骤*/
    public class unlockSceneScenarioResponse : MsgBase{
    }
    /**根据木桩ID获取一个team数据*/
    public class getTeamInfoByStumpIdRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //木桩ID
        public string stumpId = "";
    }
    /**根据木桩ID获取一个team数据*/
    public class getTeamInfoByStumpIdResponse : MsgBase{
        public Team teamInfo = new Team();
    }
    /**前端通知后端战斗场景完成加载*/
    public class notifyServerBattleSceneLoadEndRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /**前端通知后端战斗场景完成加载*/
    public class notifyServerBattleSceneLoadEndResponse : MsgBase{
    }
    /**竞技场进行挑战*/
    public class runArenaChallengeRequest: MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /**竞技场进行挑战*/
    public class runArenaChallengeResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗唯一ID
        public string battleGid = "";
        //战斗场景类型
        public int battleType = 0;
        //战场关卡配置ID
        public int levelId = 0;
        //当前回合数
        public int round = 0;
        //当前战场场景流程状态
        public int battleCycle = 0;
        //场景初始化参数-镜头位置
        public Dictionary<string, float> cameraPosition = new Dictionary<string, float>();
        //场景初始化参数-镜头角度
        public Dictionary<string, float> cameraRotation = new Dictionary<string, float>();
        //场景初始化参数-镜头尺寸
        public float cameraSize = 0f;
        //场景初始化参数-镜头区域配置下标
        public int edgeValueListIndex = 0;
        //场景初始化参数-BGM
        public string bgm = "";
        //当前主操作玩家GID
        public string mainPlayerGid = "";
        //怪物布局信息
        public List<Team> monsters = new List<Team>();
        //队伍布局信息
        public List<Team> teams = new List<Team>();
        //目前剧情触发器ID
        public string scenarioTriggerId = "";
        //目前剧情触发器index
        public int scenarioIndex = 0;
    }
    /**组队副本进行挑战*/
    public class runTeamBattleChallengeRequest: MsgBase{
        //账号唯一ID
        public string accountGid = "";
		public int country = 0;
		public int level = 0;
    }
    /**组队副本进行挑战*/
    public class runTeamBattleChallengeResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗唯一ID
        public string battleGid = "";
        //战斗场景类型
        public int battleType = 0;
        //战场关卡配置ID
        public int levelId = 0;
        //当前回合数
        public int round = 0;
        //当前战场场景流程状态
        public int battleCycle = 0;
        //场景初始化参数-镜头位置
        public Dictionary<string, float> cameraPosition = new Dictionary<string, float>();
        //场景初始化参数-镜头角度
        public Dictionary<string, float> cameraRotation = new Dictionary<string, float>();
        //场景初始化参数-镜头尺寸
        public float cameraSize = 0f;
        //场景初始化参数-镜头区域配置下标
        public int edgeValueListIndex = 0;
        //场景初始化参数-BGM
        public string bgm = "";
        //当前主操作玩家GID
        public string mainPlayerGid = "";
        //怪物布局信息
        public List<Team> monsters = new List<Team>();
        //队伍布局信息
        public List<Team> teams = new List<Team>();
        //目前剧情触发器ID
        public string scenarioTriggerId = "";
        //目前剧情触发器index
        public int scenarioIndex = 0;
    }
    /**爬塔挑战*/
    public class climbTowerChallengeRequest: MsgBase{
        //账号唯一ID
        public string accountGid = "";
    }
    /**爬塔挑战*/
    public class climbTowerChallengeResponse : MsgBase{
        //进入战斗场景数据
        public battleEnterResponse battleEnter = new battleEnterResponse();
        //国家塔血脉赠送的buff卡牌
        public List<int> cardList = new List<int>();
        //奖励血脉id
        public int descentId = 0;
        //血脉数量
        public int bloodContent = 0;
        // 关卡id
        public int levelId = 0;
    }
}