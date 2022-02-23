using System.Collections.Generic;
using UnityEngine;
public class EffectManager : Singleton<EffectManager>
{
    public static string EffectPath = "";
    //特效池
    Dictionary<string, List<GameEffect>> effectPool = new Dictionary<string, List<GameEffect>>();

    public EffectManager()
    {
        EffectManager.EffectPath = Application.dataPath + "/Effects/Prefabs/";
        // //创建特效,加入到池里
        // List<conf_effect> _conf = ConfigManager.confEffectManager.datas;

        // for (int i = 0; i < _conf.Count; i++)
        // {
        //    conf_effect conf = _conf[i];
        //    for (int j = 0; j < conf.repeat_count; j++)
        //    {
        //       CreateEffect(conf);
        //    }
        // }
    }



    public override void Dispose()
    {
        base.Dispose();
        foreach (KeyValuePair<string, List<GameEffect>> pair in effectPool)
        {
            var list = pair.Value;
            for (var i = 0; i < list.Count; i++)
            {
                var effect = list[i];
                if (effect)
                {
                    effect.Dispose();
                }
            }
            list.Clear();
        }
        effectPool.Clear();
    }

    //物体是否有效果
    public bool IsGameObjectHasEffect(GameObject gameObject, string effectPath)
    {
        var result = false;
        if (effectPool.ContainsKey(effectPath))
        {
            var effects = effectPool[effectPath];
            for (var i = 0; i < effects.Count; i++)
            {
                var effect = effects[i];
                if (effect.parent == gameObject && effect.isActive())
                {
                    result = true;
                    break;
                }
            }
        }
        return result;
    }

    //停止物体特效
    public void StopGameObjectEffect(GameObject gameObject, string effectPath)
    {
        if (effectPool.ContainsKey(effectPath))
        {
            var effects = effectPool[effectPath];
            for (var i = 0; i < effects.Count; i++)
            {
                var effect = effects[i];
                if (effect.parent == gameObject && effect.isActive())
                {
                    effect.Stop();
                    break;
                }
            }
        }
    }


    /// <summary>
    /// 添加特效到世界
    /// </summary>
    /// <returns>The world effect.</returns>
    /// <param name="effectid">配置表中的id.</param>
    /// <param name="pos">出生位置.</param>
    /// <param name="scale">特效的尺寸.</param>
    public GameEffect AddWorldEffect(string filePath, Vector3 pos, Quaternion rotation, bool usePrefabPos, bool usePrefabRotation, float scale, int delayFrame = 0, bool autoplay = true)
    {
        GameEffect ge = GetEffect(filePath);
        if (ge == null) return null;
        if (!usePrefabPos)
            ge.transform.position = pos;
        if (!usePrefabRotation)
            ge.transform.rotation = rotation;
        if (autoplay == true)
        {
            ge.Play(scale, delayFrame);
        }
        return ge;
    }

    /// <summary>
    /// 增加一个世界特效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="pos"></param>
    /// <param name="scale"></param>
    /// <param name="delayFrame"></param>
    /// <param name="effectPath"></param>
    /// <returns></returns>
    public GameEffect AddOneWorldEffect(string effectName, Vector3 pos, float scale = 1, int delayFrame = 0)
    {
        return AddWorldEffect(effectName, pos, Quaternion.identity, false, true, scale, delayFrame);
    }

    public GameEffect AddOneWorldEffectWithRotation(string effectName, Vector3 pos, Quaternion rotation, float scale = 1, int delayFrame = 0, bool autoplay = true)
    {
        return AddWorldEffect(effectName, pos, rotation, false, false, scale, delayFrame, autoplay);
    }



    /// <summary>
    ///  添加特效到指定物体
    /// </summary>
    /// <returns>The effect.</returns>
    /// <param name="effectid">配置表中的id.</param>
    /// <param name="obj">跟随物体，如果此物体不为空，特效会跟随此体移动，直到父物体变为null.</param>
    /// <param name="pos">特效在obj中的相对坐标(偏移).</param>
    /// <param name="scale">特效的尺寸.</param>
    /// <param name="keepparentposition">保持位置和父节点同步.</param>
    public GameEffect AddEffect(string filePath, GameObject obj, float scale = 1, int delayFrame = 0, bool keepparentposition = true, bool autoplay = true)
    {
        if (obj == null)
        {
            return null;
        }
        GameEffect ge = GetEffect(filePath);
        if (ge == null) return null;
        // ge.SetParent(obj);
        if (autoplay)
        {
            ge.Play(scale, delayFrame, keepparentposition, obj);
        }
        return ge;
    }

    GameEffect GetEffect(string filePath)
    {
        //对应池是否存在
        if (!effectPool.ContainsKey(filePath))
        {
            var effect = CreateEffect(filePath);
            if (effect == null) return null;
        }

        //寻找空闲特效
        List<GameEffect> pool = effectPool[filePath];
        GameEffect ret = null;
        for (int i = 0; i < pool.Count; i++)
        {
            GameEffect eff = pool[i];

            if (eff.gameObject.activeSelf)
            {
                continue;
            }

            ret = eff;
            break;
        }

        //如果没有可用特效，则创建一个新的
        if (ret == null)
        {
            // conf_effect conf = ConfigManager.confEffectManager.GetData(effectid);
            if (filePath != null) ret = CreateEffect(filePath);
        }

        return ret;
    }

    //添加一个特效到缓存池
    GameEffect CreateEffect(string filePath)
    {
        Object obj = ResourceMgr.Instance.Load<Object>(filePath);
        if (obj == null)
        {
            Debug.LogError("cant find file ! : " + filePath);
            return null;
        }
        // if (effect.res_type == 1)
        // {
        var effectName = filePath.Substring(filePath.IndexOf("/") + 1);
        var geobj = new GameObject(effectName);
        GameEffect ge = geobj.AddComponent<GameEffect>();
        GameObject effectgo = (GameObject)MonoBehaviour.Instantiate(obj, ge.transform);
        // GameObject go = (GameObject)MonoBehaviour.Instantiate(obj);
        // GameEffect ge = go.GetComponent<GameEffect>();
        // if (ge == null)
        // {
        //     ge = effectgo.AddComponent<GameEffect>();
        // }
        ge.Init(effectgo);

        if (!effectPool.ContainsKey(filePath))
        {
            effectPool.Add(filePath, new List<GameEffect>());
        }
        effectPool[filePath].Add(ge);

        return ge;
        // }
        // return null;
    }

}

