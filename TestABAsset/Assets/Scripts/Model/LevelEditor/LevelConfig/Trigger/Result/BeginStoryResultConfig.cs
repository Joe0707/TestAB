using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class BeginStoryResultConfig : ResultConfig
    {
        public const string Name = "产生剧情";
        public override string GetName
        { get { return BeginStoryResultConfig.Name; } }//结果事件名
    }

}