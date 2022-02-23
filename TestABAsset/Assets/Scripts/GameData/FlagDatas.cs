using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameData
{
    public class FlagDatas
    {
        static FlagDatas mInstance = null;
        public static FlagDatas Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new FlagDatas();
                return mInstance;
            }
        }
        public List<StaticData.Data.FlagData> shapeColor = new List<StaticData.Data.FlagData>();
        public List<StaticData.Data.FlagData> shape = new List<StaticData.Data.FlagData>();
        public List<StaticData.Data.FlagData> pattern = new List<StaticData.Data.FlagData>();
        public List<StaticData.Data.FlagData> patternColor = new List<StaticData.Data.FlagData>();
        public void LoadFlagData()
        {
            var flag = StaticData.StaticDataMgr.Instance.mFlagDataMap;
            foreach (var item in flag)
            {
                var value = item.Value;
                switch (value.flagType)
                {
                    case (int)GlobalDefine.ECorpsFlagCfgType.shapeColor:
                        shapeColor.Add(value);
                        break;
                    case (int)GlobalDefine.ECorpsFlagCfgType.shape:
                        shape.Add(value);
                        break;
                    case (int)GlobalDefine.ECorpsFlagCfgType.pattern:
                        pattern.Add(value);
                        break;
                    case (int)GlobalDefine.ECorpsFlagCfgType.patternColor:
                        patternColor.Add(value);
                        break;
                }
            }
        }
    }
}