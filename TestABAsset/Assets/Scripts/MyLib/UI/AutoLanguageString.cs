using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoLanguageString : MonoBehaviour {

    public string m_StringRefName;
    void Start()
    {
        string str = "";
        if(m_StringRefName != "")
            str = StaticData.StringMgr.Get(m_StringRefName);
            
        Text uiText = GetComponent<Text>();
        if (uiText != null)
        {
            uiText.text = str;
        }
        else
        {
            TextMesh textMsh = GetComponent<TextMesh>();
            if(textMsh != null)
            {
                textMsh.text = str;
            }
        }
    }
}
