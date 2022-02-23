using GlobalDefine;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Levels.Trigger
{
    //触发器结果数据
    public class TriggerResultDataModel
    {
        public EResultType Type = 0;//结果类型

        public Dictionary<string, object> Attrs = new Dictionary<string, object>();//结果属性
        public List<TriggerResultDataModel> SubResults = new List<TriggerResultDataModel>();
    }
}