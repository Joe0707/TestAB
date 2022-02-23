using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Levels.Trigger
{
    //角色移动到位置
    public class RoleMove2PositionEventResultConfig : ResultConfig
    {
        public const string Name = "角色到位置";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>移动角色ID</UText><URoleSelect id='1'>$property$</URoleSelect></UContainer>")]
        public string RoleId;//移动角色ID
        [ConfigAttribute("<UValue3 title='移动位置'></UValue3>", PassdPropertyByProp = "defaultvalue")]
        public Value3 Position = new Value3();//移动位置
        public override string GetName { get { return RoleMove2PositionEventResultConfig.Name; } }//结果事件名

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
                    else
                    {
                        field.SetValue(this, attr[field.Name]);
                    }
                }
            }
        }
    }

}