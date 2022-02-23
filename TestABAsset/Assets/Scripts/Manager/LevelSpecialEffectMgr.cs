using UnityEngine;
using System.Collections.Generic;
//雾效设置实体
public class FogSettingEntity
{
    public Color fogColor;//雾效颜色
    public bool isActive = false;//是否激活
    public int startValue = 0;//开始值
    public int endValue = 0;//结束值
}
//关卡特殊效果管理器
public class LevelSpecialEffectMgr : Singleton<LevelSpecialEffectMgr>
{
    //加载光照图
    public void LoadLightMap(string lightPath, LevelBakeInfo info)
    {
        //清空场景光照图
        LightmapSettings.lightmaps = null;
        //加载所有光照贴图
        var textures = ResourceMgr.Instance.LoadAll<Texture2D>(lightPath);
        var lightdata = new LightmapData[info.LightMapCount];
        for (var i = 0; i < lightdata.Length; i++)
        {
            var data = new LightmapData();
            lightdata[i] = data;
        }
        for (var i = 0; i < textures.Length; i++)
        {
            var texture = textures[i];
            var textureName = texture.name;
            var firstindex = textureName.IndexOf('-', 0) + 1;
            var secondindex = textureName.IndexOf('_', 0);
            var indexName = textureName.Substring(firstindex, secondindex - firstindex);
            //获取索引
            var index = int.Parse(indexName);
            LightmapData data = null;
            if (lightdata[index] != null)
            {
                data = lightdata[index];
            }
            if (data != null)
            {
                var typename = textureName.Substring(textureName.LastIndexOf("_") + 1);
                if (typename == "shadowmask")
                {
                    data.shadowMask = texture;
                }
                else if (typename == "light")
                {
                    data.lightmapColor = texture;
                }
            }
        }
        LightmapSettings.lightmaps = lightdata;
        LightmapSettings.lightmapsMode = LightmapsMode.NonDirectional;
    }

    public void LoadLightProbe(string lightPath)
    {
        //加载光照探针
        var path = string.Format("{0}/{1}", lightPath, "lightProbe");
        var probe = ResourceMgr.Instance.Load<LightProbes>(path);
        LightmapSettings.lightProbes = probe;
        LightProbes.Tetrahedralize();
    }

    //加载雾效设置
    public void LoadFogSetting(FogSettingEntity fog)
    {
        RenderSettings.fog = fog.isActive;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = fog.startValue;
        RenderSettings.fogEndDistance = fog.endValue;
        RenderSettings.fogColor = fog.fogColor;
    }

}