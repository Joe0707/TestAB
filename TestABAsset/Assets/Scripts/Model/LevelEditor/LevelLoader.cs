using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using StaticData.Data;
using Levels.Trigger;
using GlobalDefine;
namespace Levels
{
    public class LevelLoader
    {
        const string LevelPath = "./Assets/Resources/Data/LevelJson/";//文件路径
        const string ResourcesLoadLevelPath = "Data/LevelJson/";//文件路径
        static LevelLoader mInstance = null;
        public static LevelLoader Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new LevelLoader();
                return mInstance;
            }
        }
        //当前关卡数据
        public LevelConfig CurLevelConfig { get; protected set; } = null;
        public LevelData CurLevelData { get; set; }
        //当前打开的关卡ID
        public uint CurLevelID { get; protected set; } = 0;

        public void Clean()
        {
            CurLevelConfig = null;
            CurLevelData = null;
            CurLevelID = 0;

        }
        // //加载老结构关卡
        // public void LoadOldLevel(uint levelID)
        // {
        //     if (Application.isEditor)
        //     {
        //         var fileName = LevelPath + levelID.ToString() + ".json";
        //         if (File.Exists(fileName))
        //         {
        //             FileStream fs = new FileStream(fileName, FileMode.Open);
        //             StreamReader sr = new StreamReader(fs);
        //             string json = sr.ReadToEnd();
        //             sr.Close();
        //             CurLevelConfig = JsonConvert.DeserializeObject<LevelConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        //             // var levelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
        //             // CurLevelConfig = new LevelConfig();
        //             // CurLevelConfig.LoadFromLevelDataModel(levelModel);
        //             CurLevelID = levelID;
        //         }
        //         else
        //             Debug.LogError("未找到关卡文件:" + levelID + ".json");
        //     }
        //     else
        //     {
        //         var fileName = ResourcesLoadLevelPath + levelID.ToString();
        //         var fileres = ResourceMgr.Instance.Load<TextAsset>(fileName);
        //         if (fileres != null)
        //         {
        //             //  FileStream fs = new FileStream(fileName, FileMode.Open);
        //             //  StreamReader sr = new StreamReader(fs);
        //             string json = fileres.text;
        //             //  sr.Close();
        //             CurLevelConfig = JsonConvert.DeserializeObject<LevelConfig>(json, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
        //             // var levelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
        //             // CurLevelConfig = new LevelConfig();
        //             // CurLevelConfig.LoadFromLevelDataModel(levelModel);
        //             CurLevelID = levelID;
        //         }
        //         else
        //             Debug.LogError("未找到关卡文件:" + levelID + ".json");
        //     }

        // }

        //加载关卡
        public void LoadLevel(uint levelID)
        {
            if (Application.isEditor)
            {
                // var fileName = LevelPath + levelID.ToString() + ".json";
                // if (File.Exists(fileName))
                // {
                //     FileStream fs = new FileStream(fileName, FileMode.Open);
                //     StreamReader sr = new StreamReader(fs);
                //     string json = sr.ReadToEnd();
                //     sr.Close();
                //     var levelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
                //     CurLevelConfig = new LevelConfig();
                //     CurLevelConfig.LoadFromLevelDataModel(levelModel);
                //     CurLevelID = levelID;
                // }
                var fileName = ResourcesLoadLevelPath + levelID.ToString();
                var levelModel = ConfigManager.Instance.LoadJsonConfig<LevelDataModel>(fileName, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
                if (levelModel != null)
                {
                    CurLevelConfig = new LevelConfig();
                    CurLevelConfig.LoadFromLevelDataModel(levelModel);
                    CurLevelID = levelID;
                }
                // string json = fileres.text;
                // //  sr.Close();
                // var levelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
                // if (fileres != null)
                // {
                //     //  FileStream fs = new FileStream(fileName, FileMode.Open);
                //     //  StreamReader sr = new StreamReader(fs);
                //     string json = fileres.text;
                //     //  sr.Close();
                //     var levelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
                // }
                // else
                //     Debug.LogError("未找到关卡文件:" + levelID + ".json");
            }
            else
            {
                // var fileName = ResourcesLoadLevelPath + levelID.ToString();
                // var fileres = ResourceMgr.Instance.Load<TextAsset>(fileName);
                // if (fileres != null)
                // {
                //     //  FileStream fs = new FileStream(fileName, FileMode.Open);
                //     //  StreamReader sr = new StreamReader(fs);
                //     string json = fileres.text;
                //     //  sr.Close();
                //     var levelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
                //     CurLevelConfig = new LevelConfig();
                //     CurLevelConfig.LoadFromLevelDataModel(levelModel);
                //     CurLevelID = levelID;
                // }
                // else
                //     Debug.LogError("未找到关卡文件:" + levelID + ".json");
                var fileName = ResourcesLoadLevelPath + levelID.ToString();
                var levelModel = ConfigManager.Instance.LoadJsonConfig<LevelDataModel>(fileName, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
                if (levelModel != null)
                {
                    CurLevelConfig = new LevelConfig();
                    CurLevelConfig.LoadFromLevelDataModel(levelModel);
                    CurLevelID = levelID;
                }
            }
        }

        //保存当前关卡
        public void SaveCurLevel()
        {
            if (CurLevelConfig == null)
                return;
            //TODO Test
            // Trigger.TriggerConfig config = null;
            // var triggers = CurLevelConfig.TriggersList;
            // for (var i = 0; i < triggers.Count; i++)
            // {
            //     var trigger = triggers[i];
            //     if (trigger.Id == CurLevelConfig.BattleWinTrigger)
            //     {
            //         config = trigger;
            //         break;
            //     }
            // }
            // var group1 = new ConditionGroupConfig();
            // group1.Relation = ConditionGroupConfig.ERelation.Or;
            // var nodead1 = new RoleNoDeathConditionConfig();
            // nodead1.RoleGid = "123123123123";
            // var nodead2 = new RoleNoDeathConditionConfig();
            // nodead2.RoleGid = "234234234234234";
            // group1.mConditionList.Add(nodead1);
            // group1.mConditionList.Add(nodead2);
            // var group2 = new ConditionGroupConfig();
            // group2.Relation = ConditionGroupConfig.ERelation.Or;
            // var run1 = new TeamRunConditionConfig();
            // run1.runTeam = ETeamType.Player;
            // var run2 = new TeamRunConditionConfig();
            // run2.runTeam = ETeamType.Friend;
            // group2.mConditionList.Add(run1);
            // group2.mConditionList.Add(run2);
            // var groupall = new ConditionGroupConfig();
            // groupall.Relation = ConditionGroupConfig.ERelation.And;
            // groupall.mConditionList.Add(group1);
            // groupall.mConditionList.Add(group2);
            // config.ConditionGroup = groupall;
            // var levelModel = CurLevelConfig.ToDataModel();
            // var fileName = LevelPath + CurLevelID.ToString() + ".json";
            // FileStream fs = new FileStream(fileName, FileMode.Create);
            // StreamWriter sw = new StreamWriter(fs);
            // string json = JsonConvert.SerializeObject(levelModel);
            // // string json = JsonConvert.SerializeObject(levelModel);
            // sw.Write(json);
            // sw.Close();
            // var loadLevelModel = JsonConvert.DeserializeObject<LevelDataModel>(json, new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, Converters = new List<JsonConverter>() { new ParseObjectNumberConverter() } });
            // // var loadLevelModel = JsonConvert.DeserializeObject<LevelDataModel>(json);
            // CurLevelConfig.LoadFromLevelDataModel(loadLevelModel);
        }

        //删除关卡
        public void DeleteLevel(uint levelID)
        {
            var fileName = LevelPath + levelID.ToString() + ".json";
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

        // //创建关卡
        // public void CreateLevel(uint levelID)
        // {
        //     CurLevelConfig = new LevelConfig();
        //     CurLevelID = levelID;

        // }

        //关卡文件是否存在
        public bool HasLevelFile(uint levelID)
        {
            var fileName = LevelPath + levelID.ToString() + ".json";
            return File.Exists(fileName);
        }
    }
}