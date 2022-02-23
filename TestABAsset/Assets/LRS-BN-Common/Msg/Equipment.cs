using System.Collections.Generic;
namespace Msg{
    /** 装备返回参数定义 */
    public class Equipment{
        public string equipGid = "";    //装备唯一ID
        public int equipId = 0;         //装备ID
        public int equipSlotType = 0;   //装备类型
        public int skillId = 0;         //装备绑定的攻击技能ID
        public string actorGid = "";    //使用者唯一ID,为空没使用
        public Dictionary<int, int> equipAttrInfo = new Dictionary<int, int>();
        public int equipQuality = 0;        //装备品质
        public int equipStrengthen = 0;     //装备强化等级
        /**装备杀敌数 */
        public int killNum = 0;
        /**装备槽位信息列表 */
        public List<GemSlotInfo> gemSlotInfos = new List<GemSlotInfo>();
        /**刷新附魔属性信息次数 */
        public int refreshEnchatNum = 0;
        /**附魔信息 */
        public EquipEnchantingInfo enchantingInfo = new EquipEnchantingInfo();
        /**临时随机出未确认附魔的属性等级信息 */
        public EquipEnchantingInfo temporaryEnchatingInfo = new EquipEnchantingInfo();
        /**装备已洗炼次数 */
        public int refinementCount = 0;
        /** 装备穿戴需要力量*/
        public int needStr = 0;
        /**技能效果槽位信息列表 */
        public List<EquipSkillSlotInfo> equipSkillSlotInfos = new List<EquipSkillSlotInfo>();
        /**圣物信息*/
        public CorpsSacredInfo corpsSacred = new CorpsSacredInfo();
        /**装备主属性Id*/
        public int equipMasterAttrId = 0;
        /**装备战力*/
        public int powerValue = 0;
    }
}