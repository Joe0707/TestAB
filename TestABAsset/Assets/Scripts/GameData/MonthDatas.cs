using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class MonthDatas
    {

        static MonthDatas mInstance = null;
        public static MonthDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new MonthDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<uint, FestivalData>> mMonthDataDic = new Dictionary<int, Dictionary<uint, FestivalData>>(); //月份->节日->数据
        public Dictionary<int, Dictionary<int, FestivalData>> mMonthCityDataDic = new Dictionary<int, Dictionary<int, FestivalData>>(); //月份->城市ID->数据
        public Dictionary<int, List<FestivalOptionData>> mFestivalOptionDic = new Dictionary<int, List<FestivalOptionData>>(); //节日->选项
        public void LoadMonthData()
        {
            var festival = StaticData.StaticDataMgr.Instance.mFestivalDataMap;
            foreach (var item in festival)
            {
                var value = item.Value;
                if (mMonthDataDic.ContainsKey(value.month) == false)
                {
                    mMonthDataDic[value.month] = new Dictionary<uint, FestivalData>();
                }
                mMonthDataDic[value.month][value.mID] = value;
                //月份->城市
                string openCity = value.openCity;
                string[] strArr = openCity.Split(',');
                if (mMonthCityDataDic.ContainsKey(value.month) == false)
                {
                    mMonthCityDataDic[value.month] = new Dictionary<int, FestivalData>();
                }
                for (int i = 0; i <= strArr.Length - 1; i++)
                {
                    mMonthCityDataDic[value.month][int.Parse(strArr[i])] = value;
                }
            }
            var mFestivalOption = StaticData.StaticDataMgr.Instance.mFestivalOptionDataMap;
            foreach (var item in mFestivalOption)
            {
                var value = item.Value;
                if (mFestivalOptionDic.ContainsKey(value.festivalID) == false)
                {
                    mFestivalOptionDic[value.festivalID] = new List<FestivalOptionData>();
                }
                mFestivalOptionDic[value.festivalID].Add(value);
            }
        }
        public FestivalData GetMonthCityData(int month, int cityID)
        {
            if (mMonthCityDataDic[month].ContainsKey(cityID))
            {
                return mMonthCityDataDic[month][cityID];
            }
            else
            {
                return null;
            }
        }
    }
}