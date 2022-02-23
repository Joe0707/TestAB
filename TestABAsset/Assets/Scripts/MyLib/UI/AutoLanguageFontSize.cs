using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoLanguageFontSize : MonoBehaviour {

    public int m_FontSize_CN;
    public int m_FontSize_EN;
    void Start()
    {
        int size = m_FontSize_EN;
        //判断语言
        if (Application.systemLanguage == SystemLanguage.ChineseSimplified ||
           Application.systemLanguage == SystemLanguage.ChineseTraditional ||
           Application.systemLanguage == SystemLanguage.Chinese)
            size = m_FontSize_CN;
            
        Text uiText = GetComponent<Text>();
        if (uiText != null)
        {
            uiText.fontSize = size;
        }
        else
        {
            TextMesh textMsh = GetComponent<TextMesh>();
            if(textMsh != null)
            {
                textMsh.fontSize = size;
            }
        }
    }
}
