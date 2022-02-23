using System.Collections.Generic;
namespace Msg {
    //玩家的城堡模块数据
    public class PlayerModuleCastle {
        //城堡当前等级
        public int lv = 0;
        //额外槽位数量
        public int extraSlot = 0;
        //当前城堡商会已购买道具数量
        public List<IntPair> curBuyNum = new List<IntPair>();
        //当前城堡建筑信息
        public List<CastleArchitectureInfo> architectureList = new List<CastleArchitectureInfo>();
        //城堡联姻信息
        public CastleAllianceInfo allianceInfo = new CastleAllianceInfo();
        //城堡宴会信息
        public CastleFeastInfo feastInfo = new CastleFeastInfo();
        //城堡历练信息
        public CastlePracticeInfo practiceInfo = new CastlePracticeInfo();
        //城堡学校信息
        public CastleSchoolInfo schoolInfo = new CastleSchoolInfo();
        //城堡征兵记录信息
        public Dictionary<int, int> conscriptionInfo = new Dictionary<int, int>();
    }
}