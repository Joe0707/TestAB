using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class ConscriptionRewardDatas
    {
        static ConscriptionRewardDatas mInstance = null;
        public static ConscriptionRewardDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new ConscriptionRewardDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, ConscriptionRewardData>> conscriptionRewardDic = new Dictionary<int, Dictionary<int, ConscriptionRewardData>>();
        public void LoadConscriptionRewardData()
        {
            var data = StaticData.StaticDataMgr.Instance.mConscriptionRewardDataMap;
            foreach (var item in data)
            {
                var value = item.Value;
                if (conscriptionRewardDic.ContainsKey(value.countryID) == false)
                {
                    Dictionary<int, ConscriptionRewardData> conscriptionRewardData = new Dictionary<int, ConscriptionRewardData>();
                    conscriptionRewardDic.Add(value.countryID, conscriptionRewardData);
                }
                conscriptionRewardDic[value.countryID].Add(value.SixDimension, value);
            }
        }
        public ConscriptionRewardData GetConscriptionRewardDataa(int countryID, int sixDimension)
        {
            if (conscriptionRewardDic[countryID].ContainsKey(sixDimension))
            {
                return conscriptionRewardDic[countryID][sixDimension];
            }
            else
            {
                return null;
            }
        }
    }
}