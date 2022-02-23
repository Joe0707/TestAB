using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //相机焦点结束事件
    public class CameraFocusEndEventResultConfig : ResultConfig
    {
        public const string Name = "焦点结束";
        public override string GetName { get { return CameraFocusEndEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }

        public override ResultConfig Clone()
        {
            var result = new CameraFocusEndEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is CameraFocusEndEventResultConfig)
            {
                var sourceconfig = source as CameraFocusEndEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.CameraFocusEndEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

    }

}