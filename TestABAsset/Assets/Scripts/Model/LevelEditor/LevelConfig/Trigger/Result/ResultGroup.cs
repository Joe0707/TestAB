using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //同时发生的结果组
    public class ResultGroup : ResultConfig
    {
        public const string Name = "同时进行的结果组";
        //同时结果组
        public List<ResultConfig> Results = new List<ResultConfig>();
        public override string GetName
        { get { return ResultGroup.Name; } }//结果事件名
        public override ResultConfig Clone()
        {
            var newresult = base.Clone() as ResultGroup;
            var newList = new List<ResultConfig>();
            var list = this.Results;
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var itemclone = item.Clone();
                newList.Add(itemclone);
            }
            newresult.Results = newList;
            return newresult;
        }

        public override void Copy(ResultConfig source)
        {
            base.Copy(source);
            ResultGroup value = source as ResultGroup;
            var newList = new List<ResultConfig>();
            var list = value.Results;
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                var itemclone = item.Clone();
                newList.Add(itemclone);
            }
            this.Results = newList;
        }
        //转换为触发器条件数据
        public override TriggerResultDataModel ToTriggerResultModel()
        {
            //条件集属性进行List转化
            var resultList = new List<TriggerResultDataModel>();
            for (var i = 0; i < Results.Count; i++)
            {
                var resultitem = Results[i];
                var resultItemModel = resultitem.ToTriggerResultModel();
                resultList.Add(resultItemModel);
            }
            var result = new TriggerResultDataModel();
            result.Type = EResultType.ResultGroup;
            result.SubResults = resultList;
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
        public override void LoadFromResultModel(TriggerResultDataModel dataModel)
        {
            var attr = dataModel.Attrs;
            LoadFromAttrDictionary(attr);
            var resultModelList = dataModel.SubResults;
            var resultConfigList = new List<ResultConfig>();
            for (var j = 0; j < resultModelList.Count; j++)
            {
                var resultModel = resultModelList[j] as TriggerResultDataModel;
                var resultTypeName = resultModel.Type.ToString();
                var resultType = System.Type.GetType(string.Format("Levels.Trigger.{0}", resultTypeName));
                ResultConfig configInstance = System.Activator.CreateInstance(resultType) as ResultConfig;
                configInstance.TriggerId = this.TriggerId;
                configInstance.LoadFromResultModel(resultModel);
                resultConfigList.Add(configInstance);
            }
            this.Results = resultConfigList;
        }

        public override void LoadFromResultModelJson(TriggerResultDataModel dataModel)
        {
            var attr = dataModel.Attrs;
            LoadFromAttrDictionaryJson(attr);
            var resultModelList = dataModel.SubResults;
            var resultConfigList = new List<ResultConfig>();
            for (var j = 0; j < resultModelList.Count; j++)
            {
                var resultModel = resultModelList[j] as TriggerResultDataModel;
                var resultTypeName = resultModel.Type.ToString();
                var resultType = System.Type.GetType(string.Format("Levels.Trigger.{0}", resultTypeName));
                ResultConfig configInstance = System.Activator.CreateInstance(resultType) as ResultConfig;
                configInstance.TriggerId = this.TriggerId;
                configInstance.LoadFromResultModelJson(resultModel);
                resultConfigList.Add(configInstance);
            }
            this.Results = resultConfigList;
        }

    }

}