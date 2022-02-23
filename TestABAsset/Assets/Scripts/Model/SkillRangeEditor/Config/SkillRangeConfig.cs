using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRangeConfig
{
    public List<SkillRangeItemConfig> SkillRangeItemList = new List<SkillRangeItemConfig>();
    //转成输出格式的数据
    public SkillRangeDataModel ToDataModel()
    {
        var result = new SkillRangeDataModel();
        var skillList = new List<SkillRangeItemDataModel>();
        for (var i = 0; i < this.SkillRangeItemList.Count; i++)
        {
            var skillItemData = this.SkillRangeItemList[i].ToDataModel();
            skillList.Add(skillItemData);
        }
        result.SkillRangeItemList = skillList;
        return result;
    }
    //从输出数据加载
    public void LoadFromData(SkillRangeDataModel data)
    {
        for (var i = 0; i < data.SkillRangeItemList.Count; i++)
        {
            var skillItem = data.SkillRangeItemList[i];
            var skillRangeItem = new SkillRangeItemConfig();
            skillRangeItem.LoadFromData(skillItem);
            this.SkillRangeItemList.Add(skillRangeItem);
        }
    }
}
