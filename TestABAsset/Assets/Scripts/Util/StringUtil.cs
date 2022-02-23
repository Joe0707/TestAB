using System.Text.RegularExpressions;
public class StringUtil
{
   public static bool IsNumber(string text)
   {
      var result = false;
      if (!string.IsNullOrEmpty(text))
      {
         var rex = new Regex(@"^\d+$");
         if (rex.IsMatch(text))
         {
            result = true;
         }
      }
      return result;
   }
}