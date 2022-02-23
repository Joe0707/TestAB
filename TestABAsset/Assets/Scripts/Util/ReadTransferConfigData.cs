using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using StaticData.Data;
public static class ReadTransferConfigData
{
    public static Dictionary<int, List<int>> cityTransferConfig = new Dictionary<int, List<int>>();
    public static void LoadTransferConfigData()
    {
        System.Type type = typeof(TransferConfigData);
        FieldInfo[] fields = type.GetFields();
        Dictionary<uint, TransferConfigData> mTransferConfigDataMap = StaticData.StaticDataMgr.Instance.mTransferConfigDataMap;
        TransferConfigData first = mTransferConfigDataMap[1];

        foreach (TransferConfigData value in mTransferConfigDataMap.Values)
        {
            if (int.Parse(value.mID.ToString()) != 1)
            {
                int mID = 0;
                // jobIDs.Clear();
                List<int> jobIDs = new List<int>();
                foreach (FieldInfo f in fields)
                {
                    // Debug.Log("属性修饰 " + f.Attributes + ";属性" + f + "=" + f.GetValue(value)); // Debug.Log(f.Name);
                    int thenV = int.Parse(f.GetValue(value).ToString());
                    if (thenV == 1)
                    {
                        int firstV = int.Parse(f.GetValue(first).ToString());
                        jobIDs.Add(firstV);
                    }
                    if (thenV > 1)
                    {
                        int mIDV = int.Parse(f.GetValue(value).ToString());
                        mID = mIDV;
                    }
                }
                cityTransferConfig.Add(mID, jobIDs);
            }
        }
    }
    public static List<int> LoadTransferConfigData(int mID)
    {
        List<int> jobS = new List<int>();
        if (cityTransferConfig.TryGetValue(mID, out jobS) == false)
        {
            Debug.LogError("职业表中没有改职业");
        }
        return jobS;
    }
}