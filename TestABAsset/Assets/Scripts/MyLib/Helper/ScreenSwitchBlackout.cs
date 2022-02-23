using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

//屏幕切换时的黑屏和特效
public class ScreenSwitchBlackout : MonoBehaviour {
	static ScreenSwitchBlackout mInstance = null;
	Coroutine mShowProcess = null; //处理动画的协程
	GameObject mEffectObj = null; //创建出来的动画
	public SpriteRenderer m_BlackMask; //黑色遮罩
	public GameObject m_EffectPrefab; //特效预制
	public float m_EffectTime; //特效持续时间
	public float m_EffectDelayTime = 0; //特效播放延时
	public string m_SoundEffectRefName = "";

	void Awake()
	{
		mInstance = this;
	}
	void Start () {
		SceneManager.sceneLoaded += OnSceneLoaded;
		m_BlackMask.transform.localPosition = Vector3.zero;
		m_BlackMask.transform.parent = transform;
		m_BlackMask.color = new Color(1,1,1,0);
		ResetPosition();
	}

	//显示
	public static void Show(float time, Action actionWhenFinished)
	{
		if(mInstance == null)
			return;
        if (mInstance.mShowProcess != null)
			return;
        mInstance.mShowProcess = mInstance.StartCoroutine(mInstance.ShowProcess(time, actionWhenFinished));
    }
	public static void Stop()
	{
		if(mInstance == null)
			return;
        if (mInstance.mShowProcess == null)
			return;

		mInstance.StopCoroutine(mInstance.mShowProcess);
        //重置状态
        if (mInstance.m_BlackMask != null)
        {
            mInstance.m_BlackMask.color = new Color(1, 1, 1, 0);
        }
        if (mInstance.mEffectObj != null)
        {
            GameObject.Destroy(mInstance.mEffectObj);
            mInstance.mEffectObj = null;
        }
		mInstance.mShowProcess = null;
	}
    IEnumerator ShowProcess(float time, Action actionWhenFinished)
    {
		if(m_SoundEffectRefName != "")
            SoundMgr.PlaySoundEffect(m_SoundEffectRefName, 0.5f);
        float curElapsedTime = 0;
        var fadingTime = Mathf.Min(0.4f, time / 3f);
        var blackLastTime = time - 2 * fadingTime;
        var speed = 1f / fadingTime;
        Color c = new Color(20/255f,35/255f,105/255f,0); //渐变的背景色
		while(curElapsedTime < time)
		{
			if(m_BlackMask != null)	
			{//变黑
				if (curElapsedTime < fadingTime)
                {//变黑
					c.a = Mathf.Min(1f, c.a + speed * Time.deltaTime);
				}
				else if(curElapsedTime >= fadingTime + blackLastTime)
				{//变亮
					c.a = Mathf.Max(0f, c.a - speed * Time.deltaTime);
				}
				m_BlackMask.color = c;
			}

            //特效
            if (m_EffectPrefab != null)
            {
				if(curElapsedTime <= m_EffectDelayTime && curElapsedTime + Time.deltaTime > m_EffectDelayTime)
                {//延时
                    mEffectObj = GameObject.Instantiate(m_EffectPrefab);
                    mEffectObj.transform.position = transform.position + new Vector3(0, 0, -2);
					GameObject.DontDestroyOnLoad(mEffectObj);
                    GameObject.Destroy(mEffectObj, m_EffectTime);
                }
            }
            //执行动作
            if (actionWhenFinished != null)
			{
				if(curElapsedTime <= fadingTime + blackLastTime && curElapsedTime + Time.deltaTime > fadingTime + blackLastTime)
                    actionWhenFinished();
			}
            curElapsedTime += Time.deltaTime;
            yield return null;
        }
        mShowProcess = null;
	}
	//场景转换
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		ResetPosition();
    }
	//重新设定位置
	void ResetPosition()
	{
		var parent = transform.parent;
		transform.parent = Camera.main.transform;
		transform.localPosition = new Vector3(0, 0, 4);
		transform.parent = parent;
		if(mEffectObj != null)
		{
			mEffectObj.transform.position = transform.position + new Vector3(0, 0, -1);
		}
	}
}
