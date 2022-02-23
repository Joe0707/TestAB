using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointData
{
    public string mapID;
    public string pointID;
    public string pointName;
    public string chineseName;
    public string countryID;
    public string isOpen;
    public string x;
    public string y;
    public string visibleScale;
    public string pointType;
    public string pointIcon;
    public string taskStar;
    public string bgIcon;
    public string BGM;
    /// <summary>
    /// 功能配置
    /// </summary>
    public string functionSet;
    public string functionBG;
    public List<NpcData> npcDatas = new List<NpcData>();
}

[System.Serializable]
public class NpcData
{
    public string npcNum;
    public string actorID;
    public string npcPos;
    public string npcFunction;
    public string actorPic;
    public string picRate;
    public string dialogmID;
}

[System.Serializable]
public class PointDatas
{
    public List<PointData> pointDatas = new List<PointData>();
}

[System.Serializable]
public class PointTypes
{
    public List<PointType> pointTypes = new List<PointType>();
}

[System.Serializable]
public class PointType
{
    public int id;
    public string pointType;
    public bool isShow;
    public Color color;
}

[System.Serializable]
public class FunctionSets
{
    public List<FunctionSet> functionSets = new List<FunctionSet>();
}

[System.Serializable]
public class FunctionSet
{
    public int id;
    public string fSet;
}