using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class EndStoryResultConfig : ResultConfig
    {
        public const string Name = "结束剧情";
        public override string GetName
        { get { return EndStoryResultConfig.Name; } }//结果事件名
    }

}