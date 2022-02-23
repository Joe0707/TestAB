using System.Collections.Generic;
using Levels.Trigger;

namespace Levels
{
    //关卡数据
    public class LevelDataModel
    {
        public int RowCount = 0; //行
        public int ColCount = 0;//列
        public string ScenePrefabName; //场景预制体名称
        public Position SlotCenterPosition = new Position(); //格子根节点在场景中的相对位置
        public float UpRotation = 0;//旋转角
        public List<SlotConfig> SlotList = new List<SlotConfig>(); //格子列表
        public List<StumpConfig> StumpList = new List<StumpConfig>(); //木桩列表
        public List<TriggerDataModel> TriggersList = new List<TriggerDataModel>(); //触发器列表
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
        public List<string> ActiveEffects = new List<string>();//光效
        public bool ActiveFog = false;//是否开启雾效
        public string FogColor = "";//雾效颜色
        public int FogStartValue = 0;//雾效起始值
        public int FogEndValue = 0;//雾效结束值
        public bool ActorEnhanceEnvLight = false;//人物环境光增强
        public string BGM = "";//背景音乐名
        public string DefaultWinTrigger = "";//默认胜利触发器
        public string DefaultFailTrigger = "";//默认失败触发器

    }
}