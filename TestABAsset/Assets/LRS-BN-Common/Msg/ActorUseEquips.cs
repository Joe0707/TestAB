namespace Msg{
    /** 装备返回参数定义 */
    public class ActorUseEquips{
        public string equipGid = "";    //装备唯一ID
        public int equipId = 0;     //装备ID
        public int equipSlotType = 0;   //装备槽类型 1.主手 2.副手 3.头部 4.身体 5.鞋子 6.饰品
        public int skillId = 0;     //技能ID
    }
}