using Levels.Trigger;
//状态类型
public enum EStatusType
{
   Buff,
   Debuff
}

//状态结果配置
public class StatusResultConfig : ResultConfig
{
   public EStatusType StatusType;   //状态类型
   public override void Apply()
   {
      // throw new System.NotImplementedException();
   }
}