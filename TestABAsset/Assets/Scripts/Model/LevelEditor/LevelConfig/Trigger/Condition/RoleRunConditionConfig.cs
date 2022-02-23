using GlobalDefine;
using System.Collections.Generic;
//指定角色撤离条件
namespace Levels.Trigger
{
    public class RoleRunConditionConfig : ConditionConfig
    {
        public const string Name = "角色撤离";
        public override string GetName { get { return RoleRunConditionConfig.Name; } }
        public string roleGid;//角色唯一码
        public override ConditionConfig Clone()
        {
            var result = new RoleRunConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.roleGid = this.roleGid;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            RoleRunConditionConfig value = source as RoleRunConditionConfig;
            this.TriggerId = value.TriggerId;
            this.Type = value.Type;
            this.roleGid = value.roleGid;
        }

        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.RoleRunConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.RoleRunConditionConfig_roleGid, roleGid);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}