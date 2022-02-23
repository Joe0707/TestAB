using System.Collections.Generic;
namespace Msg {
    //城堡建筑信息
    public class CastleArchitectureInfo {
        //唯一ID
        public string id = "";
        //等级
        public int lv = 0;
        //类型
        public int type = 0;
        //是否可以领取建筑产出 0为否 1为可以
        public int canGain = 0;
        //建筑产出列表
        public List<IntPair> produce = new List<IntPair>();
        //建筑所在槽位
        public int slot = 0;
        //建筑槽位类型
        public int slotType = 0;
        //建筑守卫GID
        public string guard = "";
        //建筑守卫提供的加成百分比
        public int guardProducePro = 0;
    }
}