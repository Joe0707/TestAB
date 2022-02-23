//事件对象
public class EventVo
{
   public string mName;//事件名
   public object mData;//事件数据
   public EventVo(string name, object data)
   {
      mName = name;
      mData = data;
   }
}