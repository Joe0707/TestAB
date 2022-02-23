using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class VipDatas
    {
        static VipDatas mInstance = null;
        public static VipDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new VipDatas();
                return mInstance;
            }
        }
        public Dictionary<int, VipData> mVipDataDic = new Dictionary<int, VipData>();
        public void LoadMonthData()
        {
            var vipDataMap = StaticData.StaticDataMgr.Instance.mVipDataMap;
            foreach (var vip in vipDataMap)
            {
                var value = vip.Value;
                mVipDataDic[value.vipLevel] = value;
            }
        }
        public VipData GetVipLevelData(int vipLevel)
        {
            if (mVipDataDic[vipLevel] != null)
            {
                return mVipDataDic[vipLevel];
            }
            else
            {
                return null;
            }
        }
    }
}