using UnityEngine;
using System.Collections.Generic;
using Levels;

//预制体烘焙信息加载器
public class LevelPrefabLightMapLoader : MonoBehaviour
{
    public List<PrefabLightmapData> LightmapDatas;//烘焙数据
    void Awake()
    {
        var curLevel = LevelLoader.Instance.CurLevelConfig;
        if (curLevel != null)
        {
            var levelbakepath = LevelModel.Instance.GetBakePath(curLevel);
            if (string.IsNullOrEmpty(levelbakepath) == false)
            {
                var lightpath = levelbakepath.Substring(levelbakepath.IndexOf("_") + 1);
                for (var i = 0; i < LightmapDatas.Count; i++)
                {
                    var data = LightmapDatas[i];
                    if (data.gameObject.name == lightpath)
                    {
                        data.ApplyLightData();
                    }
                }
            }
        }
    }

}