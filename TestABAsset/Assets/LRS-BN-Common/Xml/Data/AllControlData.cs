using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AllControlData : BaseDataObject
    {
        
		public int adult = 0;	//成人年龄
		public int retireAgeMale = 0;	//退休年龄（男）
		public int retireAgeFemale = 0;	//退休年龄(女)
		public int lifeSpanMale = 0;	//最大寿命（男）
		public int lifeSpanFemale = 0;	//最大寿命（女）
		public int childbearingAgeMale = 0;	//最大怀孕年龄(男)
		public int childbearingAgeFemale = 0;	//最大怀孕年龄(女)
		public int bagMax = 0;	//背包最大格子数
		public int bagMaxSP = 0;	//背包最大叠加数
		public int silverCoinMax = 0;	//玩家银币显示上限
		public int diamondMax = 0;	//玩家钻石显示上限
		public int prestigeMax = 0;	//声望上限
		public int friendlinessMax = 0;	//友好度上限
		public string moraleMax = "";	//士气上限
		public int minValue = 0;	//强化单次最小值
		public int teamSize = 0;	//队伍人数上限
		public int mvp = 0;	//MVP系数
		public float perToMAtk = 0;	//感知转换魔攻
		public float strToPAtk = 0;	//力量转换物攻
		public int dexToPHit = 0;	//技巧转换物理命中
		public int dexToPCri = 0;	//技巧转换物理暴击
		public int wilToMCri = 0;	//感知转换魔法暴击
		public int dexToBlk = 0;	//技巧转换格挡概率
		public int dexToPry = 0;	//技巧转换架招概率
		public int bAgiToPDCri = 0;	//真实敏捷转换物理暴击抵扣系数
		public int agiToIgnoreDef = 0;	//真实敏捷转换物防忽略概率
		public int wilToMHit = 0;	//意志转换魔法命中
		public int wilToMDCri = 0;	//意志转换魔法暴击抵扣系数
		public float vitToHp = 0;	//体质转换生命值上限
		public int vitToWgt = 0;	//体质转换理想负重上限
		public int overWgtToAgi = 0;	//溢出理论负重上限的负重量转换真实敏捷惩罚
		public int agiToWgt = 0;	//实际负重量转换真实敏捷惩罚
		public float wAtkToPryDef = 0;	//武器攻击力转换招架防御值
		public float perToHeal = 0;	//感知转换受到的额外治疗值
		public int pCriDmg = 0;	//基础物理暴击伤害系数
		public int mCriDmg = 0;	//基础魔法暴击伤害系数
		public int pDevDmg = 0;	//基础物理偏斜减伤系数
		public int mDevDmg = 0;	//基础魔法偏斜减伤系数
		public int maxPDevDmg = 0;	//最高物理偏斜减伤系数
		public int baseWgt = 0;	//基础负重量
		public int baseAp = 0;	//基础AP上限
		public int baseMovN = 0;	//基础移动次数
		public int baseAtkN = 0;	//基础攻击次数
		public int baseActN = 0;	//基础行动次数
		public int basicCoolPirce = 0;	//附魔冷却基础价格
		public int nextFreeRefresh = 0;	//附魔刷新冷却时间
		public int playerMailLimit = 0;	//玩家邮箱上限
		public int maxMailSave = 0;	//邮件最大保存期
		public float transferPro = 0;	//非特产国家系数
		public string runBusinessRefresh = "";	//跑商任务刷新时间
		public string goodsRefreshTime = "";	//物资刷新时间
		public string tavernRefreshTime = "";	//酒馆刷新时间
		public int initialMorale = 0;	//初始士气
		public int queryGoodsPrice = 0;	//价格查询
		public int collectMonth = 0;	//收取封地建筑月份
		public string addBuildingPrice = "";	//额外封地建筑价格
		public string equipQualityCoefficient = "";	//装备品质系数
		public string skillCoefficient = "";	//附加技能系数
		public int basicEngagementPro = 0;	//爵位相同基础相亲概率
		public int basicEngagementPro_1 = 0;	//爵位大1基础相亲概率
		public int engagementRefreshTime = 0;	//相亲刷新月份
		public int engagementMinNobility = 0;	//参加相亲最低爵位
		public int banquetMinNobility = 0;	//参加宴会最低爵位
		public int banquetUnlockAreaNobility = 0;	//宴会解锁地区的爵位等级
		public string banquetRoyalBloodNum = "";	//宴会指定地区的主血脉人数
		public int banquetInterval = 0;	//宴会举办间隔时间
		public int banquetActorNum = 0;	//宴会相亲对象人数
		public int matchmakerID = 0;	//相亲媒人ID
		public string noneActorCha = "";	//相亲人员不出现特性
		public string cityTaskRefreshTime = "";	//城镇任务刷新时间
		public int runBusnessNPC_ID = 0;	//跑商NPCID
		public int cooltime = 0;	//领取冷却间隔
		public float recruitMale = 0;	//招募性别系数男
		public float recruitFemale = 0;	//招募性别系数女
		public int silverCoinRecruitC = 0;	//银币招募常数
		public int jobs = 0;	//新出生角色初始职业
		public int actorLevel = 0;	//初始等级
		public float jobCoefficient = 0;	//历练获取经验职业系数
		public string experiencePositionPrice = "";	//历练额外位置价格
		public int studentAgetMin = 0;	//学员最小年龄
		public int levelDifferenceMin = 0;	//历练师徒最小等级差值
		public int teacherLevelMin = 0;	//历练教官最低等级
		public int experience1Price = 0;	//短期历练银币花费
		public int experience2Price = 0;	//长期历练银币花费
		public string experience1Month = "";	//短期历练月份范围
		public string experience1MonthPro = "";	//短期历练月份随机概率
		public string experience2Month = "";	//短期历练月份范围
		public string experience2MonthPro = "";	//短期历练月份随机概率
		public int transforF_P = 0;	//友好度声望转化比
		public string consumeType = "";	//消耗品物品类型
		public string otherType = "";	//其他物品类型
		public int teachLevel = 0;	//传授教官最低等级
		public int teacherAgeMin = 0;	//学校教师最低年龄
		public string noTeachJobID = "";	//不可传授职业id
		public string teachAdditionalSpend = "";	//传授额外花费
		public string schoolAge = "";	//学校重点培养出现年龄
		public int teacherWage = 0;	//教师维护费用
		public int tuition = 0;	//学费每月价格
		public int studyChaMax = 0;	//学校学习特性数量上限
		public string yuyingtingPrice = "";	//育鹰厅建造价格
		public int keyTrainingRate = 0;	//重点培养成功率加成
		public int banquetPropSuccessMax = 0;	//宴会道具成功率使用上限
		public string flowerGirlsAge = "";	//婚宴花童年龄范围
		public int serverDailyRefresh = 0;	//每日服务器刷新时间
		public int flowerGirlsStudyNum = 0;	//花童最多可学特性数量
		public int weddingNum = 0;	//参加婚礼抢捧花人数
		public string itemType = "";	//物品增加通知提示类型
		public string renamePrice = "";	//佣兵团改名费用
		public string flagPrice = "";	//变更旗帜费用
		public int engagementActorJob = 0;	//相亲对象初始职业
		public int actorOnMonth = 0;	//角色任职最短时间
		public string changerPrice = "";	//变更岗位花费
		public int actorChaMAX = 0;	//角色最大永久特性数量（不计学校获得）
		public string generalChaNum = "";	//通用特性初始数量随机
		public int descentChaMaxType = 0;	//种族专属特性最大种类
		public int countryChaRandomRate = 0;	//国家特性随机概率
		public int legionNameMax = 0;	//佣兵团名称最长字符
		public int actorNameMax = 0;	//角色名称最长字符
		public int growOld1 = 0;	//衰老年龄1
		public int growOld2 = 0;	//衰老年龄2
		public int randomChaRate = 0;	//混血随机特性概率
		public int legionNameMin = 0;	//佣兵团名称最少字符
		public int actorNameMin = 0;	//角色名称最少字符
		public int moraleDifference = 0;	//士气真实值与显示值的差值
		public int wageSettlementTime = 0;	//军团工资结算时间
		public int sacredEffectRefresh = 0;	//军团圣物效果刷新价格
		public int unboundPrice = 0;	//圣物解绑价格
		public string sacredTransforConsume = "";	//军团圣物转换消耗
		public int sacredPositionMinID = 0;	//军团圣物装备所需最低职位
		public string noTransforEquipType = "";	//不可转化圣物的装备类型
		public string sacredEffectRandom = "";	//圣物效果数量随机
		public int moraleDiminishingMonth = 0;	//士气递减封顶月数
		public int shengling = 0;	//神令每日免费领取数量
		public int saodangjuan = 0;	//扫荡劵每日免费领取数量
		public int spiritCoolTime = 0;	//精神创伤冷却期
		public int worsenInjuryID = 0;	//恶化伤病ID
		public int triggerMoraleDiminishing = 0;	//军团士气递减触发月数
		public int legionBuffLevel = 0;	//初始军团技能等级
		public int injuryOpenJudgeMonth = 0;	//生病启动后判定月份
		public int contagionAnnuallyAddPro = 0;	//疾病爆发每年提高概率
		public int contagionNumPro = 0;	//疾病爆发数占总人口比
		public int legionBuffLevelMax = 0;	//军团技能最大等级
		public string triggerInjuryTaskType = "";	//触发战斗伤的任务类型
		public int battleInjuryRate = 0;	//战斗中被击倒的受伤概率
		public int actorJoinMonth = 0;	//角色入队满月份提需求
		public int actorDemandJudgeMonth = 0;	//每年角色需求判断月份
		public int actorDemandRate = 0;	//角色需求触发人数占入团总人数万分比
		public int actorDemandMaxNum = 0;	//触发角色个人需求最大人数上限
		public int juvenilesDeathRate = 0;	//未成年人夭折基础概率
		public int actorDemandCoolMonth = 0;	//个人需求冷却期
		public int legionPositionMonth = 0;	//军团职位收费月份
		public int unsatisfiedAddWeight = 0;	//未满足需求追加权重值
		public string bonusRandomRange = "";	//需求奖金系数随机范围
		public int demandInitialWeight = 0;	//每种需求的初始权重
		public int ageDifference = 0;	//年龄差值常数
		public int goodDemandOpenMonth = 0;	//物资需求系数启动月数
		public int fixedGoodMonth = 0;	//固定物资服役月数值
		public int unfixedGoodMonth = 0;	//非固定物资服役月数值
		public int actorNegativeRate = 0;	//角色获得负面特性概率
		public int actorNegativeAddRate = 0;	//角色获得负面特性追加概率
		public int taskEntrusPeopleNum = 0;	//委托任务执行人数
		public int entrusCaptainAge = 0;	//委托小队队长年龄
		public string entrusCaptainJobLevel = "";	//队长职业要求
		public int mainLastTaskID = 0;	//主线最后任务ID
		public int taskEntrusRefreshPrice = 0;	//委托任务刷新钻石数
		public string taskEntrusRefreshTime = "";	//委托任务刷新时间
		public int freeRefreshCoolTime = 0;	//委托任务免费刷新间隔时间
		public int doneBasicPrice = 0;	//委托任务立即完成单月钻石基数
		public int pregnantTimeMax = 0;	//最大怀孕次数
		public int pregnantCoolMonth = 0;	//怀孕间隔月数
		public int birthMonth = 0;	//生育所需月数
		public int girlRate = 0;	//生女孩的概率
		public string chaUnknownDes = "";	//特性状态“未知”描述
		public int labelDisplayBloodRate = 0;	//标签显示要求血脉比例
		public int replyBasicRate = 0;	//征兵基础回信概率
		public int replyMonth = 0;	//回信冷却月份
		public string replyMonthMax = "";	//回信随机月范围
		public int singleAddRate = 0;	//每多一个角色回信增加值
		public int replyRateMax = 0;	//最大征兵回信概率
		public string giftBagRandomRange = "";	//商店礼包折扣随机范围
		public string goodsRandomRange = "";	//商店特产折扣随机范围
		public int discountRateMin = 0;	//折扣率最小变化值
		public string sundayCountryID = "";	//周日特产国家
		public string seasonStartTime = "";	//赛季开始时间
		public string seasonEndTime = "";	//赛季结束时间
		public int entrustBuyPrice = 0;	//委托任务钻石购买价格
		public int entrustFreeRefreshTime = 0;	//委托任务每日免费刷新次数
		public int brithRate = 0;	//双胞胎概率
		public string firstChildIcon = "";	//第一个孩子标识
		public string secondChildIcon = "";	//第二个孩子标识
		public int rankPeopleNum = 0;	//战力榜单团上榜人数
		public int entrustRewardMail = 0;	//委托奖励邮件ID
		public string speedConfig = "";	//角色升级进度条配置
		public string noFamilyText = "";	//无家族成员提示
		public int arenaTimePrice = 0;	//竞技场次数购买价格
		public int rankRewardMail = 0;	//排行榜奖励邮件ID
		public int initialTaskMain = 0;	//初始主线任务ID
		public int oldChaID = 0;	//衰老特性ID
		public int juvenilesDeathOpenMonth = 0;	//未成年人夭折判定开始月份
		public int juvenilesDeathCycle = 0;	//夭折判定周期月份
		public int seriouslyHpLimit = 0;	//重伤HP界限
		public int dyingHpLimit = 0;	//濒死HP界限
		public string arenaWeeklyST = "";	//竞技场周礼包结算时间
		public int arenaMailID = 0;	//竞技场奖励邮件ID
		public string juvenilesDeathMailID = "";	//夭折邮件id
		public string teamBattlePlayerNum = "";	//组队副本人数
		public int signVipLeve = 0;	//连续签到VIP等级
		public string radomBastcHpRanger = "";	//随机基础hp范围
		public string randomBirthSixD = "";	//六维出生随机值
		public int singelBattleDailyTimes = 0;	//单个副本每日参与次数
		public int mainBattleTimes = 0;	//主线副本挑战次数
		public int branchBattleTimes = 0;	//支线副本挑战次数
		public string teamBattleBuyTimesPrice = "";	//组队副本购买挑战次数价格
		public int teamBattleFullTips = 0;	//组队副本人员已满提示
		public int teamBattleRewardMailID = 0;	//组队副本奖励邮件ID
		public int exchangeCode = 0;	//兑换码邮件模板id
		public int unlockClimbTower = 0;	//爬塔解锁友好度等级
		public int resetClimbTowerType = 0;	//爬塔重置类型
		public int climbTowerNPCid = 0;	//爬塔NpcID
		public int climbTowerShopRandomNum = 0;	//爬塔商店随机商品掉落个数
		public string specialJobsID = "";	//特殊职业id
		public string climbTowerDoneDialog = "";	//爬塔答题未完成对话
		public string climbTowerIncompleteDialog = "";	//爬塔答题已完成对话
		public int climbTowerCloseTipsID = 0;	//爬塔跨周期提示文本
		public int clmibTowerCompensateMailSendTime = 0;	//爬塔赛季结束自动补偿结算时间
		public int clmibTowerCompensateMailID = 0;	//爬塔补偿邮件ID
		public string clmibTowerGetCardTips = "";	//爬塔获取卡牌文本
		public string weeklyResetTime = "";	//每周数据重置时间
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			adult = br.ReadInt32();	//成人年龄
			retireAgeMale = br.ReadInt32();	//退休年龄（男）
			retireAgeFemale = br.ReadInt32();	//退休年龄(女)
			lifeSpanMale = br.ReadInt32();	//最大寿命（男）
			lifeSpanFemale = br.ReadInt32();	//最大寿命（女）
			childbearingAgeMale = br.ReadInt32();	//最大怀孕年龄(男)
			childbearingAgeFemale = br.ReadInt32();	//最大怀孕年龄(女)
			bagMax = br.ReadInt32();	//背包最大格子数
			bagMaxSP = br.ReadInt32();	//背包最大叠加数
			silverCoinMax = br.ReadInt32();	//玩家银币显示上限
			diamondMax = br.ReadInt32();	//玩家钻石显示上限
			prestigeMax = br.ReadInt32();	//声望上限
			friendlinessMax = br.ReadInt32();	//友好度上限
			moraleMax = br.ReadString();	//士气上限
			minValue = br.ReadInt32();	//强化单次最小值
			teamSize = br.ReadInt32();	//队伍人数上限
			mvp = br.ReadInt32();	//MVP系数
			perToMAtk = br.ReadSingle();	//感知转换魔攻
			strToPAtk = br.ReadSingle();	//力量转换物攻
			dexToPHit = br.ReadInt32();	//技巧转换物理命中
			dexToPCri = br.ReadInt32();	//技巧转换物理暴击
			wilToMCri = br.ReadInt32();	//感知转换魔法暴击
			dexToBlk = br.ReadInt32();	//技巧转换格挡概率
			dexToPry = br.ReadInt32();	//技巧转换架招概率
			bAgiToPDCri = br.ReadInt32();	//真实敏捷转换物理暴击抵扣系数
			agiToIgnoreDef = br.ReadInt32();	//真实敏捷转换物防忽略概率
			wilToMHit = br.ReadInt32();	//意志转换魔法命中
			wilToMDCri = br.ReadInt32();	//意志转换魔法暴击抵扣系数
			vitToHp = br.ReadSingle();	//体质转换生命值上限
			vitToWgt = br.ReadInt32();	//体质转换理想负重上限
			overWgtToAgi = br.ReadInt32();	//溢出理论负重上限的负重量转换真实敏捷惩罚
			agiToWgt = br.ReadInt32();	//实际负重量转换真实敏捷惩罚
			wAtkToPryDef = br.ReadSingle();	//武器攻击力转换招架防御值
			perToHeal = br.ReadSingle();	//感知转换受到的额外治疗值
			pCriDmg = br.ReadInt32();	//基础物理暴击伤害系数
			mCriDmg = br.ReadInt32();	//基础魔法暴击伤害系数
			pDevDmg = br.ReadInt32();	//基础物理偏斜减伤系数
			mDevDmg = br.ReadInt32();	//基础魔法偏斜减伤系数
			maxPDevDmg = br.ReadInt32();	//最高物理偏斜减伤系数
			baseWgt = br.ReadInt32();	//基础负重量
			baseAp = br.ReadInt32();	//基础AP上限
			baseMovN = br.ReadInt32();	//基础移动次数
			baseAtkN = br.ReadInt32();	//基础攻击次数
			baseActN = br.ReadInt32();	//基础行动次数
			basicCoolPirce = br.ReadInt32();	//附魔冷却基础价格
			nextFreeRefresh = br.ReadInt32();	//附魔刷新冷却时间
			playerMailLimit = br.ReadInt32();	//玩家邮箱上限
			maxMailSave = br.ReadInt32();	//邮件最大保存期
			transferPro = br.ReadSingle();	//非特产国家系数
			runBusinessRefresh = br.ReadString();	//跑商任务刷新时间
			goodsRefreshTime = br.ReadString();	//物资刷新时间
			tavernRefreshTime = br.ReadString();	//酒馆刷新时间
			initialMorale = br.ReadInt32();	//初始士气
			queryGoodsPrice = br.ReadInt32();	//价格查询
			collectMonth = br.ReadInt32();	//收取封地建筑月份
			addBuildingPrice = br.ReadString();	//额外封地建筑价格
			equipQualityCoefficient = br.ReadString();	//装备品质系数
			skillCoefficient = br.ReadString();	//附加技能系数
			basicEngagementPro = br.ReadInt32();	//爵位相同基础相亲概率
			basicEngagementPro_1 = br.ReadInt32();	//爵位大1基础相亲概率
			engagementRefreshTime = br.ReadInt32();	//相亲刷新月份
			engagementMinNobility = br.ReadInt32();	//参加相亲最低爵位
			banquetMinNobility = br.ReadInt32();	//参加宴会最低爵位
			banquetUnlockAreaNobility = br.ReadInt32();	//宴会解锁地区的爵位等级
			banquetRoyalBloodNum = br.ReadString();	//宴会指定地区的主血脉人数
			banquetInterval = br.ReadInt32();	//宴会举办间隔时间
			banquetActorNum = br.ReadInt32();	//宴会相亲对象人数
			matchmakerID = br.ReadInt32();	//相亲媒人ID
			noneActorCha = br.ReadString();	//相亲人员不出现特性
			cityTaskRefreshTime = br.ReadString();	//城镇任务刷新时间
			runBusnessNPC_ID = br.ReadInt32();	//跑商NPCID
			cooltime = br.ReadInt32();	//领取冷却间隔
			recruitMale = br.ReadSingle();	//招募性别系数男
			recruitFemale = br.ReadSingle();	//招募性别系数女
			silverCoinRecruitC = br.ReadInt32();	//银币招募常数
			jobs = br.ReadInt32();	//新出生角色初始职业
			actorLevel = br.ReadInt32();	//初始等级
			jobCoefficient = br.ReadSingle();	//历练获取经验职业系数
			experiencePositionPrice = br.ReadString();	//历练额外位置价格
			studentAgetMin = br.ReadInt32();	//学员最小年龄
			levelDifferenceMin = br.ReadInt32();	//历练师徒最小等级差值
			teacherLevelMin = br.ReadInt32();	//历练教官最低等级
			experience1Price = br.ReadInt32();	//短期历练银币花费
			experience2Price = br.ReadInt32();	//长期历练银币花费
			experience1Month = br.ReadString();	//短期历练月份范围
			experience1MonthPro = br.ReadString();	//短期历练月份随机概率
			experience2Month = br.ReadString();	//短期历练月份范围
			experience2MonthPro = br.ReadString();	//短期历练月份随机概率
			transforF_P = br.ReadInt32();	//友好度声望转化比
			consumeType = br.ReadString();	//消耗品物品类型
			otherType = br.ReadString();	//其他物品类型
			teachLevel = br.ReadInt32();	//传授教官最低等级
			teacherAgeMin = br.ReadInt32();	//学校教师最低年龄
			noTeachJobID = br.ReadString();	//不可传授职业id
			teachAdditionalSpend = br.ReadString();	//传授额外花费
			schoolAge = br.ReadString();	//学校重点培养出现年龄
			teacherWage = br.ReadInt32();	//教师维护费用
			tuition = br.ReadInt32();	//学费每月价格
			studyChaMax = br.ReadInt32();	//学校学习特性数量上限
			yuyingtingPrice = br.ReadString();	//育鹰厅建造价格
			keyTrainingRate = br.ReadInt32();	//重点培养成功率加成
			banquetPropSuccessMax = br.ReadInt32();	//宴会道具成功率使用上限
			flowerGirlsAge = br.ReadString();	//婚宴花童年龄范围
			serverDailyRefresh = br.ReadInt32();	//每日服务器刷新时间
			flowerGirlsStudyNum = br.ReadInt32();	//花童最多可学特性数量
			weddingNum = br.ReadInt32();	//参加婚礼抢捧花人数
			itemType = br.ReadString();	//物品增加通知提示类型
			renamePrice = br.ReadString();	//佣兵团改名费用
			flagPrice = br.ReadString();	//变更旗帜费用
			engagementActorJob = br.ReadInt32();	//相亲对象初始职业
			actorOnMonth = br.ReadInt32();	//角色任职最短时间
			changerPrice = br.ReadString();	//变更岗位花费
			actorChaMAX = br.ReadInt32();	//角色最大永久特性数量（不计学校获得）
			generalChaNum = br.ReadString();	//通用特性初始数量随机
			descentChaMaxType = br.ReadInt32();	//种族专属特性最大种类
			countryChaRandomRate = br.ReadInt32();	//国家特性随机概率
			legionNameMax = br.ReadInt32();	//佣兵团名称最长字符
			actorNameMax = br.ReadInt32();	//角色名称最长字符
			growOld1 = br.ReadInt32();	//衰老年龄1
			growOld2 = br.ReadInt32();	//衰老年龄2
			randomChaRate = br.ReadInt32();	//混血随机特性概率
			legionNameMin = br.ReadInt32();	//佣兵团名称最少字符
			actorNameMin = br.ReadInt32();	//角色名称最少字符
			moraleDifference = br.ReadInt32();	//士气真实值与显示值的差值
			wageSettlementTime = br.ReadInt32();	//军团工资结算时间
			sacredEffectRefresh = br.ReadInt32();	//军团圣物效果刷新价格
			unboundPrice = br.ReadInt32();	//圣物解绑价格
			sacredTransforConsume = br.ReadString();	//军团圣物转换消耗
			sacredPositionMinID = br.ReadInt32();	//军团圣物装备所需最低职位
			noTransforEquipType = br.ReadString();	//不可转化圣物的装备类型
			sacredEffectRandom = br.ReadString();	//圣物效果数量随机
			moraleDiminishingMonth = br.ReadInt32();	//士气递减封顶月数
			shengling = br.ReadInt32();	//神令每日免费领取数量
			saodangjuan = br.ReadInt32();	//扫荡劵每日免费领取数量
			spiritCoolTime = br.ReadInt32();	//精神创伤冷却期
			worsenInjuryID = br.ReadInt32();	//恶化伤病ID
			triggerMoraleDiminishing = br.ReadInt32();	//军团士气递减触发月数
			legionBuffLevel = br.ReadInt32();	//初始军团技能等级
			injuryOpenJudgeMonth = br.ReadInt32();	//生病启动后判定月份
			contagionAnnuallyAddPro = br.ReadInt32();	//疾病爆发每年提高概率
			contagionNumPro = br.ReadInt32();	//疾病爆发数占总人口比
			legionBuffLevelMax = br.ReadInt32();	//军团技能最大等级
			triggerInjuryTaskType = br.ReadString();	//触发战斗伤的任务类型
			battleInjuryRate = br.ReadInt32();	//战斗中被击倒的受伤概率
			actorJoinMonth = br.ReadInt32();	//角色入队满月份提需求
			actorDemandJudgeMonth = br.ReadInt32();	//每年角色需求判断月份
			actorDemandRate = br.ReadInt32();	//角色需求触发人数占入团总人数万分比
			actorDemandMaxNum = br.ReadInt32();	//触发角色个人需求最大人数上限
			juvenilesDeathRate = br.ReadInt32();	//未成年人夭折基础概率
			actorDemandCoolMonth = br.ReadInt32();	//个人需求冷却期
			legionPositionMonth = br.ReadInt32();	//军团职位收费月份
			unsatisfiedAddWeight = br.ReadInt32();	//未满足需求追加权重值
			bonusRandomRange = br.ReadString();	//需求奖金系数随机范围
			demandInitialWeight = br.ReadInt32();	//每种需求的初始权重
			ageDifference = br.ReadInt32();	//年龄差值常数
			goodDemandOpenMonth = br.ReadInt32();	//物资需求系数启动月数
			fixedGoodMonth = br.ReadInt32();	//固定物资服役月数值
			unfixedGoodMonth = br.ReadInt32();	//非固定物资服役月数值
			actorNegativeRate = br.ReadInt32();	//角色获得负面特性概率
			actorNegativeAddRate = br.ReadInt32();	//角色获得负面特性追加概率
			taskEntrusPeopleNum = br.ReadInt32();	//委托任务执行人数
			entrusCaptainAge = br.ReadInt32();	//委托小队队长年龄
			entrusCaptainJobLevel = br.ReadString();	//队长职业要求
			mainLastTaskID = br.ReadInt32();	//主线最后任务ID
			taskEntrusRefreshPrice = br.ReadInt32();	//委托任务刷新钻石数
			taskEntrusRefreshTime = br.ReadString();	//委托任务刷新时间
			freeRefreshCoolTime = br.ReadInt32();	//委托任务免费刷新间隔时间
			doneBasicPrice = br.ReadInt32();	//委托任务立即完成单月钻石基数
			pregnantTimeMax = br.ReadInt32();	//最大怀孕次数
			pregnantCoolMonth = br.ReadInt32();	//怀孕间隔月数
			birthMonth = br.ReadInt32();	//生育所需月数
			girlRate = br.ReadInt32();	//生女孩的概率
			chaUnknownDes = br.ReadString();	//特性状态“未知”描述
			labelDisplayBloodRate = br.ReadInt32();	//标签显示要求血脉比例
			replyBasicRate = br.ReadInt32();	//征兵基础回信概率
			replyMonth = br.ReadInt32();	//回信冷却月份
			replyMonthMax = br.ReadString();	//回信随机月范围
			singleAddRate = br.ReadInt32();	//每多一个角色回信增加值
			replyRateMax = br.ReadInt32();	//最大征兵回信概率
			giftBagRandomRange = br.ReadString();	//商店礼包折扣随机范围
			goodsRandomRange = br.ReadString();	//商店特产折扣随机范围
			discountRateMin = br.ReadInt32();	//折扣率最小变化值
			sundayCountryID = br.ReadString();	//周日特产国家
			seasonStartTime = br.ReadString();	//赛季开始时间
			seasonEndTime = br.ReadString();	//赛季结束时间
			entrustBuyPrice = br.ReadInt32();	//委托任务钻石购买价格
			entrustFreeRefreshTime = br.ReadInt32();	//委托任务每日免费刷新次数
			brithRate = br.ReadInt32();	//双胞胎概率
			firstChildIcon = br.ReadString();	//第一个孩子标识
			secondChildIcon = br.ReadString();	//第二个孩子标识
			rankPeopleNum = br.ReadInt32();	//战力榜单团上榜人数
			entrustRewardMail = br.ReadInt32();	//委托奖励邮件ID
			speedConfig = br.ReadString();	//角色升级进度条配置
			noFamilyText = br.ReadString();	//无家族成员提示
			arenaTimePrice = br.ReadInt32();	//竞技场次数购买价格
			rankRewardMail = br.ReadInt32();	//排行榜奖励邮件ID
			initialTaskMain = br.ReadInt32();	//初始主线任务ID
			oldChaID = br.ReadInt32();	//衰老特性ID
			juvenilesDeathOpenMonth = br.ReadInt32();	//未成年人夭折判定开始月份
			juvenilesDeathCycle = br.ReadInt32();	//夭折判定周期月份
			seriouslyHpLimit = br.ReadInt32();	//重伤HP界限
			dyingHpLimit = br.ReadInt32();	//濒死HP界限
			arenaWeeklyST = br.ReadString();	//竞技场周礼包结算时间
			arenaMailID = br.ReadInt32();	//竞技场奖励邮件ID
			juvenilesDeathMailID = br.ReadString();	//夭折邮件id
			teamBattlePlayerNum = br.ReadString();	//组队副本人数
			signVipLeve = br.ReadInt32();	//连续签到VIP等级
			radomBastcHpRanger = br.ReadString();	//随机基础hp范围
			randomBirthSixD = br.ReadString();	//六维出生随机值
			singelBattleDailyTimes = br.ReadInt32();	//单个副本每日参与次数
			mainBattleTimes = br.ReadInt32();	//主线副本挑战次数
			branchBattleTimes = br.ReadInt32();	//支线副本挑战次数
			teamBattleBuyTimesPrice = br.ReadString();	//组队副本购买挑战次数价格
			teamBattleFullTips = br.ReadInt32();	//组队副本人员已满提示
			teamBattleRewardMailID = br.ReadInt32();	//组队副本奖励邮件ID
			exchangeCode = br.ReadInt32();	//兑换码邮件模板id
			unlockClimbTower = br.ReadInt32();	//爬塔解锁友好度等级
			resetClimbTowerType = br.ReadInt32();	//爬塔重置类型
			climbTowerNPCid = br.ReadInt32();	//爬塔NpcID
			climbTowerShopRandomNum = br.ReadInt32();	//爬塔商店随机商品掉落个数
			specialJobsID = br.ReadString();	//特殊职业id
			climbTowerDoneDialog = br.ReadString();	//爬塔答题未完成对话
			climbTowerIncompleteDialog = br.ReadString();	//爬塔答题已完成对话
			climbTowerCloseTipsID = br.ReadInt32();	//爬塔跨周期提示文本
			clmibTowerCompensateMailSendTime = br.ReadInt32();	//爬塔赛季结束自动补偿结算时间
			clmibTowerCompensateMailID = br.ReadInt32();	//爬塔补偿邮件ID
			clmibTowerGetCardTips = br.ReadString();	//爬塔获取卡牌文本
			weeklyResetTime = br.ReadString();	//每周数据重置时间
			
        }
    } 
} 