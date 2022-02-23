using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class BuffsDatas
    {
        static BuffsDatas mInstance = null;
        public static BuffsDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new BuffsDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, BuffsData>> mBuffsDataDic = new Dictionary<int, Dictionary<int, BuffsData>>();
        public void LoadBuffData()
        {
            var data = StaticData.StaticDataMgr.Instance.mBuffsDataMap;
            foreach (var item in data)
            {
                var value = item.Value;
                if (mBuffsDataDic.ContainsKey(value.mbuffId) == false)
                {
                    Dictionary<int, BuffsData> buffData = new Dictionary<int, BuffsData>();
                    mBuffsDataDic.Add(value.mbuffId, buffData);
                }
                mBuffsDataDic[value.mbuffId].Add(value.buffLevel, value);
            }
        }
    }
}