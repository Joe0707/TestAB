using System.Collections.Generic;
using GlobalDefine;
//角色不能死亡条件
namespace Levels.Trigger
{
    public class RoleNoDeathConditionConfig : ConditionConfig
    {
        public const string Name = "角色不能死亡";
        public override string GetName { get { return RoleNoDeathConditionConfig.Name; } }
        public string RoleGid;//角色唯一码
        public override ConditionConfig Clone()
        {
            var result = new RoleNoDeathConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.RoleGid = this.RoleGid;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            RoleNoDeathConditionConfig value = source as RoleNoDeathConditionConfig;
            this.TriggerId = value.TriggerId;
            this.Type = value.Type;
            this.RoleGid = value.RoleGid;
        }
        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.RoleNoDeathConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.RoleNoDeathConditionConfig_RoleGid, RoleGid);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}