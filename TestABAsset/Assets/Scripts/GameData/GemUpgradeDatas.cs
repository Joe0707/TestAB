using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class GemUpgradeDatas
    {
        static GemUpgradeDatas mInstance = null;
        public static GemUpgradeDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new GemUpgradeDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, GemUpgradeData>> mGemHighLevelSynthesis = new Dictionary<int, Dictionary<int, GemUpgradeData>>();
        public Dictionary<int, GemUpgradeData> mGemUpgrade = new Dictionary<int, GemUpgradeData>();
        public void LoadGemUpgradeDatas()
        {
            foreach (var item in StaticData.StaticDataMgr.Instance.mGemUpgradeDataMap)
            {
                if (item.Value.level > 1)
                {
                    string[] itemString = item.Value.upGradeNeedNum.Split(';');
                    if (itemString.Length > 1)
                    {
                        //mMonthCityDataDic.ContainsKey(value.month)
                        //需要两个宝石才能生成（高级合成）
                        string[] item1 = itemString[0].Split(',');
                        string[] item2 = itemString[1].Split(',');
                        if (mGemHighLevelSynthesis.ContainsKey(int.Parse(item1[0])) == false)
                        {
                            mGemHighLevelSynthesis[int.Parse(item1[0])] = new Dictionary<int, GemUpgradeData>();
                        }
                        mGemHighLevelSynthesis[int.Parse(item1[0])][int.Parse(item2[0])] = item.Value;

                        if (mGemHighLevelSynthesis.ContainsKey(int.Parse(item2[0])) == false)
                        {
                            mGemHighLevelSynthesis[int.Parse(item2[0])] = new Dictionary<int, GemUpgradeData>();
                        }
                        mGemHighLevelSynthesis[int.Parse(item2[0])][int.Parse(item1[0])] = item.Value;
                    }
                    else
                    {
                        //需要一个宝石就能生成（升级）
                        string[] item1 = itemString[0].Split(',');
                        mGemUpgrade[int.Parse(item1[0])] = item.Value;
                    }
                }
            }
        }
    }
}