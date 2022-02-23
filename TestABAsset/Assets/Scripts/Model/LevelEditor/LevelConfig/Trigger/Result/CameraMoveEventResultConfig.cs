using GlobalDefine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Levels.Trigger
{
    public class CameraMoveEventResultConfig : ResultConfig
    {
        public const string Name = "相机移动";
        public Value3 EndPosition = new Value3();//相机终点位置
        public Value3 EndRotation = new Value3();//相机终点旋转角
        public float EndCameraSize;//相机终点尺寸
        public float MoveTime;//移动时长
        public override string GetName { get { return CameraMoveEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }

        public override ResultConfig Clone()
        {
            var result = new CameraMoveEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.EndPosition = this.EndPosition;
            result.EndRotation = this.EndRotation;
            result.EndCameraSize = this.EndCameraSize;
            result.MoveTime = this.MoveTime;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is CameraMoveEventResultConfig)
            {
                var sourceconfig = source as CameraMoveEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.EndPosition = sourceconfig.EndPosition;
                this.EndRotation = sourceconfig.EndRotation;
                this.EndCameraSize = sourceconfig.EndCameraSize;
                this.MoveTime = sourceconfig.MoveTime;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.CameraMoveEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.CameraMoveEventResultConfig_MoveTime, MoveTime);
        //     attr.Add(TriggerResultAttr.CameraMoveEventResultConfig_EndPosition, EndPosition);
        //     attr.Add(TriggerResultAttr.CameraMoveEventResultConfig_EndRotation, EndRotation);
        //     attr.Add(TriggerResultAttr.CameraMoveEventResultConfig_EndCameraSize, EndCameraSize);
        //     triggerResult.Attrs = attr;
        //     return triggerResult;
        // }
        //从字典中加载
        public override void LoadFromAttrDictionary(Dictionary<string, object> attr)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    if (field.Name == "EndPosition")
                    {
                        var attrObj = attr["EndPosition"] as JToken;
                        this.EndPosition = attrObj.ToObject<Value3>();
                    }
                    else if (field.Name == "EndRotation")
                    {
                        var attrObj = attr["EndRotation"] as JToken;
                        this.EndRotation = attrObj.ToObject<Value3>();
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