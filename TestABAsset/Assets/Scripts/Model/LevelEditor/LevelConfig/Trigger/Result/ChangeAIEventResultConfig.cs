using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class ChangeAIEventResultConfig : ResultConfig
    {
        public const string Name = "变更AI";
        public string RoleId;   //角色Id
        public string AIId;
        public override string GetName { get { return ChangeAIEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new ChangeAIEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            result.RoleId = this.RoleId;
            result.AIId = this.AIId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is ChangeAIEventResultConfig)
            {
                var sourceconfig = source as ChangeAIEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
                this.RoleId = sourceconfig.RoleId;
                this.AIId = sourceconfig.AIId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.ChangeAIEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.ChangeAIEventResultConfig_RoleId, RoleId);
        //     attr.Add(TriggerResultAttr.ChangeAIEventResultConfig_AIId, AIId);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}