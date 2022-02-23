using System.Collections.Generic;
namespace Msg {
    //跑商、随机任务
    public class TaskInfo {
        public string mapGid = "";//地图唯一ID
        public string pointGid = "";//城市点唯一ID
        public int pointId = 0;//接任务城市点ID
        public int taskType = 0;//任务的类型
        public int funcType = 0;//功能类型, 随机/王城/目标等等
        public int taskId = 0;//任务的配置ID
        public string taskGid = "";//任务GID
        public int taskState = 0;//任务的状态,0未知,1已接任务(执行中),2已完成任务,3已提交任务(领取了奖励)
        public int lastUpateTime = 0;//上次刷新任务时间,时间戳秒
        
    }
}