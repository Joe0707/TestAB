using UnityEngine;
using System;
//部件位置管理器
public class PartPositionMgr : Singleton<PartPositionMgr>
{
    private string PartPositionPath = "Data/Descent/PartPosition";
    //各部件的初始位置
    private Vector2[] MalePartPos = {
        new Vector2(0,0),//haira
        new Vector2(-0.36f,2.38f),//hairb
        new Vector2(0,0),//stigma
        new Vector2(1.01f,2.098f),//eara
        new Vector2(1.069f,2.881f),//earb
        new Vector2(-0.42f,3.4f),//eyebrow
        new Vector2(-0.41f,3.21f),//eye
        new Vector2(-0.44f,0.86f),//beard
        new Vector2(-0.44f,0.86f),//bigbeard
        new Vector2(-0.65f,3.006f),//nose
        new Vector2(0,3.74f),//hairc
        new Vector2(-0.1f,1.01f),//haird
        new Vector2(-0.51f,2.29f),//mouth
        new Vector2(0.07f,3.02f),//tattoo
        new Vector2(0,2.93f),//face
        new Vector2(-0.91f,2.11f),//earc
        new Vector2(0,0),//clotha
        new Vector2(0,0),//clothb
        new Vector2(0,0),//clothc
        new Vector2(0,0),//body
        new Vector2(0,0),//hairf
        new Vector2(0.13f,2.18f)//haire
    };

    private Vector2[] FeMalePartPos = {
        new Vector2(0,0),//haira
        new Vector2(0,0),//hairb
        new Vector2(0,0),//stigma
        new Vector2(0.65f,2.75f),//eara
        new Vector2(0.9f,3.41f),//earb
        new Vector2(-0.27f,4.05f),//eyebrow
        new Vector2(-0.38f,3.8f),//eye
        new Vector2(0,0),//beard
        new Vector2(0,0),//bigbeard
        new Vector2(-0.6f,3.56f),//nose
        new Vector2(0.35f,4.59f),//hairc
        new Vector2(0.15f,2.12f),//haird
        new Vector2(-0.42f,2.87f),//mouth
        new Vector2(0.07f,3.74f),//tattoo
        new Vector2(0.05f,3.66f),//face
        new Vector2(-1.02f,2.62f),//earc
        new Vector2(0,0),//clotha
        new Vector2(1.85f,0.64f),//clothb
        new Vector2(-2.59f,-0.1f),//clothc
        new Vector2(0.03f,0.06f),//body
        new Vector2(0.03f,1.13f),//hairf
        new Vector2(-0.89f,2.85f)//haire
    };

    public override void Init()
    {
        var data = ConfigManager.Instance.LoadJsonConfig<PartPositionAllData>(PartPositionPath);
        if (data != null)
        {
            LoadPositionData(data);
        }
    }
    //加载位置数据
    private void LoadPositionData(PartPositionAllData partpositionDatas)
    {
        if (partpositionDatas != null)
        {
            var malepositions = partpositionDatas.MalePosition;
            var femalepositions = partpositionDatas.FemalePosition;
            if (malepositions != null && malepositions.Count > 0 && femalepositions != null && femalepositions.Count > 0)
            {
                var partObjEnums = Enum.GetValues(typeof(EPartObjType));
                var malepositiondata = new Vector2[partObjEnums.Length];
                var femalepositiondata = new Vector2[partObjEnums.Length];
                var maleposition = malepositions[0];
                var femaleposition = femalepositions[0];
                var fields = typeof(PartPositionData).GetFields();
                for (var j = 0; j < partObjEnums.Length; j++)
                {
                    var partObjEnum = partObjEnums.GetValue(j);
                    var field = ReflectionUtil.GetFieldByName(fields, partObjEnum.ToString());
                    var malevalue = field.GetValue(maleposition);
                    var malepositionvalue = MathUtil.PositionStr2Vector(malevalue.ToString());
                    malepositiondata[j] = malepositionvalue;
                    var femalevalue = field.GetValue(femaleposition);
                    var femalepositionvalue = MathUtil.PositionStr2Vector(femalevalue.ToString());
                    femalepositiondata[j] = femalepositionvalue;
                }
                MalePartPos = malepositiondata;
                FeMalePartPos = femalepositiondata;
            }
        }
    }

    //根据部件类型和性别获取部件位置
    public Vector2 GetPartPositionByTypeAndSex(EPartObjType PartType, SexType sex)
    {
        Vector2 result = Vector2.zero;
        if (sex == SexType.m)
        {
            result = MalePartPos[(int)PartType];
        }
        else if (sex == SexType.f)
        {
            result = FeMalePartPos[(int)PartType];
        }
        return result;
    }

}
