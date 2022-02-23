using System.Collections.Generic;
namespace Msg {
    //组队副本副本信息
    public class TeamBattleCopyInfo {
		public string playerGid = "";
        /**军团名称*/
        public string corpsName = "";
        /**旗帜信息*/
        public CorpsFlagInfo flagInfo = new CorpsFlagInfo();
        //index 0为主线玩家 其他都是支线玩家
		public int index = 0;
        //已经使用的挑战次数
		public int useNum = 0;
		//购买次数
		public int buyNum = 0;
        //copyState -1为通关副本 0为未通关 正数为副本关键建筑的剩余血量
		public int copyState = 0;
    }
}