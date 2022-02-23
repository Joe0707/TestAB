using System.Collections.Generic;
namespace Msg {
    //成就(目标)任务奖励
    public class PlayerModuleAttainment {
        public Dictionary<int, AttainmentInfo> attainment = new Dictionary<int, AttainmentInfo>();//key目标ID,value目标达到信息
    }
}