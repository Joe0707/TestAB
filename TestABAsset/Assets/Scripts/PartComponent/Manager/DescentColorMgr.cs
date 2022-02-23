using StaticData;
using StaticData.Data;
using System.Collections.Generic;
using UnityEngine;
//血脉颜色管理器
public class DescentColorMgr : Singleton<DescentColorMgr>
{
    public override void Init()
    {
        // Test();
    }

    public void Test()
    {
        var colorMap = StaticDataMgr.Instance.mColorDataMap;
        var heerwoIndex = 0;
        var suolesiIndex = 0;
        foreach (var pair in colorMap)
        {
            if (pair.Value.descentType == (int)DescentType.heerwo)
            {
                if (heerwoIndex == 0)
                {
                    pair.Value.rgb = "FFFF00";
                }
                else if (heerwoIndex == 1)
                {
                    pair.Value.rgb = "FF00FF";
                }
                else if (heerwoIndex == 2)
                {
                    pair.Value.rgb = "00FFFF";
                }
                else if (heerwoIndex == 3)
                {
                    pair.Value.rgb = "00FFFF";
                }
                else if (heerwoIndex == 4)
                {
                    pair.Value.rgb = "00FFFF";
                }
                else if (heerwoIndex == 5)
                {
                    pair.Value.rgb = "00FFFF";
                }
                heerwoIndex++;
            }
            if (pair.Value.descentType == (int)DescentType.suolesi)
            {
                if (suolesiIndex == 0)
                {
                    pair.Value.rgb = "00FFFF";
                }
                else if (suolesiIndex == 1)
                {
                    pair.Value.rgb = "FFFF00";
                }
                else if (suolesiIndex == 2)
                {
                    pair.Value.rgb = "FFFF00";
                }
                else if (suolesiIndex == 3)
                {
                    pair.Value.rgb = "FFFF00";
                }
                else if (suolesiIndex == 4)
                {
                    pair.Value.rgb = "FFFF00";
                }
                else if (suolesiIndex == 5)
                {
                    pair.Value.rgb = "FFFF00";
                }

                suolesiIndex++;
            }
        }
    }
    //根据颜色Id获取颜色值
    public bool TryGetColorValueByColorId(uint id, out string color)
    {
        var colorMap = StaticDataMgr.Instance.mColorDataMap;
        var result = false;
        ColorData colorData;
        result = colorMap.TryGetValue(id, out colorData);
        color = colorData.rgb;
        return result;
    }

    //根据颜色ID获取颜色值
    public bool TryGetColorByColorId(uint id, out Color color)
    {
        var colorMap = StaticDataMgr.Instance.mColorDataMap;
        var result = false;
        ColorData colordata;
        result = colorMap.TryGetValue(id, out colordata);
        if (result == false)
        {
            DebugUtil.DebugError(string.Format("根据Id获取颜色失败 id{0}", id));
            color = Color.black;
        }
        else
        {
            color = ColorUtil.GetColor(colordata.rgb);
        }
        return result;
    }

    //根据颜色ID获取血脉类型
    public bool TryGetDescentTypeByColorId(uint Id, out DescentType type)
    {
        var colorMap = StaticDataMgr.Instance.mColorDataMap;
        var result = false;
        ColorData colordata;
        result = colorMap.TryGetValue(Id, out colordata);
        type = (DescentType)colordata.descentType;
        return result;
    }

    public List<ColorData> GetColorsByDescentTypeAndColorPartType(DescentType descentType, EColorPartType color)
    {
        var colorType = DataRelationMgr.Instance.GetColorTypeByColorPartType(color);
        return GetColorsByDescentTypeAndColorType(descentType, colorType);
    }

    //根据血脉类型和部件类型获取颜色集
    public List<ColorData> GetColorsByDescentTypeAndColorType(DescentType descentType, EColorType color)
    {
        var colorMap = StaticDataMgr.Instance.mColorDataMap;
        var result = new List<ColorData>();
        foreach (var pair in colorMap)
        {
            var colorData = pair.Value;
            if (colorData.colorType == (int)color && colorData.descentType == (int)descentType)
            {
                result.Add(colorData);
            }
        }
        return result;
    }
}