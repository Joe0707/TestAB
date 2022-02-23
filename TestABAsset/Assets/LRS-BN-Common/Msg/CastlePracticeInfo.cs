using System.Collections.Generic;
namespace Msg {
    //城堡历练信息
    public class CastlePracticeInfo {
        //城堡出发历练信息
        public List<CastlePracticeRunInfo> practiceList = new List<CastlePracticeRunInfo>();
        //额外历练槽位数量
        public int extraPracticeSlotNum = 0;
    }
}