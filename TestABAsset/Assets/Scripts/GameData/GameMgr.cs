using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    public class GameMgr
    {
        static GameMgr mInstance = null;
        public static GameMgr Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new GameMgr();
                return mInstance;
            }
        }

        public void Init()
        {
            BuildingDatas.Instance.LoadBuildingData();
            MonthDatas.Instance.LoadMonthData();
            BuffsDatas.Instance.LoadBuffData();
            SkillsDatas.Instance.LoadSkillData();
            VipDatas.Instance.LoadMonthData();
            TeachSuccessRateDatas.Instance.LoadTeachSuccessRateData();
            FlagDatas.Instance.LoadFlagData();
            //加载转职表
            ReadTransferConfigData.LoadTransferConfigData();
            //加载宝石升级表
            GemUpgradeDatas.Instance.LoadGemUpgradeDatas();
            //加载六维获取物资表
            ConscriptionRewardDatas.Instance.LoadConscriptionRewardData();
            //加载排行榜表
            RankConfigDatas.Instance.LoadRankConfigData();
            //加载排行榜奖励
            RankRewardDatas.Instance.LoadRankRewardData();
            //加载排行榜一级表
            RankFirstConfigDatas.Instance.LoadRankFirstConfigData();//拼脸数据加载
            DataRelationMgr.Instance.Init();
            DescentColorMgr.Instance.Init();
            PartPositionMgr.Instance.Init();
            PartResourceMgr.Instance.Init();
            PaintingMgr.Instance.Init();
            //加载爬塔表
            ClimbTowerLevelDatas.Instance.Init();
        }
    }

}