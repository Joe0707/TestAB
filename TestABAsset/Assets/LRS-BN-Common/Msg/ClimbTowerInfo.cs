using System.Collections.Generic;
namespace Msg {
    // 塔信息
    public class TowerInfo {
        public int towerId = 0;                //塔ID
        public int status = 0;                 //塔状态 1开启|0关闭
        public int cycle = 1;                  //循环次数
        public int battleLayer = 1;            //挑战层数
        public int battleCount = 0;            //挑战次数
    }
    public class TowerShopInfo {
        public int shopGid = 0;            //商品Gid
        public int shopId = 0;            //商品id
        public int exchangeCount = 0;     //兑换次数
    }
}