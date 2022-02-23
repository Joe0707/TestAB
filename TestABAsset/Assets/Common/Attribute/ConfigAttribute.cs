using System;
using System.Reflection;
// 一个自定义特性 BugFix 被赋给类及其成员
[AttributeUsage(AttributeTargets.Class |
AttributeTargets.Constructor |
AttributeTargets.Field |
AttributeTargets.Method |
AttributeTargets.Property,
AllowMultiple = true)]
/**
    labeltext中特殊字符
    $property$:表示引用当前字段的值
*/
public class ConfigAttribute : System.Attribute
{
    private string labeltext;//标签文本
    public string passPropertyByProp;//通过prop传递的Prop名
    public ConfigAttribute(string labeltext)
    {
        this.labeltext = labeltext;
    }

    public string LabelText
    {
        get
        {
            return labeltext;
        }
    }

    public string PassdPropertyByProp
    {
        get
        {
            return passPropertyByProp;
        }
        set
        {
            passPropertyByProp = value;
        }
    }
}