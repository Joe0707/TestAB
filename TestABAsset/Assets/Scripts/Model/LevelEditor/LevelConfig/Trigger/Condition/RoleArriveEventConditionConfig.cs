using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    public class RoleArriveEventConditionConfig : ConditionConfig
    {
        public const string Name = "角色到达";
        public string RoleId;//角色Id
        public int SlotIndex;//格子索引
        public override string GetName { get { return RoleArriveEventConditionConfig.Name; } }
        public override bool Check(ConditionContext context)
        {
            return true;
        }
        public override ConditionConfig Clone()
        {
            var result = new RoleArriveEventConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.RoleId = this.RoleId;
            result.SlotIndex = this.SlotIndex;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            if (source is RoleArriveEventConditionConfig)
            {
                var sourceconfig = source as RoleArriveEventConditionConfig;
                this.Id = sourceconfig.Id;
                this.TriggerId = sourceconfig.TriggerId;
                this.Type = sourceconfig.Type;
                this.RoleId = sourceconfig.RoleId;
                this.SlotIndex = sourceconfig.SlotIndex;
            }
        }

        //   //转换为触发器条件数据
        //   public override TriggerConditionDataModel ToTriggerConditionModel()
        //   {
        //       var result = new TriggerConditionDataModel();
        //       result.Type = EConditionType.RoleArriveEventConditionConfig;
        //       var attr = new Dictionary<string, object>();
        //       attr.Add(TriggerConditionAttr.RoleArriveEventConditionConfig_RoleId, RoleId);
        //       attr.Add(TriggerConditionAttr.RoleArriveEventConditionConfig_SlotIndex, SlotIndex);
        //       result.Attrs = attr;
        //       return result;
        //   }

    }
}