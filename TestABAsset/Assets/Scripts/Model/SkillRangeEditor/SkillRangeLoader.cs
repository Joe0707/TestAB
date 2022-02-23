using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class SkillRangeLoader : Singleton<SkillRangeLoader>
{
    const string Path = "./Assets/SkillRangeEditor/Resources/SkillJson/skill.json";

    public SkillRangeConfig CurSkillRangeConfig { get; protected set; }
    public SkillRangeConfig CurBuffSkillRangeConfig { get; protected set; }
    public override void Init()
    {
        var skillRangeData = SkillRangeDataLoader.Instance.CurSkillRangeData;
        if (skillRangeData != null)
        {
            CurSkillRangeConfig = new SkillRangeConfig();
            CurSkillRangeConfig.LoadFromData(skillRangeData);
        }
        else
        {
            InitConfig();
        }
    }

    public void Init(string path)
    {
        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string json = sr.ReadToEnd();
            sr.Close();
            CurBuffSkillRangeConfig = JsonConvert.DeserializeObject<SkillRangeConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        }
        else
        {
            Debug.LogError("未找到技能配置文件skill.config");
            InitConfig();
        }
    }

    public void InitConfig()
    {
        var skillConfig = new SkillRangeConfig();
        CurSkillRangeConfig = skillConfig;
    }

    public override void Dispose()
    {
        base.Dispose();
        CurSkillRangeConfig = null;
    }

    //保存当前关卡
    public void SaveCurConfig()
    {
        if (CurSkillRangeConfig == null)
            return;
        var skillData = CurSkillRangeConfig.ToDataModel();
        SkillRangeDataLoader.Instance.SaveData(skillData);
    }

}
