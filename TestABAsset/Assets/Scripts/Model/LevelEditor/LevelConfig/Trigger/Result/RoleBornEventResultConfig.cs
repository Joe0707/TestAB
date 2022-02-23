using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class RoleBornEventResultConfig : ResultConfig
    {
        public const string Name = "角色生成";
        public string RoleId;   //角色Id
        public override string GetName
        { get { return RoleBornEventResultConfig.Name; } }//结果事件名
    }

}