//技能ID类型
public enum SkillIdType
{
    None,//技能ID类型
    Effect,  //效果
    Status,  //状态
    Condition//条件
}
//攻击前移动方式
public enum PreAttackMoveType
{
    Teleport, //瞬移
    Move //移动
}
//攻击前移动位置类型
public enum AttackMovePositionType
{
    Front,   //人前
    Back  //人后
}
//受击移动位置类型
public enum BeHitMovePositionType
{
    AttackPosition,//攻击人位置
    Slot //偏移格子
}
//特效跟随目标
public enum EffectFollowTarget
{
    Actor,//角色
    MainHand,//主手
    OffHand//副手
}