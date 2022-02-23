using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class DrawInstanceController : MonoBehaviour
{
    public ShadowCastingMode m_ShadowMode = ShadowCastingMode.On;//是否投射阴影
    public bool m_ReceiveShadow = true;//是否接收阴影
    public string m_LayerName = "Default";//层级名
    public bool m_IsRenderDynamicObj = false;//是否是渲染动态物体
    //GPU instancing材质
    public Material[] materials;
    //GPU instancing网格
    public Mesh mesh;
    //是否使用cammandBuffer渲染
    private bool useCommandBuffer = false;
    private Matrix4x4[] m_atrix4x4s;    //渲染矩阵数据
    private List<DrawInstanceItem> m_Items = new List<DrawInstanceItem>();//渲染单体集合
    private bool m_RenderModify = false;//渲染是否修改
    protected MaterialPropertyBlock block;//渲染实例化数据
    private int layer = 0;
    private Camera m_Camera;//渲染摄像机
    void Awake()
    {
        m_Camera = Camera.main;
        this.layer = LayerMask.NameToLayer(m_LayerName);
        m_atrix4x4s = new Matrix4x4[0];
        Init();
        // CombineSubMesh();
    }

    protected virtual void Init()
    {
        block = new MaterialPropertyBlock();
    }

    void Start()
    {
        if (m_Camera == null)
        {
            m_Camera = Camera.main;
        }
    }

    //渲染初始化
    public void RenderInit(Mesh mesh, Material[] mats)
    {
        this.mesh = mesh;
        this.materials = mats;
    }

    // void Start()
    // {
    //     var items = GetComponentsInChildren<DrawInstanceItem>();
    //     if (items.Length == 0)
    //     {
    //         return;
    //     }
    //     m_matrixs = new List<Matrix4x4>();
    //     var mesh = items[0].GetMesh();
    //     var mat = items[0].GetMaterial();
    //     for (var i = 0; i < items.Length; i++)
    //     {
    //         var item = items[i];
    //         // m_matrixs.Add(item.transform.localToWorldMatrix);
    //         if (item.GetMesh() != mesh)
    //         {
    //             DebugUtil.DebugError("网格不同" + item.name);
    //             return;
    //         }
    //         if (mat != item.GetMaterial())
    //         {
    //             DebugUtil.DebugError("材质不同" + item.name);
    //             return;
    //         }
    //         item.LeaveCamera += InstanceItemLeave;
    //         item.EnterCamera += InstanceItemEnter;
    //     }
    //     this.layer = LayerMask.NameToLayer(m_LayerName);
    //     if (m_Camera == null) m_Camera = Camera.main;
    //     this.mesh = mesh;
    //     this.material = mat;
    //     block = new MaterialPropertyBlock();
    //     useCommandBuffer = true;
    //     m_atrix4x4s = m_matrixs.ToArray();
    //     // CommandBufferForDrawMeshInstanced();
    // }



    public void InstanceItemEnter(DrawInstanceItem item)
    {
        // if (item.GetMesh().GetInstanceID() != mesh.GetInstanceID())
        // {
        //     DebugUtil.DebugError(string.Format("网格InstanceId不同当前{0}和记录{1}", item.GetMesh().GetInstanceID(), mesh.GetInstanceID()));
        //     return;
        // }
        // if (material.GetInstanceID() != item.GetMaterial().GetInstanceID())
        // {
        //     DebugUtil.DebugError(string.Format("材质InstanceId不同当前{0}和记录{1}", item.GetMaterial().GetInstanceID(), material.GetInstanceID()));
        //     return;
        // }
        if (!m_Items.Contains(item))
        {
            m_Items.Add(item);
            m_RenderModify = true;
        }
    }

    public void InstanceItemLeave(DrawInstanceItem item)
    {
        if (m_Items.Contains(item))
        {
            m_Items.Remove(item);
            m_RenderModify = true;
        }
    }

    // private void OnGUI()
    // {
    //     if (GUILayout.Button("<size=50>当位置发生变化时候在更新</size>"))
    //     {

    //         CommandBufferForDrawMeshInstanced();
    //     }
    // }

    void LateUpdate()
    {
        if (m_IsRenderDynamicObj && m_RenderModify == false)
        {
            //如果是渲染动态物体并且渲染数据没修改
            for (int i = 0; i < m_atrix4x4s.Length; i++)
            {
                m_atrix4x4s[i] = m_Items[i].transform.localToWorldMatrix;
            }
        }
        if (m_RenderModify == true)
        {
            //如果是渲染数据修改了 重新生成矩阵列表
            m_atrix4x4s = new Matrix4x4[m_Items.Count];
            for (int i = 0; i < m_atrix4x4s.Length; i++)
            {
                m_atrix4x4s[i] = m_Items[i].transform.localToWorldMatrix;
            }
            m_RenderModify = false;
        }
        if (m_atrix4x4s.Length > 0)
        {
            if (mesh.subMeshCount > 1)
            {
                for (int i = 0; i < mesh.subMeshCount; i++)
                {
                    Graphics.DrawMeshInstanced(mesh, i, materials[i], m_atrix4x4s, m_atrix4x4s.Length, block, m_ShadowMode, m_ReceiveShadow, layer, this.m_Camera);
                }
            }
            else
            {
                Graphics.DrawMeshInstanced(mesh, 0, materials[0], m_atrix4x4s, m_atrix4x4s.Length, block, m_ShadowMode, m_ReceiveShadow, layer, this.m_Camera);
            }
        }
    }

    // void SetPos()
    // {
    //     for (int i = 0; i < m_atrix4x4s.Length; i++)
    //     {
    //         target.position = Random.onUnitSphere * 10f;
    //         m_atrix4x4s[i] = target.localToWorldMatrix;
    //     }

    // }


    void GraphicsForDrawMeshInstanced()
    {
        if (!useCommandBuffer)
        {
            // SetPos();
            Graphics.DrawMeshInstanced(mesh, 0, materials[0], m_atrix4x4s, m_atrix4x4s.Length);
        }
    }

    void CommandBufferForDrawMeshInstanced()
    {
        if (useCommandBuffer)
        {

            // SetPos();
            var m_buff = new CommandBuffer();
            // if (m_buff != null)
            // {
            //     m_Camera.RemoveCommandBuffer(CameraEvent.AfterForwardOpaque, m_buff);
            //     CommandBufferPool.Release(m_buff);
            // }

            // m_buff = CommandBufferPool.Get("DrawMeshInstanced");

            for (int i = 0; i < 1; i++)
            {
                m_buff.DrawMeshInstanced(mesh, 0, materials[i], 0, m_atrix4x4s, m_atrix4x4s.Length);
            }
            m_Camera.AddCommandBuffer(CameraEvent.AfterForwardOpaque, m_buff);
        }
    }

    CommandBuffer m_buff = null;
}
