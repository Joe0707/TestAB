using System.Collections.Generic;
namespace Msg {
    //战斗场景内角色数据，战斗时角色会传的模块数量和常规场景的模块数量可能不一样
    public class Team {
        public int teamIndex = 0;                       //角色在队伍内的序号
        public string stumpId = "";                     //木桩ID
        public float orientation = 0;                   //角色朝向角度
        public string campType = "";                    //阵营类型
        public int sex = 0;                             //性别
        public int curAttackSkill = 0;                  //当前攻击技能
        public ActorInfo actorInfo = new ActorInfo();   //角色信息
        public BattleStateAttrInfo stateInfo = new BattleStateAttrInfo();   //状态属性
        public Part partInfo = new Part();              //外观部件信息，怪物可能没这部分数据，会给null
        public BattleTile tileInfo = new BattleTile();  //战斗时角色所在的格子位置信息
        public ActorModuleEquip equipModule = new ActorModuleEquip(); //角色装备模块信息
        public ActorModuleSkill skillModule = new ActorModuleSkill(); //角色技能模块信息
        public ActorModuleBuff buffModule = new ActorModuleBuff(); //角色buff模块信息
    }
}