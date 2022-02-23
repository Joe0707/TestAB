using System.Collections.Generic;
public class SkillRangeItemDataModel
{
    public string Id = "";   //Id
    public string Name = ""; //范围名
    public List<RangeSlotDataModel> RangeSlotList = new List<RangeSlotDataModel>();//范围格子数据
    public int MinX = 0;//最小x
    public int MinY = 0;//最小y
    public int MaxX = 0;//最大X
    public int MaxY = 0;//最大Y

}