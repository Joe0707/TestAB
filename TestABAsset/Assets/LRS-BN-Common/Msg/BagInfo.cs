using System.Collections.Generic;
namespace Msg {
    //背包信息
    public class BagInfo {
        public int maxCount = 0;                                    //背包格子数量， -1时为无限
        public int bagType = 0;                                     //背包类型，1：装备，2：材料，3：虚拟货币等
        public List<ItemInfo> items = new List<ItemInfo>();   //背包内道具列表信息，暂时不考虑道具所在格子情况。
    }
}