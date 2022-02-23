using UnityEngine;
using System.Collections;

public enum EBmgPlayType
{
	EBPT_Rand,
};

public enum EBgmIndex{
	MENU = 0,//登陆背景音乐
	GAME_LXL = 1,//战斗场景 敌方主将李小龙背景音乐
	GAME_SL = 2,//战斗场景 敌方主将莎林背景音乐
}

//-5.3 51 258.1   176.986
public class BgmCtrl : MonoBehaviour {

	// Use this for initialization
	public static BgmCtrl instance;
	public AudioClip[] bgmList;
	public EBmgPlayType playType;

	[HideInInspector]
	AudioSource audioSrc;

	private bool musicStarted = false;

	EBgmIndex bgmIndex;

	float fadeSpeed = 0.8f;

	void Awake(){
		instance = this;
	}

	void Start () {
		//随机
//		if(bgmList.Length > 1 && playType == EBmgPlayType.EBPT_Rand)
//			audioSrc.loop = false;
		audioSrc = GetComponent<AudioSource>();
		bgmIndex = EBgmIndex.MENU;

		float v = CryptoPrefs.GetFloat("AudioVol");

		if(!CryptoPrefs.GetBool("NotFirstLogin")){
			CryptoPrefs.SetFloat ("AudioVol", 1f);
		}

		audioSrc.volume = CryptoPrefs.GetFloat ("AudioVol");
		audioSrc.clip = bgmList [(int)bgmIndex];
		audioSrc.Play ();
	}

	public AudioSource GetBmgAS(){
		return audioSrc;
	}
	
	// Update is called once per frame
	void Update () {
//		if(musicStarted == false)
//			return;
//		if(audioSrc.isPlaying == false && playType == EBmgPlayType.EBPT_Rand)
//		{//随机
//			audioSrc.clip = bgmList[Random.Range(0, bgmList.Length)];
//			audioSrc.Play();
//		}
	}
	public void StartPlayMusic()
	{
		musicStarted = true;
	}

	public void SwitchBgmByIndex(EBgmIndex index){
		StartCoroutine (VolumeFadeOut(index));
	}

	IEnumerator VolumeFadeOut(EBgmIndex index){
		while(audioSrc.volume > 0){
			print ("audioSrc.volume------" + audioSrc.volume);
			yield return null;
			audioSrc.volume = audioSrc.volume - Time.deltaTime * fadeSpeed;
		}

		audioSrc.clip = bgmList [(int)index];
		audioSrc.volume = CryptoPrefs.GetFloat("AudioVol");
		audioSrc.Play ();
	}
}
