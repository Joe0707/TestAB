using System.Collections.Generic;
namespace Msg{
    /** 技能返回参数定义 */
    public class TaskFunctionInfo{
        public TaskInfo acceptTask = new TaskInfo();//接取的任务（未完成或未提交的）
        public List<int> taskIdList = new List<int>();//随机出的任务ID列表
    }
}