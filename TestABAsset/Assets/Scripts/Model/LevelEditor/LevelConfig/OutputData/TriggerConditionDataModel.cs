using GlobalDefine;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Levels.Trigger
{
    //触发器条件数据
    public class TriggerConditionDataModel
    {
        public EConditionType Type = 0;
        public ERelation Relation = ERelation.Or;
        public Dictionary<string, object> Attrs = new Dictionary<string, object>();
        public List<TriggerConditionDataModel> SubConditions = new List<TriggerConditionDataModel>();
    }
}