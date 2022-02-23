using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using StaticData.Data;
public class SkillLoader : Singleton<SkillLoader>
{
    const string SkillPath = "./Assets/Resources/Data/SkillJson/skill.json";
    const string ResourcesLoadSkillPath = "Data/SkillJson/skill";
    public SkillConfig CurSkillConfig { get; protected set; }
    // public Dictionary<uint, SkillData> SkillDataDict { get; protected set; }
    public Dictionary<uint, EffectConsData> EffectConsDict { get; protected set; }
    public Dictionary<uint, EffectsData> EffectDataDict { get; protected set; }
    public Dictionary<uint, StatusData> StatusDataDict { get; protected set; }
    public override void Init()
    {
        // var skilldata = StaticData.StaticDataMgr.Instance.mSkillDataMap;
        EffectConsDict = StaticData.StaticDataMgr.Instance.mEffectConsDataMap;
        EffectDataDict = StaticData.StaticDataMgr.Instance.mEffectsDataMap;
        StatusDataDict = StaticData.StaticDataMgr.Instance.mStatusDataMap;
        // SkillDataDict = skilldata;
        if (Application.isEditor)
        {
            // if (File.Exists(SkillPath))
            // {
            //     FileStream fs = new FileStream(SkillPath, FileMode.Open);
            //     StreamReader sr = new StreamReader(fs);
            //     string json = sr.ReadToEnd();
            //     sr.Close();
            //     CurSkillConfig = JsonConvert.DeserializeObject<SkillConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            // }
            CurSkillConfig = ConfigManager.Instance.LoadJsonConfig<SkillConfig>(ResourcesLoadSkillPath);
            if (CurSkillConfig == null)
            {
                InitSkillConfig();
            }
            // var fileres = ResourcesManager.Instance.LoadResource<TextAsset>(ResourcesLoadSkillPath);
            // if (fileres != null)
            // {
            //     string json = fileres.text;
            //     CurSkillConfig = JsonConvert.DeserializeObject<SkillConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            // }
            // else
            // {
            //     Debug.LogError("未找到技能配置文件skill.config");
            // }
        }
        else
        {
            // var fileres = ResourcesManager.Instance.LoadResource<TextAsset>(ResourcesLoadSkillPath);
            // if (fileres != null)
            // {
            //     string json = fileres.text;
            //     CurSkillConfig = JsonConvert.DeserializeObject<SkillConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            // }
            // else
            // {
            //     Debug.LogError("未找到技能配置文件skill.config");
            //     InitSkillConfig();
            // }
            CurSkillConfig = ConfigManager.Instance.LoadJsonConfig<SkillConfig>(ResourcesLoadSkillPath);
            if (CurSkillConfig == null)
            {
                InitSkillConfig();
            }
        }

    }

    private void InitSkillConfig()
    {
        var skillConfig = new SkillConfig();
        var itemList = new List<SkillItemConfig>();
        // foreach (var pair in StaticData.StaticDataMgr.mInstance.mSkillDataMap)
        // {
        //     var Id = pair.Key;
        //     var item = new SkillItemConfig();
        //     item.Id = Id;
        //     item.Name = pair.Value.mName.ToString();
        //     itemList.Add(item);
        // }
        skillConfig.SkillItemList = itemList;
        CurSkillConfig = skillConfig;
    }

    public override void Dispose()
    {
        base.Dispose();
        CurSkillConfig = null;
    }

    //保存当前关卡
    public void SaveCurConfig()
    {
        if (CurSkillConfig == null)
            return;
        var fileName = SkillPath;
        FileStream fs = new FileStream(fileName, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        string json = JsonConvert.SerializeObject(CurSkillConfig, Formatting.Indented, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        sw.Write(json);
        sw.Close();
        CurSkillConfig = JsonConvert.DeserializeObject<SkillConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
    }

    //获取技能项
    public SkillItemConfig GetSkillItem(uint skillId)
    {
        SkillItemConfig result = null;
        var skills = CurSkillConfig.SkillItemList;
        for (var i = 0; i < skills.Count; i++)
        {
            var skillItem = skills[i];
            if (skillItem.Id == skillId)
            {
                result = skillItem;
                break;
            }
        }
        return result;
    }
}
