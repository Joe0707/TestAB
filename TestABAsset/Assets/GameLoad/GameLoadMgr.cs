using UnityEngine;
using Newtonsoft.Json;
//游戏加载管理器
public class GameLoadMgr : Singleton<GameLoadMgr>
{
    public string mResourceLoadPath = "Load/ResourceLoadConfig";
    public ResourcesLoadConfig mResourceLoadConfig;//资源加载配置
    public override void Init()
    {
        var resourceConfig = Resources.Load<TextAsset>(mResourceLoadPath);
        if (resourceConfig != null)
        {
            var json = resourceConfig.text;
            mResourceLoadConfig = JsonConvert.DeserializeObject<ResourcesLoadConfig>(json);
        }
        else
        {
            mResourceLoadConfig = new ResourcesLoadConfig();
        }
    }
    //获取资源加载配置文件写入路径
    public string GetResourceConfigWritePath()
    {
        return Application.dataPath + "/Resources/" + mResourceLoadPath + ".json";
    }

}