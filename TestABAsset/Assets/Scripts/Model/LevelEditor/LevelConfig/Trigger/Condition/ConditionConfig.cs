using GlobalDefine;
using System;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //触发器条件配置基类
    public class ConditionConfig
    {
        public ConditionConfig()
        {
            this.Id = LevelUtil.GenerateID();
        }
        public string Id = "";//唯一码
        public string TriggerId = "";//触发器ID
        public EConditionType Type = 0;
        public virtual string GetName { get; }//名字
        public virtual bool Check(ConditionContext context)
        {
            return true;
        }

        public virtual ConditionConfig Clone()
        {
            return default(ConditionConfig);
        }

        public virtual void Copy(ConditionConfig source)
        {

        }
        //转换为触发器条件数据
        public virtual TriggerConditionDataModel ToTriggerConditionModel()
        {
            var type = this.GetType();
            TriggerConditionDataModel result = new TriggerConditionDataModel();
            EConditionType conditionType = EConditionType.None;
            if (Enum.TryParse<EConditionType>(type.Name, out conditionType))
            {
                result.Type = conditionType;
                var field = typeof(ETriggerConditionAttrs).GetField(type.Name);
                if (field != null)
                {
                    var value = field.GetRawConstantValue().ToString();
                    var attrs = value.Split(',');
                    var attrdict = new Dictionary<string, object>();
                    for (var i = 0; i < attrs.Length; i++)
                    {
                        var attr = attrs[i];
                        var attrfield = type.GetField(attr);
                        if (attrfield != null)
                        {
                            attrdict.Add(attr, attrfield.GetValue(this));
                        }
                        else
                        {
                            DebugUtil.DebugError(string.Format("{0}中不存在属性{1}", type.Name, attr));
                        }
                    }
                    result.Attrs = attrdict;
                }
            }
            else
            {
                DebugUtil.DebugError(string.Format("{0}转换EConditionType失败", type.Name));
            }
            return result;
        }

        //从触发器数据中加载
        public virtual void LoadFromConditionModel(TriggerConditionDataModel dataModel)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            var attr = dataModel.Attrs;
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    field.SetValue(this, attr[field.Name]);
                }
            }
        }

    }
}
