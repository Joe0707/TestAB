using System.Collections.Generic;
using GlobalDefine;
using StaticData.Data;
using Msg;
using StaticData;
using static System.Console;
public class SkillModel : Singleton<SkillModel>
{
    public SkillItemConfig GetItemConfigFromTeamAndSkillId(uint skillId, Team team, int attackNumber, bool isRepel)
    {
        SkillItemConfig result = null;
        uint jobId = (uint)team.actorInfo.lvInfos[0].jobId;
        // int campType = 0;
        // int.TryParse(team.campType, out campType);
        // if (campType == (int)ETeamType.Player)
        // {
        //     jobId = (uint)StaticDataProxy.Instance.GetActorDataById(team.actorInfo.entityId).SodierType;
        // }
        // else if (campType == (int)ETeamType.Enemy)
        // {
        //     jobId = (uint)StaticDataProxy.Instance.GetMonsterDataById(team.actorInfo.entityId).mOccu;
        // }
        var equip = StaticDataProxy.Instance.GetEquipDataById(team.equipModule.defaultAtkEquipId);
        var equipType = EquipmentType.DanShouJian;
        if (equip != null)
        {
            equipType = (EquipmentType)equip.Type;
        }
        else
        {
            DebugUtil.DebugError("未查到装备");
        }
        result = GetItemConfigFromSkillIdJobEquipment(skillId, jobId, equipType, (EGender)team.sex, attackNumber, isRepel);
        return result;
    }

    //根据技能id 职业ID 装备类型 是否是击退 查找唯一的技能效果项
    public SkillItemConfig GetItemConfigFromSkillIdJobEquipment(uint skillId, uint jobId, EquipmentType type, EGender sex, int attackNumber, bool isRepel)
    {
        SkillItemConfig result = null;
        var skillConfig = SkillLoader.Instance.CurSkillConfig;
        var skillItemList = skillConfig.SkillItemList;
        for (var i = 0; i < skillItemList.Count; i++)
        {
            var skillItem = skillItemList[i];
            if (skillItem.Id == skillId && skillItem.JobId == jobId && skillItem.EquipType == type && skillItem.Sex == sex && skillItem.AttackNumber == attackNumber && skillItem.isReple() == isRepel)
            {
                result = skillItem;
                break;
            }
        }
        if (result == null)
        {
            DebugUtil.DebugError(string.Format("技能表现配置未找到 skillid{0} jobId{1} equipType{2} sex{3} attacknumber{4} isRepel {5}", skillId, jobId, type.ToString(), sex.ToString(), attackNumber, isRepel.ToString()));
        }
        return result;
    }

    //根据技能效果项ID查找技能效果项
    public SkillItemConfig GetItemConfigFromItemId(string skillItemId)
    {
        SkillItemConfig result = null;
        var skillConfig = SkillLoader.Instance.CurSkillConfig;
        var skillItemList = skillConfig.SkillItemList;
        for (var i = 0; i < skillItemList.Count; i++)
        {
            var skillItem = skillItemList[i];
            if (skillItem.UId == skillItemId)
            {
                result = skillItem;
                break;
            }
        }
        return result;
    }

    //根据技能ID获取技能项
    public List<SkillItemConfig> GetItemConfigsFromSkillId(uint skillId)
    {
        List<SkillItemConfig> result = new List<SkillItemConfig>();
        var skillConfig = SkillLoader.Instance.CurSkillConfig;
        var skillItemList = skillConfig.SkillItemList;
        for (var i = 0; i < skillItemList.Count; i++)
        {
            var skillItem = skillItemList[i];
            if (skillItem.Id == skillId)
            {
                result.Add(skillItem);
            }
        }
        return result;
    }
    //根据ID删除技能效果项
    public void DeleteSkillItemConfig(string itemId)
    {
        var skillConfig = SkillLoader.Instance.CurSkillConfig;
        var skillItemList = skillConfig.SkillItemList;
        var deleteIndex = -1;
        for (var i = 0; i < skillItemList.Count; i++)
        {
            var skillItem = skillItemList[i];
            if (skillItem.UId == itemId)
            {
                deleteIndex = i;
                break;
            }
        }
        if (deleteIndex != -1)
        {
            skillItemList.RemoveAt(deleteIndex);
        }
    }
}