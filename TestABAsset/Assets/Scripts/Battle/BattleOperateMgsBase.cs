using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//战斗属性消息基类
public class BattleOperateMgsBase
{
    public string srcGid = "";

    public BattleOperateMgsBase(string gid)
    {
        srcGid = gid;
    }

    public BattleOperateMgsBase() { }
}

//战斗技能通知
public class BattleOperateSkill : BattleOperateMgsBase
{

    public string tileIndex = "";
    public string skillId = "";
    public BattleOperateSkill(string gid, string tileIndex1, string skillId1) : base(gid)
    {
        tileIndex = tileIndex1;
        skillId = skillId1;
    }
}

//战斗伤害计算通知
public class BattleOperateDamage : BattleOperateMgsBase
{
    public string atkGid = "";
    public string targetGid = "";
    public string isCri = "";
    public string isDev = "";
    public string isKill = "";
    public string dHitNum = "";

    public BattleOperateDamage(string atkGid1, string targetGid1, string isCri1, string isDev1, string isKill1, string dHitNum1)
    {
        atkGid = atkGid1;
        targetGid = targetGid1;
        isCri = isCri1;
        isDev = isDev1;
        isKill = isKill1;
        dHitNum = dHitNum1;
    }
}

//战斗移动通知
public class BattleOperateMove : BattleOperateMgsBase
{
    public string targetTileIndex = "";
    public BattleOperateMove(string gid, string targetTileIndex1) : base(gid)
    {
        targetTileIndex = targetTileIndex1;
    }
}

//战斗buff挂载/移除通知
public class BattleOperateBuff : BattleOperateMgsBase
{
    public string buffId = "";
    public string changeType = "";
    public BattleOperateBuff(string gid, string buffId1, string changeType1) : base(gid)
    {
        buffId = buffId1;
        changeType = changeType1;
    }
}

//战斗ap值更变通知
public class BattleOperateAddAp : BattleOperateMgsBase
{
    public string addNum = "";
    public BattleOperateAddAp(string gid, string addNum1) : base(gid)
    {
        addNum = addNum1;
    }
}

//战斗特殊状态挂载/移除通知
public class BattleOperateStatus : BattleOperateMgsBase
{
    public string statusId = "";
    public string changeType = "";
    public BattleOperateStatus(string gid, string statusId1, string changeType1) : base(gid)
    {
        statusId = statusId1;
        changeType = changeType1;
    }
}