using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GlobalDefine;
namespace Levels.Trigger
{
    public enum ETriggerType
    {
        NoResult,   //不需要配结果的触发器
        Normal   //普通触发器
    }
    //触发器配置
    public class TriggerConfig
    {
        public TriggerConfig()
        {
            this.Id = LevelUtil.GenerateID();
            // this.ModifyDateTime = DateTime.Now.ToString("yy-MM-dd hh:mm:ss");
            this.ConditionGroup.TriggerId = this.Id;
        }
        public ETriggerType TriggerType = ETriggerType.Normal; //触发器类型
        public ETriggerApplyType TriggerApplyType = ETriggerApplyType.Both;//触发器使用类型 
        public GlobalTriggerType GlobalTriggerType = GlobalTriggerType.BattleWin;//触发器全局类型
        public string Name = "";//触发器名
        private string modifyDateTime = "";//创建时间
        public string ModifyDateTime { get { return modifyDateTime; } protected set { modifyDateTime = value; } }
        public string Id = "";//触发器ID
        public bool IsEnabled = true; //是否已激活
        public ConditionGroupConfig ConditionGroup = new ConditionGroupConfig(); //条件列表
        public List<ResultConfig> ResultList = new List<ResultConfig>();   //结果列表
        public virtual string GetName { get; }//触发器类型名字
        public TriggerConfig Clone()
        {
            var result = new TriggerConfig();
            result.TriggerType = TriggerType;
            result.Name = Name;
            result.ModifyDateTime = ModifyDateTime;
            result.Id = Id;
            result.IsEnabled = IsEnabled;
            result.ConditionGroup = ConditionGroup;
            result.ResultList = ResultList;
            result.TriggerApplyType = TriggerApplyType;
            result.GlobalTriggerType = GlobalTriggerType;
            return result;
        }

        public void Copy(TriggerConfig source)
        {
            this.TriggerType = source.TriggerType;
            this.Name = source.Name;
            this.ModifyDateTime = source.ModifyDateTime;
            this.Id = source.Id;
            this.IsEnabled = source.IsEnabled;
            this.ConditionGroup = source.ConditionGroup;
            this.ResultList = source.ResultList;
            this.TriggerApplyType = source.TriggerApplyType;
            this.GlobalTriggerType = source.GlobalTriggerType;
        }
        //转化为导出触发器数据
        public TriggerDataModel ToTriggerData()
        {
            var triggerdata = new TriggerDataModel();
            triggerdata.GlobalTriggerType = this.GlobalTriggerType;
            triggerdata.TriggerApplyType = this.TriggerApplyType;
            // triggerdata.TriggerType = this.TriggerType;
            triggerdata.ConditionGroup = ConditionGroup.ToTriggerConditionModel();
            var resultList = new List<TriggerResultDataModel>();
            for (var i = 0; i < ResultList.Count; i++)
            {
                var resultItem = ResultList[i];
                var resultModel = resultItem.ToTriggerResultModel();
                if (resultModel != null)
                {
                    resultList.Add(resultModel);
                }
            }
            triggerdata.ResultList = resultList;
            triggerdata.Name = this.Name;
            triggerdata.ModifyDateTime = this.ModifyDateTime;
            return triggerdata;
        }
        //从触发器数据加载
        public void LoadFromTriggerModel(TriggerDataModel model)
        {
            this.Id = model.Id;
            this.TriggerType = ETriggerType.Normal;
            this.TriggerApplyType = model.TriggerApplyType;
            this.GlobalTriggerType = model.GlobalTriggerType;
            this.Name = model.Name;
            this.modifyDateTime = model.ModifyDateTime;
            this.ConditionGroup.LoadFromConditionModel(model.ConditionGroup);
            var resultList = model.ResultList;
            var resultConfigList = new List<ResultConfig>();
            for (var i = 0; i < resultList.Count; i++)
            {
                var resultModel = resultList[i];
                var resultTypeName = resultModel.Type.ToString();
                var resultType = System.Type.GetType(string.Format("Levels.Trigger.{0}", resultTypeName));
                ResultConfig resultInstance = System.Activator.CreateInstance(resultType) as ResultConfig;
                resultInstance.TriggerId = this.Id;
                resultInstance.LoadFromResultModel(resultModel);
                resultConfigList.Add(resultInstance);
            }
            this.ResultList = resultConfigList;
        }
    }
}