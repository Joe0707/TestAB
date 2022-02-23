using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FrameAnim : MonoBehaviour {
    //播放完成时的动作
    public enum EAnimEndAction
    {
       KeepLast,//保持最后一帧
       KeepFirst,//保持第一帧
       Loop,//循环
       PingPong, //乒乓
       DeactiveObj, //隐藏此物体
       DestroyObj,//删除此物体
    }
    public Sprite[] mFrames;
    public float mPlayDelay = 0f;
    public float mFrameTime = 0.1f;
    public bool mPlaying = false;
    public EAnimEndAction mEndActionType;
    private int mCurFrameIdx = 0;
    private float mTime = 0;
    private bool mIsPong = false; //是否正在逆向播放
    private SpriteRenderer mSprRenderer = null;
    private Image mImage = null;

    void OnEnable()
    {
        if (mPlayDelay > 0)
        {
            mTime = mPlayDelay;
            mCurFrameIdx = -1;
        }
        else
        {
            mTime = mFrameTime;
            mCurFrameIdx = 0;
        }
        mPlaying = true;
        UpdateFrameImage();
    }
	
	void Update () {
        if (mPlaying == false)
            return;
        if(mFrames.Length == 0)
            return;    
        if (mTime > 0)
        {
            mTime -= Time.deltaTime;
            if(mTime <= 0)
            {//帧时间到
                mTime = mFrameTime; //重设时间
                if(mIsPong == false)
                    UpdatePing();
                else
                    UpdatePong();
            }
        }
    }

    //更新正向播放
    void UpdatePing()
    {
        //切换下一个
        mCurFrameIdx++;
        if (mCurFrameIdx >= mFrames.Length)
        {//到最后一帧了
            switch (mEndActionType)
            {
                case EAnimEndAction.KeepLast:
                    mCurFrameIdx = Mathf.Max(0, mFrames.Length - 1);
                    mPlaying = false;
                    break;
                case EAnimEndAction.KeepFirst:
                    mCurFrameIdx = 0;
                    mPlaying = false;
                    break;
                case EAnimEndAction.Loop:
                    mCurFrameIdx = 0; //切到第一帧
                    break;
                case EAnimEndAction.PingPong:
                    mCurFrameIdx = Mathf.Max(0, mFrames.Length - 2);//切到倒数第二帧
                    mIsPong = true;
                    break;
                case EAnimEndAction.DeactiveObj:
                    mPlaying = false;
                    gameObject.SetActive(false);
                    break;
                case EAnimEndAction.DestroyObj:
                    mPlaying = false;
                    GameObject.Destroy(gameObject);
                    break;
            }
        }
        //更新图像
        UpdateFrameImage();
    }
    //更新逆向播放
    void UpdatePong()
    {
        //切换上一个
        mCurFrameIdx--;
        if (mCurFrameIdx < 0)
        {//到最后一帧了
            mCurFrameIdx = Mathf.Min(1, mFrames.Length - 1);//切到倒数第二帧
            mIsPong = false;
        }
        //更新图像
        UpdateFrameImage();
    }

    void UpdateFrameImage()
    {
        if (mInited == false)
            Init();
        if (mSprRenderer != null)
        {
            if (mCurFrameIdx >= 0 && mCurFrameIdx < mFrames.Length)
                mSprRenderer.sprite = mFrames[mCurFrameIdx];
            else
                mSprRenderer.sprite = null;
        }
        else if(mImage != null)
        {
            if (mCurFrameIdx >= 0 && mCurFrameIdx < mFrames.Length)
            {
                mImage.sprite = mFrames[mCurFrameIdx];
                mImage.SetNativeSize();
            }
            else
                mImage.sprite = null;
        }
    }

    bool mInited = false;
    void Init()
    {
        mInited = true;
        mSprRenderer = gameObject.GetComponent<SpriteRenderer>();
        mImage = gameObject.GetComponent<Image>();
    }

}
