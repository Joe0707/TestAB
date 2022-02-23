using GlobalDefine;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Levels.Trigger
{
    //触发器结果配置基类
    public class ResultConfig
    {
        public ResultConfig()
        {
            this.Id = LevelUtil.GenerateID();
        }
        public string Id = "";//唯一码
        public string TriggerId = "";
        public EResultType type = 0;
        public virtual string GetName { get; }//结果事件名
        public bool SameTimeAsPre = false; //是否和上一条同时发生
        public virtual void Apply()
        {

        }
        public virtual ResultConfig Clone()
        {
            var typeinstance = this.GetType();
            var result = System.Activator.CreateInstance(typeinstance);
            var fields = typeinstance.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                field.SetValue(result, field.GetValue(this));
            }
            return result as ResultConfig;
        }

        public virtual void Copy(ResultConfig source)
        {
            var typeinstance = this.GetType();
            var fields = typeinstance.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                field.SetValue(this, field.GetValue(source));
            }
        }
        //转触发器结果数据
        public virtual TriggerResultDataModel ToTriggerResultModel()
        {
            var type = this.GetType();
            TriggerResultDataModel result = new TriggerResultDataModel();
            EResultType resultType = EResultType.None;
            if (Enum.TryParse<EResultType>(type.Name, out resultType))
            {
                result.Type = resultType;
                //排除掉不必要的属性
                var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                var attrdict = new Dictionary<string, object>();
                foreach (var fielditem in fields)
                {
                    if (fielditem.Name == "Id" || fielditem.Name == "TriggerId" || fielditem.Name == "type")
                    {
                        continue;
                    }
                    attrdict.Add(fielditem.Name, fielditem.GetValue(this));
                }
                result.Attrs = attrdict;
                // }
            }
            else
            {
                DebugUtil.DebugError(string.Format("{0}转换EConditionType失败", type.Name));
            }
            return result;
        }

        public EResultType GetResultType()
        {
            var type = this.GetType();
            EResultType result = EResultType.None;
            Enum.TryParse<EResultType>(type.Name, out result);
            return result;
        }

        //从触发器数据中加载
        public virtual void LoadFromResultModel(TriggerResultDataModel dataModel)
        {
            var attr = dataModel.Attrs;
            LoadFromAttrDictionary(attr);
        }

        public virtual void LoadFromResultModelJson(TriggerResultDataModel dataModel)
        {
            var attr = dataModel.Attrs;
            LoadFromAttrDictionaryJson(attr);
        }

        //从字典中加载
        public virtual void LoadFromAttrDictionary(Dictionary<string, object> attr)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    field.SetValue(this, attr[field.Name]);
                }
            }
        }

        public virtual void LoadFromAttrDictionaryJson(Dictionary<string, object> attr)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    field.SetValue(this, attr[field.Name]);
                }
            }
        }

        //获得属性
        public Dictionary<string, object> GetAttrs()
        {
            var type = this.GetType();
            //排除掉不必要的属性
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var attrdict = new Dictionary<string, object>();
            foreach (var fielditem in fields)
            {
                if (fielditem.Name == "Id" || fielditem.Name == "TriggerId" || fielditem.Name == "type")
                {
                    continue;
                }
                attrdict.Add(fielditem.Name, fielditem.GetValue(this));
            }
            return attrdict;
        }

    }
}
