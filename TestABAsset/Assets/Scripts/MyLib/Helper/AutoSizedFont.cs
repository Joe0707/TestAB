using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//根据字数调整字体大小
public class AutoSizedFont : MonoBehaviour
{
    [Tooltip("最大字体尺寸")]
    public int m_MaxFontSize;
    [Tooltip("最小字体尺寸")]
    public int m_MinFontSize;
    
    Text mText;
    string mCurString = "";
    void Start()
    {
        mText = GetComponent<Text>();
        if(mText == null)
            Debug.LogError("AutoSizedFont: No Text Component found on object " + gameObject.name);
    }

    void Update()
    {
        if(mText != null)
        {
            if(mCurString != mText.text)
            {
                if(mText.preferredWidth - mText.rectTransform.rect.width > 0 && mText.fontSize > m_MinFontSize)
                {
                    StopAllCoroutines();
                    StartCoroutine(FontShrink());
                    mCurString = mText.text;
                }
                else if (mText.preferredWidth / mText.rectTransform.rect.width <= 0.7f  && mText.fontSize < m_MaxFontSize)
                {
                    StopAllCoroutines();
                    StartCoroutine(FontGrow());
                    mCurString = mText.text;
                }
                else
                {
                    mCurString = mText.text;
                }
            }
        }
    }

    IEnumerator FontShrink()
    {
        if(mText == null)
            yield break;
        while (mText.preferredWidth - mText.rectTransform.rect.width > 0 && mText.fontSize > m_MinFontSize)
        {
            mText.fontSize = mText.fontSize - 1;
            yield return null;
        }
    }
    IEnumerator FontGrow()
    {
        if(mText == null)
            yield break;
        while (mText.preferredWidth - mText.rectTransform.rect.width < 0 && mText.fontSize < m_MaxFontSize)
        {
            mText.fontSize = mText.fontSize + 1;
            yield return null;
        }
    } 

}
