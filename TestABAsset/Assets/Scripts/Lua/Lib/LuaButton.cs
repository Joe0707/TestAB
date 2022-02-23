using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuaButton : MonoBehaviour
{
    Button mButton = null;
    public LuaBehavior m_LuaBehavior;
    public string m_FunctionName;
    public string m_Param;
    void Start()
    {
        mButton = GetComponent<Button>();
        if(mButton == null)
        {
            Debug.LogError("LuaButton 模块应该绑定在有Button控件的GameObject上");
            return;
        }
        if(m_LuaBehavior != null && string.IsNullOrEmpty(m_FunctionName) == false)
        {
            mButton.onClick.AddListener(() =>
            {
                if (string.IsNullOrEmpty(m_Param) == false)
                    m_LuaBehavior.CallLuaFunction(m_FunctionName, m_Param);
                else
                    m_LuaBehavior.CallLuaFunction(m_FunctionName);
            });
        }
    }
}
