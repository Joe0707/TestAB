using UnityEngine;
using System;
//颜色工具
public class ColorUtil
{
    //根据颜色值转换颜色
    public static Color GetColor(string colorvalue)
    {
        var result = Color.black;
        if (!string.IsNullOrEmpty(colorvalue) && colorvalue.Length == 6)
        {
            var r = Convert.ToInt32(colorvalue.Substring(0, 2), 16) / 255f;
            var g = Convert.ToInt32(colorvalue.Substring(2, 2), 16) / 255f;
            var b = Convert.ToInt32(colorvalue.Substring(4, 2), 16) / 255f;
            result.r = r;
            result.g = g;
            result.b = b;
        }
        return result;
    }
}