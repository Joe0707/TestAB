using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItem : MonoBehaviour
{
    // Start is called before the first frame update
    public uint m_ButtonID = 0;
    public GameObject m_Object = null;
    void Awake()
    {
        if (m_ButtonID != 0 && m_Object != null)
        {
            ButtonMgr.ButtonConfig config = new ButtonMgr.ButtonConfig();
            config.m_ID = m_ButtonID;
            config.m_Obj = m_Object;
            ButtonMgr.Instance.Buttons.Add(config);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
