using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{

    //状态条件设置
    public class StatusConditionConfig : ConditionConfig
    {
        public EStatusType StatusType;   //状态类型
        public int SlotIndex;   //格子索引
        public string StatusId;//Id号
        public override bool Check(ConditionContext context)
        {
            return true;
        }

        public override ConditionConfig Clone()
        {
            var config = new StatusConditionConfig();
            config.StatusType = StatusType;
            config.SlotIndex = SlotIndex;
            config.Type = Type;
            config.Id = Id;
            return config;
        }

        //   //转换为触发器条件数据
        //   public override TriggerConditionDataModel ToTriggerConditionModel()
        //   {
        //       var result = new TriggerConditionDataModel();
        //       result.Type = EConditionType.StatusConditionConfig;
        //       var attr = new Dictionary<string, object>();
        //       attr.Add(TriggerConditionAttr.StatusConditionConfig_StatusType, StatusType);
        //       attr.Add(TriggerConditionAttr.StatusConditionConfig_StatusId, StatusId);
        //       attr.Add(TriggerConditionAttr.StatusConditionConfig_SlotIndex, SlotIndex);
        //       result.Attrs = attr;
        //       return result;
        //   }

    }
}