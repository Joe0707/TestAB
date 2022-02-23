using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Levels.Trigger;
namespace Levels
{
    //关卡配置文件
    public class LevelConfig
    {
        public int RowCount = 0; //行
        public int ColCount = 0;//列
        public string ScenePrefabName; //场景预制体名称
        public Position SlotCenterPosition = new Position(); //格子根节点在场景中的相对位置
        public float UpRotation = 0;//旋转角
        public List<SlotConfig> SlotList = new List<SlotConfig>(); //格子列表
        public List<StumpConfig> StumpList = new List<StumpConfig>(); //木桩列表
        public List<Trigger.TriggerConfig> TriggersList = new List<Trigger.TriggerConfig>(); //触发器列表
        public Value3 CameraPosition = new Value3();//摄像机位置
        public Value3 CameraRotation = new Value3();//摄像机旋转角
        public float CameraSize = 0;  //摄像机尺寸
        public float CameraMinHeight = 0;//摄像机最小尺寸
        public float CameraMaxHeight = 1000;//摄像机最大尺寸
        // public string BattleWinTrigger;//战斗胜利触发器
        public List<EdgeValue> EdgeValueList = new List<EdgeValue>();//边界位置列表
        public Value3 BattleFeatureCameraPosition = new Value3();//战斗特写摄像机位置
        public Value3 BattleFeatureCameraRotation = new Value3();//战斗特写摄像机旋转
        public float BattleFeatureCameraFov = 0;//战斗特写摄像机FOV
        public Value3 BattleFeatureAttackCenterPosition = new Value3();//战斗特写攻击中心位置
        public Value3 BattleFeatureDefenseCenterPosition = new Value3();//战斗特写防御中心位置
        public float FootprintStayTime = 0;//脚印留存时间(秒)
        public bool HasFootprint = false;//是否有脚印
        public string FootStepEffect = "";//脚步特效名
        public List<string> ActiveEffects = new List<string>();//开启的特效
        public bool ActiveFog = false;//是否开启雾效
        public string FogColor = "";//雾效颜色
        public int FogStartValue = 0;//雾效起始值
        public int FogEndValue = 0;//雾效结束值
        public bool ActorEnhanceEnvLight = false;//人物环境光增强
        public string BGM = "";//背景音乐名
        public string DefaultWinTrigger = "";//默认胜利触发器
        public string DefaultFailTrigger = "";//默认失败触发器
        //转化为输出关卡数据
        public LevelDataModel ToDataModel()
        {
            LevelDataModel model = new LevelDataModel();
            //相同字段直接赋值
            var modeltype = model.GetType();
            var configType = this.GetType();
            var modelTypeFields = modeltype.GetFields();
            for (var i = 0; i < modelTypeFields.Length; i++)
            {
                var modelField = modelTypeFields[i];
                var configField = configType.GetField(modelField.Name);
                if (configField != null && configField.FieldType == modelField.FieldType)
                {
                    modelField.SetValue(model, configField.GetValue(this));
                }
            }
            // model.RowCount = this.RowCount;
            // model.ColCount = this.ColCount;
            // model.ScenePrefabName = this.ScenePrefabName;
            // model.SlotCenterPosition = this.SlotCenterPosition;
            // model.UpRotation = this.UpRotation;
            // model.SlotList = this.SlotList;
            // model.StumpList = this.StumpList;
            // model.CameraPosition = this.CameraPosition;
            // model.CameraRotation = this.CameraRotation;
            // model.CameraSize = this.CameraSize;
            // model.CameraMinHeight = this.CameraMinHeight;
            // model.CameraMaxHeight = this.CameraMaxHeight;
            // model.EdgePosList = this.EdgePosList;
            // model.CameraEdgeLimitPosition = this.CameraEdgeLimitPosition;
            // model.BattleFeatureCameraPosition = this.BattleFeatureCameraPosition;
            // model.BattleFeatureCameraRotation = this.BattleFeatureCameraRotation;
            // model.BattleFeatureCameraFov = this.BattleFeatureCameraFov;
            // model.BattleFeatureAttackCenterPosition = this.BattleFeatureAttackCenterPosition;
            // model.BattleFeatureDefenseCenterPosition = this.BattleFeatureDefenseCenterPosition;
            // model.FootprintStayTime = this.FootprintStayTime;
            // model.HasFootprint = this.HasFootprint;
            // model.FootStepEffect = this.FootStepEffect;
            // model.ActiveEffects = this.ActiveEffects;
            // model.ActiveFog = this.ActiveFog;
            // model.FogColor = this.FogColor;
            // model.FogStartValue = this.FogStartValue;

            var triggerModels = new List<TriggerDataModel>();
            for (var i = 0; i < this.TriggersList.Count; i++)
            {
                var trigger = TriggersList[i];
                triggerModels.Add(trigger.ToTriggerData());
            }
            model.TriggersList = triggerModels;
            return model;
        }
        //从关卡数据中加载
        public void LoadFromLevelDataModel(LevelDataModel model)
        {
            var configType = this.GetType();
            var modelType = model.GetType();
            var configFields = configType.GetFields();
            for (var i = 0; i < configFields.Length; i++)
            {
                var configField = configFields[i];
                var modelField = modelType.GetField(configField.Name);
                if (modelField != null && configField.FieldType == modelField.FieldType)
                {
                    configField.SetValue(this, modelField.GetValue(model));
                }
            }
            // this.RowCount = model.RowCount;
            // this.ColCount = model.ColCount;
            // this.ScenePrefabName = model.ScenePrefabName;
            // this.SlotCenterPosition = model.SlotCenterPosition;
            // this.UpRotation = model.UpRotation;
            // this.SlotList = model.SlotList;
            // this.StumpList = model.StumpList;
            // this.CameraPosition = model.CameraPosition;
            // this.CameraRotation = model.CameraRotation;
            // this.CameraSize = model.CameraSize;
            // this.CameraMinHeight = model.CameraMinHeight;
            // this.CameraMaxHeight = model.CameraMaxHeight;
            // this.EdgePosList = model.EdgePosList;
            // this.CameraEdgeLimitPosition = model.CameraEdgeLimitPosition;
            // this.BattleFeatureCameraPosition = model.BattleFeatureCameraPosition;
            // this.BattleFeatureCameraRotation = model.BattleFeatureCameraRotation;
            // this.BattleFeatureCameraFov = model.BattleFeatureCameraFov;
            // this.BattleFeatureAttackCenterPosition = model.BattleFeatureAttackCenterPosition;
            // this.BattleFeatureDefenseCenterPosition = model.BattleFeatureDefenseCenterPosition;
            // this.FootprintStayTime = model.FootprintStayTime;
            // this.HasFootprint = model.HasFootprint;
            // this.FootStepEffect = model.FootStepEffect;
            // this.ActiveEffects = model.ActiveEffects;
            var triggerList = new List<TriggerConfig>();
            for (var i = 0; i < model.TriggersList.Count; i++)
            {
                var triggerModel = model.TriggersList[i];
                var trigger = new TriggerConfig();
                trigger.LoadFromTriggerModel(triggerModel);
                triggerList.Add(trigger);
            }
            this.TriggersList = triggerList;
        }
    }

    //位置定义
    public class Position
    {
        public float x = 0;
        public float y = 0;
        public float z = 0;
    }
}