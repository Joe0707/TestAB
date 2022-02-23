using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Levels;
using Newtonsoft.Json;
public class LevelLightLoader : MonoBehaviour
{
    const string BakePath = "Bake/";
    void Awake()
    {
        var curLevel = LevelLoader.Instance.CurLevelConfig;
        if (curLevel != null)
        {
            var levelbakepath = LevelModel.Instance.GetBakePath(curLevel);
            levelbakepath = BakePath + levelbakepath;
            var json = ResourcesManager.Instance.LoadResource<TextAsset>(levelbakepath + "/light").text;
            var levelconfig = JsonConvert.DeserializeObject<LevelBakeInfo>(json);
            if (string.IsNullOrEmpty(levelbakepath) == false)
            {
                LevelSpecialEffectMgr.Instance.LoadLightProbe(levelbakepath);
                LevelSpecialEffectMgr.Instance.LoadLightMap(levelbakepath, levelconfig);
            }
            else
            {
                DebugUtil.DebugWarn("没有烘焙资源");
            }
            var fogSetting = new FogSettingEntity();
            fogSetting.fogColor = ColorUtil.GetColor(curLevel.FogColor);
            fogSetting.isActive = curLevel.ActiveFog;
            fogSetting.startValue = curLevel.FogStartValue;
            fogSetting.endValue = curLevel.FogEndValue;
            LevelSpecialEffectMgr.Instance.LoadFogSetting(fogSetting);
        }
    }
}
