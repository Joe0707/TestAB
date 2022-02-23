using System.Collections.Generic;
using GlobalDefine;
//坚持多少回合
namespace Levels.Trigger
{
    public class KeepRoundConditionConfig : ConditionConfig
    {
        public const string Name = "坚持回合数";
        public override string GetName { get { return KeepRoundConditionConfig.Name; } }
        public int roundNumber = 0;//坚持回合数
        public override ConditionConfig Clone()
        {
            var result = new KeepRoundConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.roundNumber = this.roundNumber;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            KeepRoundConditionConfig value = source as KeepRoundConditionConfig;
            this.TriggerId = value.TriggerId;
            this.Type = value.Type;
            this.roundNumber = value.roundNumber;
        }
        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.KeepRoundConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.KeepRoundConditionConfig_roundNumber, roundNumber);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}