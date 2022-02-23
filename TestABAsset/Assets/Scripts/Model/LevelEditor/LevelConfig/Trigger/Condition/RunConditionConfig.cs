using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //撤离条件配置
    public class RunConditionConfig : ConditionConfig
    {
        public ETeamType Team = ETeamType.Enemy; //队伍
        public int SlotIndex;   //格子索引
        public override bool Check(ConditionContext context)
        {
            return true;
        }

        public override ConditionConfig Clone()
        {
            var config = new RunConditionConfig();
            config.Type = Type;
            config.SlotIndex = SlotIndex;
            config.Team = Team;
            return config;
        }

        // //转换为触发器条件数据
        // public override TriggerConditionDataModel ToTriggerConditionModel()
        // {
        //     var result = new TriggerConditionDataModel();
        //     result.Type = EConditionType.RunConditionConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerConditionAttr.RunConditionConfig_Team, Team);
        //     attr.Add(TriggerConditionAttr.RunConditionConfig_SlotIndex, SlotIndex);
        //     result.Attrs = attr;
        //     return result;
        // }

    }
}