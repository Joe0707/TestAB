using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
using System;
namespace GameData
{
    public class RankRewardDatas
    {
        static RankRewardDatas mInstance = null;
        public static RankRewardDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new RankRewardDatas();
                return mInstance;
            }
        }
        public Dictionary<int, List<RankRewardData>> rankRewardDataDic = new Dictionary<int, List<RankRewardData>>(); //榜单ID，榜单奖励
        public void LoadRankRewardData()
        {
            var mRankRewardDataMap = StaticData.StaticDataMgr.Instance.mRankRewardDataMap;
            foreach (var rankRewardData in mRankRewardDataMap)
            {
                var value = rankRewardData.Value;
                if (rankRewardDataDic.ContainsKey(value.rewardType) == false)
                {
                    rankRewardDataDic[value.rewardType] = new List<RankRewardData>();
                }
                rankRewardDataDic[value.rewardType].Add(value);
            }
        }
        public string GetRankReward(int rewardType, int rank) //所属榜单，人物排名
        {
            uint reward_mID = 0;
            for (int i = 0; i < rankRewardDataDic[rewardType].Count; i++)
            {
                if (rank < rankRewardDataDic[rewardType][i].rank)
                    break;
                else
                    reward_mID = rankRewardDataDic[rewardType][i].mID;
            }
            if (reward_mID == 0)
                return "";
            else
                return StaticData.StaticDataMgr.Instance.mRankRewardDataMap[reward_mID].rankReward;
        }
        public int GetNextRewardNeedUp(int rewardType, int rank) //距离下一档奖励还需提升多少名
        {
            if (rank <= 1)
                return 0;
            else
            {
                int index = 0;
                for (int i = 0; i < rankRewardDataDic[rewardType].Count; i++)
                {
                    if (rank < rankRewardDataDic[rewardType][i].rank)
                        break;
                    else
                        index = i;
                }
                return rank - rankRewardDataDic[rewardType][index - 1].rank;
            }
        }
    }
}
