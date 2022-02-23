using System.Collections.Generic;
namespace Msg {
    //玩家主线、支线任务模块
    public class PlayerModuleTaskMain {
        public TaskMainInfo mainTask = new TaskMainInfo();//主线任务信息
        public List<TaskMainInfo> branchTask = new List<TaskMainInfo>();//支线任务信息
    }
}