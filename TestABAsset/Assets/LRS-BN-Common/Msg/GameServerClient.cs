using System.Collections.Generic;
namespace Msg {
    /**
    * [game服]客户端获取连接信息
    * 返回消息的data参数定义，总消息为msg:{code: 0, data:{}}
    */

    /**[爬塔功能] 兑换塔内商店商品 (客户端请求)*/
    public class exchangeTowerShopRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**商品Gid*/
        public int shopGid = 0;
    }

    /**[爬塔功能] 进入塔内商店 (客户端请求)*/
    public class enterTheTowerShopRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }

    /**[爬塔功能] 进入塔内商店 (服务器返回)*/
    public class enterTheTowerShopResponse: MsgBase{
        /**商店商品 */
        public List<TowerShopInfo> shopList = new List<TowerShopInfo>();
    }

    /**[爬塔功能] 回答问题 (客户端请求)*/
    public class towerAnswerTheQuestionsRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**答案ID */
        public int answerId = 0;
        
    }

    /**[爬塔功能] 回答问题 (服务器返回)*/
    public class towerAnswerTheQuestionsResponse: MsgBase{
        /**获得卡牌 */
        public List<int> cardList = new List<int>();
        /**下一道问题id */
        public int nextQuestion = 0;
    }

    /**[爬塔功能] 进入答题 (客户端请求)*/
    public class enterTheTowerAnswerRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }

    /**[爬塔功能] 进入答题 (服务器返回)*/
    public class enterTheTowerAnswerResponse: MsgBase{
        /**当前问题 */
        public int question = 0;
        /**获得卡牌 */
        public List<int> cardList = new List<int>();
        /**答题状态 1可答题 0不可答题 */
        public int answerstatus = 0;
    }

    /**[爬塔功能] 进入塔内 (客户端请求)*/
    public class enterTheTowerRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**塔ID */
        public int towerId = 0;
    }

    /**[爬塔功能] 进入塔内 (服务器返回)*/
    public class enterTheTowerResponse: MsgBase{
        /**第一位通关玩家 */
        public string firstPlayer = "";
        /**最低通关战力 */
        public int lowestPower = 0;
        /**最低战力通关玩家 */
        public string lowestPlayer = "";
    }

    /**[爬塔功能] 获取全部塔信息 (客户端请求)*/
    public class getAllTowerInfoRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }

    /**[爬塔功能] 获取全部塔信息 (服务器返回)*/
    public class getAllTowerInfoResponse: MsgBase{
        /**全部塔信息 */
        public List<TowerInfo> towerInfoList = new List<TowerInfo>();
    }

    /**[系统设置] 账号登出 (客户端请求)*/
    public class logoutRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }

    /**[主线、支线任务] 接默认主线任务 (客户端请求)*/
    public class acceptDefaultTaskMainRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }

    /**[系统设置] 使用兑换码 (客户端请求)*/
    public class useExchangeCodeRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**兑换码 */
        public string exchangeCode = "";
    }

    /**[装备附魔] 获取附魔冷却时间 (客户端请求)*/
    public class getEnchantingCoolingTimeRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
    }

    /**[装备附魔] 获取附魔冷却时间 (服务器返回) */
    public class getEnchantingCoolingTimeResponse: MsgBase{
        /**刷新剩余冷却时间 */
        public long refreshCoolingTime = 0;
        /**刷新剩余冷却时间 */
        public long enchantingCoolingTime = 0;
    }

    /**[任务] 修改追踪任务(客户端请求) */
    public class modifyTrackingTaskRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**任务唯一id*/
        public string taskGid = "";
    }

    /**[每日签到] 领取连续签到奖励(客户端请求) */
    public class receiveContinuousSignRewardRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[每日签到] 领取连续签到奖励(服务器返回) */
    public class receiveContinuousSignRewardResponse: MsgBase{
        /**奖励信息*/
        public List<SignCycleReward> rewardList = new List<SignCycleReward>();
    }

    /**[每日签到] 获取连续签到信息(客户端请求) */
    public class getContinuousSignInfoRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[每日签到] 获取连续签到信息(服务器返回) */
    public class getContinuousSignInfoResponse: MsgBase{
        /**最高连续签到次数*/
        public int signContinuousMax = 0;
        /**连续签到次数*/
        public int signContinuous = 0;
        /**奖励信息*/
        public List<SignCycleReward> rewardList = new List<SignCycleReward>();
    }

    /**[每日签到] 点击签到(客户端请求) */
    public class clickTheSignInRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[每日签到] 获取签到信息(客户端请求) */
    public class getSignInfoRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[每日签到] 获取签到信息(服务器返回) */
    public class getSignInfoResponse: MsgBase{
        /**可签到次数*/
        public int signCount = 0;
        /**当前签到ID*/
        public int curSignId = 0;
        /**连续签到次数*/
        public int signContinuous = 0;
    }

    /**[排行榜] 获取排行榜角色详情信息(客户端请求) */
    public class getRankListActorInfoRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**排行榜id*/
        public int rankId = 0;
        /**角色实体唯一ID*/
        public string entityGid = "";
    }

    /**[排行榜] 获取排行榜角色详情信息(服务器返回) */
    public class getRankListActorInfoResponse: MsgBase{
        /**角色详情*/
        public RankActorInfo actorInfo = new RankActorInfo();
    }

    /**[排行榜] 获取角色排行榜信息(客户端请求) */
    public class getActorRankListInfoRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**排行榜id*/
        public int rankId = 0;
    }

    /**[排行榜] 获取角色排行榜信息(服务器返回) */
    public class getActorRankListInfoResponse: MsgBase{
        /**军团名称*/
        public string corpsName = "";
        /**榜单排名信息*/
        public List<ActorRankListInfo> rankList = new List<ActorRankListInfo>();
        /**玩家上榜信息*/
        public List<PlayreRankActorInfo> playerRankInfo = new List<PlayreRankActorInfo>();
    }

    /**[排行榜] 获取活动排行榜(客户端请求) */
    public class getOpenActiveRankInfoRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[排行榜] 获取活动排行榜(服务器返回) */
    public class getOpenActiveRankInfoResponse: MsgBase{
        /**活动榜单*/
        public List<ActiveRankInfo> activeRankList = new List<ActiveRankInfo>();
    }

    /**[排行榜] 获取通用排行榜信息(客户端请求) */
    public class getGeneralRankListInfoRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**排行榜id*/
        public int rankId = 0;
    }

    /**[排行榜] 获取通用排行榜信息(服务器返回) */
    public class getGeneralRankListInfoResponse: MsgBase{
        /**军团名称*/
        public string corpsName = "";
        /**榜单排名信息*/
        public List<RankListInfo> rankList = new List<RankListInfo>();
        /**玩家榜单信息*/
        public PlayerRankInfo playerRankInfo = new PlayerRankInfo();
    }

    /**[征兵] 角色参与征兵(客户端请求) */
    public class actorJoinConscriptionRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一id数组*/
        public List<string> entityGids = new List<string>();
        /**加入国家*/
        public int countryId = 0;
    }

    /**[角色] 添加自定义标签(客户端请求) */
    public class addActorCustomTagRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一id*/
        public string entityGid = "";
        /**自定义标签*/
        public string customTag = "";
    }

    /**[测试命令] 测试命令协议(客户端请求) */
    public class testCommandRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**参数字典 "functionName":"方法名(必填)","方法参数名":"方法参数(按方法需要选填)"*/
        public Dictionary<string, string> data = new Dictionary<string, string>();
    }

    /**[军团需求] 处理角色要求(客户端请求) */
    public class processingActorDemandRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色Gid*/
        public string entityGid = "";
        /**需求状态 0拒绝 1接受 */
        public int status = 0;
    }

    /**[军团技能] 激活军团技能(客户端请求) */
    public class activatedCorpSkillRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**军团技能id*/
        public int corpSkillId = 0;
    }

    /**[军团技能] 升级解锁军团技能(客户端请求) */
    public class upUnlockedCorpSkillRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**军团技能id*/
        public int corpSkillId = 0;
    }

    /**[军团技能] 升级解锁军团技能(服务器返回) */
    public class upUnlockedCorpSkillResponse: MsgBase{
        /**军团技能*/
        public CorpsSkillInfo corpSkill = new CorpsSkillInfo();
    }

    /**[军团圣物] 开始突破军团圣物(客户端请求) */
    public class startCorpsSacredBreakRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**装备唯一id*/
        public string equipGid = "";
    }

    /**[军团圣物] 开始突破军团圣物(服务器返回) */
    public class startCorpsSacredBreakResponse: MsgBase{
        /**可选效果列表*/
        public List<string> effectList = new List<string>();
    }

    /**[军团圣物] 圣物人物解绑(客户端请求) */
    public class corpsSacredUnbundlingRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**装备唯一id*/
        public string equipGid = "";
    }
    
    /**[军团圣物] 军团圣物突破(客户端请求) */
    public class corpsSacredBreakRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[军团圣物] 打造军团圣物(客户端请求) */
    public class createCorpsSacredRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**效果*/
        public string effect = "";
        /**圣物名*/
        public string name = "";
    }

    /**[军团圣物] 刷新军团圣物效果(客户端请求) */
    public class refreshCorpsSacredEffectRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[军团圣物] 刷新军团圣物效果(服务器返回) */
    public class refreshCorpsSacredEffectResponse: MsgBase{
        /**可选效果列表*/
        public List<string> effectList = new List<string>();
    }

    /**[军团圣物] 开始打造军团圣物(客户端请求) */
    public class startCreateCorpsSacredRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**装备唯一id*/
        public string equipGid = "";
    }

    /**[军团圣物] 开始打造军团圣物(服务器返回) */
    public class startCreateCorpsSacredResponse: MsgBase{
        /**可选效果列表*/
        public List<string> effectList = new List<string>();
    }

    /**[军团管理] 给角色任命军团职位(客户端请求) */
    public class appointmentCorpsPositionRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**槽位坐标*/
        public int index = 0;
        /**任命的角色*/
        public string entityGid = "";
    }

    /**[军团管理] 给角色任命军团职位(服务器返回) */
    public class appointmentCorpsPositionResponse: MsgBase{
        /**职位槽位信息*/
        public CorpsPositionSlotInfo positionSlotInfo = new CorpsPositionSlotInfo();
    }

    /**[军团管理] 升级军团职位(客户端请求) */
    public class upCorpsPositionRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**升级槽位坐标*/
        public int index = 0;
    }

    /**[军团管理] 升级军团职位(服务器返回) */
    public class upCorpsPositionResponse: MsgBase{
        /**职位槽位信息*/
        public CorpsPositionSlotInfo positionSlotInfo = new CorpsPositionSlotInfo();
    }

    /**[军团管理] 修改军团名(客户端请求) */
    public class modifyCorpsNameRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**军团名称*/
        public string corpsName = "";
    }

    /**[军团管理] 修改军团旗帜(客户端请求) */
    public class modifyCorpsFlagRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**旗帜信息*/
        public CorpsFlagInfo flagInfo = new CorpsFlagInfo();
    }

    /**[军团管理] 创建军团信息(客户端请求) */
    public class createNewCorpsRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**军团名称*/
        public string corpsName = "";
        /**旗帜信息*/
        public CorpsFlagInfo flagInfo = new CorpsFlagInfo();
    }

    /**[军团管理] 创建军团信息(服务器返回) */
    public class createNewCorpsResponse: MsgBase{
        /**军团信息*/
        public CorpsInfo corpsInfo = new CorpsInfo();
    }

    /**[使用道具] 使用扫荡券(客户端请求) */
    public class useItemSweepingRequest: MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**任务Gid*/
        public string taskGid = "";
        /**编队名*/
        public string teamName = "";
    }

    /**[节日香桃节] 获取香桃节相亲对象(客户端请求)*/
    public class getFestivalPeachBlindDateRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**相亲者坐标:Gid字典*/
        public Dictionary<int,string> entityGids = new Dictionary<int,string>();
    }

    /**[节日香桃节] 获取香桃节相亲对象(服务器返回)*/
    public class getFestivalPeachBlindDateResponse:MsgBase{
        /**相亲对象坐标:对象信息字典*/
        public Dictionary<int,PeachFestivalActorInfoList> entitys = new Dictionary<int,PeachFestivalActorInfoList>();
    }

    /**[节日香桃节] 表白相亲对象(客户端请求)*/
    public class festivalPeachConfessionRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**相亲者Gid*/
        public string entityGid = "";
        /**相亲对象Gid*/
        public string targetGid = "";
    }

    /**[节日香桃节] 表白相亲对象(服务器返回)*/
    public class festivalPeachConfessionResponse:MsgBase{
        /**回信id*/
        public int replyId = 0;
    }

    /**[节日] 祈祷增加全局特性(客户端请求)*/
    public class prayerAddPlayerSpecialityRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /***祈祷选项id */
        public int optionId = 0;
        /**祈祷效果*/
        public int optionEffect = 0;
    }

    /**[节日] 祈祷增加角色特性(客户端请求)*/
    public class prayerAddActorSpecialityRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**接受祈祷的角色唯一id数组*/
        public List<string> actorGidList = new List<string>();
        /***祈祷选项id */
        public int optionId = 0;
        /**祈祷效果*/
        public int optionEffect = 0;
    }

    /**[节日] 进入角斗日(客户端请求)*/
    public class enterWrestleFestivalRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**竞技场等级*/
        public int level = 0;
    }

    /**[节日] 进入角斗日(服务器返回)*/
    public class enterWrestleFestivalResponse:MsgBase{
        /**总战斗次数*/
        public int sum = 0;
        /**战斗序号:战斗id*/
        public Dictionary<int,int> battleIds = new Dictionary<int,int>();
    }

    /**[节日] 退出节日(客户端请求)*/
    public class exitFestivalRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[节日] 贸易兑换节兑换物资(客户端请求)*/
    public class tradeFestivalExchangeRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**兑换配置id*/
        public int exchangeId = 0;
        /**兑换数量*/
        public int count = 0;
    }

    /**[节日] 进入贸易兑换节(客户端请求)*/
    public class enterTradeFestivalRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[节日] 进入贸易兑换节(服务器返回)*/
    public class enterTradeFestivalResponse:MsgBase{
        /**兑换配置数量*/
        public Dictionary<int,int> exchangeItems = new Dictionary<int,int>();
    }

    /**改变账号所在城市点的某功能协议 */
    public class changeMapPointFuncTypeRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**地图唯一ID*/
        public string mapGid = "";
        /**城市点唯一ID */
        public int mapPointId = 0;
        /**功能ID */
        public int funcType = 0;
        /**改变状态类型,0进入,1退出*/
        public int changeStatus = 0;
    }

    /**[时间测试] 推进一个月时间 TODO后续删除(客户端请求)*/
    public class testTimeAddOneRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**月数*/
        public int count = 0;
    }

    /**[荣誉殿堂] 进入荣誉殿堂(客户端请求)*/
    public class enterTheHallOfHonorRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }
    /**[荣誉殿堂] 进入荣誉殿堂(客户端请求)*/
    public class enterTheHallOfHonorResponse:MsgBase{
        /**爵位等级冷却时间字典*/
        public Dictionary<int, int> cooldown = new Dictionary<int, int>();
    }

    /**[荣誉殿堂] 提升角色爵位(客户端请求)*/
    public class nobilityLevelUpRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一id*/
        public string actorGid = "";
        /**目标爵位等级*/
        public int level = 0;
    }

    /**[荣誉殿堂] 国家声望兑换友好度(客户端请求)*/
    public class countryPrestigeBuyFriendlyRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**使用的声望数量*/
        public int count = 0;
    }

    /**[经验池] 经验池给角色添加经验(客户端请求)*/
    public class actorAddExpByExpPondRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一ID*/
        public string actorGid = "";
        /**添加经验数量*/
        public int count = 0;
    }

    /**[角色] 解雇角色(客户端请求)*/
    public class firedActorRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一ID*/
        public string actorGid = "";
    }

    /**[酒馆招募] 钻石招募酒馆角色(客户端请求)*/
    public class specialRecruitTavernActorRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }

    /**[酒馆招募] 银币招募酒馆角色(客户端请求)*/
    public class recruitTavernActorRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一ID*/
        public string actorGid = "";
    }

    /**[酒馆招募] 银币刷新酒馆角色(客户端请求)*/
    public class refreshTavernActorsRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }
    /**[酒馆招募] 银币刷新酒馆角色(服务器返回)*/
    public class refreshTavernActorsResponse:MsgBase{
        /**账号唯一ID*/
        public List<TavernActorInfo> actorList = new List<TavernActorInfo>();
    }

    /**[酒馆招募] 获取酒馆角色(客户端请求)*/
    public class getTavernActorsRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
    }
    /**[酒馆招募] 获取酒馆角色(服务器返回)*/
    public class getTavernActorsResponse:MsgBase{
        /**账号唯一ID*/
        public List<TavernActorInfo> actorList = new List<TavernActorInfo>();
        /**酒馆刷新次数*/
        public int tavernRefreshCount = 0;
    }

    /**[商城购买] 购买商店物品 (客户端请求) */
    public class buyStoryItemRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**商店ID */
        public int shopId = 0;
        /**物品ID */
        public int itemId = 0;
        /**物品数量*/
        public int num = 0;
    }

    /**[商城购买] 购买商店物品 (服务器返回) */
    public class buyStoryItemResponse:MsgBase{
    }

    /**[商城出售物资] 出售商店物资物品 (客户端请求) */
    public class sellStoryItemRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**商店ID */
        public int shopId = 0;
        /**物品ID */
        public List<IntPair> itemList = new List<IntPair>();
        /**待出售装备GID列表*/
        public List<string> equipGidList = new List<string>();
    }

    /**[商城出售物资] 出售商店物资物品 (服务器返回) */
    public class sellStoryItemResponse:MsgBase{
    }

    /**[选定商会任务]选定商会任务（客户端请求）*/
    public class pickStoryTaskRequest:MsgBase {
        /**账号唯一ID*/
        public string accountGid = "";
        /**商店ID */
        public int shopId = 0;
        /**任务ID */
        public string listGid = "";
    }

    /**[选定商会任务]选定商会任务（服务端返回）*/
    public class pickStoryTaskResponse:MsgBase{
        public TaskInfo taskInfo = new TaskInfo();
    }

    /**[放弃商会任务]放弃商会任务（客户端请求）*/
    public class deleteChamberOfCommerceTaskRequest:MsgBase {
        /**账号唯一ID*/
        public string accountGid = "";
        /**商店ID */
        public int shopId = 0;
        /**任务GID */
        public string taskGid = "";
    }

    /**[放弃商会任务]放弃商会任务（服务端返回）*/
    public class deleteChamberOfCommerceTaskResponse:MsgBase{
        public string listGid = "";
    }

    /**[角色转职] 获取角色六维属性 (客户端请求) */
    public class getActorSixAttrsRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一id */
        public string actorGid = "";
    }

    /**[角色转职] 获取角色六维属性 (服务器返回) */
    public class getActorSixAttrsResponse:MsgBase{
        /** 角色的六位属性 */
        public Dictionary<int, float> attrs = new Dictionary<int, float>();
    }

    /**[角色转职] 改变角色职业 (客户端请求) */
    public class actorChangeJobRequest:MsgBase{
        /**账号唯一ID*/
        public string accountGid = "";
        /**角色唯一id */
        public string actorGid = "";
        /**职业id */
        public int jobId = 0;
    }

    /**[角色转职] 改变角色职业 (服务器返回) */
    public class actorChangeJobResponse:MsgBase{
        /**角色信息 */
        public Actor actorAgent = new Actor();
    }

    /**[邮件系统] 根据分页获取邮件 (客户端请求)*/
    public class getMailsByPageRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }
    /**[邮件系统] 根据分页获取邮件  (服务器返回) */
    public class getMailsByPageResponse:MsgBase{
        /**邮件简介列表 */
        public List<MailInfo> mailList = new List<MailInfo>();
    }

    /**[邮件系统] 一键删除已读邮件 （客户端请求）*/
    public class fastDeleteMailRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }
    /**[邮件系统] 一键删除已读邮件  (服务器返回) */
    public class fastDeleteMailResponse:MsgBase{
        /**邮件简介列表 */
        public List<MailInfo> mails = new List<MailInfo>();
        /**邮件总量 */
        public int sum = 0;
    }

    /**[邮件系统] 获取邮件详情 （客户端请求）*/
    public class getMailDetailRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**邮件唯一ID */
        public string mailGid = "";
    }
    /**[邮件系统] 获取邮件详情  (服务器返回) */
    public class getMailDetailResponse:MsgBase{
        /**邮件详细信息 */
        public MailInfo mail = new MailInfo();
    }

    /**[邮件系统] 领取指定邮件 （客户端请求）*/
    public class receiveMailRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**邮件唯一ID */
        public string mailGid = "";
    }
    /**[邮件系统] 领取指定邮件  (服务器返回) */
    public class receiveMailResponse:MsgBase{
        /**邮件 */
        public MailInfo mail = new MailInfo();
        /**获取道具信息*/
        public List<ItemInfo> itemInfos = new List<ItemInfo>();
        /**获取宝石信息 TODEL*/
        public List<ItemInfo> gemInfos = new List<ItemInfo>();
        /**获取装备信息 TODEL*/
        public List<Equipment> equipInfos = new List<Equipment>();
        /**过期附件列表*/
        public List<int> expirationInfos = new List<int>();
    }

    /**[邮件系统] 收取全部邮件 （客户端请求）*/
    public class receiveAllMailRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
    }
    /**[邮件系统] 收取全部邮件  (服务器返回) */
    public class receiveAllMailResponse:MsgBase{
        /**邮件简介列表 */
        public List<MailInfo> mails = new List<MailInfo>();
        /** 获取道具信息*/
        public List<ItemInfo> itemInfos = new List<ItemInfo>();
        /**获取宝石信息*/
        public List<ItemInfo> gemInfos = new List<ItemInfo>();
        /**获取装备信息*/
        public List<Equipment> equipInfos = new List<Equipment>();
        /**过期信息列表*/
        public List<MailExpirationInfo> expirationInfos = new List<MailExpirationInfo>();
    }
    /**[邮件系统] 删除邮件 （客户端请求）*/
    public class deleteMailRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**邮件唯一ID */
        public string mailGid = "";
    }
    /**[邮件系统] 删除邮件  (服务器返回) */
    public class deleteMailResponse:MsgBase{
        /**删除邮件的唯一id */
        public string mailGid = "";
    }

    /**[装备强化道具合成] 合成强化道具（客户端请求）*/
    public class syntheticEquipStrengthenItemRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /** 目标道具ID */
        public int itemId = 0;
        /** 目标合成数量 */
        public int count = 0;
    }

    /**[装备强化道具合成] 全部合成 （客户端请求）*/
    public class allSyntheticEquipStrengthenItemRequest:MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /** 目标道具ID */
        public int itemId = 0;
    }

    /**[装备] 重置宝石槽位 （客户端请求）*/
    public class resetGemSlotRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
        /**装备槽位Gid*/
        public string gemSlotGid = "";
    }

    /**[钻石] 增加钻石 （客户端请求）*/
    public class addZuanShiRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**银币数量 */
        public int addNum = 0;
    }

    /**[装备洗练] 确认洗炼结果保存到库 (客户端请求)*/
    public class saveRefinementRandomEquipAttrRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
        /**洗炼属性是否保存 1保存，0不保存 */
        public int isSave = 0;
    }

    /**[装备洗练] 装备洗练属性 (客户端请求)*/
    public class getRefinementRandomEquipAttrRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
    }
    /**[装备洗练] 装备洗练属性 (服务器返回) */
    public class getRefinementRandomEquipAttrResponse: MsgBase{
        /**已经洗练的次数 */
        public int randomNum = 0;
        /**当前装备主属性信息 */
        public Dictionary<int, int> attrs = new Dictionary<int, int>();
    }

    /**[装备附魔] 获取新随机附魔属性信息 (客户端请求)*/
    public class getRandomEnchantingInfoRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
    }
    /**[装备附魔] 获取新随机附魔属性信息 (服务器返回) */
    public class getRandomEnchantingInfoResponse: MsgBase{
        /**刷新附魔属性次数 */
        public int refreshEnchatNum = 0;
        /**剩余冷却时间 */
        public long coolingTime = 0;
        /**附魔信息 */
        public EquipEnchantingInfo equipEnchantingInfo = new EquipEnchantingInfo();
    }

    /**[装备附魔] 确定附魔属性到装备上 (客户端请求)*/
    public class useRandomEnchantingAttrRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
        /**提升成功率道具数量,0不使用 */
        public int addProCount = 0;
        /**使用保护道具,1使用,0不使用 */
        public int isPro = 0;
    }
    /**[装备附魔] 确定附魔属性到装备上 (服务器返回) */
    public class useRandomEnchantingAttrResponse: MsgBase{
        /**剩余冷却时间 */
        public long coolingTime = 0;
        /**附魔信息 */
        public EquipEnchantingInfo equipEnchantingInfo = new EquipEnchantingInfo();
        /**临时附魔信息 */
        public EquipEnchantingInfo temporaryEnchatingInfo = new EquipEnchantingInfo();
    }

    /**[宝石镶嵌] 装备镶嵌宝石（客户端请求）*/
    public class equipInlayGemRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备Gid */
        public string equipGid = "";
        /**宝石Gid */
        public string gemGid = "";
        /** 装备槽位Gid*/
        public string gemSlotGid = "";
    }

    /**[宝石合成] 彩色宝石合成（客户端请求）*/
    public class createColoredGemRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**宝石唯一ID */
        public List<string> gemGids = new List<string>();
        /**生成的数量 */
        public int count = 0;
    }

    /**[装备镶嵌宝石的槽位] 槽位升级（客户端请求）*/
    public class gemSlotUpLevelRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备唯一ID */
        public string equipGid = "";
        /**槽位唯一ID */
        public string slotGid = "";
        /**消耗提升成功率道具数量 */
        public int upRateCount = 0;
    }
    /**[装备镶嵌宝石的槽位] 槽位升级（服务器返回） */
    public class gemSlotUpLevelResponse: MsgBase{
        /**0失败, 1成功 */
        public int isSuccess = 0;
    }

    /**[宝石升级] 宝石升级（客户端请求）*/
    public class upGradeGemRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**宝石唯一ID */
        public string gemGid = "";
        /**生成的数量 */
        public int count = 0;
    }

    /**[背包] 使用道具（客户端请求）*/
    public class useBagItemRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**道具唯一ID */
        public string itemGid = "";
        /**使用数量 */
        public int count = 0;
    }

    /**[编队] 创建新编队（客户端请求）*/
    public class createNewTeamRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**编队名称 */
        public string teamName = "";
        /**编队ID */
        public int teamId = 0;
    }
    /**[编队] 创建新编队（服务器返回） */
    public class createNewTeamResponse: MsgBase{
        /**编队对象 */
        public BattleTeamInfo battleTeamInfo = new BattleTeamInfo();
    }

    /**[装备强化] 装备强化等级（客户端请求）*/
    public class equipStrengthenRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备唯一ID */
        public string equipGid = "";
        /**使用保护道具, 0不使用,1使用 */
        public int usePro = 0;
        /**消耗提升成功率道具数量 */
        public int upRateCount = 0;
    }
    /**[装备强化] 装备强化等级（服务器返回） */
    public class equipStrengthenResponse: MsgBase{
        /**0失败, 1成功(成功失败不返回任何东西) */
        public int isSuccess = 0;
    }

    /**[装备升品] 装备提升品质（客户端请求）*/
    public class equipUpPromoteRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**装备唯一ID */
        public string equipGid = "";
        /**消耗提升成功率道具数量 */
        public int upRateCount = 0;
    }
    /**[装备升品] 装备提升品质（服务器返回） */
    public class equipUpPromoteResponse: MsgBase{
        /**0失败, 1成功 */
        public int isSuccess = 0;
    }

    /**[货币] 增加银币 （客户端请求）*/
    public class addSilverRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**银币数量 */
        public int addNum = 0;
    }

    /**[装备]脱装备（客户端请求） */
    public class takeOffEquipRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**角色唯一ID */
        public string actorGid = "";
        /**要穿的装备唯一ID */
        public string equipGid = "";
    }

    /**[装备]穿/替换装备（客户端请求） */
    public class useEquipRequest: MsgBase{
        /**账号唯一ID */
        public string accountGid = "";
        /**角色唯一ID */
        public string actorGid = "";
        /**要穿的装备唯一ID */
        public string equipGid = "";
    }

    /**[装备]装备分解（客户端请求） */
    public class equipDecomposeRequest: MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //装备唯一ID列表
        public List<string> equipGidList = new List<string>();
    }

    /**[背包]删除道具 （客户端请求） */
    public class deleteBagItemRequest : MsgBase
    {
        //账号唯一ID
        public string accountGid = "";
        //道具ID
        public string itemGid = "";
        //道具数量
        public int count = 0;
    }

    /**[装备]添加装备 （客户端请求） */
    public class addEquipmentRequest : MsgBase
    {
        //账号唯一ID
        public string accountGid = "";
        //装备ID
        public int equipId = 0;
    }

    /**[背包]添加道具 （客户端请求） */
    public class addBagItemRequest : MsgBase
    {
        //账号唯一ID
        public string accountGid = "";
        //道具ID
        public int itemId = 0;
        //道具数量
        public int count = 0;
    }

    /**设置队员上阵、下阵（客户端发送） */
    public class setActorIsGoBattleRequest : MsgBase
    {
        //账号唯一ID
        public string accountGid = "";
        //卡牌唯一ID
        public string actorGid = "";
        //是上阵, 0 下阵, 1 上阵
        public int isGoBattle = 0;
    }
    /**设置队员上阵、下阵（服务器返回） */
    public class setActorIsGoBattleResponse : MsgBase
    {
        //卡牌唯一ID
        public string actorGid = "";
        //在新队伍中的位置
        public int newIndex = 0;
        //是否还在队伍中
        public int inTeam = 0;
        //是否上阵,0下阵,1上阵
        public int isGoBattle = 0;
        //返回上阵队员的唯一ID有序字符串
        public List<BattleTeamActorInfo> battleActorInfoList = new List<BattleTeamActorInfo>();
    }

    /** 招募队员 （客户端发送）*/
    public class getNewActorRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //连接服ID
        public string connId = "";
        //actor模板ID
        public int actorId = 0;
        //actor性别,0未知,1男,2女
        public int sex = 0;
    }

    /** 招募队员 （服务器返回）*/
    public class getNewActorResponse : MsgBase{
        public Actor newActor = new Actor();
        public List<Equipment> actorEquips = new List<Equipment>();
    }

    
    /** 战斗结束，玩家领取关卡奖励 (客户端发送) */
    public class getBattleRewardRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //关卡唯一ID
        public string levelGid = "";
    }
    /** 战斗结束，玩家领取关卡奖励 (服务器返回) */
    public class getBattleRewardResponse : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //战斗奖励数据
        public List<ItemInfo> reward = new List<ItemInfo>();
    }

    /** 进入游戏 (客户端发送) */
    public class enterGameRequest : MsgBase{
        //账号ID
        public string accountId = "";
    }
    /** 进入游戏 (服务器返回) */
    public class enterGameResponse : MsgBase{
        //player
        public Player player = new Player();
        public long serverTime = 0; //服务器真实时间
    }

    /**提取角色2级属性技能成技能道具 */
    public class getActorAttrChangeSkillItemRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //角色唯一ID
        public string actorGid = "";
        //技能ID
        public int skillId = 0;
    }

    /**给装备穿上/替换技能效果道具 */
    public class useSkillItemToEquipRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //装备唯一ID
        public string equipGid = "";
        //技能效果槽位下标
        public int index = 0;
        //道具唯一ID
        public string itemGid = "";
    }

    /**切换大地图和城市点协议 */
    public class changeMapPointInfoRequest : MsgBase{
        //账号唯一ID
        public string accountGid = "";
        //地图唯一ID
        public string mapGid = "";
        //城市点ID
        public int mapPointId = 0;
    }
        
    /** 获取指定城市的商会信息*/
    public class getChamberOfCommerceInfoByCityRequest: MsgBase {
        public string accountGid = "";
        public uint cityId = 0;
    }

    /** 获取指定城市的商会信息*/
    public class getChamberOfCommerceInfoByCityResponse: MsgBase {
        public ChamberOfCommerceInfo info = new ChamberOfCommerceInfo();
    }

    /**替换技能请求 skillId为-1的时候视为拆卸技能*/
    public class skillSlotUseSkillRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public int skillId = 0;
        public uint slotType = 0;
    }
    /**替换技能返回 skillId为-1的时候视为拆卸技能*/
    public class skillSlotUseSkillResponse: MsgBase {
    }

	/**获取城堡信息请求*/
    public class getPlayerModuleCastleInfoRequest: MsgBase {
        public string accountGid = "";
    }

    /**获取城堡信息返回*/
    public class getPlayerModuleCastleInfoResponse: MsgBase {
        public PlayerModuleCastle info = new PlayerModuleCastle();
    }

    /**升级城堡请求*/
    public class upCastleLvRequest: MsgBase {
        public string accountGid = "";
    }

    /**升级城堡返回*/
    public class upCastleLvResponse: MsgBase {
    }
    /**建造建筑请求*/
    public class buildArchitectureRequest: MsgBase {
        
        public string accountGid = "";
        public int architectureType = 0;
        public int slot = 0;
        public int slotType = 0;
    }
    /**建造建筑返回*/
    public class buildArchitectureResponse: MsgBase {
        public CastleArchitectureInfo info = new CastleArchitectureInfo();
    }
    /**拆除建筑请求*/
    public class dismantleArchitectureRequest: MsgBase {
        public string accountGid = "";
        public string architectureId = "";
    }
    /**拆除建筑返回*/
    public class dismantleArchitectureResponse: MsgBase {
    }
    /**领取建筑产出请求*/
    public class gainArchitectureProduceRequest: MsgBase {
        public string accountGid = "";
        public string architectureId = "";
    }
    /**领取建筑产出返回*/
    public class gainArchitectureProduceResponse: MsgBase {
    }
    /**领取所有建筑产出请求*/
    public class gainAllArchitectureProduceRequest: MsgBase {
        public string accountGid = "";
    }
    /**领取所有建筑产出返回*/
    public class gainAllArchitectureProduceResponse: MsgBase {
    }
    /**随机联姻对象请求*/
    public class randomAllianceTargetRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public string prestige = "";
    }
    /**随机联姻对象返回*/
    public class randomAllianceTargetResponse: MsgBase {
    }
    /**根据角色联姻对象随机获取介绍请求*/
    public class randomAllianceTargetIntroRequest: MsgBase {
        public string accountGid = "";
    }
    /**根据角色联姻对象随机获取介绍返回*/
    public class randomAllianceTargetIntroResponse: MsgBase {
        public Part partInfo = new Part();
        public string entityName = "";
        public List<int> introList = new List<int>();
    }
    /**确认提亲*/
    public class affirmAllianceRequest: MsgBase {
        public string accountGid = "";
    }
    /**确认提亲*/
    public class affirmAllianceResponse: MsgBase {
    }
    /**退出城堡联姻*/
    public class exitAllianceRequest: MsgBase {
        public string accountGid = "";
    }
    /**退出城堡联姻*/
    public class exitAllianceResponse: MsgBase {
    }

    /**接任务协议*/
    public class acceptTaskRequest: MsgBase {
        public string accountGid = "";//账号唯一ID
        public int taskId = 0;//任务ID
    }
    /**接任务协议*/
    public class acceptTaskResponse: MsgBase {
        public TaskInfo taskInfo = new TaskInfo();//接任务的数据信息
    }

    /**提交任务协议*/
    public class submitTaskRequest: MsgBase {
        public string accountGid = "";//账号唯一ID
        public string taskGid = "";//任务唯一ID
    }
    /**提交任务协议*/
    public class submitTaskResponse: MsgBase {
        public TaskInfo taskInfo = new TaskInfo();//提交任务的数据信息
    }
    /**举办城堡宴会请求*/
    public class castleFeastRunRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public int country = 0;
        public int area = 0;
        //是否从城堡商会补充缺少物资
        public int isReplenishGoods = 0;
    }
    /**举办城堡宴会返回*/
    public class castleFeastRunResponse: MsgBase {
        public List<CastleFeastTargetInfo> infoList = new List<CastleFeastTargetInfo>();
    }
    /**城堡宴会表白请求*/
    public class castleFeastRunConfessionRequest: MsgBase {
        public string accountGid = "";
        public string targetId = "";
    }
    /**城堡宴会表白返回*/
    public class castleFeastRunConfessionResponse: MsgBase {
        public int issueId = 0;
    }

    /**城堡宴会回答问题请求*/
    public class castleFeastReplyIssueRequest: MsgBase {
        public string accountGid = "";
    }

    /**城堡宴会回答问题返回*/
    public class castleFeastReplyIssueResponse: MsgBase {
        //目标的回答ID
        public int replyId = 0;
        //后续场景状态可使用的物资组ID 0为直接结束宴会 否则进入使用物资挽回阶段 
        public int issueId = 0;
        public float issuePro = 0.0f;
    }

    /**城堡宴会使用物资挽回对象请求*/
    public class castleFeastUseGoodsRetrieveRequest: MsgBase {
        public string accountGid = "";
        //使用的类型 0为取消 1为物资 2为钻石
        public int useType = 0;
        public List<IntPair> goodsList = new List<IntPair>();
    }
    /**城堡宴会使用物资挽回对象返回*/
    public class castleFeastUseGoodsRetrieveResponse: MsgBase {
    }
    /**城堡宴会退出请求*/
    public class castleFeastExitRequest: MsgBase {
        public string accountGid = "";
    }
    /**城堡宴会退出返回*/
    public class castleFeastExitResponse: MsgBase {
    }
    /**城堡建筑任命守卫请求*/
    public class castleAppointArchitectureGuardRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public string architectureId = "";
    }
    /**城堡建筑任命守卫返回*/
    public class castleAppointArchitectureGuardResponse: MsgBase {
        public CastleArchitectureInfo info = new CastleArchitectureInfo();
    }
    /**城堡建筑撤销守卫请求*/
    public class castleRevocationArchitectureGuardRequest: MsgBase {
        public string accountGid = "";
        public string architectureId = "";
    }
    /**城堡建筑撤销守卫返回*/
    public class castleRevocationArchitectureGuardResponse: MsgBase {
    }
    /**城堡建筑开启额外槽位返回*/
    public class castleArchitectureOpenExtraSlotRequest: MsgBase {
        public string accountGid = "";
    }
    /**城堡建筑开启额外槽位返回*/
    public class castleArchitectureOpenExtraSlotResponse: MsgBase {
    }
    /**城堡历练设置教师*/
    public class appointPracticeInstructorRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public int slot = 0;
        public int slotType = 0;
    }
    /**城堡历练设置教师*/
    public class appointPracticeInstructorResponse: MsgBase {
    }
    /**城堡历练撤销教师*/
    public class revocationPracticeInstructorRequest: MsgBase {
        public string accountGid = "";
        public int slot = 0;
        public int slotType = 0;
    }
    /**城堡历练撤销教师*/
    public class revocationPracticeInstructorResponse: MsgBase {
    }
    /**城堡历练设置学员*/
    public class appointPracticeStudentRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public int slot = 0;
        public int slotType = 0;
    }
    /**城堡历练设置学员*/
    public class appointPracticeStudentResponse: MsgBase {
    }
    /**城堡历练撤销学员*/
    public class revocationPracticeStudentRequest: MsgBase {
        public string accountGid = "";
        public int slot = 0;
        public int slotType = 0;
    }
    /**城堡历练撤销学员*/
    public class revocationPracticeStudentResponse: MsgBase {
    }
    /**城堡历练开始历练*/
    public class runPracticeRequest: MsgBase {
        public string accountGid = "";
        public int slot = 0;
        public int slotType = 0;
        public int practiceType = 0;
        public int targetPrestige = 0;
    }
    /**城堡历练开始历练*/
    public class runPracticeResponse: MsgBase {
        public CastlePracticeRunInfo info = new CastlePracticeRunInfo();
    }
    /**城堡历练终止历练*/
    public class terminatePracticeRequest: MsgBase {
        public string accountGid = "";
        public int slot = 0;
        public int slotType = 0;
    }
    /**城堡历练终止历练*/
    public class terminatePracticeResponse: MsgBase {
        public string studentGid = "";
        public int oldLv = 0;
        public int newLv = 0;
        public int oldExp = 0;
        public int newExp = 0;
        public List<IntPair> rewardList = new List<IntPair>();
        public Dictionary<int, IntPairList> randomEventList = new Dictionary<int, IntPairList>();
    }
    /**城堡历练开启额外历练位*/
    public class openExtraPracticeSlotRequest: MsgBase {
        public string accountGid = "";
    }
    /**城堡历练开启额外历练位*/
    public class openExtraPracticeSlotResponse: MsgBase {
    }
    /**城堡历练选择随机事件结果*/
    public class selectPracticeRandomEventOptionRequest: MsgBase {
        public string accountGid = "";
        public int slot = 0;
        public int slotType = 0;
        public int optionIndex = 0;
    }
    /**城堡历练选择随机事件结果*/
    public class selectPracticeRandomEventOptionResponse: MsgBase {
        public int replyId = 0;
        public List<IntPair> rewardList = new List<IntPair>();
    }
    /**城堡历练选择随机相亲结果*/
    public class selectPracticeRandomMarriageOptionRequest: MsgBase {
        public string accountGid = "";
        public int slot = 0;
        public int slotType = 0;
        public int optionIndex = 0;
    }
    /**城堡历练选择随机相亲结果*/
    public class selectPracticeRandomMarriageOptionResponse: MsgBase {
        public int replyId = 0;
    }
    /**[任务]任务超时放弃任务*/
    public class deleteTaskRequest: MsgBase{
        public string accountGid = "";//账号唯一ID
        public string taskGid = "";//任务唯一ID
    }
    /**城堡学校传授技能*/
    public class castleImpartSkillRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
        public string studentGid = "";
        public string instructorGid = "";
        public int skillId = 0;
    }
    /**城堡学校传授技能*/
    public class castleImpartSkillResponse: MsgBase {
        //是否成功学习技能
        public int isAddSkill = 0;
    }
    /**城堡商会获取商会道具列表*/
    public class getCastleChamberOfCommerceGoodsRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
    }
    /**城堡商会获取商会道具列表*/
    public class getCastleChamberOfCommerceGoodsResponse: MsgBase {
        public List<ChamberOfCommerceGoodsInfo> goodsList = new List<ChamberOfCommerceGoodsInfo>();
    }
    /**城堡商会购买道具*/
    public class buyCastleGoodsRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
        public List<IntPair> itemList = new List<IntPair>();
    }
    /**城堡商会购买道具*/
    public class buyCastleGoodsResponse: MsgBase {
    }
    /**城堡商会获取大陆资源菜单*/
    public class getCastleChamberOfCommerceGoodsMenuRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
    }
    /**城堡商会获取大陆资源菜单*/
    public class getCastleChamberOfCommerceGoodsMenuResponse: MsgBase {
        public List<CastleChamberOfCommerceGoodsMenu> menuList = new List<CastleChamberOfCommerceGoodsMenu>();
    }
    /**城堡学校设置教师*/
    public class appointSchoolInstructorRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
        public string entityGid = "";
        public int slot = 0;
    }
    /**城堡学校设置教师*/
    public class appointSchoolInstructorResponse: MsgBase {
    }
    /**城堡学校卸任教师*/
    public class revocationSchoolInstructorRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
        public int slot = 0;
    }
    /**城堡学校卸任教师*/
    public class revocationSchoolInstructorResponse: MsgBase {
    }
    /**城堡学校设置重点学生*/
    public class addSchoolEmphasisStudentRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
        public string entityGid = "";
        public int slot = 0;
    }
    /**城堡学校设置重点学生*/
    public class addSchoolEmphasisStudentResponse: MsgBase {
    }
    /**城堡学校卸下重点学生*/
    public class revocationSchoolEmphasisStudentRequest: MsgBase {
        //账号唯一ID
        public string accountGid = "";
        public int slot = 0;
    }
    /**城堡学校卸下重点学生*/
    public class revocationSchoolEmphasisStudentResponse: MsgBase {
    }
    /**进行婚宴*/
    public class runWeddingRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
        public int level = 0;
        //伴郎伴娘GID组
        public List<string> attendant = new List<string>();
        //花童GID组
        public List<string> student = new List<string>();
        //捧花人员GID组
        public List<string> bouquet = new List<string>();
    }

    /**进行婚宴*/
    public class runWeddingResponse: MsgBase {
        public List<IntPair> rewardList = new List<IntPair>();
        public string bouquetGid = "";
    }
    /**领取成就目标任务奖励协议 */
    public class getPlayerTargetAttainmentReward: MsgBase {
        public string accountGid = "";
        public int isAll = 0;//0不全部领取奖励,id 目标数据ID.1全部领取奖励,id = 0 
        public int id = 0;//0不全部领取奖励,id 目标数据ID.1全部领取奖励,id = 0 
    }
    /**保存编队预设*/
    public class saveTeamPresetRequest: MsgBase {
        public string accountGid = "";
        public string name = "";
        public int teamId = 0;
    }

    /**保存编队预设*/
    public class saveTeamPresetResponse: MsgBase {
        public BattleTeamInfo info = new BattleTeamInfo();
    }

    /**使用编队预设*/
    public class useTeamPresetRequest: MsgBase {
        public string accountGid = "";
        public int teamId = 0;
    }
    
    /**使用编队预设*/
    public class useTeamPresetResponse: MsgBase {
        public Dictionary<string, List<int>> showCode = new Dictionary<string, List<int>>();
        public BattleTeamInfo info = new BattleTeamInfo();
    }

    /**确认城堡相亲结果*/
    public class affirmCastleAllianceResultRequest: MsgBase {
        public string accountGid = "";
        public int type = 0;
        public string entityGid = "";
    }

    /**确认城堡相亲结果*/
    public class affirmCastleAllianceResultResponse: MsgBase {
    }
    
    /**[广场] 点击某诚实点广场的NPC */
    public class clickMapPointFunctionNpcRequest: MsgBase {
        public string accountGid = "";
        public int npcId = 0;//npc的ID
    }
    public class clickMapPointFunctionNpcResponse: MsgBase {
        public int dialogId = 0;//对话ID
    }
    
    /**[广场]领取对话中奖励协议*/
    public class getDialogRewardRequest: MsgBase {
        public string accountGid = "";
        public int dialogId = 0;//对话ID
        public int index = 0;//奖励下标

    }
    /**[广场]对话结束*/
    public class closeNpcDialogGetRewardRequest: MsgBase {
        public string accountGid = "";
        public int dialogId = 0;//对话ID
    }
    /**理发店进行理发*/
    public class runBarberRequest: MsgBase {
        public string accountGid = "";
        public string actorGid = "";
        public List<int> partIdList = new List<int>();
    }
    /**理发店进行理发*/
    public class runBarberResponse: MsgBase {
    }
    /**伤病进行治疗*/
    public class cureInjuryRequest: MsgBase {
        public string accountGid = "";
        public string actorGid = "";
        public int injuryId = 0;
        public int useItemNum = 0; 
    }
    /**伤病进行治疗*/
    public class cureInjuryResponse: MsgBase {
    }
    /**伤病进行全员治疗*/
    public class allActorCureInjuryRequest: MsgBase {
        public string accountGid = "";
        public int cureItemId = 0; 
    }
    /**伤病进行全员治疗*/
    public class allActorCureInjuryResponse: MsgBase {
    }
    /**[城堡委托派遣] 获取委托任务列表*/
    public class getEntrustTaskListRequest: MsgBase {
        public string accountGid = "";
    }
    public class getEntrustTaskListResponse: MsgBase {
        public List<EntrustInfo> entrustTaskList = new List<EntrustInfo>();
    }
    /**[城堡委托派遣] 选择一个委托任务派遣六名角色去执行*/
    public class entrustActorCompleteTaskRequest: MsgBase {
        public string accountGid = "";
        public string entrustGid = "";//委托任务唯一ID
        public List<string> actorGids = new List<string>();//选择的角色唯一ID列表
    }
    /**[城堡委托派遣] 刷新未接取的委托任务列表*/
    public class refreshEntrustTaskListRequest: MsgBase {
        public string accountGid = "";
    }
    public class refreshEntrustTaskListResponse: MsgBase {
        public List<EntrustInfo> entrustTaskList = new List<EntrustInfo>();
    }
    /**[城堡委托派遣] 领取完成委托任务奖励*/
    public class getCompleteEntrustTaskRewardRequest: MsgBase {
        public string accountGid = "";
        public string entrustGid = "";//委托任务唯一ID
    }
    /**[城堡委托派遣]-购买今日接任务的次数 */
    public class buyCurrDayAcceptWeiTuoTaskCountRequest: MsgBase {
        public string accountGid = "";
    }
    public class buyCurrDayAcceptWeiTuoTaskCountResponse: MsgBase {
        public int buyAcceptCount = 0;//今日购买接任务次数的次数
        public int buyAcceptTime = 0;//上次购买接任务次数的时间
    }
    /**获取钻石商店数据*/
    public class getDiamondShopInfoRequest: MsgBase {
        public string accountGid = "";
    }
    /**获取钻石商店数据*/
    public class getDiamondShopInfoResponse: MsgBase {
        public Dictionary<int, int> buyNumHash = new Dictionary<int, int>();
        public DiamondShopInfo info = new DiamondShopInfo();
    }
    /**钻石商店购买商品*/
    public class buyGoodsOfDiamondShopRequest: MsgBase {
        public string accountGid = "";
        public List<IntPair> randomGoodsList = new List<IntPair>();
        public List<IntPair> shopCycleGoodsList = new List<IntPair>();
    }
    /**钻石商店购买商品*/
    public class buyGoodsOfDiamondShopResponse: MsgBase {
    }
    /**[主线、支线任务] 结束上一个剧情*/
    public class stopLastStoryRequest: MsgBase{
        public string accountGid = "";
        public string taskGid = "";//任务唯一ID
    }
    
    /**获取玩家竞技场数据*/
    public class getPlayerArenaInfoRequest: MsgBase {
        public string accountGid = "";
    }
    /**获取玩家竞技场数据*/
    public class getPlayerArenaInfoResponse: MsgBase {
        public List<int> buffList = new List<int>();
        public int useBattleNum = 0;
        public int buyBattleNum = 0;
        public List<int> gainBattleNumPrizeLv = new List<int>();
        public int curScore = 0;
        public int curIndex = 0;
        public int seasonBattleNum = 0;
        public int lastGainArenaLvPrize = 0;
        public int winNum = 0;
    }
    /**获取玩家战报*/
    public class getPlayerArenaBattleRecordRequest: MsgBase {
        public string accountGid = "";
        public int start = 0;
        public int num = 0;
    }
    /**获取玩家战报*/
    public class getPlayerArenaBattleRecordResponse: MsgBase {
        public List<ArenaRecordInfo> list = new List<ArenaRecordInfo>();
    }
    /**领取赛季战斗总次数奖励*/
    public class gainArenaSeasonBattleNumPrizeRequest: MsgBase {
        public string accountGid = "";
        public int targetLv = 0;
    }
    /**领取赛季战斗总次数奖励*/
    public class gainArenaSeasonBattleNumPrizeResponse: MsgBase {
    }
    /**领取晋级奖励*/
    public class gainArenaRankLvPrizeRequest: MsgBase {
        public string accountGid = "";
    }
    /**领取晋级奖励*/
    public class gainArenaRankLvPrizeResponse: MsgBase {
    }
    /**进行竞技场匹配*/
    public class arenaRunMatchRequest: MsgBase {
        public string accountGid = "";
    }
    /**进行竞技场匹配*/
    public class arenaRunMatchResponse: MsgBase {
    }
    /**购买竞技场战斗次数*/
    public class buyArenaBattleNumRequest: MsgBase {
        public string accountGid = "";
        public int num = 0;
    }
    /**购买竞技场战斗次数*/
    public class buyArenaBattleNumResponse: MsgBase {
    }
    /**将成年角色加入军团*/
    public class adultActorJoinCorpsRequest: MsgBase {
        public string accountGid = "";
        public string entityGid = "";
    }
    /**将成年角色加入军团*/
    public class adultActorJoinCorpsResponse: MsgBase {
    }
    
    /**账号登录成功后客户端主动获取当前主线剧情协议 */
    public class accountLoginOkGetTaskMainInfoRequest : MsgBase{
        public string accountGid = "";
    }
	/**获取前三席位数据*/
    public class getArenaSeatListInfoRequest: MsgBase {
        public string accountGid = "";
    }
    /**获取前三席位数据*/
    public class getArenaSeatListInfoResponse: MsgBase {
        public List<StrPair> list = new List<StrPair>();
    }
    /**新增获取战斗点任务列表协议 */
    public class getBattlePointTaskGidsRequest : MsgBase{
        public string accountGid = "";
        public string pointGid = "";
    }
	/**[组队副本]获取玩家组队副本模式数据*/
    public class getTeamBattleInfoRequest: MsgBase {
        public string accountGid = "";
    }
    /**[组队副本]获取玩家组队副本模式数据*/
    public class getTeamBattleInfoResponse: MsgBase {
		public List<int> enterLevelIdList = new List<int>();
    }
	/**[组队副本]获取玩家组队副本指定副本队伍数据*/
    public class getTeamBattleCopyInfoRequest: MsgBase {
        public string accountGid = "";
		public int levelId = 0;
    }
    /**[组队副本]获取玩家组队副本指定副本队伍数据*/
    public class getTeamBattleCopyInfoResponse: MsgBase {
		public string id = "";
		public int country = 0;
		public int level = 0;
		public int createIndex = 0;
		public List<TeamBattleCopyInfo> copyInfoList = new List<TeamBattleCopyInfo>();
    }
	/**[组队副本]购买组队副本进入次数*/
    public class BuyTeamBattleEntryNumRequest: MsgBase {
        public string accountGid = "";
		public int country = 0;
		public int level = 0;
    }
    /**[组队副本]购买组队副本进入次数*/
    public class BuyTeamBattleEntryNumResponse: MsgBase {
		
    }
	/**[组队副本]创建副本组队伍*/
    public class CreateTeamBattleGroupRequest: MsgBase {
        public string accountGid = "";
		public int enterType = 0;
		public int country = 0;
		public int level = 0;
    }
    /**[组队副本]创建副本组队伍*/
    public class CreateTeamBattleGroupResponse: MsgBase {
		public string id = "";
		public int country = 0;
		public int level = 0;
		public int createIndex = 0;
		public List<TeamBattleCopyInfo> copyInfoList = new List<TeamBattleCopyInfo>();
    }
	/**[组队副本]匹配进入队伍*/
    public class MatchTeamBattleGroupRequest: MsgBase {
        public string accountGid = "";
		public int enterType = 0;
		public int country = 0;
		public int level = 0;
    }
    /**[组队副本]匹配进入队伍*/
    public class MatchTeamBattleGroupResponse: MsgBase {
		public string id = "";
		public int country = 0;
		public int level = 0;
		public int createIndex = 0;
		public List<TeamBattleCopyInfo> copyInfoList = new List<TeamBattleCopyInfo>();
    }
	/**[组队副本]进入指定队伍*/
    public class EntryTargetTeamBattleGroupRequest: MsgBase {
        public string accountGid = "";
		public string groupId = "";
		public int enterType = 0;
    }
    /**[组队副本]进入指定队伍*/
    public class EntryTargetTeamBattleGroupResponse: MsgBase {
		public string id = "";
		public int country = 0;
		public int level = 0;
		public int createIndex = 0;
		public List<TeamBattleCopyInfo> copyInfoList = new List<TeamBattleCopyInfo>();
    }
	/**[组队副本]根据队伍ID获取队伍信息*/
    public class getTeamBattleCopyGroupInfoRequest: MsgBase {
        public string accountGid = "";
		public string groupId = "";
    }
    /**[组队副本]根据队伍ID获取队伍信息*/
    public class getTeamBattleCopyGroupInfoResponse: MsgBase {
		public string id = "";
		public int country = 0;
		public int level = 0;
		public int createIndex = 0;
		public List<TeamBattleCopyInfo> copyInfoList = new List<TeamBattleCopyInfo>();
    }

}