using System.Collections.Generic;
using GlobalDefine;
using System;
namespace Levels.Trigger
{

    //战斗场景状态事件
    public class FightScenetStatusConditionConfig : ConditionConfig
    {
        public const string Name = "战斗状态";
        public override string GetName { get { return FightScenetStatusConditionConfig.Name; } }
        public EFightStatus FightStatus;
        public override ConditionConfig Clone()
        {
            var result = new FightScenetStatusConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.FightStatus = this.FightStatus;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            if (source is FightScenetStatusConditionConfig)
            {
                var sourceconfig = source as FightScenetStatusConditionConfig;
                this.Id = sourceconfig.Id;
                this.TriggerId = sourceconfig.TriggerId;
                this.Type = sourceconfig.Type;
                this.FightStatus = sourceconfig.FightStatus;
            }
        }
        //   //转换为触发器条件数据
        //   public override TriggerConditionDataModel ToTriggerConditionModel()
        //   {
        //       var result = new TriggerConditionDataModel();
        //       result.Type = EConditionType.FightSceneStatusConditionConfig;
        //       var attr = new Dictionary<string, object>();
        //       attr.Add(TriggerConditionAttr.FightScenetStatusConditionConfig_FightStatus, FightStatus);
        //       result.Attrs = attr;
        //       return result;
        //   }

    }
}