using GlobalDefine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Levels.Trigger
{
    public class CameraInitPositionSetEventResultConfig : ResultConfig
    {
        public const string Name = "相机初始设置";
        public Value3 Position = new Value3();//相机终点位置
        public Value3 Rotation = new Value3();//相机终点旋转角
        public float CameraSize;//相机终点尺寸
        public override string GetName { get { return CameraInitPositionSetEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
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
                    if (field.Name == "Position")
                    {
                        var attrObj = attr["Position"] as JToken;
                        this.Position = attrObj.ToObject<Value3>();
                    }
                    else if (field.Name == "Rotation")
                    {
                        var attrObj = attr["Rotation"] as JToken;
                        this.Rotation = attrObj.ToObject<Value3>();
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