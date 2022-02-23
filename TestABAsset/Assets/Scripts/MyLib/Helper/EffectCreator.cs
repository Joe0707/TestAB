using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreator : MonoBehaviour {
	[System.Serializable]
	public class EffectPrefabConfig
	{
		public string m_EffectName = "";
		public GameObject m_Prefab;
	}
	static EffectCreator mInstance = null;
	public EffectPrefabConfig[] m_PrefabConfig;
	Dictionary<string, GameObject> mPrefabDic = new Dictionary<string, GameObject>();
	// Use this for initialization
	void Awake () {
		mInstance = this;	
	}
	
	void Start () {
		foreach(var config in m_PrefabConfig)
		{
			mPrefabDic.Add(config.m_EffectName, config.m_Prefab);
		}
	}
	//创建特效
	public static GameObject CreateEffect(string prefabName)
	{
		return CreateEffect(prefabName, Vector3.zero);
	}
	public static GameObject CreateEffect(string prefabName, Vector3 pos)
	{
		if(mInstance == null)
			return null;
		GameObject retValue = null;
		if(mInstance.mPrefabDic.ContainsKey(prefabName))
		{
			var prefab = mInstance.mPrefabDic[prefabName];
			retValue = GameObject.Instantiate(prefab, pos, prefab.transform.rotation);
		}
		return retValue;
	}
	//根据屏幕分辨率缩放特效(假定原始分辨率是根据2:3来做的)
	public static void ScaleEffectAccordingToScreenRatio(GameObject eff)
	{
		var scale = 1f;
		if(Screen.width > Screen.height)
		{//横屏
			scale = (Screen.height / (float)Screen.width) / (3f / 2f);
		}
		else
		{//竖屏
			scale = (Screen.width / (float)Screen.height) / (2f / 3f);
		}
		ScaleEffect(eff, scale);
	}
	
	public static void ScaleEffect(GameObject eff, float scaleValue)
	{
        ParticleSystem particle = eff.GetComponent<ParticleSystem>();
        if (particle != null)
            ScaleParticleSystem(particle, scaleValue);
        for (int i = 0; i < eff.transform.childCount; i++)
        {
            ScaleEffect(eff.transform.GetChild(i).gameObject, scaleValue);
        }
    }
    static void ScaleParticleSystem(ParticleSystem particle, float scaleValue)
    {
		var main = particle.main;
        var startSize = main.startSize;
        switch (startSize.mode)
		{
            case ParticleSystemCurveMode.Constant:
				startSize.constant *= scaleValue;	
                break;
            case ParticleSystemCurveMode.TwoConstants:
				startSize.constantMin *= scaleValue;	
				startSize.constantMax *= scaleValue;	
                break;
            case ParticleSystemCurveMode.Curve:
            case ParticleSystemCurveMode.TwoCurves:
				startSize.curveMultiplier *= scaleValue;
                break;
		}
        main.startSize = startSize;
        particle.GetComponent<ParticleSystemRenderer>().maxParticleSize *= scaleValue;
        
        ParticleSystem.Particle[] particleList  = new ParticleSystem.Particle[particle.particleCount];
        particle.GetParticles(particleList);
        if(particleList != null)
        {
            for(var i = 0; i < particleList.Length; i++)
            {
                particleList[i].startSize *= scaleValue;
            }
            particle.SetParticles(particleList, particleList.Length);
        }
    }
}
