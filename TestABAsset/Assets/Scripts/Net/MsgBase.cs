using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using SimpleJson;
using UnityEngine;
public class MsgBase
{
    //将对象转成Json
    public SimpleJson.JsonObject ToJson()
    {
        var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(this);
        var jsonObj = (JsonObject)SimpleJson.SimpleJson.DeserializeObject(jsonStr);
        return jsonObj;
    }

    //将JsonObject转成对象
    public static T JsonToObject<T>(SimpleJson.JsonObject data)
    {
        var jsonStr = SimpleJson.SimpleJson.SerializeObject(data);
        T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonStr);
        return obj;
    }
    //通过字符串查询类型
    public static MsgBase JsonToObjectWithTypeName(string type, SimpleJson.JsonObject data)
    {
        var t = System.Type.GetType(type);
        System.Reflection.MethodInfo mi = typeof(MsgBase).GetMethod("JsonToObject").MakeGenericMethod(t);
        return (MsgBase)mi.Invoke(null, new object[] { data });
    }

    public static System.Object JsonToObjectWithType(System.Type type, SimpleJson.JsonObject data)
    {
        // UnityEngine.Debug.Log(data.ToString());
        return Newtonsoft.Json.JsonConvert.DeserializeObject(Newtonsoft.Json.JsonConvert.SerializeObject(data), type);
    }
}
