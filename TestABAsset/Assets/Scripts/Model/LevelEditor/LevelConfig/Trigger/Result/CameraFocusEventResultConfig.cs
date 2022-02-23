using GlobalDefine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace Levels.Trigger
{
    //相机焦点事件
    public class CameraFocusEventResultConfig : ResultConfig
    {
        public CameraFocusEventResultConfig() : base()
        {

        }
        public const string Name = "相机焦点";
        public string RoleID = "";//角色ID
        public float Move2FocusTime = 0;//从当前状态到焦点状态的时间
        public Value3 EndPosition = new Value3();//相机焦点位置
        public Value3 EndRotation = new Value3();//相机焦点旋转角
        public float EndCameraSize = 0;//相机焦点尺寸
        public override string GetName { get { return CameraFocusEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }

        // //转换结果数据
        // public override TriggerResultDataModel ToTriggerResultModel()
        // {
        //     var triggerResult = new TriggerResultDataModel();
        //     triggerResult.type = EResultType.CameraFocusEventResultConfig;
        //     var attr = new Dictionary<string, object>();
        //     attr.Add(TriggerResultAttr.CameraFocusEventResultConfig_RoleID, RoleID);
        //     attr.Add(TriggerResultAttr.CameraFocusEventResultConfig_Move2FocusTime, Move2FocusTime);
        //     attr.Add(TriggerResultAttr.CameraFocusEventResultConfig_EndPosition, EndPosition);
        //     attr.Add(TriggerResultAttr.CameraFocusEventResultConfig_EndRotation, EndRotation);
        //     attr.Add(TriggerResultAttr.CameraFocusEventResultConfig_EndCameraSize, EndCameraSize);
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