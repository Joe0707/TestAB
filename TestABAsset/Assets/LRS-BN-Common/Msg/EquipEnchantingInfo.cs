namespace Msg {
    /** 装备附魔信息*/
    public class EquipEnchantingInfo {
        /**附魔属性ID */
        public int attrId = 0;
        /**附魔属性等级 */
        public int level = 0;
        /**确定附魔次数 */
        public int enchantingNum = 0;
        /**附魔提供的所有增加的属性值,获得的值/10000*100 */
        public int currAttr = 0;

    }
}