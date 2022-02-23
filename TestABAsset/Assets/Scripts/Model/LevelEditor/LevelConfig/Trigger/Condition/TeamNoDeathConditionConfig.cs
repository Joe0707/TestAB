using GlobalDefine;
using System.Collections.Generic;
//部队不能有成员死亡条件
namespace Levels.Trigger
{
    public class TeamNoDeathConditionConfig : ConditionConfig
    {
        public const string Name = "部队无人死";
        public override string GetName { get { return TeamNoDeathConditionConfig.Name; } }
        public ETeamType team;//指定部队
        public override ConditionConfig Clone()
        {
            var config = new TeamNoDeathConditionConfig();
            config.Id = this.Id;
            config.Type = this.Type;
            config.TriggerId = this.TriggerId;
            config.team = this.team;
            return config;
        }

        public override void Copy(ConditionConfig source)
        {
            TeamNoDeathConditionConfig value = source as TeamNoDeathConditionConfig;
            this.Type = value.Type;
            this.TriggerId = value.TriggerId;
            this.team = value.team;
        }
        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.TeamNoDeathConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.TeamNoDeathConditionConfig_team, team);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}