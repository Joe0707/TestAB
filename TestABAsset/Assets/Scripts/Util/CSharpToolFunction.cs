using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tool
{
    public static class CSharpToolFunction
    {
        public static int StrLength(string str)
        {
            return str.Length;
        }
        //字符串中只包含数字 字母 中文
        public static bool IsStrLawful(string str)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z0-9\u4e00-\u9fa5]+$");
        }
    }
}