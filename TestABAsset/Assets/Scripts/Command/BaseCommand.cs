//命令基类
public class BaseCommand
{
   public BaseCommand()
   {

   }
   public bool NeedUnDo = false;//需要撤销
                                //执行
   public virtual void Execute(object param)
   {

   }
   //释放
   public virtual void Dispose()
   {

   }
   //撤销
   public virtual void UnDo()
   {

   }

}
