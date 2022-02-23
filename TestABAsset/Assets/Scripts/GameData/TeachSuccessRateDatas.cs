using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class TeachSuccessRateDatas
    {
        static TeachSuccessRateDatas mInstance = null;
        public static TeachSuccessRateDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new TeachSuccessRateDatas();
                return mInstance;
            }
        }
        public Dictionary<string, Dictionary<int, TeachSuccessRateData>> mTeachSuccessRateDataDic = new Dictionary<string, Dictionary<int, TeachSuccessRateData>>();
        public void LoadTeachSuccessRateData()
        {
            var data = StaticData.StaticDataMgr.Instance.mTeachSuccessRateDataMap;
            foreach (var item in data)
            {
                var value = item.Value;
                if (mTeachSuccessRateDataDic.ContainsKey(value.skillSlotType) == false)
                {
                    Dictionary<int, TeachSuccessRateData> teachSuccessRateData = new Dictionary<int, TeachSuccessRateData>();
                    mTeachSuccessRateDataDic.Add(value.skillSlotType, teachSuccessRateData);
                }
                mTeachSuccessRateDataDic[value.skillSlotType].Add(value.skillLevel, value);
            }
        }
    }
}