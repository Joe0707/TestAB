using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //部队撤离条件
    public class TeamRunConditionConfig : ConditionConfig
    {
        public const string Name = "部队撤离";
        public override string GetName { get { return TeamRunConditionConfig.Name; } }
        public ETeamType runTeam;//撤离部队
        public override ConditionConfig Clone()
        {
            var config = new TeamRunConditionConfig();
            config.Id = this.Id;
            config.Type = this.Type;
            config.TriggerId = this.TriggerId;
            config.runTeam = this.runTeam;
            return config;
        }

        public override void Copy(ConditionConfig source)
        {
            TeamRunConditionConfig value = source as TeamRunConditionConfig;
            this.Type = value.Type;
            this.TriggerId = value.TriggerId;
            this.runTeam = value.runTeam;
        }

        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.TeamRunConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.TeamRunConditionConfig_runTeam, runTeam);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}