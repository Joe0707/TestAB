using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class BuildingDatas
    {
        static BuildingDatas mInstance = null;
        public static BuildingDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new BuildingDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, BuildingData>> mBuildingDataDic = new Dictionary<int, Dictionary<int, BuildingData>>();
        public void LoadBuildingData()
        {
            var data = StaticData.StaticDataMgr.Instance.mBuildingDataMap;
            foreach (var item in data)
            {
                var value = item.Value;
                if (mBuildingDataDic.ContainsKey(value.buildingType) == false)
                {
                    Dictionary<int, BuildingData> buildData = new Dictionary<int, BuildingData>();
                    mBuildingDataDic.Add(value.buildingType, buildData);
                }
                mBuildingDataDic[value.buildingType].Add(value.buildingLevel, value);
            }
        }

    }
}