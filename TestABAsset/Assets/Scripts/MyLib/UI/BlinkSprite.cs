using UnityEngine;
using System.Collections;

public class BlinkSprite : MonoBehaviour {
    public string[] m_IgnoreTags;//需要忽略的Tag
    private SpriteRenderer mSpriteRenderer = null;
    public float m_BlinkInterval = 1f;
    public int m_BlinkCount = 100000;
    private float mBlinkCntLeft = 0f;
    private float mTimeElapsed = 0f;
    private bool mCurEnableState = true;
    void Start()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
         mBlinkCntLeft = m_BlinkCount;
    }

    void Update()
    {
        if (mBlinkCntLeft > 0)
        {
            mTimeElapsed += Time.deltaTime;
            if (mTimeElapsed >= m_BlinkInterval)
            {
                mTimeElapsed = 0f;
                mCurEnableState = !mCurEnableState;
                if (mSpriteRenderer != null)
                    mSpriteRenderer.enabled = mCurEnableState;
                if (mCurEnableState == true)
                {
                    mBlinkCntLeft--;
                }
                //子级别的跟着闪烁
                for (int i = 0; i < transform.childCount; i++)
                {
                    GameObject obj = transform.GetChild(i).gameObject;
                    if(IsInIgnoreList(obj.tag) == false)
                        obj.SetActive(mCurEnableState);
                }
            }
        }
    }

    public void Blink(float vmBlinkCntLeft, float vmBlinkInterval)
    {
        mBlinkCntLeft = vmBlinkCntLeft;
        m_BlinkInterval = vmBlinkInterval;
        mTimeElapsed = vmBlinkInterval;
    }

    bool IsInIgnoreList(string tag)
    {
        bool retValue = false;
        for(int i = 0; i < m_IgnoreTags.Length; i++)
        {
            if(m_IgnoreTags[i] == tag)
            {
                retValue = true;
                break;
            }
        }
        return retValue;
    }
}
