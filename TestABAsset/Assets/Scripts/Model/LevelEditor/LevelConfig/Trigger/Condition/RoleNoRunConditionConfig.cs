using GlobalDefine;
using System.Collections.Generic;
//指定角色不能撤离条件
namespace Levels.Trigger
{
    public class RoleNoRunConditionConfig : ConditionConfig
    {
        public const string Name = "角色不能撤离";
        public override string GetName { get { return RoleNoRunConditionConfig.Name; } }
        public string roleGid;//角色唯一码
        public override ConditionConfig Clone()
        {
            var result = new RoleNoRunConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.roleGid = this.roleGid;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            RoleNoRunConditionConfig value = source as RoleNoRunConditionConfig;
            this.TriggerId = value.TriggerId;
            this.Type = value.Type;
            this.roleGid = value.roleGid;
        }
        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.RoleNoRunConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.RoleNoRunConditionConfig_roleGid, roleGid);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}