using System.Collections.Generic;
namespace Msg {
    //主线、支线任务
    public class TaskMainInfo {
        public string taskGid = "";//任务GID
        public int taskId = 0;//任务的配置ID
        public int taskType = 0;//任务的类型,1主线,2支线
        public int storyIdIndex = 0;//当前主线剧情ID在cfg的下标
        public int taskState = 0;//任务的状态,0未知,1已接任务(执行中),2已完成任务,3已提交任务(领取了奖励)
    }
}