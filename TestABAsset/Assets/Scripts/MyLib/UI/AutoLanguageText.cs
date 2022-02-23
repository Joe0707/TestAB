using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoLanguageText : MonoBehaviour {

    // Use this for initialization
    public string textCN;
    public string textEN;
    public string textCNTR;
    void Start()
    {
        Text uiText = GetComponent<Text>();
        if (uiText != null)
        {
            if(Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
                uiText.text = textCN;
            else if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
                uiText.text = textCNTR;
            else
                uiText.text = textEN;
        }
        else
        {
            TextMesh textMsh = GetComponent<TextMesh>();
            if(textMsh != null)
            {
                if (Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
                    textMsh.text = textCN;
                else if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
                    textMsh.text = textCNTR;
                else
                    textMsh.text = textEN;
            }
        }
    }
}
