using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageMgr
{
    [System.Serializable]
    public class PageConfig
    {
        public string m_ID = "";
        public GameObject m_Obj = null;
    }
    // Start is called before the first frame update
    public List<PageConfig> Buttons = new List<PageConfig>();
    static PageMgr mInstance = null;
    public static PageMgr Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = new PageMgr();
            return mInstance;
        }
    }
}
