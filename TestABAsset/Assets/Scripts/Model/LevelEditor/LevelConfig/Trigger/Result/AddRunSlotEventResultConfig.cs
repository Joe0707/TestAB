using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class AddRunSlotEventResultConfig : ResultConfig
    {
        public const string Name = "加撤离点";
        public int SlotIndex;   //格子索引
        public ETeamType Team;  //阵营
        public override string GetName { get { return AddRunSlotEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new AddRunSlotEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            result.SlotIndex = this.SlotIndex;
            result.Team = this.Team;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is AddRunSlotEventResultConfig)
            {
                var sourceconfig = source as AddRunSlotEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
                this.SlotIndex = sourceconfig.SlotIndex;
                this.Team = sourceconfig.Team;
            }
        }
        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.AddRunSlotEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.AddRunSlotEventResultConfig_SlotIndex, SlotIndex);
        //     attr.Add(TriggerResultAttr.AddRunSlotEventResultConfig_Team, Team);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }
    }

}