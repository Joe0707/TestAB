using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    public class RoundEventConditionConfig : ConditionConfig
    {
        public const string Name = "回合信息";
        public int RoundNumber;//回合数
        public ETeamType Team;//阵营
        public ERoundStatus RoundStatus;//回合状态
        public override string GetName { get { return RoundEventConditionConfig.Name; } }
        public override bool Check(ConditionContext context)
        {
            return true;
        }
        public override ConditionConfig Clone()
        {
            var result = new RoundEventConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.RoundNumber = this.RoundNumber;
            result.Team = this.Team;
            result.RoundStatus = this.RoundStatus;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            if (source is RoundEventConditionConfig)
            {
                var sourceconfig = source as RoundEventConditionConfig;
                this.Id = sourceconfig.Id;
                this.Type = sourceconfig.Type;
                this.RoundNumber = sourceconfig.RoundNumber;
                this.Team = sourceconfig.Team;
                this.RoundStatus = sourceconfig.RoundStatus;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.RoundEventConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.RoundEventConditionConfig_RoundNumber, RoundNumber);
        //     attr.Add(TriggerConditionAttr.RoundEventConditionConfig_Team, Team);
        //     attr.Add(TriggerConditionAttr.RoundEventConditionConfig_RoundStatus, RoundStatus);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}