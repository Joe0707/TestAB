using System.Collections.Generic;
namespace Msg {
    /** 城堡训练历练信息*/
    public class CastlePracticeRunInfo {
        //教师GID
        public string instructorGid = "";
        //学生GID
        public string studentGid = "";
        //历练结束时间
        public int endTime = -1;
        //历练目标势力范围
        public int targetPrestige = 0;
        //历练槽位
        public int slot = 0;
        //历练槽位类型
        public int slotType = 0;
        //历练过程中已经发生的随机事件IDg
        public Dictionary<int, IntPairList> randomEventList = new Dictionary<int, IntPairList>();
    }
}