namespace Msg {
    /** 装备镶嵌宝石的槽位信息*/
    public class GemSlotInfo {
        /**槽位ID */
        public string gemSlotGid = "";
        /** 槽位(品质)颜色*/
        public int color = 0;
        /**槽位等级 */
        public int slotLevel = 1;
        /**宝石唯一ID*/
        public string gemGid = "";
        /**槽位重置次数 */
        public int resetCount = 0;
    }
}