using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //部队全灭条件
    public class TeamDeathConditionConfig : ConditionConfig
    {
        public const string Name = "部队全灭";
        public override string GetName { get { return TeamDeathConditionConfig.Name; } }

        public ETeamType deathTeam = ETeamType.Player;//死亡部队
        public override ConditionConfig Clone()
        {
            var config = new TeamDeathConditionConfig();
            config.Id = this.Id;
            config.Type = this.Type;
            config.TriggerId = this.TriggerId;
            config.deathTeam = this.deathTeam;
            return config;
        }

        public override void Copy(ConditionConfig source)
        {
            TeamDeathConditionConfig value = source as TeamDeathConditionConfig;
            this.Type = value.Type;
            this.TriggerId = value.TriggerId;
            this.deathTeam = value.deathTeam;
        }

        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.TeamDeathConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.TeamDeathConditionConfig_deathTeam, deathTeam);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}