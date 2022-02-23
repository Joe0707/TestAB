using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
using System;
namespace GameData
{
    public class RankConfigDatas
    {
        static RankConfigDatas mInstance = null;
        public static RankConfigDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new RankConfigDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, Dictionary<int, int>>> mrankRelationDic = new Dictionary<int, Dictionary<int, Dictionary<int, int>>>(); //排行榜界面字典
        public Dictionary<int, Dictionary<int, RankRelationData>> secondOptionDic = new Dictionary<int, Dictionary<int, RankRelationData>>(); //二级分类字典
        public void LoadRankConfigData()
        {
            var rankRelationData = StaticData.StaticDataMgr.Instance.mRankRelationDataMap;
            foreach (var rankRelation in rankRelationData)
            {
                var value = rankRelation.Value;
                if (mrankRelationDic.ContainsKey(value.firstType) == false)
                {
                    mrankRelationDic[value.firstType] = new Dictionary<int, Dictionary<int, int>>();
                }
                if (mrankRelationDic[value.firstType].ContainsKey(Convert.ToInt32(value.mID)) == false)
                {
                    mrankRelationDic[value.firstType][Convert.ToInt32(value.mID)] = new Dictionary<int, int>();
                }
                string[] thirdTimeType = value.thirdTimeType.Split(',');
                string[] thirdRankID = value.thirdRankID.Split(',');
                for (int i = 0; i < thirdTimeType.Length; i++)
                {
                    mrankRelationDic[value.firstType][Convert.ToInt32(value.mID)][int.Parse(thirdTimeType[i])] = int.Parse(thirdRankID[i]);
                }
                if (secondOptionDic.ContainsKey(value.firstType) == false)
                {
                    secondOptionDic[value.firstType] = new Dictionary<int, RankRelationData>();
                }
                secondOptionDic[value.firstType][Convert.ToInt32(value.mID)] = value;
            }
        }
        public int GetIsHaveTimeType(int fristOption, int secondOption, int timeType)
        {
            if (mrankRelationDic[fristOption][secondOption].ContainsKey(timeType) == true)
            {
                return mrankRelationDic[fristOption][secondOption][timeType];
            }
            else
            {
                return 0;
            }
        }
    }
}
