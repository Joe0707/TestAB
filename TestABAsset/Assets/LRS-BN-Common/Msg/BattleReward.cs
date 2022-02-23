using System.Collections.Generic;
namespace Msg{
    public class BattleRewardActorInfo {
        public string entityGid = "";
        public int oldLv = 0;
        public int oldExp = 0;
        public int newLv = 0;
        public int newExp = 0;
        public int addExp = 0;
        public int killNum = 0;
        public AttrInfo oldAttr = new AttrInfo();
        public AttrInfo newAttr = new AttrInfo();
        public List<SpecialityInfo> addInjury = new List<SpecialityInfo>();
        public List<Skill> updateList = new List<Skill>();
    }

    /** 战斗结束获得奖励消息字段定义 */
    public class BattleReward {
        public List<ItemInfo> itemList = new List<ItemInfo>();
        public List<Equipment> equipList = new List<Equipment>();
        public List<BattleRewardActorInfo> actorList = new List<BattleRewardActorInfo>();
    }
}