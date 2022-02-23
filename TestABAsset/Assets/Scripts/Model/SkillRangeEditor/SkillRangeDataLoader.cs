using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class SkillRangeDataLoader : Singleton<SkillRangeDataLoader>
{
    const string Path = "./Assets/Resources/Data/SkillRangeJson/SkillRange.json";
    const string ResourcesPath = "Data/SkillRangeJson/SkillRange";
    public SkillRangeDataModel CurSkillRangeData { get; protected set; }
    public override void Init()
    {
        LoadSkillRangeData();
    }

    public void LoadSkillRangeData()
    {
        if (Application.isEditor)
        {
            // if (File.Exists(Path))
            // {
            //     FileStream fs = new FileStream(Path, FileMode.Open);
            //     StreamReader sr = new StreamReader(fs);
            //     string json = sr.ReadToEnd();
            //     sr.Close();
            //     CurSkillRangeData = JsonConvert.DeserializeObject<SkillRangeDataModel>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            // }
            CurSkillRangeData = ConfigManager.Instance.LoadJsonConfig<SkillRangeDataModel>(ResourcesPath);
            // var fileres = ResourcesManager.Instance.LoadResource<TextAsset>(ResourcesPath);
            // if (fileres != null)
            // {
            //     string json = fileres.text;
            //     CurSkillRangeData = JsonConvert.DeserializeObject<SkillRangeDataModel>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            // }
            // else
            // {
            //     Debug.LogError("未找到技能配置文件SkillRange.config");
            // }
        }
        else
        {
            CurSkillRangeData = ConfigManager.Instance.LoadJsonConfig<SkillRangeDataModel>(ResourcesPath);
            // var fileres = ResourcesManager.Instance.LoadResource<TextAsset>(ResourcesPath);
            // if (fileres != null)
            // {
            //     string json = fileres.text;
            //     CurSkillRangeData = JsonConvert.DeserializeObject<SkillRangeDataModel>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            // }
            // else
            // {
            //     Debug.LogError("未找到技能配置文件SkillRange.config");
            // }
        }
    }
    //存储数据
    public void SaveData(SkillRangeDataModel data)
    {
        if (data == null)
            return;
        var fileName = Path;
        FileStream fs = new FileStream(fileName, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        sw.Write(json);
        sw.Close();
        CurSkillRangeData = JsonConvert.DeserializeObject<SkillRangeDataModel>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        MessageBox.ShowOneMessage("保存技能范围数据成功");
    }

    public override void Dispose()
    {
        base.Dispose();
        CurSkillRangeData = null;
    }
}