using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;

namespace GameData
{
    public class ClimbTowerLevelDatas
    {
        static ClimbTowerLevelDatas mInstance = null;
        public static ClimbTowerLevelDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new ClimbTowerLevelDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, ClimbTowerLevelConfigData>> mClimbTowerLevelDataDic = new Dictionary<int, Dictionary<int, ClimbTowerLevelConfigData>>();
        public void Init()
        {
            var data = StaticData.StaticDataMgr.Instance.mClimbTowerLevelConfigDataMap;
            int tower = 1;
            int floor = 1;
            foreach (var item in data)
            {
                var value = item.Value;
                if (mClimbTowerLevelDataDic.ContainsKey(value.towerType) == false)
                {
                    Dictionary<int, ClimbTowerLevelConfigData> floorData = new Dictionary<int, ClimbTowerLevelConfigData>();
                    mClimbTowerLevelDataDic.Add(value.towerType, floorData);
                }
                if (value.towerType == tower)
                {
                    mClimbTowerLevelDataDic[value.towerType].Add(floor, value);
                    floor++;
                }
                else
                {
                    tower++;
                    floor = 1;
                    mClimbTowerLevelDataDic[value.towerType].Add(floor, value);
                    floor++;
                }
            }
        }
    }
}