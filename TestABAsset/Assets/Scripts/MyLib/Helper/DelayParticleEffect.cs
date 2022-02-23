using UnityEngine;
using System.Collections;

public class DelayParticleEffect : MonoBehaviour {
    [Tooltip("特效整体播放延迟时间")]
    public float delayTime = 0f;
    private float timeLeft = 0;
	// Use this for initialization
	void Awake () {
        if(delayTime > 0)
            SetPlayState(transform, false);
        timeLeft = delayTime;
    }

    // Update is called once per frame
    void Update () {
        if(delayTime > 0)
        {
            if (timeLeft >= 0)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                    SetPlayState(transform, true);
            }
        }
	}

    void SetPlayState(Transform objNode, bool play)
    {
        ParticleSystem ps = objNode.GetComponent<ParticleSystem>();
        if(ps != null)
        {
            if (play)
                ps.Play(false);
            else
                ps.Stop(false);
        }
        //遍历子级别
        int childCount = objNode.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform child = objNode.GetChild(i);
            SetPlayState(child, play);
        }
    }
}
