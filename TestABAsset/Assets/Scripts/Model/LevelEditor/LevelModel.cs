using Levels;
using Levels.Trigger;
using System.Collections.Generic;
using GlobalDefine;
using System;
using XLua;
//关卡数据管理器
public class LevelModel : Singleton<LevelModel>
{
    //获取slot配置数据
    public SlotConfig GetSlotConfig(int slotindex)
    {
        SlotConfig result = null;
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var slotlist = curconfig.SlotList;
        for (var i = 0; i < slotlist.Count; i++)
        {
            var slot = slotlist[i];
            if (slot.Index == slotindex)
            {
                result = slot;
                break;
            }
        }
        return result;
    }
    //获取slotconfig列表   
    public List<SlotConfig> GetSlotConfigs()
    {
        return LevelLoader.Instance.CurLevelConfig.SlotList;
    }

    public StumpConfig GetSlotStump(int slotindex, ETeamType team)
    {
        StumpConfig result = null;
        var list = GetSlotStumpList(slotindex);
        for (var i = 0; i < list.Count; i++)
        {
            var stump = list[i];
            if (stump.Team == team)
            {
                result = stump;
                break;
            }
        }
        return result;
    }
    //获取一个排序后的阵营的所有木桩
    public List<StumpConfig> GetTeamStumps(ETeamType team)
    {
        List<StumpConfig> result = new List<StumpConfig>();
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var stumplist = curconfig.StumpList;
        for (var i = 0; i < stumplist.Count; i++)
        {
            var stump = stumplist[i];
            if (stump.Team == team)
            {
                result.Add(stump);
            }
        }
        return result;
    }
    //对木桩集合进行按队伍位置排序
    public void SortStumpByPositionInTeam(List<StumpConfig> list)
    {
        list.Sort((a, b) =>
        {
            return a.PositionInTeam - b.PositionInTeam;
        });
    }


    /// <summary>
    /// 获取格子的木桩
    /// </summary>
    /// <param name="slotIndex"></param>
    /// <returns></returns>
    public StumpConfig GetSlotStump(int slotIndex)
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var stumplist = curconfig.StumpList;
        StumpConfig result = null;
        for (var i = 0; i < stumplist.Count; i++)
        {
            var stump = stumplist[i];
            if (stump.SlotIndex == slotIndex)
            {
                result = stump;
                break;
            }
        }
        return result;
    }

    //获取格子的怪物列表
    public List<StumpConfig> GetSlotStumpList(int slotindex)
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var stumplist = curconfig.StumpList;
        var result = new List<StumpConfig>();
        for (var i = 0; i < stumplist.Count; i++)
        {
            var stump = stumplist[i];
            if (stump.SlotIndex == slotindex)
            {
                result.Add(stump);
            }
        }
        return result;
    }
    // //获取格子的条件列表
    // public List<TriggerConfig> GetSlotTriggerConfig(int slotindex)
    // {
    //     var curconfig = LevelLoader.Instance.CurLevelConfig;
    //     var triggerlist = curconfig.TriggersList;
    //     var resultList = new List<TriggerConfig>();
    //     for (var i = 0; i < triggerlist.Count; i++)
    //     {
    //         var trigger = triggerlist[i];
    //         var conditionGroup = trigger.ConditionGroup;
    //         var conditionList = conditionGroup.mConditionList;
    //         for (var j = 0; j < conditionList.Count; j++)
    //         {
    //             var condition = conditionList[j];
    //             if (condition is StatusConditionConfig)
    //             {
    //                 if ((condition as StatusConditionConfig).SlotIndex == slotindex)
    //                 {
    //                     resultList.Add(trigger);
    //                 }
    //             }
    //         }
    //     }
    //     return resultList;
    // }
    public void DeleteStumpConfigFromConfig(StumpConfig config)
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var stumplist = curconfig.StumpList;
        var removeindexlist = new List<int>();
        for (var i = 0; i < stumplist.Count; i++)
        {
            var stump = stumplist[i];
            if (stump.SlotIndex == config.SlotIndex)
            {
                removeindexlist.Add(i);
            }
        }
        for (var i = 0; i < removeindexlist.Count; i++)
        {
            stumplist.RemoveAt(removeindexlist[i]);
        }
    }
    // //删除格子触发器
    // public void DeleteSlotTriggerFromConfig(ConditionConfig config)
    // {
    //     var curconfig = LevelLoader.Instance.CurLevelConfig;
    //     var triggerlist = curconfig.TriggersList;
    //     var removelist = new List<int>();
    //     for (var i = 0; i < triggerlist.Count; i++)
    //     {
    //         var triggerconfig = triggerlist[i];
    //         var group = triggerconfig.ConditionGroup;
    //         var conditionList = group.mConditionList;
    //         for (var j = 0; j < conditionList.Count; j++)
    //         {
    //             var condition = conditionList[j];
    //             if (condition.GetType() == config.GetType())
    //             {
    //                 if (config is StatusConditionConfig)
    //                 {
    //                     var statusconfig = config as StatusConditionConfig;
    //                     var statuscondition = condition as StatusConditionConfig;
    //                     if (statusconfig.SlotIndex == statuscondition.SlotIndex && statusconfig.StatusType == statuscondition.StatusType)
    //                     {
    //                         removelist.Add(i);
    //                         break;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //     for (var i = 0; i < removelist.Count; i++)
    //     {
    //         triggerlist.RemoveAt(i);
    //     }
    // }

    // public void AddOneSlotCondition2Config(ConditionConfig condition)
    // {
    //     var triggerconfig = new TriggerConfig();
    //     triggerconfig.TriggerType = ETriggerType.NoResult;
    //     var conditiongroup = new ConditionGroupConfig();
    //     conditiongroup.mConditionList.Add(condition);
    //     triggerconfig.ConditionGroup = conditiongroup;
    //     var triggerlist = LevelLoader.Instance.CurLevelConfig.TriggersList;
    //     triggerlist.Add(triggerconfig);
    // }
    //根据ID获取关卡配置数据
    public TriggerConfig GetTriggerConfigFromId(string id)
    {
        TriggerConfig result = null;
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var levels = curconfig.TriggersList;
        for (var i = 0; i < levels.Count; i++)
        {
            var leveltrigger = levels[i];
            if (leveltrigger.Id == id)
            {
                result = leveltrigger;
                break;
            }
        }
        return result;
    }
    //根据Id从触发器获取条件
    public ConditionConfig GetConditionFromTriggerById(string id, TriggerConfig trigger)
    {
        ConditionConfig result = null;
        var conditions = trigger.ConditionGroup.mConditionList;
        for (var i = 0; i < conditions.Count; i++)
        {
            var condition = conditions[i];
            if (condition.Id == id)
            {
                result = condition;
                break;
            }
        }
        return result;
    }
    //根据ID从触发器获取结果
    public ResultConfig GetResultFromTriggerById(string id, TriggerConfig trigger)
    {
        ResultConfig result = null;
        var results = trigger.ResultList;
        for (var i = 0; i < results.Count; i++)
        {
            var resultconfig = results[i];
            if (resultconfig.Id == id)
            {
                result = resultconfig;
                break;
            }
        }
        return result;
    }
    //根据ID在触发器配置中删除条件
    public void DeleteConditionByIdFromTrigger(string Id, TriggerConfig trigger)
    {
        var deleteIndex = -1;
        var conditions = trigger.ConditionGroup.mConditionList;
        for (var i = 0; i < conditions.Count; i++)
        {
            var condition = conditions[i];
            if (condition.Id == Id)
            {
                deleteIndex = i;
                break;
            }
        }
        if (deleteIndex >= 0)
        {
            conditions.RemoveAt(deleteIndex);
        }
    }
    //根据ID在触发器配置中删除结果
    public void DeleteResultByIdFromTrigger(string Id, TriggerConfig trigger)
    {
        var deleteIndex = -1;
        var results = trigger.ResultList;
        for (var i = 0; i < results.Count; i++)
        {
            var resultconfig = results[i];
            if (resultconfig.Id == Id)
            {
                deleteIndex = i;
                break;
            }
        }
        if (deleteIndex >= 0)
        {
            results.RemoveAt(deleteIndex);
        }

    }
    //获取烘焙路径
    public string GetBakePath(LevelConfig curLevel)
    {
        var result = "";
        var activeeffects = curLevel.ActiveEffects;
        for (int i = 0; i < activeeffects.Count; i++)
        {
            var effect = activeeffects[i];
            if (effect.Contains("Lighting"))
            {
                result = curLevel.ScenePrefabName + "_" + effect;
            }
        }
        return result;
    }

    // //根据Id删除触发器配置
    // public void DeleteTriggerConfigById(string Id)
    // {
    //     var deleteIndex = -1;
    //     var curconfig = LevelLoader.Instance.CurLevelConfig;
    //     var triggers = curconfig.TriggersList;
    //     for (var i = 0; i < triggers.Count; i++)
    //     {
    //         var trigger = triggers[i];
    //         if (trigger.Id == Id)
    //         {
    //             deleteIndex = i;
    //             break;
    //         }
    //     }
    //     triggers.RemoveAt(deleteIndex);
    // }

    public int GetRowCount()
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        return curconfig.RowCount;
    }

    public int GetColumnCount()
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        return curconfig.ColCount;
    }

    public int ComputeRowNumber(int slotIndex)
    {
        var columnCount = GetColumnCount();
        var r = slotIndex / columnCount;
        r++;
        return r;
    }

    public int ComputeColumnNumber(int slotIndex)
    {
        var columnCount = GetColumnCount();
        var c = slotIndex - (slotIndex / columnCount) * columnCount;
        c++;
        return c;
    }

    public int ComputeSlotIndex(int cNum, int rNum)
    {
        var columnCount = GetColumnCount();
        var r = rNum - 1;
        var c = cNum - 1;
        return columnCount * r + c;
    }
    //根据队伍类型获取撤离点
    public List<SlotConfig> GetEscapeSlotsByTeam(ETeamType teamType)
    {
        var result = new List<SlotConfig>();
        var slots = LevelLoader.Instance.CurLevelConfig.SlotList;
        for (var i = 0; i < slots.Count; i++)
        {
            var slot = slots[i];
            if (slot.CanEscape && slot.EscapeTeam == teamType)
            {
                result.Add(slot);
            }
        }
        return result;
    }
    public StumpConfig GetStump(string roleGid)
    {
        StumpConfig stump = null;
        foreach (var stumpItem in LevelLoader.Instance.CurLevelConfig.StumpList)
        {
            if (stumpItem.Id == roleGid)
            {
                stump = stumpItem;
                break;
            }
        }
        return stump;
    }

    //获取特效集
    public List<string> GetEffectsExcludeLight(LevelConfig curconfig)
    {
        var list = new List<string>();
        for (var i = 0; i < curconfig.ActiveEffects.Count; i++)
        {
            var effect = curconfig.ActiveEffects[i];
            if (!effect.Contains("Lighting"))
            {
                list.Add(effect);
            }
        }
        return list;
    }
}