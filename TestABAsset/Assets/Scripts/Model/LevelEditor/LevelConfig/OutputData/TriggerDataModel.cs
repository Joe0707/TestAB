using System.Collections.Generic;
using GlobalDefine;

namespace Levels.Trigger
{
    //触发器数据
    public class TriggerDataModel
    {
        public string Id;//触发器Id
        public ETriggerApplyType TriggerApplyType = ETriggerApplyType.Both;//触发器使用类型 
        public GlobalTriggerType GlobalTriggerType = GlobalTriggerType.Common;//触发器类型
        public TriggerConditionDataModel ConditionGroup = new TriggerConditionDataModel();//触发器条件组数据
        public List<TriggerResultDataModel> ResultList = new List<TriggerResultDataModel>();//触发器结果列表
        public string Name;//触发器名
        public string ModifyDateTime;//创建时间
    }
}