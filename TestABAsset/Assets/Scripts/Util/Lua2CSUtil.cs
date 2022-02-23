using System.Collections.Generic;
using XLua;
using System;

public enum Lua2CSType
{
    CString,//字符串
    CFloat,//浮点数
    CInt//整形
}

//Lua转CS工具
public class Lua2CSUtil
{
    public static Dictionary<string, float> LuaTable2DictionaryStringFloat(LuaTable table)
    {
        var result = new Dictionary<string, float>();
        var keys = table.GetKeys();
        foreach (string key in keys)
        {
            float value = 0;
            table.Get<string, float>(key, out value);
            result.Add(key, value);
        }
        return result;
    }
    //Lua表转CS List
    public static Object LuaTable2List(LuaTable table, Type type)
    {
        var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { type }));
        var addmethod = list.GetType().GetMethod("Add");
        var keys = table.GetKeys<int>();
        foreach (int key in keys)
        {
            object value = null;
            table.Get<int, object>(key, out value);
            addmethod.Invoke(list, new object[] { value });
        }
        return list;
    }
}