using System.Collections.Generic;
using System.Collections;
using System;
/// <summary>
/// 数据类工具
/// </summary>
public class DataUtil
{
    public static void PopStack<T>(Stack<T> stack, T obj) where T : class
    {
        if (stack.Contains(obj))
        {
            if (stack.Peek() == obj)
            {
                //第一个就是要弹出的物体
                stack.Pop();
            }
            else
            {
                var newStack = new Stack<T>();
                while (stack.Count > 0)
                {
                    var stackObj = stack.Pop();
                    if (stackObj == obj)
                    {
                        continue;
                    }
                    newStack.Push(stackObj);
                }
                stack.Clear();
                while (newStack.Count > 0)
                {
                    stack.Push(newStack.Pop());
                }
            }
        }
    }

    public static void PopStack(Stack stack, Object obj)
    {
        if (stack.Contains(obj))
        {
            if (stack.Peek() == obj)
            {
                //第一个就是要弹出的物体
                stack.Pop();
            }
            else
            {
                var newStack = new Stack();
                while (stack.Count > 0)
                {
                    var stackObj = stack.Pop();
                    if (stackObj == obj)
                    {
                        continue;
                    }
                    newStack.Push(stackObj);
                }
                stack.Clear();
                while (newStack.Count > 0)
                {
                    stack.Push(newStack.Pop());
                }
            }
        }
    }

    public static T Clone<T>(T t) where T : new()
    {
        T result = new T();
        var fieldInfos = t.GetType().GetFields();
        for (var i = 0; i < fieldInfos.Length; i++)
        {
            var fieldInfo = fieldInfos[i];
            fieldInfo.SetValue(result, fieldInfo.GetValue(t));
        }
        return result;
    }
}