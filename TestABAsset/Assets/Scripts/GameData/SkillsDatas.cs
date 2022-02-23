using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData.Data;
namespace GameData
{
    public class SkillsDatas
    {
        static SkillsDatas mInstance = null;
        public static SkillsDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new SkillsDatas();
                return mInstance;
            }
        }
        public Dictionary<int, Dictionary<int, SkillsData>> mSkillsDataDic = new Dictionary<int, Dictionary<int, SkillsData>>();
        public void LoadSkillData()
        {
            var data = StaticData.StaticDataMgr.Instance.mSkillsDataMap;
            foreach (var item in data)
            {
                var value = item.Value;
                if (mSkillsDataDic.ContainsKey(value.skillId) == false)
                {
                    Dictionary<int, SkillsData> skillData = new Dictionary<int, SkillsData>();
                    mSkillsDataDic.Add(value.skillId, skillData);
                }
                mSkillsDataDic[value.skillId].Add(value.skilllevel, value);
            }
        }
    }
}