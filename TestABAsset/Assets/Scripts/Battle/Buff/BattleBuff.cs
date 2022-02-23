using System.Collections.Generic;
using System;
using XLua;
[CSharpCallLua]
public delegate void BuffDelete(string gid, uint tid);
//战斗Buff
public class BattleBuff
{
    public List<string> Gids = new List<string>();  //BuffGids
    public uint Tid = 0;//BuffTid
    private int roundRemain = 1;    //剩余回合数
    private int buffCount = 1;  //叠加数
    public List<Action<int>> RoundRemainChange = new List<Action<int>>(); //剩余回合数更改
    public List<Action<int>> BuffCountChange = new List<Action<int>>(); //Buff叠加数更改
    public List<BuffDelete> BuffDelete = new List<BuffDelete>();//Buff删除委托
    public BattleBuff(string buffGid, uint buffTid, int roundRemain)
    {
        Tid = buffTid;
        Gids.Add(buffGid);
        this.roundRemain = roundRemain;
        buffCount = 1;
    }
    //是否包含Gid
    public bool ContainsGid(string gid)
    {
        return Gids.Contains(gid);
    }

    public void AddDeleteDelegate(BuffDelete action)
    {
        if (BuffDelete.Contains(action) == false)
        {
            BuffDelete.Add(action);
        }
    }

    public void RemoveDeleteDelegate(BuffDelete action)
    {
        if (BuffDelete.Contains(action))
        {
            BuffDelete.Remove(action);
        }

    }

    public void AddRoundRemainDelegate(Action<int> action)
    {
        if (RoundRemainChange.Contains(action) == false)
        {
            RoundRemainChange.Add(action);
        }
    }

    public void RemoveRoundRemainDelegate(Action<int> action)
    {
        if (RoundRemainChange.Contains(action))
        {
            RoundRemainChange.Remove(action);
        }
    }

    public void AddBuffCountChangeDelegate(Action<int> action)
    {
        if (BuffCountChange.Contains(action) == false)
        {
            BuffCountChange.Add(action);
        }
    }

    public void RemoveBuffCountChangeDelegate(Action<int> action)
    {
        if (BuffCountChange.Contains(action))
        {
            BuffCountChange.Remove(action);
        }
    }

    public int RoundRemain
    {
        get { return roundRemain; }
        set
        {
            if (roundRemain != value)
            {
                roundRemain = value;
                for (var i = 0; i < RoundRemainChange.Count; i++)
                {
                    RoundRemainChange[i](roundRemain);
                }
            }
        }
    }

    public int BuffCount
    {
        get { return buffCount; }
        set
        {
            if (buffCount != value)
            {
                buffCount = value;
                for (var i = 0; i < BuffCountChange.Count; i++)
                {
                    BuffCountChange[i](buffCount);
                }
            }
        }
    }

    public void AddBuff(string gid)
    {
        if (Gids.Contains(gid))
        {
            DebugUtil.DebugError(string.Format("Buff{0}已经存在,不可叠加相同Buff", gid));
            return;
        }
        Gids.Add(gid);
        BuffCount = Gids.Count;
    }

    public void UpdateBuff(int roundRemain)
    {
        //获取Buff回合数   
        RoundRemain = roundRemain;
    }
    public void ReduceBuff(string gid)
    {
        if (Gids.Contains(gid) == false)
        {
            DebugUtil.DebugError(string.Format("Buff{0}不存在,无法删除", gid));
            return;
        }
        Gids.Remove(gid);
        BuffCount = Gids.Count;
        if (BuffCount == 0)
        {
            for (var i = 0; i < BuffDelete.Count; i++)
            {
                BuffDelete[i](gid, Tid);
            }
        }
    }
}