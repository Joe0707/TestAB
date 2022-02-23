using SimpleJson;
using UnityEngine;
using System;

//JsonObject的工具类
public class JUtil
{
    //获取子级别
    static object GetSubObject(JsonObject parent, string subKey)
    {
        if (parent.ContainsKey(subKey))
            return parent[subKey];
        return null;
    }

    static object Get(JsonObject jobj, string key, object defaltValue)
    {
        if (key.Contains("/") == false) //没有目录结构
        {
            if (jobj.ContainsKey(key))
            {
                var a  = jobj[key];
                return (object)a;
            }
        }
        else
        {//有目录结构
            var subkeys = key.Split('/');
            JsonObject subObj = jobj;
            for (int i = 0; i < subkeys.Length - 1; i++)
            {
                var subKey = subkeys[i];
                if (subKey.Contains("[") && subKey.Contains("]"))
                {//数组
                    var index_start = subKey.IndexOf('[');
                    var index_end = subKey.IndexOf(']');
                    var strIndex = subKey.Substring(index_start + 1, index_end - index_start - 1);
                    int index = -1;
                    string subKeyName = subKey.Substring(0, index_start);
                    if( false == System.Int32.TryParse(strIndex, out index))
                    {//解析数组下标
                        Debug.LogError("parse index failed:" + subKey);
                        break;
                    }
                    var objList = (JsonObject[])GetSubObject(subObj, subKeyName);
                    if(objList == null)
                    {
                        Debug.LogError("no list named:" + subKeyName);
                        break;
                    }
                    if(index < objList.Length)
                        subObj = objList[index];
                    else
                    {
                        Debug.LogError("index out of range:" + subKey);
                        break;
                    }
                }
                else
                {
                    subObj = (JsonObject)GetSubObject(subObj, subKey);
                }
                //没找到子节点
                if(subObj == null)
                {
                    Debug.LogError("didn't find subkey:" + subKey); 
                    break;
                }
            }
            if(subObj != null)
            {
                var lastKey = subkeys[subkeys.Length - 1];
                if (lastKey.Contains("[") && lastKey.Contains("]"))
                {//最后是个数组
                    var index_start = lastKey.IndexOf('[');
                    var index_end = lastKey.IndexOf(']');
                    var strIndex = lastKey.Substring(index_start + 1, index_end - index_start - 1);
                    int index = -1;
                    string lastKeyName = lastKey.Substring(0, index_start);
                    if( false == System.Int32.TryParse(strIndex, out index))
                    {//解析数组下标失败
                        Debug.LogError("parse index failed:" + lastKey);
                        return defaltValue;
                    }
                    //取出数组
                    var list = (object[])GetSubObject(subObj, lastKeyName);
                    if (list == null)
                    {
                        Debug.LogError("no list named:" + lastKeyName);
                    }
                    if (index < list.Length)
                        return (object)(list[index]);
                    else
                        Debug.LogError("index out of range:" + lastKey);
                }
                else if (subObj.ContainsKey(lastKey)) //不是数组
                    return (object)(subObj[lastKey]);
            }
        }
        return defaltValue;
    }

    public static string GetString(JsonObject jobj, string key, string defaultValue = "")
    {
        return Convert.ToString(Get(jobj, key, defaultValue));
    }

    public static int GetInt(JsonObject jobj, string key, int defaultValue = 0)
    {
        return Convert.ToInt32(Get(jobj, key, defaultValue));
    }

    public static uint GetUInt(JsonObject jobj, string key, uint defaultValue = 0)
    {
        return Convert.ToUInt32(Get(jobj, key, defaultValue));
    }

    public static short GetShort(JsonObject jobj, string key, short defaultValue = 0)
    {
        return Convert.ToInt16(Get(jobj, key, defaultValue));
    }
    public static ushort GetUShort(JsonObject jobj, string key, ushort defaultValue = 0)
    {
        return Convert.ToUInt16(Get(jobj, key, defaultValue));
    }

    public static long GetLong(JsonObject jobj, string key, long defaultValue = 0)
    {
        return Convert.ToInt64(Get(jobj, key, defaultValue));
    }

    public static ulong GetULong(JsonObject jobj, string key, ulong defaultValue = 0)
    {
        return Convert.ToUInt64(Get(jobj, key, defaultValue));
    }

    public static byte GetByte(JsonObject jobj, string key, byte defaultValue = 0)
    {
        return Convert.ToByte(Get(jobj, key, defaultValue));
    }

    public static object GetObject(JsonObject jobj, string key, object defaultValue = null)
    {
        return Get(jobj, key, defaultValue);
    }

    //获得一个列表
    public static object[] GetList(JsonObject jobj, string key, object[] defaultValue = null)
    {
        var array = Get(jobj, key, defaultValue) as JsonArray;
        return array.ToArray();
    }
}