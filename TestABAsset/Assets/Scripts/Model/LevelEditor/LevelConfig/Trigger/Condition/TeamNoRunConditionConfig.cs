using GlobalDefine;
using System.Collections.Generic;
//部队不能撤离条件
namespace Levels.Trigger
{
    public class TeamNoRunConditionConfig : ConditionConfig
    {
        public const string Name = "部队不能撤离";
        public override string GetName { get { return TeamNoRunConditionConfig.Name; } }
        public ETeamType runTeam;//撤离部队
        public override ConditionConfig Clone()
        {
            var config = new TeamNoRunConditionConfig();
            config.Id = this.Id;
            config.Type = this.Type;
            config.TriggerId = this.TriggerId;
            config.runTeam = this.runTeam;
            return config;
        }

        public override void Copy(ConditionConfig source)
        {
            TeamNoRunConditionConfig value = source as TeamNoRunConditionConfig;
            this.Type = value.Type;
            this.TriggerId = value.TriggerId;
            this.runTeam = value.runTeam;
        }
        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.TeamNoRunConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.TeamNoRunConditionConfig_runTeam, runTeam);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}