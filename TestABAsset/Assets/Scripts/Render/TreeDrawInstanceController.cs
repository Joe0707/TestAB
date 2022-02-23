using UnityEngine;
//树绘制控制器
public class TreeDrawInstanceController : DrawInstanceController
{
    public WindzoneController m_windZone;
    protected override void Init()
    {
        m_windZone.EnableWind += OnWindzonEnable;
        m_windZone.DisableWind += OnWindzoneDisable;
        block = new MaterialPropertyBlock();
        if (m_windZone.gameObject.activeInHierarchy == true)
        {
            var windZone = m_windZone.GetWind();
            if (windZone != null)
            {
                var forward = windZone.transform.forward;
                var wind = new Vector4(forward.x, forward.y, forward.z, windZone.windMain);
                block.SetVector("_Wind", wind);
            }
        }
        var childCount = transform.childCount;
        for (var i = 0; i < childCount; i++)
        {
            var childObj = transform.GetChild(i).gameObject;
            if (childObj.GetComponent<DrawInstanceItem>() == null)
            {
                var item = childObj.AddComponent<DrawInstanceItem>();
                item.m_DrawInstanceController = this;
                item.InitByDrawInstanceController(this);
            }
        }
    }

    void OnWindzonEnable()
    {
        var windZone = m_windZone.GetWind();
        var forward = windZone.transform.forward;
        var wind = new Vector4(forward.x, forward.y, forward.z, windZone.windMain);
        block.SetVector("_Wind", wind);
    }

    void OnWindzoneDisable()
    {
        block.SetVector("_Wind", Vector4.zero);
    }

    void OnDestroy()
    {
        m_windZone.EnableWind -= OnWindzonEnable;
        m_windZone.DisableWind -= OnWindzoneDisable;
    }

}