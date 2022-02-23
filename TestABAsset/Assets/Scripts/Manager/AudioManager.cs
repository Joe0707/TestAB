using UnityEngine;
//音效管理器
public class AudioManager : MonoSingleton<AudioManager>
{
    private string AudioPath = "";
    protected override void OnStart()
    {
        base.OnStart();
        AudioPath = "Audio/";
    }

    // public AudioManager() : base()
    // {
    //     AudioPath = Application.dataPath + "/Audio/";
    // }
    //播放背景音乐
    public void PlayBGM(string fileName)
    {
        var clip = ResourceMgr.Instance.Load<AudioClip>(AudioPath + fileName);
        Play(clip, gameObject, 1f, 1f, true, 0);
    }

    //停止背景音乐
    public void StopBGM()
    {
        AudioAsset audioAsset = gameObject.GetComponent<AudioAsset>();
        if (audioAsset != null)
        {
            audioAsset.Stop();
        }
    }

    //播放一次声音
    public void PlayOneShot(string audioName, GameObject go, int delayFrame = 0)
    {
        var clip = ResourceMgr.Instance.Load<AudioClip>(AudioPath + audioName);
        Play(clip, go, 1f, 1f, false, delayFrame);
    }

    public void Play(AudioClip clip, GameObject obj, float volume, float pitch, bool loop, int delayFrame = 0)
    {
        AudioAsset audioAsset = obj.GetComponent<AudioAsset>();
        if (audioAsset == null)
        {
            audioAsset = obj.AddComponent<AudioAsset>();
            audioAsset.Init();
        }
        audioAsset.Play(clip, volume, pitch, loop, delayFrame);
    }

}