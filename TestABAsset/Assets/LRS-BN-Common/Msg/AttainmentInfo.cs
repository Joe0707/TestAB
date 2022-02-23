using System.Collections.Generic;
namespace Msg {
    //成就目标任务信息
    public class AttainmentInfo {
        public int id = 0;  //目标数据ID
        public int count = 0;   //当前达成目标数量
        public int status = 0;  //目标当前状态
        public int index = 0;  //已经过的奖励下标，如果非进度条展示的值为-1
    }
}