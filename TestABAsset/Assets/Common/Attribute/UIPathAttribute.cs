using System;
using System.Reflection;
// 一个自定义特性 BugFix 被赋给类及其成员
[AttributeUsage(AttributeTargets.Class |
AttributeTargets.Constructor |
AttributeTargets.Field |
AttributeTargets.Method |
AttributeTargets.Property,
AllowMultiple = true)]
public class UIPathAttribute : System.Attribute
{
    private string path;//路径名
    public UIPathAttribute(string path)
    {
        this.path = path;
    }

    public string Path
    {
        get
        {
            return path;
        }
    }
}