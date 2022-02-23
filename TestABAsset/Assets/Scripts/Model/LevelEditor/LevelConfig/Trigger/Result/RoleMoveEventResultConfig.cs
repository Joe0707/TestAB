using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Levels.Trigger
{
    //角色移动事件
    public class RoleMoveEventResultConfig : ResultConfig
    {
        public const string Name = "角色移动";
        public string RoleId;//移动角色ID
        public bool IsMove2Position = false;//是否是移动到位置
        public int SlotIndex = 0;//终点格子索引
        public Value3 Position = new Value3();//移动位置
        public string TargetId;//目标角色ID
        public int RolesSlotInterval;//角色和目标角色之间的间隔格子数
        public float MoveTime;//移动需要时间（秒）
        public override string GetName { get { return RoleMoveEventResultConfig.Name; } }//结果事件名

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