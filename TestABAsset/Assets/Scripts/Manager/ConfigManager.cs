using UnityEngine;
using Newtonsoft.Json;
//数据管理器
public class ConfigManager : Singleton<ConfigManager>
{
    //加载Json数据
    public T LoadJsonConfig<T>(string path, JsonSerializerSettings settings = null) where T : class
    {
        T result = null;
        TextAsset text = ResourcesManager.Instance.LoadResource<TextAsset>(path);
        if (text != null)
        {
            string json = text.text;
            result = JsonConvert.DeserializeObject<T>(json, settings);
            if (ResourcesManager.Instance.m_LoadFormAssetBundle == true)
            {
                ResourcesManager.Instance.ReleaseResouce(text, true);
            }
        }
        else
        {
            DebugUtil.DebugError(string.Format("数据资源未找到,路径{0}", path));
        }
        return result;
    }
    //加载配置的字节数据
    public byte[] LoadConfigBytes(string path)
    {
        byte[] result = null;
        TextAsset text = ResourcesManager.Instance.LoadResource<TextAsset>(path);
        if (text != null)
        {
            result = new byte[text.bytes.Length];
            text.bytes.CopyTo(result, 0);
            if (ResourcesManager.Instance.m_LoadFormAssetBundle == true)
            {
                ResourcesManager.Instance.ReleaseResouce(text, true);
            }
        }
        else
        {
            DebugUtil.DebugError(string.Format("数据资源未找到,路径{0}", path));
        }
        return result;
    }
}