using UnityEngine;
using System.Collections;


public class ScaleParticles : MonoBehaviour {
    public float scaleFactor = 1.0f;
    void Start () 
    {
        if(scaleFactor != 1.0)
        {
            SetScale(scaleFactor);
        }
    }

    private void ScaleParticleObject(GameObject obj, float scaleValue)
    {
            ParticleSystem particle = obj.GetComponent<ParticleSystem>();
            if(particle != null)
                ScaleParticleSystem(particle, scaleValue);
            for(int i = 0; i < obj.transform.childCount; i++)
            {
                ScaleParticleObject(obj.transform.GetChild(i).gameObject, scaleValue);
            }
    }

    private void ScaleParticleSystem(ParticleSystem particle , float scaleValue)
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

    public void SetScale(float scaleValue)
    {
        //将根节点缩放
        transform.localScale *= scaleValue;
        ScaleParticleObject(gameObject, scaleValue);
    }

}
