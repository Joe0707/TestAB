//战斗伤害实体
using System.Collections.Generic;
using XLua;
public class BattleDamageEntity
{
    public string DefenseActorGid;//受击目标集合
    public int isDead;//是否死亡 1死亡 0不死亡
    public List<int> isDev = new List<int>();  //是否偏斜
    public List<int> isRit = new List<int>();//是否暴击
    public List<int> damage = new List<int>();//伤害值
    public int AttackCount = 1;//攻击次数
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="msg">
    /// 字典字段
    /// srcGid:攻击源id; 
    /// targetGid:攻击目标的id 
    /// skillId:技能Id; 
    /// isKill:是否死亡;
    /// attackCount:攻击次数;
    /// isDev：是否偏斜 使用','分割字符串的方式传连击参数
    /// isCri：是否暴击 使用','分割字符串的方式传连击参数
    /// realDmg：真实伤害 使用','分割字符串的方式传连击参数
    /// isRepel: 是否是击退 0 不击退 1 击退
    /// </param>    
    public BattleDamageEntity(LuaTable msg)
    {
        this.DefenseActorGid = msg.Get<string>("targetGid");
        int isDead = 0;
        int.TryParse(msg.Get<string>("isKill"), out isDead);
        this.isDead = isDead;
        string isDev = msg.Get<string>("isDev");
        string isRit = msg.Get<string>("isCri");
        string damage = msg.Get<string>("realDmg");
        var isDevs = isDev.Split(',');
        var isDevsList = new List<int>();
        for (var i = 0; i < isDevs.Length; i++)
        {
            isDevsList.Add(int.Parse(isDevs[i]));
        }
        this.isDev = isDevsList;
        var isRits = isRit.Split(',');
        var isRitsList = new List<int>();
        for (var i = 0; i < isRits.Length; i++)
        {
            isRitsList.Add(int.Parse(isRits[i]));
        }
        this.isRit = isRitsList;
        var damages = damage.Split(',');
        var damagesList = new List<int>();
        for (var i = 0; i < damages.Length; i++)
        {
            damagesList.Add(int.Parse(damages[i]));
        }
        this.damage = damagesList;
    }
}