using GlobalDefine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace Levels.Trigger
{
    public class CameraPlaceEventResultConfig : ResultConfig
    {
        public const string Name = "相机放置";
        public Value3 CameraPosition = new Value3();//相机位置
        public Value3 CameraRotation = new Value3();//相机旋转角
        public float CameraSize;//相机尺寸
        public override string GetName { get { return CameraPlaceEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }

        public override ResultConfig Clone()
        {
            var result = new CameraPlaceEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.CameraPosition = this.CameraPosition;
            result.CameraRotation = this.CameraRotation;
            result.CameraSize = this.CameraSize;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is CameraPlaceEventResultConfig)
            {
                var sourceconfig = source as CameraPlaceEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.CameraPosition = sourceconfig.CameraPosition;
                this.CameraRotation = sourceconfig.CameraRotation;
                this.CameraSize = sourceconfig.CameraSize;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.CameraPlaceEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.CameraPlaceEventResultConfig_CameraPosition, CameraPosition);
        //     attr.Add(TriggerResultAttr.CameraPlaceEventResultConfig_CameraRotation, CameraRotation);
        //     attr.Add(TriggerResultAttr.CameraPlaceEventResultConfig_CameraSize, CameraSize);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }

        public override void LoadFromAttrDictionary(Dictionary<string, object> attr)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    if (field.Name == "CameraPosition")
                    {
                        var attrObj = attr["CameraPosition"] as JToken;
                        this.CameraPosition = attrObj.ToObject<Value3>();
                    }
                    else if (field.Name == "CameraRotation")
                    {
                        var attrObj = attr["CameraRotation"] as JToken;
                        this.CameraRotation = attrObj.ToObject<Value3>();
                    }
                    else
                    {
                        field.SetValue(this, attr[field.Name]);
                    }
                }
            }
        }


    }
}