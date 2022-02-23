using System.Collections.Generic;
namespace Msg {
    public class EntrustInfo {
        public string entrustGid = ""; //委托任务唯一ID
        public int entrustId = 0; //委托任务ID
        public int time = 0; //接委托任务的时间
        public int status = 0; //委托任务状态, 0未接取, 1已接未完成, 2完成任务待领奖
        public List<string> actorGids = new List<string>(); //负责执行委托任务的角色唯一ID列表
        public int completeTime = 0;//完成任务需要时间/月(游戏内时间)
        public int rewardGroupId = 0;//奖励组ID
        public int extraEntrustCondition = 0;//接委托任务额外限制条件ID(TaskEntrustRequirementRandom表中的ID)
        public int extraRewardCount = 0;//额外限制的奖励道具数量(追加奖励ID在TaskEntrustRequirementRandom表配置)
        public long createTime = 0;//委托任务创建时间
    }
}