using System.Collections.Generic;
namespace Msg {
    //玩家的背包模块数据
    public class PlayerModuleBag {
        public List<ItemInfo> bags = new List<ItemInfo>();    //背包信息
        public List<Equipment> equipments = new List<Equipment>();//装备信息
        public List<GemInfo> gems = new List<GemInfo>(); // 宝石信息
    }
}