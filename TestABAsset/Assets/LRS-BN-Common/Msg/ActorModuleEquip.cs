using System.Collections.Generic;
namespace Msg {
    public class ActorModuleEquip {
        public List<Equipment> useEquips = new List<Equipment>();  //角色穿的装备唯一ID列表
        public uint defaultAtkEquipId = 0;                      //攻击时使用的默认装备ID
    }
}