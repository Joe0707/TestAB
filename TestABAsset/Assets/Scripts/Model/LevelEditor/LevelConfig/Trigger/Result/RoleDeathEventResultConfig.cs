using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class RoleDeathEventResultConfig : ResultConfig
    {
        public const string Name = "角色死亡";
        public string RoleId;   //角色Id
        public override string GetName { get { return RoleDeathEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new RoleDeathEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.RoleId = this.RoleId;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is RoleDeathEventResultConfig)
            {
                var sourceconfig = source as RoleDeathEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.RoleId = sourceconfig.RoleId;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.RoleDeathEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.RoleDeathEventResultConfig_RoleId, RoleId);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}