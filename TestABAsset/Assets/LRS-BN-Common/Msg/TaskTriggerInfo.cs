using System.Collections.Generic;
namespace Msg {
    public class TaskTriggerInfo {
        public int triggerId = 0;//触发器ID
        public int triggerType = 0;//触发器类型
        public int triggerParam = 0;//触发器的参数
        public int extraParam = 0;//触发器额外参数,例如类型为战场类型是,该参数是战斗关卡ID
    }
}