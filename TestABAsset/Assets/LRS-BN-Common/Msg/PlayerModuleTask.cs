using System.Collections.Generic;
namespace Msg {
    //玩家跑商、随机任务模块
    public class PlayerModuleTask {
        public Dictionary<int, TaskInfo> tasks = new Dictionary<int, TaskInfo>();//key任务类型,任务信息
    }
}