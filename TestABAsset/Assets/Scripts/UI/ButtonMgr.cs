using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ButtonMgr
{
    public class ButtonConfig
    {
        public uint m_ID = 0;
        public GameObject m_Obj = null;
    }
    public List<ButtonConfig> Buttons = new List<ButtonConfig>();
    // Start is called before the first frame update
    static ButtonMgr mInstance = null;
    public static ButtonMgr Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = new ButtonMgr();
            return mInstance;
        }
    }
}
