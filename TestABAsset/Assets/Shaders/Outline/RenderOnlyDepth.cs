using UnityEngine;
using UnityEngine.Rendering;
public class RenderOnlyDepth : PostEffectsBase
{
    public Shader shader;
    private Material mMaterial = null;
    public Material Material
    {
        get
        {
            mMaterial = CheckShaderAndCreateMaterial(shader, mMaterial);
            return mMaterial;
        }
    }

    // public Shader _clearShader;
    // private Material _clearMat;
    // public Material ClearMat
    // {
    //     get
    //     {
    //         _clearMat = CheckShaderAndCreateMaterial(_clearShader, _clearMat);
    //         return _clearMat;
    //     }
    // }
    public Shader briSatConShader;
    private Material briSatConMaterial;
    public Material bscmaterial
    {
        get
        {
            briSatConMaterial = CheckShaderAndCreateMaterial(briSatConShader, briSatConMaterial);
            return briSatConMaterial;
        }
    }


    [SerializeField]
    string targetTexture = "_CustomDepthTexture";
    [SerializeField]
    string imageTargetTexture = "_CustomWholeTexture";
    private RenderTexture _depthTexture;
    private Camera mCamera;
    private RenderTexture depthRT;
    private RenderTexture depthTex;
    private RenderTexture colorTex;
    private RenderTexture cleanTex;
    private RenderTexture cleanDepthTex;
    private CommandBuffer _cbDepth = null;
    private CommandBuffer _clearCommand = null;
    private RenderTexture _imageTexture = null;
    [Range(0.0f, 3.0f)]
    public float brightness = 1.0f;

    [Range(0.0f, 3.0f)]
    public float saturation = 1.0f;

    [Range(0.0f, 3.0f)]
    public float contrast = 1.0f;
    public Color _setColor = Color.blue;
    public float _sensitivity = 0;
    protected override bool CheckSupport()
    {
        // Shader shader = Shader.Find(shader.name);
        if (!shader || !shader.isSupported)
        {
            return false;
        }
        return true;
        // if (!SystemInfo.supportsImageEffects)
        // {
        //    LogSystem.DebugLog("supportsImageEffects false, shaderName:", shaderName);
        //    isSupport = false;
        //    enabled = false;
        //    return;
        // }

        // if (!SystemInfo.supportsRenderTextures)
        // {
        //    LogSystem.DebugLog("supportsRenderTextures false, shaderName:", shaderName);
        //    isSupport = false;
        //    enabled = false;
        //    return;
        // }

        // if (mode == DepthTextureMode.Depth || mode == DepthTextureMode.DepthNormals)
        // {
        //    if (!SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
        //    {
        //       LogSystem.DebugLog("SupportsRenderTextureFormat(RenderTextureFormat.Depth) false, shaderName:", shaderName);
        //       isSupport = false;
        //       enabled = false;
        //       return;
        //    }
        // }

        // m_Material = new Material(shader);
        // isSupport = true;
        // enabled = true;
    }
    // private Camera _camera;
    void OnEnable()
    {

        // _camera = GetComponent<Camera>();
        // _depthTexture = RenderTexture.GetTemporary(Screen.width,Screen.height,24,RenderTextureFormat.Depth);
        // _camera.targetTexture = _depthTexture;

    }

    // void Awake()
    // {
    //    mCamera = GetComponent<Camera>();
    //    depthRT = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24, RenderTextureFormat.RGB111110Float);
    //    colorTex = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24, RenderTextureFormat.RGB111110Float);
    //    cleanTex = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24, RenderTextureFormat.RGB111110Float);
    //    mCamera.SetTargetBuffers(colorTex.colorBuffer, depthRT.depthBuffer);
    //    // _clearCommand = new CommandBuffer();
    //    // _clearCommand.SetRenderTarget(colorTex);
    //    // _clearCommand.ClearRenderTarget(true, true, Color.black);
    // }

    // void Update()
    // {
    //    // Graphics.Blit(cleanTex, colorTex);
    //    // Graphics.Blit(cleanTex, depthRT);
    //    mCamera.SetTargetBuffers(colorTex.colorBuffer, depthRT.depthBuffer);
    // }

    // private void OnPostRender()
    // {
    //    //目前的机制不需要这次拷贝
    //    Graphics.Blit(colorTex, cleanTex);
    // }

    // void OnRenderImage(RenderTexture src, RenderTexture dest)
    // {
    //    Graphics.Blit(colorTex, dest);
    //    // Graphics.CopyTexture(cleanTex, colorTex);
    // }
    // void Awake()
    // {
    // mCamera = GetComponent<Camera>();

    //    depthRT = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24, RenderTextureFormat.Depth);
    //    depthRT.name = "MainDepthBuffer";

    //    int Width = mCamera.pixelWidth;
    //    int Height = mCamera.pixelHeight;
    //    depthTex = new RenderTexture(Width, Height, 24, RenderTextureFormat.R16);
    //    depthTex.name = "SceneDepthTex";
    //    colorTex = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 0, RenderTextureFormat.RGB111110Float);
    //    colorTex.name = "MainColorBuffer";
    //    _clearCommand = new CommandBuffer();
    //    _clearCommand.name = "ClearCommand";
    //    // _clearCommand.SetRenderTarget(depthTex);
    //    // _clearCommand.ClearRenderTarget(true, true, Color.black);
    //    // _clearCommand.SetRenderTarget(depthRT);
    //    // _clearCommand.ClearRenderTarget(true, true, Color.black);
    //    // _clearCommand.SetRenderTarget(colorTex.colorBuffer, depthRT.depthBuffer);
    //    _cbDepth = new CommandBuffer();
    //    _cbDepth.name = "CommandBuffer_DepthBuffer";
    //    // _cbDepth.ClearRenderTarget(true, true, Color.black);
    //    // _cbDepth.Blit(null, depthTex);
    //    _cbDepth.Blit(depthRT.depthBuffer, depthTex.colorBuffer);
    //    // mCamera.AddCommandBuffer(CameraEvent.BeforeImageEffects, _cbDepth);

    //    // mCamera.AddCommandBuffer(CameraEvent.BeforeForwardOpaque, _clearCommand);
    // mCamera.SetTargetBuffers(colorTex.colorBuffer, depthRT.depthBuffer);
    //    // Shader.SetGlobalTexture(targetTexture, depthTex);
    // }

    protected override void OnStart()
    {
        base.OnStart();
        GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        _depthTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.RFloat);
        _imageTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.RGB111110Float);
        cleanDepthTex = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.RFloat);
        cleanTex = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.RGB111110Float);
        Shader.SetGlobalTexture(targetTexture, _depthTexture);
        Shader.SetGlobalTexture(imageTargetTexture, _imageTexture);
    }

    void OnDestroy()
    {
        Shader.SetGlobalTexture(targetTexture, null);
        Shader.SetGlobalTexture(imageTargetTexture, null);
        _depthTexture.Release();
        _imageTexture.Release();
        cleanDepthTex.Release();
        cleanTex.Release();
        // Graphics.Blit
        // depthRT.Release();
        // depthTex.Release();
        // mCamera.RemoveAllCommandBuffers();
    }
    // void OnRenderImage(RenderTexture src, RenderTexture dest)
    // {
    //    Graphics.Blit(colorTex, dest);
    // }
    // private void Update()
    // {
    //    Shader.SetGlobalTexture(targetTexture, depthTex);
    // }
    // void Update()
    // {
    //    Graphics.Blit(colorTex, colorTex, ClearMat);
    //    // depthTex.DiscardContents(true, true);
    //    // depthRT.DiscardContents(true, true);
    //    // colorTex.DiscardContents(true, true);
    // }


    // void Update()
    // {
    //    Shader.SetGlobalTexture(targetTexture, depthTex);

    // }
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (Material != null)
        {
            // Debug.Log("RenderImage shader is loaded");
            // _camera.RenderWithShader(shader,string.Empty);
            // var depthTexture = RenderTexture.GetTemporary(src.width,src.height,0);
            Graphics.CopyTexture(cleanDepthTex, _depthTexture);
            Graphics.Blit(null, _depthTexture, Material);
            // Shader.SetGlobalTexture(targetTexture, _depthTexture);
            Graphics.CopyTexture(cleanTex, _imageTexture);
            // bscmaterial.SetFloat("_Brightness", brightness);
            // bscmaterial.SetFloat("_Saturation", saturation);
            // bscmaterial.SetFloat("_Contrast", contrast);
            // bscmaterial.SetFloat("_AddSensitivity", _sensitivity);
            // bscmaterial.SetColor("_AddColor", _setColor);
            // Graphics.Blit(src, _imageTexture, bscmaterial);

            Graphics.Blit(src, _imageTexture);

            // Graphics.Blit(_depthTexture, dest);

            // var edgeRT = new RenderTexture(src.width,src.height,24);
            // if(material!=null){
            //     material.SetFloat("_EdgeOnly",edgeOnly);
            //     material.SetColor("_EdgeColor",edgeColor);
            //     material.SetColor("_BackgroundColor",backgroundColor);
            //     material.SetFloat("_SampleDistance",sampleDistance);
            //     material.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
            //     material.SetTexture("_EdgeTex",edgeRT);
            //     Graphics.Blit(src,dest,material);
            //     edgeRT.Release();
            // }

            // var onlyEdgeMaterial = OnlyEdgeMaterial;
            // material.SetFloat("_EdgeOnly",edgeOnly);
            // material.SetColor("_EdgeColor",edgeColor);
            // material.SetColor("_BackgroundColor",backgroundColor);
            // material.SetFloat("_SampleDistance",sampleDistance);
            // material.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
            // var rt = new RenderTexture(src.width,src.height,24,RenderTextureFormat.ARGB32);
            // Graphics.Blit(src,rt,Material);
            // Shader.SetGlobalTexture(targetTexture, rt);
            // Graphics.Blit(src,dest,Material);
        }
        else
        {
            Debug.Log("RenderImage shader is not loaded");
        }
    }

}