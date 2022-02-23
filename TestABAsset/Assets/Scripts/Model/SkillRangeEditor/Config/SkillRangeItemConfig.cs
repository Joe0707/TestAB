using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//技能范围项配置
public class SkillRangeItemConfig
{
    public string Id = "";   //Id
    public string Name = ""; //范围名
    public List<RangeSlotConfig> RangeSlotList = new List<RangeSlotConfig>();//范围格子数据
    public int MinX = 0;//最小x
    public int MinY = 0;//最小y
    public int MaxX = 0;//最大X
    public int MaxY = 0;//最大Y
    public SkillRangeItemConfig()
    {
        // Id = LevelUtil.GenerateID();
        var rangeSlot = new RangeSlotConfig();
        rangeSlot.X = 0;
        rangeSlot.Y = 0;
        rangeSlot.isCenter = true;
        RangeSlotList.Add(rangeSlot);
    }
    public SkillRangeItemConfig Clone()
    {
        var result = new SkillRangeItemConfig();
        result.Id = Id;
        result.Name = Name;
        var cloneList = new List<RangeSlotConfig>();
        for (var i = 0; i < RangeSlotList.Count; i++)
        {
            var slotclone = RangeSlotList[i].Clone();
            cloneList.Add(slotclone);
        }
        result.RangeSlotList = cloneList;
        result.MinX = MinX;
        result.MinY = MinY;
        result.MaxX = MaxX;
        result.MaxY = MaxY;
        return result;
    }
    public void CopyValue(SkillRangeItemConfig source)
    {
        Id = source.Id;
        Name = source.Name;
        var rangeSlotList = source.RangeSlotList;
        var cloneList = new List<RangeSlotConfig>();
        for (var i = 0; i < rangeSlotList.Count; i++)
        {
            var slotclone = rangeSlotList[i].Clone();
            cloneList.Add(slotclone);
        }
        RangeSlotList = cloneList;
        MinX = source.MinX;
        MinY = source.MinY;
        MaxX = source.MaxX;
        MaxY = source.MaxY;
    }
    //转输出数据
    public SkillRangeItemDataModel ToDataModel()
    {
        var result = new SkillRangeItemDataModel();
        result.Id = this.Id;
        result.MaxX = this.MaxX;
        result.MaxY = this.MaxY;
        result.MinX = this.MinX;
        result.MinY = this.MinY;
        result.Name = this.Name;
        var rangeSlotList = new List<RangeSlotDataModel>();
        for (var i = 0; i < this.RangeSlotList.Count; i++)
        {
            var rangeItem = RangeSlotList[i];
            if (rangeItem.IsSelect == true)
            {
                var rangeData = rangeItem.ToDataModel();
                rangeSlotList.Add(rangeData);
            }
        }
        result.RangeSlotList = rangeSlotList;
        return result;
    }
    //从数据加载
    public void LoadFromData(SkillRangeItemDataModel data)
    {
        this.MaxX = data.MaxX;
        this.MaxY = data.MaxY;
        this.MinX = data.MinX;
        this.MinY = data.MinY;
        this.Id = data.Id;
        this.Name = data.Name;
        var rangeList = new List<RangeSlotConfig>();
        for (var y = MaxY; y > MinY - 1; y--)
        {
            for (var x = MinX; x < MaxX + 1; x++)
            {
                var rangeSlotConfig = new RangeSlotConfig();
                rangeSlotConfig.SkillRangeItemId = Id;
                rangeSlotConfig.X = x;
                rangeSlotConfig.Y = y;
                if (x == 0 && y == 0)
                {
                    rangeSlotConfig.isCenter = true;
                }
                rangeList.Add(rangeSlotConfig);
            }
        }

        for (var i = 0; i < data.RangeSlotList.Count; i++)
        {
            var rangeItemData = data.RangeSlotList[i];
            for (var j = 0; j < rangeList.Count; j++)
            {
                var rangeItem = rangeList[j];
                if (rangeItemData.X == rangeItem.X && rangeItemData.Y == rangeItem.Y)
                {
                    rangeItem.LoadFromData(rangeItemData);
                }
            }
        }
        this.RangeSlotList = rangeList;
    }
}
