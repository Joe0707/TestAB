using System.Collections.Generic;
namespace Msg {
    public class ItemInfo {
        /**道具唯一ID */
        public string itemGid = "";
        /**道具ID */ 
        public int itemId = 0;
        /**道具数量*/
        public int count = 0;
        /**道具类型*/
        public int itemType = 0;
        /**是否在背包展示*/
        public int display = 0;
        /**额外属性的唯一id*/
        public string extraAttrGid ="";
        /**道具额外属性 */
        public Dictionary<string, string > extraAttr = new Dictionary<string, string>();
        /**宝石增加的属性 addNatureConfig */
        /**使用次数 useCount*/
    }
}