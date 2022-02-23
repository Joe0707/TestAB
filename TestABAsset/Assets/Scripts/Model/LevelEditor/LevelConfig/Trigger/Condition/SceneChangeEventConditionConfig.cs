using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //场景类型
    public enum ESceneType
    {
        Fight = 0,   //战斗
        World = 1    //世界
    }
    //场景切换事件配置
    public class SceneChangeEventConditionConfig : ConditionConfig
    {
        public const string Name = "场景切换";
        public ESceneType CurScene;   //当前场景
        public ESceneType NextScene;  //进入场景
        public override string GetName { get { return SceneChangeEventConditionConfig.Name; } }
        public override bool Check(ConditionContext context)
        {
            return true;
        }
        public override ConditionConfig Clone()
        {
            var result = new SceneChangeEventConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.CurScene = this.CurScene;
            result.NextScene = this.NextScene;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            if (source is SceneChangeEventConditionConfig)
            {
                var sourceconfig = source as SceneChangeEventConditionConfig;
                this.Id = sourceconfig.Id;
                this.Type = sourceconfig.Type;
                this.CurScene = sourceconfig.CurScene;
                this.NextScene = sourceconfig.NextScene;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

        //   //转换为触发器条件数据
        //   public override TriggerConditionDataModel ToTriggerConditionModel()
        //   {
        //       var result = new TriggerConditionDataModel();
        //       result.Type = EConditionType.SceneChangeEventConditionConfig;
        //       var attr = new Dictionary<string, object>();
        //       attr.Add(TriggerConditionAttr.SceneChangeEventConditionConfig_CurScene, CurScene);
        //       attr.Add(TriggerConditionAttr.SceneChangeEventConditionConfig_NextScene, NextScene);
        //       result.Attrs = attr;
        //       return result;
        //   }

    }
}