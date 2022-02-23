using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//用于顺序播放logo的管理器
public class LogoPlayer : MonoBehaviour {
    [Serializable]
    public class Logo
    {
		public GameObject m_LogoObject;
		public float m_ShowTime = 2f;//显示时间
    }
    static LogoPlayer mInstance = null;
    public Logo[] m_LogoList;//logo列表
    void Awake()
    {
        mInstance = this;
	}
	void Start()
	{
        Color color = Color.white;
        color.a = 0;
        foreach (var logo in m_LogoList)
		{
			var sprRdr = logo.m_LogoObject.GetComponent<SpriteRenderer>();
			if(sprRdr != null)
                sprRdr.color = color;
            logo.m_LogoObject.SetActive(false);
		}
	}

	public static void Play(Action finishAction)
	{
		if(mInstance == null)
			return;
		mInstance.StartCoroutine(mInstance._Play(finishAction));
	}

	IEnumerator _Play(Action finishAction)
	{
        yield return null;
		foreach(var logo in m_LogoList)
		{
			if(logo == null)
				continue;
            logo.m_LogoObject.SetActive(true);
            var sprRdr = logo.m_LogoObject.GetComponent<SpriteRenderer>();
            if (sprRdr != null)
            {
                float fadeTime = Mathf.Min(0.5f, logo.m_ShowTime * 0.2f);
                float fadeSpeed = 1 / fadeTime;
                float stayTime = Mathf.Max(0.5f, logo.m_ShowTime - 2 * fadeTime);
                Color color = Color.white;
                color.a = 0;
                //淡入
                while (color.a < 1)
                {
                    sprRdr.color = color;
                    color.a += Time.deltaTime * fadeSpeed;
                    yield return null;
                }
                sprRdr.color = color;
                yield return new WaitForSeconds(stayTime);
                //淡出
                while (color.a > 0)
                {
                    sprRdr.color = color;
                    color.a -= Time.deltaTime * fadeSpeed;
                    yield return null;
                }
                logo.m_LogoObject.SetActive(false);
            }
			else
			{
				yield return new WaitForSeconds(logo.m_ShowTime);
				logo.m_LogoObject.SetActive(false);
			}
        }
        if (finishAction != null)
            finishAction();
    }
}
