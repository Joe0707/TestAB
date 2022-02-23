using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//声音优先级
public enum ESoundPriority
{
	NotImportant,
	Normal,
	Important,
	MostImportant,
}
public class SoundMgr : MonoBehaviour {

	//背景音乐的配置
	[System.Serializable]
	public class BgmConfig
	{
		[Tooltip("场景名字设定，可多次使用同一场景名，将随机播放")]
		public string m_SceneName;
		public AudioClip m_Music;
		public float m_Volume = 1.0f;
		public bool m_AutoPlay = true;
	}
	//特效配置
	[System.Serializable]
	public class SfxConfig
	{
		public string m_SfxName;
		public AudioClip m_Sfx;
		public ESoundPriority m_Priority = ESoundPriority.Normal;
	}
	

	//播放音效的组件
	private AudioSource[] mSfxAudioSources = null;
	//播放背景音乐的组件
	private AudioSource mBgmAudioSource = null;

	public static SoundMgr mInstance = null;
	public static bool mMusicOn = true;//音乐
	public static bool mSndEffectOn = true;//音效
	public static bool mVibrateTouchFeedBackOn = true; //震动是否开启

	[Tooltip("游戏场景对应的音乐名称，游戏场景名可重复出现，一个场景被设置的多个音乐会随机播放")]
	public BgmConfig[] m_BgmConfig;
	private Dictionary<string, List<BgmConfig>> mBgmDic = new Dictionary<string, List<BgmConfig>>();

	[Tooltip("音效的引用名称和音效文件的对应表")]
	public SfxConfig[] m_SfxConfig;
	private Dictionary<string, AudioSource> mSfxDic = new Dictionary<string, AudioSource>();

	void Awake()
	{
		mInstance = this;
		mMusicOn = CryptoPrefs.GetInt("mMusicOn", 1) > 0;
		mSndEffectOn = CryptoPrefs.GetInt("mSndEffectOn", 1) > 0;
		mVibrateTouchFeedBackOn = CryptoPrefs.GetBool("mVibrateTouchFeedBackOn", true);
	}
	void Start () {
		//创建背景音乐的组件
		var go = new GameObject();
		go.name = "BgMusic";
		go.transform.parent = transform;
		go.transform.localPosition = Vector3.zero;
        mBgmAudioSource = go.AddComponent<AudioSource>();
        mBgmAudioSource.playOnAwake = false;
        mBgmAudioSource.loop = true;
		mBgmAudioSource.priority = 255;
        //创建播放音效的组件
		mSfxAudioSources = new AudioSource[m_SfxConfig.Length];
		for(int i = 0; i < mSfxAudioSources.Length; i++)
        {
			var sfxCfg = m_SfxConfig[i];
			var newGo = new GameObject();
			newGo.transform.parent = gameObject.transform;
			newGo.transform.localPosition = Vector3.zero;
			newGo.name = "sfx:" + sfxCfg.m_SfxName;
			var audioSource = newGo.AddComponent<AudioSource>();
            mSfxAudioSources[i] = audioSource;
            audioSource.playOnAwake = false;
            audioSource.loop = false;
            audioSource.clip = sfxCfg.m_Sfx;
			//优先级
			switch(sfxCfg.m_Priority)
			{
                case ESoundPriority.NotImportant:
					audioSource.priority = 64;
                    break;
				case ESoundPriority.Normal:
					audioSource.priority = 128;
                    break;
				case ESoundPriority.Important:
					audioSource.priority = 200;
                    break;
				case ESoundPriority.MostImportant:
					audioSource.priority = 255;
                    break;
			}
			//加入字典
            if (mSfxDic.ContainsKey(sfxCfg.m_SfxName) == false)
            {
                mSfxDic.Add(sfxCfg.m_SfxName, audioSource);
            }
            else
                Debug.LogError("SoundMgr:sfx name already exist:" + sfxCfg.m_SfxName);
        }
		//初始化音乐列表
		foreach(var bgmCfg in m_BgmConfig)
		{
			if(mBgmDic.ContainsKey(bgmCfg.m_SceneName) == false)
				mBgmDic.Add(bgmCfg.m_SceneName, new List<BgmConfig>());
			var list = mBgmDic[bgmCfg.m_SceneName];
			list.Add(bgmCfg);
		}
		//注册切换场景的事件
		SceneManager.sceneLoaded += OnSceneLoaded;
		SetMusic(mMusicOn);
		SetSndEffect(mSndEffectOn);
		//播放Start场景的音乐
		if(mBgmDic.ContainsKey("Start") == true)
		{
			if(mBgmDic["Start"][0].m_AutoPlay)
                PlayMusic("Start", true);
		}
    }

    void Update()
    {

    }

	//设定音乐
    public static void SetMusic(bool on)
	{
		if(mInstance == null)
			return;
		mMusicOn = on;
		CryptoPrefs.SetInt("mMusicOn", mMusicOn==true?1:0);
		EventMgr.FireEvent("OnSndOnOffChanged", "");
		if(mInstance.mBgmAudioSource != null)
			mInstance.mBgmAudioSource.mute = !on;
	}
	//设定音效
	public static void SetSndEffect(bool on)
	{
		if(mInstance == null)
			return;	
		mSndEffectOn = on;
		CryptoPrefs.SetInt("mSndEffectOn", mSndEffectOn==true?1:0);
		EventMgr.FireEvent("OnSndOnOffChanged", "");
		foreach(var audio in mInstance.mSfxAudioSources)
		{
			audio.mute = !on;
		}
	}

	//设定震动反馈
	public static void SetVibrateFeedback(bool on)
	{
		if(mInstance == null)
			return;	
		mVibrateTouchFeedBackOn = on;
		CryptoPrefs.SetBool("mVibrateTouchFeedBackOn", mVibrateTouchFeedBackOn);
		EventMgr.FireEvent("OnSndOnOffChanged", "");
	}

	//播放音乐
	public static void PlayMusic(string sceneName, bool crossFade = true)
	{
		Debug.Log("PlayMusic");
		if(mInstance == null)
			return;
		if(mInstance.mBgmDic.ContainsKey(sceneName))
		{
			var list = mInstance.mBgmDic[sceneName];
			if(list.Count > 0)
			{
                var bgm = list[Random.Range(0, list.Count)];
				PlayMusic(bgm.m_Music, crossFade, bgm.m_Volume);
			}
			else
                Debug.LogError("SoundMgr.Play:No music for scene :" + sceneName);
		}
		else
		{
			Debug.LogError("SoundMgr.Play:SceneName Not found :" + sceneName);
		}
	}
	public static void PlayMusic(AudioClip clip, bool crossFade = true, float atVolume = 1f)
	{
		if(mInstance == null)
			return;
		if(mInstance.mBgmAudioSource.clip == clip)
		{
			if(mInstance.mBgmAudioSource.isPlaying == false)
			{
				mInstance.mBgmAudioSource.Play();
			}
            mInstance.mBgmAudioSource.volume = atVolume;
			return;//同样的音乐，不要停止了
		}
		Debug.Log("Play Music:" + clip.name);
		if(crossFade == false)
        {
            mInstance.mBgmAudioSource.clip = clip;
            mInstance.mBgmAudioSource.volume = atVolume;
            mInstance.mBgmAudioSource.Play();
        }
		else
		{
			mInstance.StopAllCoroutines();
			mInstance.StartCoroutine(mInstance._CrossFade(clip, atVolume));
		}
    }
	//淡入淡出切换
	IEnumerator _CrossFade(AudioClip newClip, float atVolume)
	{
        float volume = mInstance.mBgmAudioSource.volume;
        if (mBgmAudioSource.isPlaying)
        {
            while (volume > 0.1f)
            {
                volume -= 1f * Time.deltaTime;
                if (volume <= 0)
                    volume = 0;
                mBgmAudioSource.volume = volume;
                yield return null;
            }
		}
        mBgmAudioSource.Stop();
		yield return new WaitForSeconds(0.1f);
        mBgmAudioSource.volume = 0.1f;
		volume = 0.1f;
		mBgmAudioSource.clip = newClip;
		mBgmAudioSource.Play();
		while(volume < atVolume)
		{
			volume += 1f * Time.deltaTime;
			if(volume > atVolume)
				volume = atVolume;
            mBgmAudioSource.volume = volume;
            yield return null;
		}
    }

    //停止音乐
    public static void StopMusic(bool fadeOut = true)
    {
		if(mInstance == null)
			return;
		if(fadeOut == false)
            mInstance.mBgmAudioSource.Stop();
		else
			mInstance.StartCoroutine(mInstance._FadeoutMusic());
	}
	//淡出音乐
	IEnumerator _FadeoutMusic()
	{
		float volume = mInstance.mBgmAudioSource.volume ;
		while(volume > 0)
        {
            volume -= 1f * Time.deltaTime;
			if(volume <= 0)
				volume = 0;
			mBgmAudioSource.volume = volume;
			yield return null;
		}
		mBgmAudioSource.Stop();	
    }
    //播放音效
    public static void PlaySoundEffect(string sfxName, float volume = 1f)
    {
        if (mInstance == null)
            return;
        if (mInstance.mSfxDic.ContainsKey(sfxName))
		{
			var audio = mInstance.mSfxDic[sfxName];
			audio.volume = volume;
			audio.Play();
		}
		else
			Debug.LogError("SoundMgr:No sfx named:" + sfxName);
	}

	//切换场景时
	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(mInstance.mBgmDic.ContainsKey(scene.name))
		{
			if(mInstance.mBgmDic[scene.name][0].m_AutoPlay)
                PlayMusic(scene.name, true);
		}
	}

	//播放震动反馈
	public static void PlayTouchFeedBack()
	{
		if(mVibrateTouchFeedBackOn)
			PluginUtil.TouchFeedBack();
	}
}
