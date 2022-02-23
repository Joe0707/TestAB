using System.Collections.Generic;
namespace Msg {
    /** 城堡训练历练信息*/
    public class CastleTrainPracticeInfo {
        //教师GID
        public string instructorGid = "";
        //学生GID
        public string studenGid = "";
        //开始时间
        public int startTime = -1;
        //历练目标势力范围
        public int targetPrestige = 0;
        //历练槽位
        public int slot = 0;
        //历练槽位类型
        public int slotType = 0;
    }
}