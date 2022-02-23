namespace Levels.Trigger
{

    //职业击杀角色条件
    public class JobKillRoleConditionConfig : ConditionConfig
    {
        public const string Name = "职业击杀角色条件";
        public override string GetName { get { return JobKillRoleConditionConfig.Name; } }
        public string RoleId;//角色Id
        public int JobId;//职业Id
        public override ConditionConfig Clone()
        {
            var result = new JobKillRoleConditionConfig();
            result.Id = this.Id;
            result.TriggerId = this.TriggerId;
            result.Type = this.Type;
            result.JobId = this.JobId;
            result.RoleId = this.RoleId;
            return result;
        }

        public override void Copy(ConditionConfig source)
        {
            JobKillRoleConditionConfig value = source as JobKillRoleConditionConfig;
            this.TriggerId = value.TriggerId;
            this.Type = value.Type;
            this.JobId = value.JobId;
            this.RoleId = value.RoleId;
        }

    }
}