using UnityEngine;
using System.Collections;

//控制粒子播放速度
public class ParticleSpeedCtrl : MonoBehaviour
{
    public float playbackSpeed = 1.0f;
    void Start()
    {
        if (playbackSpeed != 1.0f)
        {
            SetParticleSpeed(gameObject, playbackSpeed);
        }
    }

    public static void SetParticleSpeed(GameObject obj, float speed)
    {
        ParticleSystem particle = obj.GetComponent<ParticleSystem>();
        if (particle != null)
            SetParticleSpeed(particle, speed);
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            SetParticleSpeed(obj.transform.GetChild(i).gameObject, speed);
        }
    }

    //
    private static void SetParticleSpeed(ParticleSystem particle, float speed)
    {
        if (particle == null)
            return;
        var main = particle.main;
        main.simulationSpeed = speed;
    }
}

