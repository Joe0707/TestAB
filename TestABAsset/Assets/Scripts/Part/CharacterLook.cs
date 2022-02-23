using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalDefine;
using StaticData;
public class CharacterLook : MonoBehaviour
{
    public Dictionary<EPart, CharacterPart> PartDic = new Dictionary<EPart, CharacterPart>();//存储部件的字典
    void Awake()
    {
        //往字典添加部件
        for (int i = 0; i < transform.childCount; i++)
        {
            var part = transform.GetChild(i).GetComponent<CharacterPart>();
            if (part != null && PartDic.ContainsKey(part.m_Type) == false)
            {
                PartDic.Add(part.m_Type, part);
            }
        }
    }
    void Start()
    {

    }
    //加载部件文件名称
    public void LoadPartFileName(List<ushort> partIdList)
    {
        //临时注掉，mPartDataMap报错
        // if (PartDic == null)
        //     return;
        // foreach (var itemId in partIdList)
        // {
        //     if (StaticDataMgr.Instance.mPartDataMap.ContainsKey(itemId) == false)
        //         return;
        //     var name = StaticDataMgr.Instance.mPartDataMap[itemId].mRefName;
        //     var type = StaticDataMgr.Instance.mPartDataMap[itemId].mPartType;
        //     PartDic[type].LoadPartSprite(name);
        //     Debug.Log("partName：" + PartDic[type].m_Type);
        // }
    }
}
