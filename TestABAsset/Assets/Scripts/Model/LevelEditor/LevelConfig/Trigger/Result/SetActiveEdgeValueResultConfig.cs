using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //设置边界数据激活
    public class SetActiveEdgeValueResultConfig : ResultConfig
    {
        public const string Name = "激活边界数据";
        public int Index;   //边界索引
        public bool Active;  //是否激活
        public override string GetName { get { return SetActiveEdgeValueResultConfig.Name; } }

        public override void LoadFromAttrDictionary(Dictionary<string, object> attr)
        {
            var type = this.GetType();
            var fields = type.GetFields();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                if (attr.ContainsKey(field.Name))
                {
                    if (field.Name == "Index")
                    {
                        field.SetValue(this, System.Convert.ToInt32(attr[field.Name]));
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