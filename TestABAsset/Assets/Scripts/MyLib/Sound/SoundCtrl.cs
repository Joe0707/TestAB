using UnityEngine;
using System.Collections;

public enum ESoundType
{
	EST_Sound,
	EST_Music,
    EST_Vibrate,
}
public class SoundCtrl : MonoBehaviour {
	//设定是音乐还是音效
	public ESoundType mSoundType = ESoundType.EST_Sound;
	private AudioSource[] mAudioSrc = null;
    private int curClipIdx = 0;
	void Start () {
		mAudioSrc = gameObject.GetComponents<AudioSource>();
		UpdateSoundState();	
		EventMgr.AddEventHandler("OnSndOnOffChanged", OnSndOnOffChanged);
	}
	void OnDestroy()
	{
		EventMgr.RemoveEventHandler("OnSndOnOffChanged", OnSndOnOffChanged);
	}

	public void OnSndOnOffChanged(object param)
	{
		UpdateSoundState();
	}
    public void UpdateSoundState()
    {
        if (mAudioSrc == null)
        {
            mAudioSrc = gameObject.GetComponents<AudioSource>();
            if (mAudioSrc == null)
                return;
        }
        for (int i = 0; i < mAudioSrc.Length; i++)
        {
            if (mSoundType == ESoundType.EST_Sound)
            {//音效
                mAudioSrc[i].mute = !SoundMgr.mSndEffectOn;
            }
            else if (mSoundType == ESoundType.EST_Music)
            {//音乐
                mAudioSrc[i].mute = !SoundMgr.mMusicOn;
            }
        }
    }
    //播放声音片段
    public void PlayClip(AudioClip clip, bool loop = false)
    {
        if (mAudioSrc == null)
            return;
        curClipIdx++;
        if (curClipIdx >= mAudioSrc.Length)
            curClipIdx = 0;
        mAudioSrc[curClipIdx].clip = clip;
        mAudioSrc[curClipIdx].loop = false;
        mAudioSrc[curClipIdx].Play();
    }
    //停止声音片段
    public void StopClip(AudioClip clip)
    {
        for(int i = 0; i < mAudioSrc.Length; i++)
        {
            if(mAudioSrc[i].clip == clip)
            {
                mAudioSrc[i].Stop();
                break;
            }
        }
    }
    //停止所有声音
    public void StopAll()
    {
        for (int i = 0; i < mAudioSrc.Length; i++)
        {
            mAudioSrc[i].Stop();
        }
    }
}

