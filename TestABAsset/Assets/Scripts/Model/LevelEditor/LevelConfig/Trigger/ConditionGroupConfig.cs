using GlobalDefine;
using System.Collections.Generic;
using System;
using System.Collections;
using Newtonsoft.Json.Linq;
namespace Levels.Trigger
{
    //触发器条件组
    public class ConditionGroupConfig : ConditionConfig
    {
        public const string Name = "条件组";
        public override string GetName { get { return ConditionGroupConfig.Name; } }
        //条件关系
        public ERelation Relation = 0;
        //条件列表
        public List<ConditionConfig> mConditionList = new List<ConditionConfig>();
        //判断是否触发
        public override bool Check(ConditionContext context)
        {
            bool retValue = false;
            if (Relation == ERelation.And)
            {//组里的条件是与的关系
                retValue = true;
                foreach (var condition in mConditionList)
                {
                    if (condition.Check(context) == false)
                    {
                        retValue = false;
                        break;
                    }
                }
            }
            else if (Relation == ERelation.Or)
            {//或
                retValue = false;
                foreach (var condition in mConditionList)
                {
                    if (condition.Check(context) == true)
                    {
                        retValue = true;
                        break;
                    }
                }
            }
            return retValue;
        }

        public override ConditionConfig Clone()
        {
            var result = new ConditionGroupConfig();
            result.Id = this.Id;
            var newList = new List<ConditionConfig>();
            var list = this.mConditionList;
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var itemclone = item.Clone();
                newList.Add(itemclone);
            }
            result.mConditionList = newList;
            result.Relation = this.Relation;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            var value = source as ConditionGroupConfig;
            this.Id = value.Id;
            var newList = new List<ConditionConfig>();
            var list = value.mConditionList;
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var itemclone = item.Clone();
                newList.Add(itemclone);
            }
            this.mConditionList = newList;
            this.Relation = value.Relation;
            this.TriggerId = value.TriggerId;
            this.Type = value.Type;
        }

        //根据ID获得条件项
        public ConditionConfig GetConditionById(string Id)
        {
            ConditionConfig result = null;
            for (var i = 0; i < mConditionList.Count; i++)
            {
                var condition = mConditionList[i];
                if (condition.Id == Id)
                {
                    result = condition;
                    break;
                }
            }
            return result;
        }
        //根据Id删除条件
        public void DeleteConditionById(string Id)
        {
            var removeIndex = -1;
            for (var i = 0; i < mConditionList.Count; i++)
            {
                var condition = mConditionList[i];
                if (condition.Id == Id)
                {
                    removeIndex = i;
                    break;
                }
            }
            if (removeIndex != -1)
            {
                mConditionList.RemoveAt(removeIndex);
            }
        }


        //转换为触发器条件数据
        public override TriggerConditionDataModel ToTriggerConditionModel()
        {
            //条件集属性进行List转化
            var resultConditionList = new List<TriggerConditionDataModel>();
            for (var i = 0; i < mConditionList.Count; i++)
            {
                var condition = mConditionList[i];
                var conditionModel = condition.ToTriggerConditionModel();
                resultConditionList.Add(conditionModel);
            }
            var result = new TriggerConditionDataModel();
            result.Type = EConditionType.ConditionGroupConfig;
            result.SubConditions = resultConditionList;
            result.Relation = Relation;
            // var attr = new Dictionary<string, object>();
            // var type = this.GetType();
            // var attrvalue = ETriggerConditionAttrs.ConditionGroupConfig;
            // var attrfields = attrvalue.Split(',');
            // for (var i = 0; i < attrfields.Length; i++)
            // {
            //     var attrfield = attrfields[i];
            //     if (attrfield != "mConditionList")
            //     {
            //         var attrfieldInfo = type.GetField(attrfield);
            //         if (attrfieldInfo != null)
            //         {
            //             attr.Add(attrfield, attrfieldInfo.GetValue(this));
            //         }
            //         else
            //         {
            //             DebugUtil.DebugError(string.Format("{0}中不存在属性{1}", type.Name, attr));
            //         }
            //     }
            // }
            // result.Attrs = attr;
            return result;
        }


        //从触发器数据中加载
        public override void LoadFromConditionModel(TriggerConditionDataModel dataModel)
        {
            // var type = this.GetType();
            // var fields = type.GetFields();
            // var attr = dataModel.Attrs;
            // for (var i = 0; i < fields.Length; i++)
            // {
            //     var field = fields[i];
            //     if (attr.ContainsKey(field.Name))
            //     {
            //         if (field.Name != "mConditionList")
            //         {
            //             field.SetValue(this, attr[field.Name]);
            //         }
            //     }
            // }
            var conditionModelList = dataModel.SubConditions;
            var conditionConfigList = new List<ConditionConfig>();
            for (var j = 0; j < conditionModelList.Count; j++)
            {
                var conditionModel = conditionModelList[j] as TriggerConditionDataModel;
                var conditionTypeName = conditionModel.Type.ToString();
                var conditionType = System.Type.GetType(string.Format("Levels.Trigger.{0}", conditionTypeName));
                ConditionConfig configInstance = System.Activator.CreateInstance(conditionType) as ConditionConfig;
                configInstance.TriggerId = this.TriggerId;
                configInstance.LoadFromConditionModel(conditionModel);
                conditionConfigList.Add(configInstance);
            }
            this.mConditionList = conditionConfigList;
            this.Relation = dataModel.Relation;
        }

    }
}
