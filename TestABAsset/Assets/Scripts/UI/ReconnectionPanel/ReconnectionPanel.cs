using UnityEngine;
using UnityEngine.UI;
public class ReconnectionPanel : MonoBehaviour
{
    public Button m_Reconnect;//重连按钮
    public GameObject m_Bg;//背景
    public void Show()
    {
        m_Bg.SetActive(true);
    }

    public void Hide()
    {
        m_Bg.SetActive(false);
    }

}
