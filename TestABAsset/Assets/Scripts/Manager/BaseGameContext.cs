using System.Collections.Generic;
using System;
using UnityEngine;
public class BaseGameContext : MonoBehaviour
{
   //一个事件和控制器关联的字典
   protected Dictionary<string, Type> eventCommandDict = new Dictionary<string, Type>();
   protected Stack<BaseCommand> commandStack = new Stack<BaseCommand>();

   public virtual void Init()
   {

   }

   public virtual void Dispose()
   {
      eventCommandDict.Clear();
      commandStack.Clear();
   }

   //撤销指令
   public void UnDoCommand(object param)
   {
      //从栈中取出一个指令
      var command = commandStack.Pop();
      command.UnDo();
      command.Dispose();
   }
   //处理事件
   public void ProcessEvent(object param)
   {
      var eventvo = param as EventVo;
      var eventname = eventvo.mName;
      var type = GetCommandTypeByEventName(eventname);
      if (type != null)
      {
         BaseCommand command = Activator.CreateInstance(type) as BaseCommand;
         if (command.NeedUnDo)
         {
            commandStack.Push(command);
         }
         command.Execute(eventvo.mData);
         if (command.NeedUnDo == false)
         {
            command.Dispose();
         }
      }
   }
   //根据事件名获得命令类型
   private Type GetCommandTypeByEventName(string eventName)
   {
      Type t = null;
      this.eventCommandDict.TryGetValue(eventName, out t);
      return t;
   }

   void Start()
   {
      Init();
   }

   void OnDestroy()
   {
      Dispose();
   }

}