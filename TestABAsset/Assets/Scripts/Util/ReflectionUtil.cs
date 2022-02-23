using System.Reflection;
public class ReflectionUtil
{
    //根据字段名获取属性
    public static FieldInfo GetFieldByName(FieldInfo[] infos, string fieldName)
    {
        FieldInfo result = null;
        for (var i = 0; i < infos.Length; i++)
        {
            var info = infos[i];
            if (info.Name == fieldName)
            {
                result = info;
                break;
            }
        }
        return result;
    }

}