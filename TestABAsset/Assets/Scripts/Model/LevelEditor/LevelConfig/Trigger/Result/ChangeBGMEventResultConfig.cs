using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class ChangeBGMEventResultConfig : ResultConfig
    {
        public const string Name = "更改BGM";
        public string BGMId;
        public override string GetName { get { return ChangeBGMEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new ChangeBGMEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            result.BGMId = this.BGMId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is ChangeBGMEventResultConfig)
            {
                var sourceconfig = source as ChangeBGMEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
                this.BGMId = sourceconfig.BGMId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.ChangeBGMEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.ChangeBGMEventResultConfig_BGMId, BGMId);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }
    }

}