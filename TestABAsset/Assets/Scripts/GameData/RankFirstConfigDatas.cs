using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
using System;
namespace GameData
{
    public class RankFirstConfigDatas
    {
        static RankFirstConfigDatas mInstance = null;
        public static RankFirstConfigDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new RankFirstConfigDatas();
                return mInstance;
            }
        }
        public List<RankFirstConfigData> rankFirstConfigList = new List<RankFirstConfigData>();
        public void LoadRankFirstConfigData()
        {
            var rankFirstConfigDataMap = StaticData.StaticDataMgr.Instance.mRankFirstConfigDataMap;
            foreach (var rankFirstConfig in rankFirstConfigDataMap)
            {
                var value = rankFirstConfig.Value;
                rankFirstConfigList.Add(value);
            }
            rankFirstConfigList.Sort((a, b) => a.displaySort.CompareTo(b.displaySort));
        }
    }
}