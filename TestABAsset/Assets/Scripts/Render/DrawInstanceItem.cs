using UnityEngine;
using UnityEngine.Events;
using System.Collections;
//实例化渲染单项
public class DrawInstanceItem : MonoBehaviour
{
    private Mesh mesh;
    private Material[] materials;
    public UnityAction<DrawInstanceItem> LeaveCamera;//离开摄像机视野
    public UnityAction<DrawInstanceItem> EnterCamera;//进入摄像机视野
    bool isInCamera = false;//在摄像机视野中
    public DrawInstanceController m_DrawInstanceController;//实例化绘制控制器
    private Renderer renderer;
    public int m_RenderBoundExpand = 10;//渲染扩展
    public Camera m_Camera;//摄像机
    private CameraItemController mCameraCtl;//摄像机控制器接口
    private Coroutine mUpdateCoroutine;//更新协程
    void Awake()
    {
        var render = GetComponent<Renderer>();
        if (render == null)
        {
            DebugUtil.DebugError(gameObject.name + "has no render");
            return;
        }
        if (render is SkinnedMeshRenderer)
        {
            DebugUtil.DebugInfo(gameObject.name + "is skinnedMeshRenderer");
            return;
        }
        renderer = render;
        var filter = GetComponent<MeshFilter>();
        if (filter == null)
        {
            DebugUtil.DebugError(gameObject.name + "has no filter");
            return;
        }
        mesh = filter.sharedMesh;
        materials = render.sharedMaterials;
        // var id = material.GetInstanceID();
        // DebugUtil.DebugInfo("Awake Mat Id" + id.ToString());
        if (m_DrawInstanceController != null)
        {
            InitByDrawInstanceController(m_DrawInstanceController);
        }
        mUpdateCoroutine = StartCoroutine(UpdateCoroutine());
    }

    void Start()
    {
        if (m_Camera == null)
        {
            m_Camera = Camera.main;
        }
        mCameraCtl = m_Camera.GetComponent<CameraItemController>();
    }

    void OnDestroy()
    {
        if (mUpdateCoroutine != null)
        {
            StopCoroutine(mUpdateCoroutine);
            mUpdateCoroutine = null;
        }
    }

    //是否可以实例化绘制
    public bool CanDrawInstance()
    {
        return GetMesh() != null && GetMaterial() != null;
    }

    //根据控制器初始化
    public void InitByDrawInstanceController(DrawInstanceController controller)
    {
        EnterCamera += controller.InstanceItemEnter;
        LeaveCamera += controller.InstanceItemLeave;
        //修改层级摄像机不再渲染
        gameObject.layer = LayerMask.NameToLayer("NoRender");
    }

    void OnDisable()
    {
        if (isInCamera)
        {
            isInCamera = false;
            if (LeaveCamera != null)
            {
                LeaveCamera(this);
            }
        }
        if (mUpdateCoroutine != null)
        {
            StopCoroutine(mUpdateCoroutine);
            mUpdateCoroutine = null;
        }
    }

    void OnEnable()
    {
        if (mUpdateCoroutine == null)
        {
            mUpdateCoroutine = StartCoroutine(UpdateCoroutine());
        }
    }


    IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            yield return null;
            Plane[] planes = mCameraCtl.GetCameraPlanes();
            var bounds = renderer.bounds;
            if (m_RenderBoundExpand > 0)
            {
                bounds.Expand(m_RenderBoundExpand);
            }
            if (GeometryUtility.TestPlanesAABB(planes, bounds))
            {
                if (!isInCamera)
                {
                    isInCamera = true;
                    if (EnterCamera != null)
                    {
                        EnterCamera(this);
                    }
                }
            }
            else
            {
                if (isInCamera)
                {
                    isInCamera = false;
                    if (LeaveCamera != null)
                    {
                        LeaveCamera(this);
                    }
                }
            }
        }
    }

    // void Update()
    // {
    // }
    //获取网格
    public Mesh GetMesh()
    {
        return mesh;
    }
    //获取材质
    public Material[] GetMaterial()
    {
        return materials;
    }
}
