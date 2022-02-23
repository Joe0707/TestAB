using GlobalDefine;
using System.Collections.Generic;
using System;
namespace Levels.Trigger
{
    public enum ERoleProperty
    {
        HP = 0   //HP
    }
    //角色信息事件配置
    public class RoleInfoEventConditionConfig : ConditionConfig
    {
        public const string Name = "角色信息";
        public string RoleId = "";//角色Id
        public ERoleProperty Property = ERoleProperty.HP;//角色属性
        public float Limit = 0;//限制数值
        public override string GetName { get { return RoleInfoEventConditionConfig.Name; } }
        public override bool Check(ConditionContext context)
        {
            return true;
        }

        public override ConditionConfig Clone()
        {
            var result = new RoleInfoEventConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.RoleId = this.RoleId;
            result.Limit = this.Limit;
            result.Property = this.Property;
            result.Type = this.Type;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            if (source is RoleInfoEventConditionConfig)
            {
                var sourceconfig = source as RoleInfoEventConditionConfig;
                this.Id = sourceconfig.Id;
                this.Type = sourceconfig.Type;
                this.Property = sourceconfig.Property;
                this.Limit = sourceconfig.Limit;
                this.TriggerId = sourceconfig.TriggerId;
                this.RoleId = sourceconfig.RoleId;
            }
        }

        //转换为触发器条件数据
        public override TriggerConditionDataModel ToTriggerConditionModel()
        {
            var result = new TriggerConditionDataModel();
            result.Type = EConditionType.RoleInfoEventConditionConfig;
            var attr = new Dictionary<string, object>();
            var type = this.GetType();
            var attrvalue = ETriggerConditionAttrs.RoleInfoEventConditionConfig;
            var attrfields = attrvalue.Split(',');
            for (var i = 0; i < attrfields.Length; i++)
            {
                var attrfield = attrfields[i];
                if (attrfield == "Property")
                {
                    attr.Add("Property", ConvertProperty2EActorAttr(Property));
                }
                else
                {
                    var attrfieldInfo = type.GetField(attrfield);
                    if (attrfieldInfo != null)
                    {
                        attr.Add(attrfield, attrfieldInfo.GetValue(this));
                    }
                    else
                    {
                        DebugUtil.DebugError(string.Format("{0}中不存在属性{1}", type.Name, attr));
                    }
                }
            }
            result.Attrs = attr;
            return result;
        }
        //转换属性为角色的属性
        public EActorAttrType ConvertProperty2EActorAttr(ERoleProperty property)
        {
            EActorAttrType result = EActorAttrType.curHp;
            switch (property)
            {
                case ERoleProperty.HP:
                    result = EActorAttrType.curHp;
                    break;
                default:
                    DebugUtil.DebugError(string.Format("{0}转换EActorAttrType失败", property.ToString()));
                    break;
            }
            return result;
        }

        //转换属性为角色的属性
        public ERoleProperty ConvertEActorAttr2Property(EActorAttrType property)
        {
            ERoleProperty result = ERoleProperty.HP;
            switch (property)
            {
                case EActorAttrType.curHp:
                    result = ERoleProperty.HP;
                    break;
                default:
                    DebugUtil.DebugError(string.Format("{0}转换ERoleProperty失败", property.ToString()));
                    break;
            }
            return result;
        }

        //从触发器数据中加载
        public override void LoadFromConditionModel(TriggerConditionDataModel dataModel)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            var attr = dataModel.Attrs;
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    if (field.Name == "Property")
                    {
                        var property = attr["Property"];
                        var attrType = (EActorAttrType)property;
                        this.Property = ConvertEActorAttr2Property(attrType);
                    }
                    else
                    {
                        var value = attr[field.Name];
                        field.SetValue(this, value);
                    }
                }
            }
        }


    }

}