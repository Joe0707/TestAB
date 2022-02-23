public class Value2
{
   public Value2()
   {

   }

   public Value2(float x, float y)
   {
      this.x = x;
      this.y = y;
   }
   public float x = 0;
   public float y = 0;

   public Value2 Clone()
   {
      var result = new Value2();
      result.x = this.x;
      result.y = this.y;
      return result;
   }

}