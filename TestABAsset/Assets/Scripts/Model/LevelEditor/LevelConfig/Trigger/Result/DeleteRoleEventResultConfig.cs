using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色死亡事件配置
    public class DeleteRoleEventResultConfig : ResultConfig
    {
        public const string Name = "删除角色";
        public string RoleId;   //角色Id
        public override string GetName { get { return DeleteRoleEventResultConfig.Name; } }//结果事件名
        public override void Apply()
        {
        }
        public override ResultConfig Clone()
        {
            var result = new DeleteRoleEventResultConfig();
            result.Id = this.Id;
            result.type = this.type;
            result.RoleId = this.RoleId;
            result.TriggerId = this.TriggerId;
            return result;
        }

        public override void Copy(ResultConfig source)
        {
            if (source is DeleteRoleEventResultConfig)
            {
                var sourceconfig = source as DeleteRoleEventResultConfig;
                this.Id = sourceconfig.Id;
                this.type = sourceconfig.type;
                this.RoleId = sourceconfig.RoleId;
                this.TriggerId = sourceconfig.TriggerId;
            }
        }
    }

}