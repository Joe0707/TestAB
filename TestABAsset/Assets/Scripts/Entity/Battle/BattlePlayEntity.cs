using System.Collections.Generic;
using System.Collections;
using Msg;
using XLua;
//战斗播放结构
public class BattlePlayEntity
{
    public List<BattleDamageEntity> damageEntities = new List<BattleDamageEntity>();//伤害实体集
    public string AttackActorGid;  //攻击角色id
    public uint skillId;//技能id
    public int AttackCount = 1;//攻击次数
    public bool hasCrit = false;//是否有暴击
    public bool isRepel = false;//是否是击退
    /// <summary>
    /// 构造函数
    /// </summary>
    public BattlePlayEntity(LuaTable table)
    {
        var count = table.Length;
        for (var i = 1; i <= count; i++)
        {
            var value = table.Get<int, LuaTable>(i);
            var damage = new BattleDamageEntity(value);
            this.damageEntities.Add(damage);
            if (i == 1)
            {
                //第一条信息
                this.AttackActorGid = value.Get<string>("srcGid");
                uint skillId = 0;
                uint.TryParse(value.Get<string>("skillId"), out skillId);
                this.skillId = skillId;
                this.AttackCount = int.Parse(value.Get<string>("attackCount"));
                int repelValue = 0;
                if (int.TryParse(value.Get<string>("isRepel"), out repelValue) == false)
                {
                    DebugUtil.DebugWarn("传入Table中isRepel参数不正确");
                }
                this.isRepel = repelValue == 1;

            }

        }
        for (var i = 0; i < damageEntities.Count; i++)
        {
            var damageEntity = damageEntities[i];
            var damageIsRit = damageEntity.isRit;
            for (var j = 0; j < damageIsRit.Count; j++)
            {
                if (damageIsRit[j] == 1)
                {
                    this.hasCrit = true;
                    break;
                }
            }
            if (this.hasCrit == true)
            {
                break;
            }
        }
    }
}