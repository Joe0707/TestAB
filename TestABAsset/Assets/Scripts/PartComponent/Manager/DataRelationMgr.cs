using System.Collections.Generic;
using System;
using System.Reflection;
//部件管理器
public class DataRelationMgr : Singleton<DataRelationMgr>
{
    private Dictionary<EPartType, EPartObjType[]> partObjDict = new Dictionary<EPartType, EPartObjType[]>();
    private Dictionary<EColorPartType, EColorType> colorPartColorDict = new Dictionary<EColorPartType, EColorType>();
    public override void Init()
    {
        base.Init();
        partObjDict.Add(EPartType.hair, new EPartObjType[] { EPartObjType.hair_a, EPartObjType.hair_b, EPartObjType.hair_c, EPartObjType.hair_d, EPartObjType.hair_e, EPartObjType.hair_f });
        partObjDict.Add(EPartType.beard, new EPartObjType[] { EPartObjType.beard });
        partObjDict.Add(EPartType.bigbeard, new EPartObjType[] { EPartObjType.bigbeard });
        partObjDict.Add(EPartType.body, new EPartObjType[] { EPartObjType.body });
        partObjDict.Add(EPartType.clothes, new EPartObjType[] { EPartObjType.clothes_a, EPartObjType.clothes_b, EPartObjType.clothes_c, EPartObjType.clothes_d });
        partObjDict.Add(EPartType.ear, new EPartObjType[] { EPartObjType.ear_a, EPartObjType.ear_b, EPartObjType.ear_c });
        partObjDict.Add(EPartType.eye, new EPartObjType[] { EPartObjType.eye });
        partObjDict.Add(EPartType.eyebrow, new EPartObjType[] { EPartObjType.eyebrow });
        partObjDict.Add(EPartType.face, new EPartObjType[] { EPartObjType.face });
        partObjDict.Add(EPartType.mouth, new EPartObjType[] { EPartObjType.mouth });
        partObjDict.Add(EPartType.nose, new EPartObjType[] { EPartObjType.nose });
        partObjDict.Add(EPartType.tattoo, new EPartObjType[] { EPartObjType.tattoo });
        partObjDict.Add(EPartType.stigma, new EPartObjType[] { EPartObjType.stigma });
        colorPartColorDict.Add(EColorPartType.beardcolor, EColorType.haircolor);
        colorPartColorDict.Add(EColorPartType.haircolor, EColorType.haircolor);
        colorPartColorDict.Add(EColorPartType.eyebrowcolor, EColorType.haircolor);
        colorPartColorDict.Add(EColorPartType.skincolor, EColorType.skincolor);
    }

    //根据颜色部件类型获取颜色类型
    public EColorType GetColorTypeByColorPartType(EColorPartType colorPartType)
    {
        EColorType result;
        colorPartColorDict.TryGetValue(colorPartType, out result);
        return result;
    }

    //根据部件类型获取部件物体类型集
    public EPartObjType[] GetPartObjTypesFromPartType(EPartType partType)
    {
        EPartObjType[] result = null;
        partObjDict.TryGetValue(partType, out result);
        return result;
    }
}