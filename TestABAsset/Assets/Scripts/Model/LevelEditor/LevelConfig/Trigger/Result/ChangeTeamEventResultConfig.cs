using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class ChangeTeamEventResultConfig : ResultConfig
    {
        public const string Name = "变更阵营";
        public string RoleId;   //角色Id
        public ETeamType Team;  //变更阵容类型
        public override string GetName { get { return ChangeTeamEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new ChangeTeamEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            result.RoleId = this.RoleId;
            result.Team = this.Team;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is ChangeTeamEventResultConfig)
            {
                var sourceconfig = source as ChangeTeamEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
                this.RoleId = sourceconfig.RoleId;
                this.Team = sourceconfig.Team;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.ChangeTeamEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.ChangeTeamEventResultConfig_RoleId, RoleId);
        //     attr.Add(TriggerResultAttr.ChangeTeamEventResultConfig_Team, Team);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}