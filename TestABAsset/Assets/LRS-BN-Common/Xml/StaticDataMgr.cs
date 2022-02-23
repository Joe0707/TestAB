using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System;
using StaticData;
using System.Reflection;
using GlobalDefine;
using StaticData.Data;
using UnityEngine;
using StaticDataTool;

namespace StaticData
{
    public class StaticDataMgr
    {
        private static StaticDataMgr instance = null;
        public static StaticDataMgr Instance
        {
            get
            {
                if (instance == null)
                    instance = new StaticDataMgr();
                return instance;
            }
            protected set { instance = value; }
        }

        // *************				data	 	***************
        public Dictionary<uint, ActiveDailyData> mActiveDailyDataMap = new Dictionary<uint, ActiveDailyData>(); //ActiveDaily Data
        public Dictionary<uint, ActorData> mActorDataMap = new Dictionary<uint, ActorData>(); //Actor Data
        public Dictionary<uint, ActorDemandConditionData> mActorDemandConditionDataMap = new Dictionary<uint, ActorDemandConditionData>(); //ActorDemandCondition Data
        public Dictionary<uint, ActorDemandGoodsData> mActorDemandGoodsDataMap = new Dictionary<uint, ActorDemandGoodsData>(); //ActorDemandGoods Data
        public Dictionary<uint, ActorInitialNatureData> mActorInitialNatureDataMap = new Dictionary<uint, ActorInitialNatureData>(); //ActorInitialNature Data
        public Dictionary<uint, AgeData> mAgeDataMap = new Dictionary<uint, AgeData>(); //Age Data
        public Dictionary<uint, AgeDifferenceData> mAgeDifferenceDataMap = new Dictionary<uint, AgeDifferenceData>(); //AgeDifference Data
        public Dictionary<uint, AiData> mAiDataMap = new Dictionary<uint, AiData>(); //Ai Data
        public Dictionary<uint, AirFloatData> mAirFloatDataMap = new Dictionary<uint, AirFloatData>(); //AirFloat Data
        public Dictionary<uint, AllControlData> mAllControlDataMap = new Dictionary<uint, AllControlData>(); //AllControl Data
        public Dictionary<uint, AreaData> mAreaDataMap = new Dictionary<uint, AreaData>(); //Area Data
        public Dictionary<uint, ArenaBuffData> mArenaBuffDataMap = new Dictionary<uint, ArenaBuffData>(); //ArenaBuff Data
        public Dictionary<uint, ArenaLevelData> mArenaLevelDataMap = new Dictionary<uint, ArenaLevelData>(); //ArenaLevel Data
        public Dictionary<uint, ArenaSecondConfigData> mArenaSecondConfigDataMap = new Dictionary<uint, ArenaSecondConfigData>(); //ArenaSecondConfig Data
        public Dictionary<uint, ArenaWinningStreakData> mArenaWinningStreakDataMap = new Dictionary<uint, ArenaWinningStreakData>(); //ArenaWinningStreak Data
        public Dictionary<uint, ArenaWinningStreakRewardData> mArenaWinningStreakRewardDataMap = new Dictionary<uint, ArenaWinningStreakRewardData>(); //ArenaWinningStreakReward Data
        public Dictionary<uint, AvatarsData> mAvatarsDataMap = new Dictionary<uint, AvatarsData>(); //Avatars Data
        public Dictionary<uint, BagItemData> mBagItemDataMap = new Dictionary<uint, BagItemData>(); //BagItem Data
        public Dictionary<uint, BanquetActorAgeData> mBanquetActorAgeDataMap = new Dictionary<uint, BanquetActorAgeData>(); //BanquetActorAge Data
        public Dictionary<uint, BanquetBloodPlanData> mBanquetBloodPlanDataMap = new Dictionary<uint, BanquetBloodPlanData>(); //BanquetBloodPlan Data
        public Dictionary<uint, BanquetConfigData> mBanquetConfigDataMap = new Dictionary<uint, BanquetConfigData>(); //BanquetConfig Data
        public Dictionary<uint, BanquetQuestionData> mBanquetQuestionDataMap = new Dictionary<uint, BanquetQuestionData>(); //BanquetQuestion Data
        public Dictionary<uint, BanquetQuestionOptionData> mBanquetQuestionOptionDataMap = new Dictionary<uint, BanquetQuestionOptionData>(); //BanquetQuestionOption Data
        public Dictionary<uint, BanquetQuestionResultData> mBanquetQuestionResultDataMap = new Dictionary<uint, BanquetQuestionResultData>(); //BanquetQuestionResult Data
        public Dictionary<uint, BanquetResultCoefficientData> mBanquetResultCoefficientDataMap = new Dictionary<uint, BanquetResultCoefficientData>(); //BanquetResultCoefficient Data
        public Dictionary<uint, BarberPartData> mBarberPartDataMap = new Dictionary<uint, BarberPartData>(); //BarberPart Data
        public Dictionary<uint, BattleNatureDisplayData> mBattleNatureDisplayDataMap = new Dictionary<uint, BattleNatureDisplayData>(); //BattleNatureDisplay Data
        public Dictionary<uint, BTNodeData> mBTNodeDataMap = new Dictionary<uint, BTNodeData>(); //BTNode Data
        public Dictionary<uint, BuffsData> mBuffsDataMap = new Dictionary<uint, BuffsData>(); //Buffs Data
        public Dictionary<uint, BuildingData> mBuildingDataMap = new Dictionary<uint, BuildingData>(); //Building Data
        public Dictionary<uint, BuildingProduceData> mBuildingProduceDataMap = new Dictionary<uint, BuildingProduceData>(); //BuildingProduce Data
        public Dictionary<uint, ButtonData> mButtonDataMap = new Dictionary<uint, ButtonData>(); //Button Data
        public Dictionary<uint, CannotRefinementData> mCannotRefinementDataMap = new Dictionary<uint, CannotRefinementData>(); //CannotRefinement Data
        public Dictionary<uint, CastleData> mCastleDataMap = new Dictionary<uint, CastleData>(); //Castle Data
        public Dictionary<uint, CastleQueueUnlockData> mCastleQueueUnlockDataMap = new Dictionary<uint, CastleQueueUnlockData>(); //CastleQueueUnlock Data
        public Dictionary<uint, ChaEffectConditionData> mChaEffectConditionDataMap = new Dictionary<uint, ChaEffectConditionData>(); //ChaEffectCondition Data
        public Dictionary<uint, ChamberOfCommerceData> mChamberOfCommerceDataMap = new Dictionary<uint, ChamberOfCommerceData>(); //ChamberOfCommerce Data
        public Dictionary<uint, ChaMixedRaceData> mChaMixedRaceDataMap = new Dictionary<uint, ChaMixedRaceData>(); //ChaMixedRace Data
        public Dictionary<uint, CharacteristicData> mCharacteristicDataMap = new Dictionary<uint, CharacteristicData>(); //Characteristic Data
        public Dictionary<uint, ClimbTowerData> mClimbTowerDataMap = new Dictionary<uint, ClimbTowerData>(); //ClimbTower Data
        public Dictionary<uint, ClimbTowerAnswerData> mClimbTowerAnswerDataMap = new Dictionary<uint, ClimbTowerAnswerData>(); //ClimbTowerAnswer Data
        public Dictionary<uint, ClimbTowerCardData> mClimbTowerCardDataMap = new Dictionary<uint, ClimbTowerCardData>(); //ClimbTowerCard Data
        public Dictionary<uint, ClimbTowerLevelBuffData> mClimbTowerLevelBuffDataMap = new Dictionary<uint, ClimbTowerLevelBuffData>(); //ClimbTowerLevelBuff Data
        public Dictionary<uint, ClimbTowerLevelConfigData> mClimbTowerLevelConfigDataMap = new Dictionary<uint, ClimbTowerLevelConfigData>(); //ClimbTowerLevelConfig Data
        public Dictionary<uint, ClimbTowerQuestionData> mClimbTowerQuestionDataMap = new Dictionary<uint, ClimbTowerQuestionData>(); //ClimbTowerQuestion Data
        public Dictionary<uint, ClimbTowerShopData> mClimbTowerShopDataMap = new Dictionary<uint, ClimbTowerShopData>(); //ClimbTowerShop Data
        public Dictionary<uint, ClmibTowerCountryCardConfigData> mClmibTowerCountryCardConfigDataMap = new Dictionary<uint, ClmibTowerCountryCardConfigData>(); //ClmibTowerCountryCardConfig Data
        public Dictionary<uint, ColorData> mColorDataMap = new Dictionary<uint, ColorData>(); //Color Data
        public Dictionary<uint, ConscriptionBloodExchangeData> mConscriptionBloodExchangeDataMap = new Dictionary<uint, ConscriptionBloodExchangeData>(); //ConscriptionBloodExchange Data
        public Dictionary<uint, ConscriptionReplyData> mConscriptionReplyDataMap = new Dictionary<uint, ConscriptionReplyData>(); //ConscriptionReply Data
        public Dictionary<uint, ConscriptionReplyRewardData> mConscriptionReplyRewardDataMap = new Dictionary<uint, ConscriptionReplyRewardData>(); //ConscriptionReplyReward Data
        public Dictionary<uint, ConscriptionRewardData> mConscriptionRewardDataMap = new Dictionary<uint, ConscriptionRewardData>(); //ConscriptionReward Data
        public Dictionary<uint, ConstellationChaRandomData> mConstellationChaRandomDataMap = new Dictionary<uint, ConstellationChaRandomData>(); //ConstellationChaRandom Data
        public Dictionary<uint, CountryData> mCountryDataMap = new Dictionary<uint, CountryData>(); //Country Data
        public Dictionary<uint, DescentData> mDescentDataMap = new Dictionary<uint, DescentData>(); //Descent Data
        public Dictionary<uint, DescentCoefficientData> mDescentCoefficientDataMap = new Dictionary<uint, DescentCoefficientData>(); //DescentCoefficient Data
        public Dictionary<uint, DialogData> mDialogDataMap = new Dictionary<uint, DialogData>(); //Dialog Data
        public Dictionary<uint, EffectConditionsData> mEffectConditionsDataMap = new Dictionary<uint, EffectConditionsData>(); //EffectConditions Data
        public Dictionary<uint, EffectConsData> mEffectConsDataMap = new Dictionary<uint, EffectConsData>(); //EffectCons Data
        public Dictionary<uint, EffectResultsData> mEffectResultsDataMap = new Dictionary<uint, EffectResultsData>(); //EffectResults Data
        public Dictionary<uint, EffectsData> mEffectsDataMap = new Dictionary<uint, EffectsData>(); //Effects Data
        public Dictionary<uint, EngagemenEntryData> mEngagemenEntryDataMap = new Dictionary<uint, EngagemenEntryData>(); //EngagemenEntry Data
        public Dictionary<uint, EngagementActorAgeData> mEngagementActorAgeDataMap = new Dictionary<uint, EngagementActorAgeData>(); //EngagementActorAge Data
        public Dictionary<uint, EngagementActorJobsData> mEngagementActorJobsDataMap = new Dictionary<uint, EngagementActorJobsData>(); //EngagementActorJobs Data
        public Dictionary<uint, EngagementActorNobilityRangeData> mEngagementActorNobilityRangeDataMap = new Dictionary<uint, EngagementActorNobilityRangeData>(); //EngagementActorNobilityRange Data
        public Dictionary<uint, EngagementBasicProData> mEngagementBasicProDataMap = new Dictionary<uint, EngagementBasicProData>(); //EngagementBasicPro Data
        public Dictionary<uint, EngagementBloodRuleData> mEngagementBloodRuleDataMap = new Dictionary<uint, EngagementBloodRuleData>(); //EngagementBloodRule Data
        public Dictionary<uint, EngagementCastleBloodPlanData> mEngagementCastleBloodPlanDataMap = new Dictionary<uint, EngagementCastleBloodPlanData>(); //EngagementCastleBloodPlan Data
        public Dictionary<uint, EngagementNobilityBloodData> mEngagementNobilityBloodDataMap = new Dictionary<uint, EngagementNobilityBloodData>(); //EngagementNobilityBlood Data
        public Dictionary<uint, EngagementPeachBloodPlanData> mEngagementPeachBloodPlanDataMap = new Dictionary<uint, EngagementPeachBloodPlanData>(); //EngagementPeachBloodPlan Data
        public Dictionary<uint, EquipBuffExtractData> mEquipBuffExtractDataMap = new Dictionary<uint, EquipBuffExtractData>(); //EquipBuffExtract Data
        public Dictionary<uint, EquipDecomposeData> mEquipDecomposeDataMap = new Dictionary<uint, EquipDecomposeData>(); //EquipDecompose Data
        public Dictionary<uint, EquipEnchantingData> mEquipEnchantingDataMap = new Dictionary<uint, EquipEnchantingData>(); //EquipEnchanting Data
        public Dictionary<uint, EquipEnchantingRefreshData> mEquipEnchantingRefreshDataMap = new Dictionary<uint, EquipEnchantingRefreshData>(); //EquipEnchantingRefresh Data
        public Dictionary<uint, EquipEnchantingResultsData> mEquipEnchantingResultsDataMap = new Dictionary<uint, EquipEnchantingResultsData>(); //EquipEnchantingResults Data
        public Dictionary<uint, EquipmentAnimatorData> mEquipmentAnimatorDataMap = new Dictionary<uint, EquipmentAnimatorData>(); //EquipmentAnimator Data
        public Dictionary<uint, EquipmentsData> mEquipmentsDataMap = new Dictionary<uint, EquipmentsData>(); //Equipments Data
        public Dictionary<uint, EquipmentsRangeData> mEquipmentsRangeDataMap = new Dictionary<uint, EquipmentsRangeData>(); //EquipmentsRange Data
        public Dictionary<uint, EquipmentTypeData> mEquipmentTypeDataMap = new Dictionary<uint, EquipmentTypeData>(); //EquipmentType Data
        public Dictionary<uint, EquipPromoteData> mEquipPromoteDataMap = new Dictionary<uint, EquipPromoteData>(); //EquipPromote Data
        public Dictionary<uint, EquipRandomNatureData> mEquipRandomNatureDataMap = new Dictionary<uint, EquipRandomNatureData>(); //EquipRandomNature Data
        public Dictionary<uint, EquipRefinementData> mEquipRefinementDataMap = new Dictionary<uint, EquipRefinementData>(); //EquipRefinement Data
        public Dictionary<uint, EquipSCData> mEquipSCDataMap = new Dictionary<uint, EquipSCData>(); //EquipSC Data
        public Dictionary<uint, EquipSourceData> mEquipSourceDataMap = new Dictionary<uint, EquipSourceData>(); //EquipSource Data
        public Dictionary<uint, EquipStrengthenData> mEquipStrengthenDataMap = new Dictionary<uint, EquipStrengthenData>(); //EquipStrengthen Data
        public Dictionary<uint, ExteriorPartData> mExteriorPartDataMap = new Dictionary<uint, ExteriorPartData>(); //ExteriorPart Data
        public Dictionary<uint, FemaleDataData> mFemaleDataDataMap = new Dictionary<uint, FemaleDataData>(); //FemaleData Data
        public Dictionary<uint, FestivalData> mFestivalDataMap = new Dictionary<uint, FestivalData>(); //Festival Data
        public Dictionary<uint, FestivalExchangeData> mFestivalExchangeDataMap = new Dictionary<uint, FestivalExchangeData>(); //FestivalExchange Data
        public Dictionary<uint, FestivalOptionData> mFestivalOptionDataMap = new Dictionary<uint, FestivalOptionData>(); //FestivalOption Data
        public Dictionary<uint, FestivalPeachConfigData> mFestivalPeachConfigDataMap = new Dictionary<uint, FestivalPeachConfigData>(); //FestivalPeachConfig Data
        public Dictionary<uint, FestivalPeachNobilityData> mFestivalPeachNobilityDataMap = new Dictionary<uint, FestivalPeachNobilityData>(); //FestivalPeachNobility Data
        public Dictionary<uint, FestivalWrestleData> mFestivalWrestleDataMap = new Dictionary<uint, FestivalWrestleData>(); //FestivalWrestle Data
        public Dictionary<uint, FlagData> mFlagDataMap = new Dictionary<uint, FlagData>(); //Flag Data
        public Dictionary<uint, FlowerGirlsChaData> mFlowerGirlsChaDataMap = new Dictionary<uint, FlowerGirlsChaData>(); //FlowerGirlsCha Data
        public Dictionary<uint, FunctionExplainData> mFunctionExplainDataMap = new Dictionary<uint, FunctionExplainData>(); //FunctionExplain Data
        public Dictionary<uint, GemInlayConfigData> mGemInlayConfigDataMap = new Dictionary<uint, GemInlayConfigData>(); //GemInlayConfig Data
        public Dictionary<uint, GemSlotRefreshData> mGemSlotRefreshDataMap = new Dictionary<uint, GemSlotRefreshData>(); //GemSlotRefresh Data
        public Dictionary<uint, GemUpgradeData> mGemUpgradeDataMap = new Dictionary<uint, GemUpgradeData>(); //GemUpgrade Data
        public Dictionary<uint, GoodsData> mGoodsDataMap = new Dictionary<uint, GoodsData>(); //Goods Data
        public Dictionary<uint, GoodsFluctuateData> mGoodsFluctuateDataMap = new Dictionary<uint, GoodsFluctuateData>(); //GoodsFluctuate Data
        public Dictionary<uint, GoodsGroupData> mGoodsGroupDataMap = new Dictionary<uint, GoodsGroupData>(); //GoodsGroup Data
        public Dictionary<uint, GoodsNumRandomData> mGoodsNumRandomDataMap = new Dictionary<uint, GoodsNumRandomData>(); //GoodsNumRandom Data
        public Dictionary<uint, HeroNatureRuleData> mHeroNatureRuleDataMap = new Dictionary<uint, HeroNatureRuleData>(); //HeroNatureRule Data
        public Dictionary<uint, HerosData> mHerosDataMap = new Dictionary<uint, HerosData>(); //Heros Data
        public Dictionary<uint, InjuryData> mInjuryDataMap = new Dictionary<uint, InjuryData>(); //Injury Data
        public Dictionary<uint, InjuryWorsenData> mInjuryWorsenDataMap = new Dictionary<uint, InjuryWorsenData>(); //InjuryWorsen Data
        public Dictionary<uint, JobsData> mJobsDataMap = new Dictionary<uint, JobsData>(); //Jobs Data
        public Dictionary<uint, LegionActorDemandData> mLegionActorDemandDataMap = new Dictionary<uint, LegionActorDemandData>(); //LegionActorDemand Data
        public Dictionary<uint, LegionBuffUnlockData> mLegionBuffUnlockDataMap = new Dictionary<uint, LegionBuffUnlockData>(); //LegionBuffUnlock Data
        public Dictionary<uint, LegionSacredBindindData> mLegionSacredBindindDataMap = new Dictionary<uint, LegionSacredBindindData>(); //LegionSacredBindind Data
        public Dictionary<uint, LegionSacredEffectData> mLegionSacredEffectDataMap = new Dictionary<uint, LegionSacredEffectData>(); //LegionSacredEffect Data
        public Dictionary<uint, LegionSacredEffectNatureData> mLegionSacredEffectNatureDataMap = new Dictionary<uint, LegionSacredEffectNatureData>(); //LegionSacredEffectNature Data
        public Dictionary<uint, LegionSacredEffectUpgradeData> mLegionSacredEffectUpgradeDataMap = new Dictionary<uint, LegionSacredEffectUpgradeData>(); //LegionSacredEffectUpgrade Data
        public Dictionary<uint, LegionSacredUpgradeData> mLegionSacredUpgradeDataMap = new Dictionary<uint, LegionSacredUpgradeData>(); //LegionSacredUpgrade Data
        public Dictionary<uint, LevelData> mLevelDataMap = new Dictionary<uint, LevelData>(); //Level Data
        public Dictionary<uint, LevelConstData> mLevelConstDataMap = new Dictionary<uint, LevelConstData>(); //LevelConst Data
        public Dictionary<uint, LevelResultData> mLevelResultDataMap = new Dictionary<uint, LevelResultData>(); //LevelResult Data
        public Dictionary<uint, LevelUpData> mLevelUpDataMap = new Dictionary<uint, LevelUpData>(); //LevelUp Data
        public Dictionary<uint, lvleffectData> mlvleffectDataMap = new Dictionary<uint, lvleffectData>(); //lvleffect Data
        public Dictionary<uint, MailData> mMailDataMap = new Dictionary<uint, MailData>(); //Mail Data
        public Dictionary<uint, MonstersData> mMonstersDataMap = new Dictionary<uint, MonstersData>(); //Monsters Data
        public Dictionary<uint, MoraleData> mMoraleDataMap = new Dictionary<uint, MoraleData>(); //Morale Data
        public Dictionary<uint, MoraleActionData> mMoraleActionDataMap = new Dictionary<uint, MoraleActionData>(); //MoraleAction Data
        public Dictionary<uint, NamesData> mNamesDataMap = new Dictionary<uint, NamesData>(); //Names Data
        public Dictionary<uint, NatureIdExplainData> mNatureIdExplainDataMap = new Dictionary<uint, NatureIdExplainData>(); //NatureIdExplain Data
        public Dictionary<uint, NewsTickerData> mNewsTickerDataMap = new Dictionary<uint, NewsTickerData>(); //NewsTicker Data
        public Dictionary<uint, NobilityData> mNobilityDataMap = new Dictionary<uint, NobilityData>(); //Nobility Data
        public Dictionary<uint, PageData> mPageDataMap = new Dictionary<uint, PageData>(); //Page Data
        public Dictionary<uint, PageControlData> mPageControlDataMap = new Dictionary<uint, PageControlData>(); //PageControl Data
        public Dictionary<uint, PlayerShortBuffsData> mPlayerShortBuffsDataMap = new Dictionary<uint, PlayerShortBuffsData>(); //PlayerShortBuffs Data
        public Dictionary<uint, PositionData> mPositionDataMap = new Dictionary<uint, PositionData>(); //Position Data
        public Dictionary<uint, PositionJobEffectData> mPositionJobEffectDataMap = new Dictionary<uint, PositionJobEffectData>(); //PositionJobEffect Data
        public Dictionary<uint, PrestigeData> mPrestigeDataMap = new Dictionary<uint, PrestigeData>(); //Prestige Data
        public Dictionary<uint, RankConfigData> mRankConfigDataMap = new Dictionary<uint, RankConfigData>(); //RankConfig Data
        public Dictionary<uint, RankCycleConfigData> mRankCycleConfigDataMap = new Dictionary<uint, RankCycleConfigData>(); //RankCycleConfig Data
        public Dictionary<uint, RankFirstConfigData> mRankFirstConfigDataMap = new Dictionary<uint, RankFirstConfigData>(); //RankFirstConfig Data
        public Dictionary<uint, RankRelationData> mRankRelationDataMap = new Dictionary<uint, RankRelationData>(); //RankRelation Data
        public Dictionary<uint, RankRewardData> mRankRewardDataMap = new Dictionary<uint, RankRewardData>(); //RankReward Data
        public Dictionary<uint, RateData> mRateDataMap = new Dictionary<uint, RateData>(); //Rate Data
        public Dictionary<uint, RefinementRandomProData> mRefinementRandomProDataMap = new Dictionary<uint, RefinementRandomProData>(); //RefinementRandomPro Data
        public Dictionary<uint, ReplyData> mReplyDataMap = new Dictionary<uint, ReplyData>(); //Reply Data
        public Dictionary<uint, RewardGroupData> mRewardGroupDataMap = new Dictionary<uint, RewardGroupData>(); //RewardGroup Data
        public Dictionary<uint, RunTaskNumRandomData> mRunTaskNumRandomDataMap = new Dictionary<uint, RunTaskNumRandomData>(); //RunTaskNumRandom Data
        public Dictionary<uint, SchoolChaDropData> mSchoolChaDropDataMap = new Dictionary<uint, SchoolChaDropData>(); //SchoolChaDrop Data
        public Dictionary<uint, SchoolChaRandomResultData> mSchoolChaRandomResultDataMap = new Dictionary<uint, SchoolChaRandomResultData>(); //SchoolChaRandomResult Data
        public Dictionary<uint, ShopData> mShopDataMap = new Dictionary<uint, ShopData>(); //Shop Data
        public Dictionary<uint, ShopGoodsData> mShopGoodsDataMap = new Dictionary<uint, ShopGoodsData>(); //ShopGoods Data
        public Dictionary<uint, ShopWeekData> mShopWeekDataMap = new Dictionary<uint, ShopWeekData>(); //ShopWeek Data
        public Dictionary<uint, SignCycleRewardData> mSignCycleRewardDataMap = new Dictionary<uint, SignCycleRewardData>(); //SignCycleReward Data
        public Dictionary<uint, SignDailyData> mSignDailyDataMap = new Dictionary<uint, SignDailyData>(); //SignDaily Data
        public Dictionary<uint, SixDimensionTransferData> mSixDimensionTransferDataMap = new Dictionary<uint, SixDimensionTransferData>(); //SixDimensionTransfer Data
        public Dictionary<uint, SkillBasicFightingData> mSkillBasicFightingDataMap = new Dictionary<uint, SkillBasicFightingData>(); //SkillBasicFighting Data
        public Dictionary<uint, SkillLevelCoefficientData> mSkillLevelCoefficientDataMap = new Dictionary<uint, SkillLevelCoefficientData>(); //SkillLevelCoefficient Data
        public Dictionary<uint, SkillsData> mSkillsDataMap = new Dictionary<uint, SkillsData>(); //Skills Data
        public Dictionary<uint, SkillStudyConfigData> mSkillStudyConfigDataMap = new Dictionary<uint, SkillStudyConfigData>(); //SkillStudyConfig Data
        public Dictionary<uint, StatusData> mStatusDataMap = new Dictionary<uint, StatusData>(); //Status Data
        public Dictionary<uint, StringsData> mStringsDataMap = new Dictionary<uint, StringsData>(); //Strings Data
        public Dictionary<uint, TaskData> mTaskDataMap = new Dictionary<uint, TaskData>(); //Task Data
        public Dictionary<uint, TaskAttainmentData> mTaskAttainmentDataMap = new Dictionary<uint, TaskAttainmentData>(); //TaskAttainment Data
        public Dictionary<uint, TaskBasicNatureData> mTaskBasicNatureDataMap = new Dictionary<uint, TaskBasicNatureData>(); //TaskBasicNature Data
        public Dictionary<uint, TaskCityData> mTaskCityDataMap = new Dictionary<uint, TaskCityData>(); //TaskCity Data
        public Dictionary<uint, TaskdailyData> mTaskdailyDataMap = new Dictionary<uint, TaskdailyData>(); //Taskdaily Data
        public Dictionary<uint, TaskDropData> mTaskDropDataMap = new Dictionary<uint, TaskDropData>(); //TaskDrop Data
        public Dictionary<uint, TaskEntrustData> mTaskEntrustDataMap = new Dictionary<uint, TaskEntrustData>(); //TaskEntrust Data
        public Dictionary<uint, TaskEntrustOverviewData> mTaskEntrustOverviewDataMap = new Dictionary<uint, TaskEntrustOverviewData>(); //TaskEntrustOverview Data
        public Dictionary<uint, TaskEntrustRequirementConditionData> mTaskEntrustRequirementConditionDataMap = new Dictionary<uint, TaskEntrustRequirementConditionData>(); //TaskEntrustRequirementCondition Data
        public Dictionary<uint, TaskEntrustRequirementRandomData> mTaskEntrustRequirementRandomDataMap = new Dictionary<uint, TaskEntrustRequirementRandomData>(); //TaskEntrustRequirementRandom Data
        public Dictionary<uint, TaskMainData> mTaskMainDataMap = new Dictionary<uint, TaskMainData>(); //TaskMain Data
        public Dictionary<uint, TaskMainStoryData> mTaskMainStoryDataMap = new Dictionary<uint, TaskMainStoryData>(); //TaskMainStory Data
        public Dictionary<uint, TavernData> mTavernDataMap = new Dictionary<uint, TavernData>(); //Tavern Data
        public Dictionary<uint, TeachSuccessRateData> mTeachSuccessRateDataMap = new Dictionary<uint, TeachSuccessRateData>(); //TeachSuccessRate Data
        public Dictionary<uint, TeachSuccessRateDesData> mTeachSuccessRateDesDataMap = new Dictionary<uint, TeachSuccessRateDesData>(); //TeachSuccessRateDes Data
        public Dictionary<uint, TeamBattleData> mTeamBattleDataMap = new Dictionary<uint, TeamBattleData>(); //TeamBattle Data
        public Dictionary<uint, TeamBattleBuffsData> mTeamBattleBuffsDataMap = new Dictionary<uint, TeamBattleBuffsData>(); //TeamBattleBuffs Data
        public Dictionary<uint, TeamBattleInvitationCodeData> mTeamBattleInvitationCodeDataMap = new Dictionary<uint, TeamBattleInvitationCodeData>(); //TeamBattleInvitationCode Data
        public Dictionary<uint, TeamBattleMainRewardData> mTeamBattleMainRewardDataMap = new Dictionary<uint, TeamBattleMainRewardData>(); //TeamBattleMainReward Data
        public Dictionary<uint, TopographyBuffData> mTopographyBuffDataMap = new Dictionary<uint, TopographyBuffData>(); //TopographyBuff Data
        public Dictionary<uint, Training_ExperienceData> mTraining_ExperienceDataMap = new Dictionary<uint, Training_ExperienceData>(); //Training_Experience Data
        public Dictionary<uint, Training_Experience_EventData> mTraining_Experience_EventDataMap = new Dictionary<uint, Training_Experience_EventData>(); //Training_Experience_Event Data
        public Dictionary<uint, Training_Experience_EventRewardData> mTraining_Experience_EventRewardDataMap = new Dictionary<uint, Training_Experience_EventRewardData>(); //Training_Experience_EventReward Data
        public Dictionary<uint, Training_Experience_EventTriggerData> mTraining_Experience_EventTriggerDataMap = new Dictionary<uint, Training_Experience_EventTriggerData>(); //Training_Experience_EventTrigger Data
        public Dictionary<uint, Training_Experience_RewardData> mTraining_Experience_RewardDataMap = new Dictionary<uint, Training_Experience_RewardData>(); //Training_Experience_Reward Data
        public Dictionary<uint, TransferConfigData> mTransferConfigDataMap = new Dictionary<uint, TransferConfigData>(); //TransferConfig Data
        public Dictionary<uint, TriggersData> mTriggersDataMap = new Dictionary<uint, TriggersData>(); //Triggers Data
        public Dictionary<uint, ValueRangeRandomData> mValueRangeRandomDataMap = new Dictionary<uint, ValueRangeRandomData>(); //ValueRangeRandom Data
        public Dictionary<uint, VipData> mVipDataMap = new Dictionary<uint, VipData>(); //Vip Data
        public Dictionary<uint, WeddingData> mWeddingDataMap = new Dictionary<uint, WeddingData>(); //Wedding Data
        public Dictionary<uint, WeddingRewardData> mWeddingRewardDataMap = new Dictionary<uint, WeddingRewardData>(); //WeddingReward Data
        public Dictionary<uint, WeddingRingData> mWeddingRingDataMap = new Dictionary<uint, WeddingRingData>(); //WeddingRing Data
        public Dictionary<uint, WorldEventData> mWorldEventDataMap = new Dictionary<uint, WorldEventData>(); //WorldEvent Data
        public Dictionary<uint, WorldEventConditionData> mWorldEventConditionDataMap = new Dictionary<uint, WorldEventConditionData>(); //WorldEventCondition Data
        public Dictionary<uint, WorldEventResultData> mWorldEventResultDataMap = new Dictionary<uint, WorldEventResultData>(); //WorldEventResult Data
        public Dictionary<uint, WrinkleData> mWrinkleDataMap = new Dictionary<uint, WrinkleData>(); //Wrinkle Data

        //加载数据
        public void LoadData()
        {
            LoadDataBinWorker<ActiveDailyData>("ActiveDaily.bytes", mActiveDailyDataMap); //ActiveDaily Data
            LoadDataBinWorker<ActorData>("Actor.bytes", mActorDataMap); //Actor Data
            LoadDataBinWorker<ActorDemandConditionData>("ActorDemandCondition.bytes", mActorDemandConditionDataMap); //ActorDemandCondition Data
            LoadDataBinWorker<ActorDemandGoodsData>("ActorDemandGoods.bytes", mActorDemandGoodsDataMap); //ActorDemandGoods Data
            LoadDataBinWorker<ActorInitialNatureData>("ActorInitialNature.bytes", mActorInitialNatureDataMap); //ActorInitialNature Data
            LoadDataBinWorker<AgeData>("Age.bytes", mAgeDataMap); //Age Data
            LoadDataBinWorker<AgeDifferenceData>("AgeDifference.bytes", mAgeDifferenceDataMap); //AgeDifference Data
            LoadDataBinWorker<AiData>("Ai.bytes", mAiDataMap); //Ai Data
            LoadDataBinWorker<AirFloatData>("AirFloat.bytes", mAirFloatDataMap); //AirFloat Data
            LoadDataBinWorker<AllControlData>("AllControl.bytes", mAllControlDataMap); //AllControl Data
            LoadDataBinWorker<AreaData>("Area.bytes", mAreaDataMap); //Area Data
            LoadDataBinWorker<ArenaBuffData>("ArenaBuff.bytes", mArenaBuffDataMap); //ArenaBuff Data
            LoadDataBinWorker<ArenaLevelData>("ArenaLevel.bytes", mArenaLevelDataMap); //ArenaLevel Data
            LoadDataBinWorker<ArenaSecondConfigData>("ArenaSecondConfig.bytes", mArenaSecondConfigDataMap); //ArenaSecondConfig Data
            LoadDataBinWorker<ArenaWinningStreakData>("ArenaWinningStreak.bytes", mArenaWinningStreakDataMap); //ArenaWinningStreak Data
            LoadDataBinWorker<ArenaWinningStreakRewardData>("ArenaWinningStreakReward.bytes", mArenaWinningStreakRewardDataMap); //ArenaWinningStreakReward Data
            LoadDataBinWorker<AvatarsData>("Avatars.bytes", mAvatarsDataMap); //Avatars Data
            LoadDataBinWorker<BagItemData>("BagItem.bytes", mBagItemDataMap); //BagItem Data
            LoadDataBinWorker<BanquetActorAgeData>("BanquetActorAge.bytes", mBanquetActorAgeDataMap); //BanquetActorAge Data
            LoadDataBinWorker<BanquetBloodPlanData>("BanquetBloodPlan.bytes", mBanquetBloodPlanDataMap); //BanquetBloodPlan Data
            LoadDataBinWorker<BanquetConfigData>("BanquetConfig.bytes", mBanquetConfigDataMap); //BanquetConfig Data
            LoadDataBinWorker<BanquetQuestionData>("BanquetQuestion.bytes", mBanquetQuestionDataMap); //BanquetQuestion Data
            LoadDataBinWorker<BanquetQuestionOptionData>("BanquetQuestionOption.bytes", mBanquetQuestionOptionDataMap); //BanquetQuestionOption Data
            LoadDataBinWorker<BanquetQuestionResultData>("BanquetQuestionResult.bytes", mBanquetQuestionResultDataMap); //BanquetQuestionResult Data
            LoadDataBinWorker<BanquetResultCoefficientData>("BanquetResultCoefficient.bytes", mBanquetResultCoefficientDataMap); //BanquetResultCoefficient Data
            LoadDataBinWorker<BarberPartData>("BarberPart.bytes", mBarberPartDataMap); //BarberPart Data
            LoadDataBinWorker<BattleNatureDisplayData>("BattleNatureDisplay.bytes", mBattleNatureDisplayDataMap); //BattleNatureDisplay Data
            LoadDataBinWorker<BTNodeData>("BTNode.bytes", mBTNodeDataMap); //BTNode Data
            LoadDataBinWorker<BuffsData>("Buffs.bytes", mBuffsDataMap); //Buffs Data
            LoadDataBinWorker<BuildingData>("Building.bytes", mBuildingDataMap); //Building Data
            LoadDataBinWorker<BuildingProduceData>("BuildingProduce.bytes", mBuildingProduceDataMap); //BuildingProduce Data
            LoadDataBinWorker<ButtonData>("Button.bytes", mButtonDataMap); //Button Data
            LoadDataBinWorker<CannotRefinementData>("CannotRefinement.bytes", mCannotRefinementDataMap); //CannotRefinement Data
            LoadDataBinWorker<CastleData>("Castle.bytes", mCastleDataMap); //Castle Data
            LoadDataBinWorker<CastleQueueUnlockData>("CastleQueueUnlock.bytes", mCastleQueueUnlockDataMap); //CastleQueueUnlock Data
            LoadDataBinWorker<ChaEffectConditionData>("ChaEffectCondition.bytes", mChaEffectConditionDataMap); //ChaEffectCondition Data
            LoadDataBinWorker<ChamberOfCommerceData>("ChamberOfCommerce.bytes", mChamberOfCommerceDataMap); //ChamberOfCommerce Data
            LoadDataBinWorker<ChaMixedRaceData>("ChaMixedRace.bytes", mChaMixedRaceDataMap); //ChaMixedRace Data
            LoadDataBinWorker<CharacteristicData>("Characteristic.bytes", mCharacteristicDataMap); //Characteristic Data
            LoadDataBinWorker<ClimbTowerData>("ClimbTower.bytes", mClimbTowerDataMap); //ClimbTower Data
            LoadDataBinWorker<ClimbTowerAnswerData>("ClimbTowerAnswer.bytes", mClimbTowerAnswerDataMap); //ClimbTowerAnswer Data
            LoadDataBinWorker<ClimbTowerCardData>("ClimbTowerCard.bytes", mClimbTowerCardDataMap); //ClimbTowerCard Data
            LoadDataBinWorker<ClimbTowerLevelBuffData>("ClimbTowerLevelBuff.bytes", mClimbTowerLevelBuffDataMap); //ClimbTowerLevelBuff Data
            LoadDataBinWorker<ClimbTowerLevelConfigData>("ClimbTowerLevelConfig.bytes", mClimbTowerLevelConfigDataMap); //ClimbTowerLevelConfig Data
            LoadDataBinWorker<ClimbTowerQuestionData>("ClimbTowerQuestion.bytes", mClimbTowerQuestionDataMap); //ClimbTowerQuestion Data
            LoadDataBinWorker<ClimbTowerShopData>("ClimbTowerShop.bytes", mClimbTowerShopDataMap); //ClimbTowerShop Data
            LoadDataBinWorker<ClmibTowerCountryCardConfigData>("ClmibTowerCountryCardConfig.bytes", mClmibTowerCountryCardConfigDataMap); //ClmibTowerCountryCardConfig Data
            LoadDataBinWorker<ColorData>("Color.bytes", mColorDataMap); //Color Data
            LoadDataBinWorker<ConscriptionBloodExchangeData>("ConscriptionBloodExchange.bytes", mConscriptionBloodExchangeDataMap); //ConscriptionBloodExchange Data
            LoadDataBinWorker<ConscriptionReplyData>("ConscriptionReply.bytes", mConscriptionReplyDataMap); //ConscriptionReply Data
            LoadDataBinWorker<ConscriptionReplyRewardData>("ConscriptionReplyReward.bytes", mConscriptionReplyRewardDataMap); //ConscriptionReplyReward Data
            LoadDataBinWorker<ConscriptionRewardData>("ConscriptionReward.bytes", mConscriptionRewardDataMap); //ConscriptionReward Data
            LoadDataBinWorker<ConstellationChaRandomData>("ConstellationChaRandom.bytes", mConstellationChaRandomDataMap); //ConstellationChaRandom Data
            LoadDataBinWorker<CountryData>("Country.bytes", mCountryDataMap); //Country Data
            LoadDataBinWorker<DescentData>("Descent.bytes", mDescentDataMap); //Descent Data
            LoadDataBinWorker<DescentCoefficientData>("DescentCoefficient.bytes", mDescentCoefficientDataMap); //DescentCoefficient Data
            LoadDataBinWorker<DialogData>("Dialog.bytes", mDialogDataMap); //Dialog Data
            LoadDataBinWorker<EffectConditionsData>("EffectConditions.bytes", mEffectConditionsDataMap); //EffectConditions Data
            LoadDataBinWorker<EffectConsData>("EffectCons.bytes", mEffectConsDataMap); //EffectCons Data
            LoadDataBinWorker<EffectResultsData>("EffectResults.bytes", mEffectResultsDataMap); //EffectResults Data
            LoadDataBinWorker<EffectsData>("Effects.bytes", mEffectsDataMap); //Effects Data
            LoadDataBinWorker<EngagemenEntryData>("EngagemenEntry.bytes", mEngagemenEntryDataMap); //EngagemenEntry Data
            LoadDataBinWorker<EngagementActorAgeData>("EngagementActorAge.bytes", mEngagementActorAgeDataMap); //EngagementActorAge Data
            LoadDataBinWorker<EngagementActorJobsData>("EngagementActorJobs.bytes", mEngagementActorJobsDataMap); //EngagementActorJobs Data
            LoadDataBinWorker<EngagementActorNobilityRangeData>("EngagementActorNobilityRange.bytes", mEngagementActorNobilityRangeDataMap); //EngagementActorNobilityRange Data
            LoadDataBinWorker<EngagementBasicProData>("EngagementBasicPro.bytes", mEngagementBasicProDataMap); //EngagementBasicPro Data
            LoadDataBinWorker<EngagementBloodRuleData>("EngagementBloodRule.bytes", mEngagementBloodRuleDataMap); //EngagementBloodRule Data
            LoadDataBinWorker<EngagementCastleBloodPlanData>("EngagementCastleBloodPlan.bytes", mEngagementCastleBloodPlanDataMap); //EngagementCastleBloodPlan Data
            LoadDataBinWorker<EngagementNobilityBloodData>("EngagementNobilityBlood.bytes", mEngagementNobilityBloodDataMap); //EngagementNobilityBlood Data
            LoadDataBinWorker<EngagementPeachBloodPlanData>("EngagementPeachBloodPlan.bytes", mEngagementPeachBloodPlanDataMap); //EngagementPeachBloodPlan Data
            LoadDataBinWorker<EquipBuffExtractData>("EquipBuffExtract.bytes", mEquipBuffExtractDataMap); //EquipBuffExtract Data
            LoadDataBinWorker<EquipDecomposeData>("EquipDecompose.bytes", mEquipDecomposeDataMap); //EquipDecompose Data
            LoadDataBinWorker<EquipEnchantingData>("EquipEnchanting.bytes", mEquipEnchantingDataMap); //EquipEnchanting Data
            LoadDataBinWorker<EquipEnchantingRefreshData>("EquipEnchantingRefresh.bytes", mEquipEnchantingRefreshDataMap); //EquipEnchantingRefresh Data
            LoadDataBinWorker<EquipEnchantingResultsData>("EquipEnchantingResults.bytes", mEquipEnchantingResultsDataMap); //EquipEnchantingResults Data
            LoadDataBinWorker<EquipmentAnimatorData>("EquipmentAnimator.bytes", mEquipmentAnimatorDataMap); //EquipmentAnimator Data
            LoadDataBinWorker<EquipmentsData>("Equipments.bytes", mEquipmentsDataMap); //Equipments Data
            LoadDataBinWorker<EquipmentsRangeData>("EquipmentsRange.bytes", mEquipmentsRangeDataMap); //EquipmentsRange Data
            LoadDataBinWorker<EquipmentTypeData>("EquipmentType.bytes", mEquipmentTypeDataMap); //EquipmentType Data
            LoadDataBinWorker<EquipPromoteData>("EquipPromote.bytes", mEquipPromoteDataMap); //EquipPromote Data
            LoadDataBinWorker<EquipRandomNatureData>("EquipRandomNature.bytes", mEquipRandomNatureDataMap); //EquipRandomNature Data
            LoadDataBinWorker<EquipRefinementData>("EquipRefinement.bytes", mEquipRefinementDataMap); //EquipRefinement Data
            LoadDataBinWorker<EquipSCData>("EquipSC.bytes", mEquipSCDataMap); //EquipSC Data
            LoadDataBinWorker<EquipSourceData>("EquipSource.bytes", mEquipSourceDataMap); //EquipSource Data
            LoadDataBinWorker<EquipStrengthenData>("EquipStrengthen.bytes", mEquipStrengthenDataMap); //EquipStrengthen Data
            LoadDataBinWorker<ExteriorPartData>("ExteriorPart.bytes", mExteriorPartDataMap); //ExteriorPart Data
            LoadDataBinWorker<FemaleDataData>("FemaleData.bytes", mFemaleDataDataMap); //FemaleData Data
            LoadDataBinWorker<FestivalData>("Festival.bytes", mFestivalDataMap); //Festival Data
            LoadDataBinWorker<FestivalExchangeData>("FestivalExchange.bytes", mFestivalExchangeDataMap); //FestivalExchange Data
            LoadDataBinWorker<FestivalOptionData>("FestivalOption.bytes", mFestivalOptionDataMap); //FestivalOption Data
            LoadDataBinWorker<FestivalPeachConfigData>("FestivalPeachConfig.bytes", mFestivalPeachConfigDataMap); //FestivalPeachConfig Data
            LoadDataBinWorker<FestivalPeachNobilityData>("FestivalPeachNobility.bytes", mFestivalPeachNobilityDataMap); //FestivalPeachNobility Data
            LoadDataBinWorker<FestivalWrestleData>("FestivalWrestle.bytes", mFestivalWrestleDataMap); //FestivalWrestle Data
            LoadDataBinWorker<FlagData>("Flag.bytes", mFlagDataMap); //Flag Data
            LoadDataBinWorker<FlowerGirlsChaData>("FlowerGirlsCha.bytes", mFlowerGirlsChaDataMap); //FlowerGirlsCha Data
            LoadDataBinWorker<FunctionExplainData>("FunctionExplain.bytes", mFunctionExplainDataMap); //FunctionExplain Data
            LoadDataBinWorker<GemInlayConfigData>("GemInlayConfig.bytes", mGemInlayConfigDataMap); //GemInlayConfig Data
            LoadDataBinWorker<GemSlotRefreshData>("GemSlotRefresh.bytes", mGemSlotRefreshDataMap); //GemSlotRefresh Data
            LoadDataBinWorker<GemUpgradeData>("GemUpgrade.bytes", mGemUpgradeDataMap); //GemUpgrade Data
            LoadDataBinWorker<GoodsData>("Goods.bytes", mGoodsDataMap); //Goods Data
            LoadDataBinWorker<GoodsFluctuateData>("GoodsFluctuate.bytes", mGoodsFluctuateDataMap); //GoodsFluctuate Data
            LoadDataBinWorker<GoodsGroupData>("GoodsGroup.bytes", mGoodsGroupDataMap); //GoodsGroup Data
            LoadDataBinWorker<GoodsNumRandomData>("GoodsNumRandom.bytes", mGoodsNumRandomDataMap); //GoodsNumRandom Data
            LoadDataBinWorker<HeroNatureRuleData>("HeroNatureRule.bytes", mHeroNatureRuleDataMap); //HeroNatureRule Data
            LoadDataBinWorker<HerosData>("Heros.bytes", mHerosDataMap); //Heros Data
            LoadDataBinWorker<InjuryData>("Injury.bytes", mInjuryDataMap); //Injury Data
            LoadDataBinWorker<InjuryWorsenData>("InjuryWorsen.bytes", mInjuryWorsenDataMap); //InjuryWorsen Data
            LoadDataBinWorker<JobsData>("Jobs.bytes", mJobsDataMap); //Jobs Data
            LoadDataBinWorker<LegionActorDemandData>("LegionActorDemand.bytes", mLegionActorDemandDataMap); //LegionActorDemand Data
            LoadDataBinWorker<LegionBuffUnlockData>("LegionBuffUnlock.bytes", mLegionBuffUnlockDataMap); //LegionBuffUnlock Data
            LoadDataBinWorker<LegionSacredBindindData>("LegionSacredBindind.bytes", mLegionSacredBindindDataMap); //LegionSacredBindind Data
            LoadDataBinWorker<LegionSacredEffectData>("LegionSacredEffect.bytes", mLegionSacredEffectDataMap); //LegionSacredEffect Data
            LoadDataBinWorker<LegionSacredEffectNatureData>("LegionSacredEffectNature.bytes", mLegionSacredEffectNatureDataMap); //LegionSacredEffectNature Data
            LoadDataBinWorker<LegionSacredEffectUpgradeData>("LegionSacredEffectUpgrade.bytes", mLegionSacredEffectUpgradeDataMap); //LegionSacredEffectUpgrade Data
            LoadDataBinWorker<LegionSacredUpgradeData>("LegionSacredUpgrade.bytes", mLegionSacredUpgradeDataMap); //LegionSacredUpgrade Data
            LoadDataBinWorker<LevelData>("Level.bytes", mLevelDataMap); //Level Data
            LoadDataBinWorker<LevelConstData>("LevelConst.bytes", mLevelConstDataMap); //LevelConst Data
            LoadDataBinWorker<LevelResultData>("LevelResult.bytes", mLevelResultDataMap); //LevelResult Data
            LoadDataBinWorker<LevelUpData>("LevelUp.bytes", mLevelUpDataMap); //LevelUp Data
            LoadDataBinWorker<lvleffectData>("lvleffect.bytes", mlvleffectDataMap); //lvleffect Data
            LoadDataBinWorker<MailData>("Mail.bytes", mMailDataMap); //Mail Data
            LoadDataBinWorker<MonstersData>("Monsters.bytes", mMonstersDataMap); //Monsters Data
            LoadDataBinWorker<MoraleData>("Morale.bytes", mMoraleDataMap); //Morale Data
            LoadDataBinWorker<MoraleActionData>("MoraleAction.bytes", mMoraleActionDataMap); //MoraleAction Data
            LoadDataBinWorker<NamesData>("Names.bytes", mNamesDataMap); //Names Data
            LoadDataBinWorker<NatureIdExplainData>("NatureIdExplain.bytes", mNatureIdExplainDataMap); //NatureIdExplain Data
            LoadDataBinWorker<NewsTickerData>("NewsTicker.bytes", mNewsTickerDataMap); //NewsTicker Data
            LoadDataBinWorker<NobilityData>("Nobility.bytes", mNobilityDataMap); //Nobility Data
            LoadDataBinWorker<PageData>("Page.bytes", mPageDataMap); //Page Data
            LoadDataBinWorker<PageControlData>("PageControl.bytes", mPageControlDataMap); //PageControl Data
            LoadDataBinWorker<PlayerShortBuffsData>("PlayerShortBuffs.bytes", mPlayerShortBuffsDataMap); //PlayerShortBuffs Data
            LoadDataBinWorker<PositionData>("Position.bytes", mPositionDataMap); //Position Data
            LoadDataBinWorker<PositionJobEffectData>("PositionJobEffect.bytes", mPositionJobEffectDataMap); //PositionJobEffect Data
            LoadDataBinWorker<PrestigeData>("Prestige.bytes", mPrestigeDataMap); //Prestige Data
            LoadDataBinWorker<RankConfigData>("RankConfig.bytes", mRankConfigDataMap); //RankConfig Data
            LoadDataBinWorker<RankCycleConfigData>("RankCycleConfig.bytes", mRankCycleConfigDataMap); //RankCycleConfig Data
            LoadDataBinWorker<RankFirstConfigData>("RankFirstConfig.bytes", mRankFirstConfigDataMap); //RankFirstConfig Data
            LoadDataBinWorker<RankRelationData>("RankRelation.bytes", mRankRelationDataMap); //RankRelation Data
            LoadDataBinWorker<RankRewardData>("RankReward.bytes", mRankRewardDataMap); //RankReward Data
            LoadDataBinWorker<RateData>("Rate.bytes", mRateDataMap); //Rate Data
            LoadDataBinWorker<RefinementRandomProData>("RefinementRandomPro.bytes", mRefinementRandomProDataMap); //RefinementRandomPro Data
            LoadDataBinWorker<ReplyData>("Reply.bytes", mReplyDataMap); //Reply Data
            LoadDataBinWorker<RewardGroupData>("RewardGroup.bytes", mRewardGroupDataMap); //RewardGroup Data
            LoadDataBinWorker<RunTaskNumRandomData>("RunTaskNumRandom.bytes", mRunTaskNumRandomDataMap); //RunTaskNumRandom Data
            LoadDataBinWorker<SchoolChaDropData>("SchoolChaDrop.bytes", mSchoolChaDropDataMap); //SchoolChaDrop Data
            LoadDataBinWorker<SchoolChaRandomResultData>("SchoolChaRandomResult.bytes", mSchoolChaRandomResultDataMap); //SchoolChaRandomResult Data
            LoadDataBinWorker<ShopData>("Shop.bytes", mShopDataMap); //Shop Data
            LoadDataBinWorker<ShopGoodsData>("ShopGoods.bytes", mShopGoodsDataMap); //ShopGoods Data
            LoadDataBinWorker<ShopWeekData>("ShopWeek.bytes", mShopWeekDataMap); //ShopWeek Data
            LoadDataBinWorker<SignCycleRewardData>("SignCycleReward.bytes", mSignCycleRewardDataMap); //SignCycleReward Data
            LoadDataBinWorker<SignDailyData>("SignDaily.bytes", mSignDailyDataMap); //SignDaily Data
            LoadDataBinWorker<SixDimensionTransferData>("SixDimensionTransfer.bytes", mSixDimensionTransferDataMap); //SixDimensionTransfer Data
            LoadDataBinWorker<SkillBasicFightingData>("SkillBasicFighting.bytes", mSkillBasicFightingDataMap); //SkillBasicFighting Data
            LoadDataBinWorker<SkillLevelCoefficientData>("SkillLevelCoefficient.bytes", mSkillLevelCoefficientDataMap); //SkillLevelCoefficient Data
            LoadDataBinWorker<SkillsData>("Skills.bytes", mSkillsDataMap); //Skills Data
            LoadDataBinWorker<SkillStudyConfigData>("SkillStudyConfig.bytes", mSkillStudyConfigDataMap); //SkillStudyConfig Data
            LoadDataBinWorker<StatusData>("Status.bytes", mStatusDataMap); //Status Data
            LoadDataBinWorker<StringsData>("Strings.bytes", mStringsDataMap); //Strings Data
            LoadDataBinWorker<TaskData>("Task.bytes", mTaskDataMap); //Task Data
            LoadDataBinWorker<TaskAttainmentData>("TaskAttainment.bytes", mTaskAttainmentDataMap); //TaskAttainment Data
            LoadDataBinWorker<TaskBasicNatureData>("TaskBasicNature.bytes", mTaskBasicNatureDataMap); //TaskBasicNature Data
            LoadDataBinWorker<TaskCityData>("TaskCity.bytes", mTaskCityDataMap); //TaskCity Data
            LoadDataBinWorker<TaskdailyData>("Taskdaily.bytes", mTaskdailyDataMap); //Taskdaily Data
            LoadDataBinWorker<TaskDropData>("TaskDrop.bytes", mTaskDropDataMap); //TaskDrop Data
            LoadDataBinWorker<TaskEntrustData>("TaskEntrust.bytes", mTaskEntrustDataMap); //TaskEntrust Data
            LoadDataBinWorker<TaskEntrustOverviewData>("TaskEntrustOverview.bytes", mTaskEntrustOverviewDataMap); //TaskEntrustOverview Data
            LoadDataBinWorker<TaskEntrustRequirementConditionData>("TaskEntrustRequirementCondition.bytes", mTaskEntrustRequirementConditionDataMap); //TaskEntrustRequirementCondition Data
            LoadDataBinWorker<TaskEntrustRequirementRandomData>("TaskEntrustRequirementRandom.bytes", mTaskEntrustRequirementRandomDataMap); //TaskEntrustRequirementRandom Data
            LoadDataBinWorker<TaskMainData>("TaskMain.bytes", mTaskMainDataMap); //TaskMain Data
            LoadDataBinWorker<TaskMainStoryData>("TaskMainStory.bytes", mTaskMainStoryDataMap); //TaskMainStory Data
            LoadDataBinWorker<TavernData>("Tavern.bytes", mTavernDataMap); //Tavern Data
            LoadDataBinWorker<TeachSuccessRateData>("TeachSuccessRate.bytes", mTeachSuccessRateDataMap); //TeachSuccessRate Data
            LoadDataBinWorker<TeachSuccessRateDesData>("TeachSuccessRateDes.bytes", mTeachSuccessRateDesDataMap); //TeachSuccessRateDes Data
            LoadDataBinWorker<TeamBattleData>("TeamBattle.bytes", mTeamBattleDataMap); //TeamBattle Data
            LoadDataBinWorker<TeamBattleBuffsData>("TeamBattleBuffs.bytes", mTeamBattleBuffsDataMap); //TeamBattleBuffs Data
            LoadDataBinWorker<TeamBattleInvitationCodeData>("TeamBattleInvitationCode.bytes", mTeamBattleInvitationCodeDataMap); //TeamBattleInvitationCode Data
            LoadDataBinWorker<TeamBattleMainRewardData>("TeamBattleMainReward.bytes", mTeamBattleMainRewardDataMap); //TeamBattleMainReward Data
            LoadDataBinWorker<TopographyBuffData>("TopographyBuff.bytes", mTopographyBuffDataMap); //TopographyBuff Data
            LoadDataBinWorker<Training_ExperienceData>("Training_Experience.bytes", mTraining_ExperienceDataMap); //Training_Experience Data
            LoadDataBinWorker<Training_Experience_EventData>("Training_Experience_Event.bytes", mTraining_Experience_EventDataMap); //Training_Experience_Event Data
            LoadDataBinWorker<Training_Experience_EventRewardData>("Training_Experience_EventReward.bytes", mTraining_Experience_EventRewardDataMap); //Training_Experience_EventReward Data
            LoadDataBinWorker<Training_Experience_EventTriggerData>("Training_Experience_EventTrigger.bytes", mTraining_Experience_EventTriggerDataMap); //Training_Experience_EventTrigger Data
            LoadDataBinWorker<Training_Experience_RewardData>("Training_Experience_Reward.bytes", mTraining_Experience_RewardDataMap); //Training_Experience_Reward Data
            LoadDataBinWorker<TransferConfigData>("TransferConfig.bytes", mTransferConfigDataMap); //TransferConfig Data
            LoadDataBinWorker<TriggersData>("Triggers.bytes", mTriggersDataMap); //Triggers Data
            LoadDataBinWorker<ValueRangeRandomData>("ValueRangeRandom.bytes", mValueRangeRandomDataMap); //ValueRangeRandom Data
            LoadDataBinWorker<VipData>("Vip.bytes", mVipDataMap); //Vip Data
            LoadDataBinWorker<WeddingData>("Wedding.bytes", mWeddingDataMap); //Wedding Data
            LoadDataBinWorker<WeddingRewardData>("WeddingReward.bytes", mWeddingRewardDataMap); //WeddingReward Data
            LoadDataBinWorker<WeddingRingData>("WeddingRing.bytes", mWeddingRingDataMap); //WeddingRing Data
            LoadDataBinWorker<WorldEventData>("WorldEvent.bytes", mWorldEventDataMap); //WorldEvent Data
            LoadDataBinWorker<WorldEventConditionData>("WorldEventCondition.bytes", mWorldEventConditionDataMap); //WorldEventCondition Data
            LoadDataBinWorker<WorldEventResultData>("WorldEventResult.bytes", mWorldEventResultDataMap); //WorldEventResult Data
            LoadDataBinWorker<WrinkleData>("Wrinkle.bytes", mWrinkleDataMap); //Wrinkle Data


            //定义如型： void SheetNameDataProcess(ClassType data) 的函数, 会被自动调用

            //设置进度
            Console.WriteLine("Read All Data Done!");
        }

        //根据指定的数据文件名，创建流。 参数格式：“Strings.bytes”
        private Stream OpenBinDataFile(string filename)
        {//
            var path = FolderCfg.BinFolder() + filename.Substring(0, filename.Length - 6);
            path = path.Replace('\\', '/');
            return FileDes.DecryptDataToStream(ConfigManager.Instance.LoadConfigBytes(path));

        }

        void LoadDataBinWorker<ClassType>(string filename, object dic, Action<ClassType> process = null) where ClassType : BaseDataObject, new()
        {
            Dictionary<uint, ClassType> dataMap = dic as Dictionary<uint, ClassType>;

            BinaryReader br = null;
            Stream ds = OpenBinDataFile(filename);
            br = new BinaryReader(ds);
            try
            {
                while (true)
                {
                    ClassType tNewData = new ClassType();
                    tNewData.ReadFromStream(br);
                    dataMap.Add(tNewData.mID, tNewData);
                    if (process != null)
                    {
                        process(tNewData);
                    }
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine(filename + "Load Data Done");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                br.Close();
                FileDes.CloseStream();
            }
            return;
        }
    }//class
    //数据结构基类
    public abstract class BaseDataObject
    {
        public uint mID = 0; // ID
        public abstract void ReadFromStream(BinaryReader br);
    }

    public class StringMgr
    {
        enum ELanguage
        {
            English,
            S_Chinese, //简体
            T_Chinese //繁体
        }
        static bool mInitialized = false;
        static ELanguage mLanguage = ELanguage.English;
        static Dictionary<string, uint> mRefNameToIDMap = new Dictionary<string, uint>();
        static void Initialize()
        {
            mInitialized = true;
            if (Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
                mLanguage = ELanguage.S_Chinese;
            else if (Application.systemLanguage == SystemLanguage.ChineseTraditional)
                mLanguage = ELanguage.T_Chinese;
            else
                mLanguage = ELanguage.English;
            //建立引用名到ID的映射
            mRefNameToIDMap.Clear();
            foreach (var sd in StaticDataMgr.Instance.mStringsDataMap)
            {
                mRefNameToIDMap.Add(sd.Value.mRefName, sd.Key);
            }
        }

        public static string GetByID(uint strID)
        {
            return Get(strID);
        }
        //查找字符串数据
        public static string Get(uint strID)
        {
            if (mInitialized == false)
                Initialize();
            if (StaticDataMgr.Instance.mStringsDataMap.ContainsKey(strID) == false)
                return "";
            return StaticDataMgr.Instance.mStringsDataMap[strID].mStrings[(int)mLanguage];
        }
        //用引用名称查找字符串
        public static string Get(string refName)
        {
            if (mInitialized == false)
                Initialize();
            string retValue = "";
            if (mRefNameToIDMap.ContainsKey(refName))
            {
                retValue = GetByID(mRefNameToIDMap[refName]);
            }
            return retValue;
        }
        public static bool IsChinese_S
        {
            get
            {
                if (mInitialized == false)
                    Initialize();
                return (mLanguage == ELanguage.S_Chinese);
            }
        }
        public static bool IsChinese_T
        {
            get
            {
                if (mInitialized == false)
                    Initialize();
                return (mLanguage == ELanguage.T_Chinese);
            }
        }
    }
}


