using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEffectManager : MonoSingleton<LevelEffectManager>
{
    private Dictionary<string, GameObject> EffectDict = new Dictionary<string, GameObject>();//特效字典
    public List<GameObject> Effects;//特效列表从场景中拖上
    public List<GameObject> Cameras;//摄像机列表
    protected override void OnStart()
    {
        for (var i = 0; i < Effects.Count; i++)
        {
            var effect = Effects[i];
            EffectDict.Add(effect.name, effect);
        }
    }
    //获取激活的相机
    public GameObject GetActiveCamera()
    {
        GameObject result = null;
        for (var i = 0; i < Cameras.Count; i++)
        {
            var camera = Cameras[i];
            if (camera.gameObject.activeInHierarchy == true)
            {
                result = camera.gameObject;
                break;
            }
        }
        return result;
    }

    //获取所有特效物体
    public List<GameObject> GetAllEffects()
    {
        return new List<GameObject>(EffectDict.Values);
    }

    //设置特效开关
    public void SetEffectActive(string effectName, bool isActive)
    {
        if (EffectDict.ContainsKey(effectName))
        {
            EffectDict[effectName].SetActive(isActive);
        }
        else
        {
            DebugUtil.DebugError(string.Format("设置的特效名{0}不存在", effectName));
        }
    }

}
