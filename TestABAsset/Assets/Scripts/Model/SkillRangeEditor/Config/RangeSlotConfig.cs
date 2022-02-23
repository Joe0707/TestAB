public class RangeSlotConfig
{
    public RangeSlotConfig()
    {
        Id = LevelUtil.GenerateID();
    }
    public string SkillRangeItemId = "";//范围技能项Id
    public string Id = "";//范围格子项Id
    public bool IsSelect = false;//是否是选择的
    public bool isCenter = false;//是否是中心
    public int X = 0;//X值
    public int Y = 0;//Y值
    public void CopyValue(RangeSlotConfig source)
    {
        // X = source.X;
        // Y = source.Y;
        IsSelect = source.IsSelect;
        isCenter = source.isCenter;
    }

    public RangeSlotConfig Clone()
    {
        var result = new RangeSlotConfig();
        result.Id = Id;
        result.SkillRangeItemId = SkillRangeItemId;
        result.isCenter = isCenter;
        result.IsSelect = IsSelect;
        result.X = X;
        result.Y = Y;
        return result;
    }

    public RangeSlotDataModel ToDataModel()
    {
        var result = new RangeSlotDataModel();
        result.X = this.X;
        result.Y = this.Y;
        return result;
    }
    //从数据加载
    public void LoadFromData(RangeSlotDataModel data)
    {
        if (data != null)
        {
            this.IsSelect = true;
        }
        this.X = data.X;
        this.Y = data.Y;
    }
}