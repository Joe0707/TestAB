using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //战斗胜利结果
    public class BattleFailedResultConfig : ResultConfig
    {
        public const string Name = "战斗失败";
        public override string GetName { get { return BattleFailedResultConfig.Name; } }

        public override ResultConfig Clone()
        {
            var result = new BattleFailedResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            this.Id = source.Id;
            this.type = source.type;
            this.TriggerId = source.TriggerId;
        }
        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.BattleFailedResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}