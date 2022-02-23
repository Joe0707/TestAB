using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class ChangeSlotElementEventResultConfig : ResultConfig
    {
        public const string Name = "元件变更";
        public string ElementId;   //元件Id
        public int SlotIndex;//格子索引
        public override string GetName { get { return ChangeSlotElementEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new ChangeSlotElementEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            result.ElementId = this.ElementId;
            result.SlotIndex = this.SlotIndex;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is ChangeSlotElementEventResultConfig)
            {
                var sourceconfig = source as ChangeSlotElementEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
                this.ElementId = sourceconfig.ElementId;
                this.SlotIndex = sourceconfig.SlotIndex;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.ChangeSlotElementEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.ChangeSlotElementEventResultConfig_ElementId, ElementId);
        //     attr.Add(TriggerResultAttr.ChangeSlotElementEventResultConfig_SlotIndex, SlotIndex);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}