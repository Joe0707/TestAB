using System.Collections.Generic;
namespace Msg {
    //城堡宴会信息
    public class CastleTrainInfo {
        //城堡训练教师信息
        public List<CastleTrainInstructorInfo> instructorList = new List<CastleTrainInstructorInfo>();
        //城堡训练重点学生列表
        public List<string> emphasisStudent = new List<string>();
        //城堡训练历练信息
        public List<CastleTrainPracticeInfo> practiceList = new List<CastleTrainPracticeInfo>();
        //额外历练槽位数量
        public int extraPracticeSlotNum = 0;
    }
}