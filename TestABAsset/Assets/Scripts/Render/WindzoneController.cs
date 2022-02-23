using UnityEngine;
using UnityEngine.Events;
public class WindzoneController : MonoBehaviour
{
    private WindZone m_WindZone;//风
    public UnityAction EnableWind;//开启风事件
    public UnityAction DisableWind;//关闭风事件
    void Awake()
    {
        m_WindZone = GetComponent<WindZone>();
    }
    void OnEnable()
    {
        if (EnableWind != null)
        {
            EnableWind();
        }
    }

    void OnDisable()
    {
        if (DisableWind != null)
        {
            DisableWind();
        }
    }
    //获取风
    public WindZone GetWind()
    {
        return m_WindZone;
    }
}
