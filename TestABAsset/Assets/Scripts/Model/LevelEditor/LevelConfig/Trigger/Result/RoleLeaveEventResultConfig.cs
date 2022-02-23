namespace Levels.Trigger
{
   //角色离开事件配置
   public class RoleLeaveEventResultConfig : ResultConfig
   {
      public const string Name = "角色离场";
      public string RoleId;//角色ID
      public int LevelSlotIndex;//离场格子索引
      public override string GetName { get { return RoleLeaveEventResultConfig.Name; } }//结果事件名
      public override void Apply()
      {
      }
      public override ResultConfig Clone()
      {
         var result = new RoleLeaveEventResultConfig();
         result.Id = this.Id;
         result.type = this.type;
         result.RoleId = this.RoleId;
         result.LevelSlotIndex = this.LevelSlotIndex;
         result.TriggerId = this.TriggerId;
         return result;
      }

      public override void Copy(ResultConfig source)
      {
         if (source is RoleLeaveEventResultConfig)
         {
            var sourceconfig = source as RoleLeaveEventResultConfig;
            this.Id = sourceconfig.Id;
            this.type = sourceconfig.type;
            this.RoleId = sourceconfig.RoleId;
            this.LevelSlotIndex = sourceconfig.LevelSlotIndex;
            this.TriggerId = sourceconfig.TriggerId;
         }
      }

   }
}