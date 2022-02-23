using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class ChangeWinEventResultConfig : ResultConfig
    {
        public const string Name = "胜利变更";
        public string WinId;   //角色Id
        public override string GetName { get { return ChangeWinEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new ChangeWinEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            result.WinId = this.WinId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is ChangeWinEventResultConfig)
            {
                var sourceconfig = source as ChangeWinEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
                this.WinId = sourceconfig.WinId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.ChangeWinEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.ChangeWinEventResultConfig_WinId, WinId);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}