using UnityEngine;
using System.Collections.Generic;
//音效播放事件
public class AudioPlayEvent
{
    public int curFrame = 0;//当前帧
    public int delayFrame = 0;//延迟帧
    public float playTime = 0;//播放时间
    public bool startPlay = true;//开始播放
    public bool audioRealPlay = false;//实际在播放
    public AudioClip clip;//播放音频
    public float volume = 0;//音量
    public float pitch = 0;//音调
    public bool loop = false;//循环
}
public class AudioAsset : MonoBehaviour
{
    // private bool startPlay = true;
    // private int curFrame = 0;
    // private int delayFrame = 0;
    // private float playTime = 0;
    // private bool audioRealPlay = false;//音效时机开始播放
    private List<AudioPlayEvent> events = new List<AudioPlayEvent>();
    private List<AudioSource> audioSources = new List<AudioSource>();
    public void Init()
    {
        // audioSource = transform.GetComponent<AudioSource>();
        // if (audioSource == null)
        // {
        //     audioSource = gameObject.AddComponent<AudioSource>();
        //     audioSource.playOnAwake = false;
        // }
    }

    public void Play(AudioClip clip, float volume, float pitch, bool loop, int delayFrame = 0)
    {
        //新建一个播放事件
        var playEvent = new AudioPlayEvent();
        playEvent.clip = clip;
        playEvent.delayFrame = delayFrame;
        playEvent.volume = volume;
        playEvent.pitch = pitch;
        playEvent.loop = loop;
        events.Add(playEvent);
        // if (audioSource.isPlaying)
        // {
        //     audioSource.Stop();
        // }
        // audioSource.clip = clip;
        // audioSource.volume = volume;
        // audioSource.pitch = pitch;
        // audioSource.loop = loop;
        // this.delayFrame = delayFrame;
        // curFrame = 0;
        // playTime = 0;
        // startPlay = true;
    }

    void OnDisable()
    {
        Stop();
    }
    //获取声源
    AudioSource GetAudioSource()
    {
        AudioSource result = null;
        //遍历已用声源
        for (var i = 0; i < audioSources.Count; i++)
        {
            var audioSource = audioSources[i];
            if (audioSource.enabled == false)
            {
                //如果有可用声源则返回,并设置active
                audioSource.enabled = true;
                result = audioSource;
                break;
            }
        }
        if (result == null)
        {
            //如果没有则添加一个新的声源
            result = gameObject.AddComponent<AudioSource>();
            result.playOnAwake = false;
            audioSources.Add(result);
        }
        return result;
    }
    void FixedUpdate()
    {
        List<int> removes = null;
        //播放事件轮播
        for (var i = 0; i < events.Count; i++)
        {
            var playevent = events[i];
            //一旦开始播放选择一个音源
            if (playevent.startPlay)
            {
                playevent.curFrame++;
                if (playevent.audioRealPlay == true)
                {
                    playevent.playTime += Time.deltaTime;
                    if (playevent.loop == false && playevent.playTime >= playevent.clip.length)
                    {
                        if (removes == null)
                        {
                            removes = new List<int>();
                        }
                        removes.Add(i);
                        continue;
                    }
                }
                if (playevent.audioRealPlay == false && playevent.curFrame >= playevent.delayFrame)
                {
                    //一旦开始播放选择一个音源
                    var audioSource = GetAudioSource();
                    audioSource.volume = playevent.volume;
                    audioSource.loop = playevent.loop;
                    audioSource.pitch = playevent.pitch;
                    audioSource.clip = playevent.clip;
                    audioSource.Play();
                    playevent.audioRealPlay = true;
                }
            }
        }

        if (removes != null)
        {
            for (var i = 0; i < removes.Count; i++)
            {
                events.RemoveAt(i);
            }
        }

        //遍历声源
        for (var i = 0; i < audioSources.Count; i++)
        {
            var audioSource = audioSources[i];
            if (audioSource.isPlaying == false && audioSource.loop == false)
            {
                audioSource.enabled = false;
            }
        }

        // if (startPlay)
        // {
        //     curFrame++;
        //     if (audioRealPlay == true)
        //     {
        //         playTime += Time.deltaTime;
        //         if (audioSource != null && audioSource.loop == false && playTime >= audioSource.clip.length)
        //         {
        //             Stop();
        //             return;
        //         }
        //     }
        //     if (audioRealPlay == false && curFrame >= delayFrame)
        //     {
        //         audioSource.Play();
        //         audioRealPlay = true;
        //     }
        // }
    }

    public void Stop()
    {
        events.Clear();
        for (var i = 0; i < audioSources.Count; i++)
        {
            var audioSource = audioSources[i];
            audioSource.Stop();
            audioSource.enabled = false;
        }
    }

    void OnDestroy()
    {
        events.Clear();
        audioSources.Clear();
        // playTime = 0;
        // curFrame = 0;
        // startPlay = false;
        // audioSource = null;
    }
}