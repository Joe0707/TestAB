public class SkillRangeModel : Singleton<SkillRangeModel>
{
    public SkillRangeItemConfig GetSkillRangeItemConfigFromId(string Id)
    {
        SkillRangeItemConfig result = null;
        var CurSkillRangeConfig = SkillRangeLoader.Instance.CurSkillRangeConfig;
        var list = CurSkillRangeConfig.SkillRangeItemList;
        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item.Id == Id)
            {
                result = item;
                break;
            }
        }
        return result;
    }
    //根据ID获取技能范围数据
    public SkillRangeItemDataModel GetSkillRangeItemDataFromId(string Id)
    {
        SkillRangeItemDataModel result = null;
        var CurSkillRangeData = SkillRangeDataLoader.Instance.CurSkillRangeData;
        var list = CurSkillRangeData.SkillRangeItemList;
        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item.Id == Id)
            {
                result = item;
                break;
            }
        }
        return result;
    }

    public RangeSlotConfig GetRangeSlotConfigFromRangeItem(SkillRangeItemConfig itemConfig, string rangeSlotId)
    {
        RangeSlotConfig result = null;
        var list = itemConfig.RangeSlotList;
        for (var i = 0; i < list.Count; i++)
        {
            var rangeSlotConfig = list[i];
            if (rangeSlotConfig.Id == rangeSlotId)
            {
                result = rangeSlotConfig;
                break;
            }
        }
        return result;
    }

    //根据ID删除技能范围项
    public bool DeleteSkillRangeItemFromId(string Id)
    {
        var result = false;
        var CurSkillRangeConfig = SkillRangeLoader.Instance.CurSkillRangeConfig;
        var list = CurSkillRangeConfig.SkillRangeItemList;
        var removeIndex = -1;
        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            if (item.Id == Id)
            {
                removeIndex = i;
                break;
            }
        }
        if (removeIndex != -1)
        {
            list.RemoveAt(removeIndex);
            result = true;
        }
        return result;
    }
    public SkillRangeItemConfig newSkillRangeItemConfig()
    {
        SkillRangeItemConfig newSkillRangeItemConfig = new SkillRangeItemConfig();
        return newSkillRangeItemConfig;
    }
}