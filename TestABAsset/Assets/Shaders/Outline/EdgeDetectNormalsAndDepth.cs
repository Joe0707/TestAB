using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EdgeDetectNormalsAndDepth : PostEffectsBase
{
    // public Mesh[] outlineMeshes;
    public GameObject[] outlineObjects;
    public Shader mLuminanceProcessShader;//亮度处理Shader
    private Material mLuminanceProcessMat = null;
    public Material LuminanceProcessMat
    {
        get
        {
            mLuminanceProcessMat = CheckShaderAndCreateMaterial(mLuminanceProcessShader, mLuminanceProcessMat);
            return mLuminanceProcessMat;
        }
    }

    public Shader mOutlineClipShader;
    private Material mOutlineClipMaterial = null;
    public Material OutlineClipMaterial
    {
        get
        {
            mOutlineClipMaterial = CheckShaderAndCreateMaterial(mOutlineClipShader, mOutlineClipMaterial);
            return mOutlineClipMaterial;
        }
    }
    public Shader _gaussionShader;
    private Material _gaussionMaterial = null;
    public Material GaussionMaterial
    {
        get
        {
            _gaussionMaterial = CheckShaderAndCreateMaterial(_gaussionShader, _gaussionMaterial);
            return _gaussionMaterial;
        }
    }

    public Shader notCoverEdgeObjShader;
    private Material notCoverEdgeMat = null;
    public Material NotCoverEdgeMat
    {
        get
        {
            notCoverEdgeMat = CheckShaderAndCreateMaterial(notCoverEdgeObjShader, notCoverEdgeMat);
            return notCoverEdgeMat;
        }
    }

    public Shader _onlyEdgeDetectFromParamShader;
    private Material _onlyEdgeDetectFromParamMat = null;
    public Material OnlyEdgeDetectFromParamMat
    {
        get
        {
            _onlyEdgeDetectFromParamMat = CheckShaderAndCreateMaterial(_onlyEdgeDetectFromParamShader, _onlyEdgeDetectFromParamMat);
            return _onlyEdgeDetectFromParamMat;
        }
    }

    public Shader _notCoverObj;
    private Material _notCoverObjMat;
    public Material NotCoverObjMat
    {
        get
        {
            _notCoverObjMat = CheckShaderAndCreateMaterial(_notCoverObj, _notCoverObjMat);
            return _notCoverObjMat;
        }
    }

    public Shader _alphaBlend;
    private Material _alphaBlendMat = null;
    public Material AlphaBlendMat
    {
        get
        {
            _alphaBlendMat = CheckShaderAndCreateMaterial(_alphaBlend, _alphaBlendMat);
            return _alphaBlendMat;
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

    public Shader _coverObjShader;
    private Material _coverObjMat;
    public Material CoverObjMat
    {
        get
        {
            _coverObjMat = CheckShaderAndCreateMaterial(_coverObjShader, _coverObjMat);
            return _coverObjMat;
        }
    }

    public Shader _mixEdgeAndCover;
    private Material _mixEdgeAndCoverMat;
    public Material MixEdgeAndConveMat
    {
        get
        {
            _mixEdgeAndCoverMat = CheckShaderAndCreateMaterial(_mixEdgeAndCover, _mixEdgeAndCoverMat);
            return _mixEdgeAndCoverMat;
        }
    }

    public Shader _subTexShader;
    private Material _subTexMat;
    public Material SubTexMat
    {
        get
        {
            _subTexMat = CheckShaderAndCreateMaterial(_subTexShader, _subTexMat);
            return _subTexMat;
        }
    }

    public Shader _edgeObj;
    private Material _edgeMat;
    public Material EdgeMat
    {
        get
        {
            _edgeMat = CheckShaderAndCreateMaterial(_edgeObj, _edgeMat);
            return _edgeMat;
        }
    }

    public Shader _normalEdgeShader;
    private Material _normalEdgeMat;
    public Material NormalEdgeMat
    {
        get
        {
            _normalEdgeMat = CheckShaderAndCreateMaterial(_normalEdgeShader, _normalEdgeMat);
            return _normalEdgeMat;
        }
    }

    public Shader _addTexShader;
    private Material _addTexMat;
    public Material AddTexMat
    {
        get
        {
            _addTexMat = CheckShaderAndCreateMaterial(_addTexShader, _addTexMat);
            return _addTexMat;
        }
    }

    public Shader _expandTexShader;
    private Material _expandTexMat;
    public Material ExpandTexMat
    {
        get
        {
            _expandTexMat = CheckShaderAndCreateMaterial(_expandTexShader, _expandTexMat);
            return _expandTexMat;
        }
    }

    public Shader _depthEdgeShader;
    private Material _depthEdgeMat;
    public Material DepthEdgeMat
    {
        get
        {
            _depthEdgeMat = CheckShaderAndCreateMaterial(_depthEdgeShader, _depthEdgeMat);
            return _depthEdgeMat;
        }
    }

    [Range(0.0f, 1.0f)]
    public float edgeOnly = 0.0f;
    public Color edgeColor = Color.black;
    public Color backgroundColor = Color.white;
    public float sampleDistance = 1.0f;
    public float innerSampleDistance = 0.5f;
    public float sensitivityDepth = 1.0f;
    public float sensitivityNormals = 1.0f;
    public float offSet = 0.005f;
    public float blurSize;
    public float saturation = 1.0f;
    public int iterations = 3;
    public Texture m_RampTexture;//梯度图
    public Texture m_RampTexture2;//梯度图2
    private RenderTexture notCoverObj;
    private RenderTexture edgeObj;
    private RenderTexture buffer1;
    private RenderTexture buffer2;
    private RenderTexture buffer3;
    private RenderTexture clear;
    private CommandBuffer commandBuffer1;
    void OnDestroy()
    {
        // var camera = GetComponent<Camera>();
        // if (commandBuffer1 != null)
        // {
        //    camera.RemoveCommandBuffer(CameraEvent.BeforeImageEffects, commandBuffer1);
        // }
        // notCoverObj.Release();
        // edgeObj.Release();
        buffer1.Release();
        buffer2.Release();
        clear.Release();
        // buffer3.Release();
    }

    protected override void OnStart()
    {
        base.OnStart();
        var camera = GetComponent<Camera>();
        camera.depthTextureMode |= DepthTextureMode.DepthNormals;
        // camera.depthTextureMode |= DepthTextureMode.Depth;
        // notCoverObj = new RenderTexture(Screen.width, Screen.height, 0);
        // edgeObj = new RenderTexture(Screen.width, Screen.height, 0);
        buffer1 = new RenderTexture(Screen.width, Screen.height, 0);
        buffer2 = new RenderTexture(Screen.width, Screen.height, 0);
        clear = new RenderTexture(Screen.width, Screen.height, 0);
        // buffer3 = new RenderTexture(Screen.width, Screen.height, 0);
        // var outlineClipMat = OutlineClipMaterial;
        // outlineClipMat.SetFloat("_SampleDistance", sampleDistance);
        // outlineClipMat.SetVector("_Sensitivity", new Vector4(sensitivityNormals, sensitivityDepth, 0.0f, 0.0f));
        // commandBuffer1 = new CommandBuffer();
        // commandBuffer1.name = "TestCommandBuffer";
        // // var matrix = Matrix4x4.TRS(outlineObjects[0].transform.position, outlineObjects[0].transform.rotation, outlineObjects[0].transform.lossyScale);
        // // commandBuffer1.DrawMesh(outlineObjects[0].GetComponent<SkinnedMeshRenderer>().sharedMesh, matrix, outlineClipMat, 0);
        // var meshrender = outlineObjects[0].GetComponent<SkinnedMeshRenderer>();
        // var submeshCount = meshrender.sharedMaterials.Length;
        // for (var i = 0; i < submeshCount; i++)
        // {
        //    commandBuffer1.DrawRenderer(meshrender, outlineClipMat, i);
        // }
        // camera.AddCommandBuffer(CameraEvent.AfterForwardOpaque, commandBuffer1);
    }

    // void OnPostRender()
    // {
    //    // Graphics.Blit(src, dest);
    //    var outlineClipMat = OutlineClipMaterial;
    //    outlineClipMat.SetFloat("_SampleDistance", sampleDistance);
    //    outlineClipMat.SetVector("_Sensitivity", new Vector4(sensitivityNormals, sensitivityDepth, 0.0f, 0.0f));

    //    for (var i = 0; i < outlineObjects.Length; i++)
    //    {
    //       var obj = outlineObjects[i];
    //       var mesh = obj.GetComponent<SkinnedMeshRenderer>().sharedMesh;
    //       // Graphics.DrawMesh(mesh,)
    //       Graphics.DrawMesh(mesh, obj.transform.localPosition, obj.transform.localRotation, outlineClipMat, 0);
    //    }
    // }


    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // var clearMat = ClearMat;
        // Graphics.Blit(notCoverObj, notCoverObj, clearMat);
        // Graphics.Blit(edgeObj, edgeObj, clearMat);
        Graphics.CopyTexture(clear, buffer1);
        Graphics.CopyTexture(clear, buffer2);
        // Graphics.Blit(buffer3, buffer3, clearMat);

        // Graphics.Blit(src, dest);
        // return;
        // return;



        //   Graphics.Blit(null, notCoverObj, NotCoverEdgeMat);
        var onlyEdgeDetectFromParamMat = OnlyEdgeDetectFromParamMat;
        onlyEdgeDetectFromParamMat.SetFloat("_SampleDistance", sampleDistance);
        onlyEdgeDetectFromParamMat.SetVector("_Sensitivity", new Vector4(sensitivityNormals, sensitivityDepth, 0.0f, 0.0f));
        Graphics.Blit(src, buffer1, OnlyEdgeDetectFromParamMat);
        // return;
        // return;
        // return;
        // return;
        // return;
        //   return;
        //   return;
        //   return;
        // var notcoverRT= RenderTexture.GetTemporary(src.width,src.height);
        //   Graphics.Blit(null, notCoverObj, NotCoverObjMat);
        //   Graphics.Blit(notCoverObj, buffer1, ExpandTexMat);
        // return;
        var gaussionMat = GaussionMaterial;
        for (var i = 1; i <= iterations; i++)
        {
            var offset = blurSize * i;
            gaussionMat.SetFloat("_BlurSize", offset);
            Graphics.Blit(buffer1, buffer2, gaussionMat, 0);
            Graphics.CopyTexture(clear, buffer1);
            Graphics.Blit(buffer2, buffer1, gaussionMat, 1);
            Graphics.CopyTexture(clear, buffer2);
        }
        // Graphics.Blit(buffer1, dest);
        //   return;
        //   Graphics.Blit(null, buffer2, EdgeMat);
        //   return;
        //   var subTexMat = SubTexMat;
        //   subTexMat.SetTexture("_SubTex", buffer2);
        //   Graphics.Blit(buffer1, buffer3, SubTexMat);
        //   return;
        // reutrn
        //   subTexMat.SetTexture("_SubTex", null);
        //   Graphics.Blit(buffer2, buffer2, clearMat);
        //   Graphics.Blit(buffer1, buffer1, clearMat);
        // var normalEdgeMat = NormalEdgeMat;
        // normalEdgeMat.SetFloat("_SampleDistance", sampleDistance);
        // normalEdgeMat.SetVector("_Sensitivity", new Vector4(sensitivityNormals, sensitivityDepth, 0.0f, 0.0f));
        // Graphics.Blit(null, buffer1, NormalEdgeMat);
        // for (var i = 1; i <= iterations; i++)
        // {
        //     var offset = blurSize * i;
        //     gaussionMat.SetFloat("_BlurSize", offset);
        //     Graphics.Blit(buffer1, buffer2, gaussionMat, 0);
        //     Graphics.Blit(buffer1, buffer1, clearMat);
        //     Graphics.Blit(buffer2, buffer1, gaussionMat, 1);
        //     Graphics.Blit(buffer2, buffer2, clearMat);
        // }
        // var addTexMat = AddTexMat;
        // addTexMat.SetTexture("_AddTex", buffer3);
        // Graphics.Blit(buffer1, buffer2, addTexMat);
        // addTexMat.SetTexture("_AddTex", null);
        // // return;
        // Graphics.Blit(buffer3, buffer3, clearMat);
        // Graphics.Blit(buffer1, buffer1, clearMat);


        // Graphics.Blit(buffer1,buffer1,clearMat);

        // return;
        // return;
        // return;
        // return;
        // RenderTexture.ReleaseTemporary(depthTexture);
        // var buffer1 = RenderTexture.GetTemporary(src.width,src.height);
        // Graphics.Blit(src,dest);
        // return;
        // var onlyEdgeMat = OnlyEdgeMat;
        // onlyEdgeMat.SetColor("_EdgeColor",edgeColor);
        // onlyEdgeMat.SetFloat("_SampleDistance",sampleDistance);
        // onlyEdgeMat.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
        // // var buffer1 = RenderTexture.GetTemporary(src.width,src.height,0);
        // Graphics.Blit(src,edgeObj,onlyEdgeMat);
        // // return;
        // var mixEdgeAndConveMat = MixEdgeAndConveMat;
        // mixEdgeAndConveMat.SetTexture("_CoverTex",notCoverObj);
        // Graphics.Blit(edgeObj,dest,MixEdgeAndConveMat);
        // // mixEdgeAndConveMat.SetTexture("_CoverTex",null);
        // return;
        // return;
        // RenderTexture.ReleaseTemporary(notcoverRT);
        // var gaussionMat = GaussionMaterial;
        // for(var i =1;i<=iterations;i++)
        // {
        //     var offset = blurSize*i;
        //     gaussionMat.SetFloat("_BlurSize",offset);
        //     Graphics.Blit(buffer1,buffer2,gaussionMat,0);
        //     Graphics.Blit(buffer1,buffer1,clearMat);
        //     Graphics.Blit(buffer2,buffer1,gaussionMat,1);
        //     Graphics.Blit(buffer2,buffer2,clearMat);
        // }
        // RenderTexture buffer2 = RenderTexture.GetTemporary(src.width,src.height,0);

        // RenderTexture.ReleaseTemporary(buffer1);
        // var buffer3 = RenderTexture.GetTemporary(src.width,src.height,0);

        // RenderTexture.ReleaseTemporary(buffer2);
        // RenderTexture.ReleaseTemporary(buffer1);
        // buffer1 = buffer2;
        // buffer2 = RenderTexture.GetTemporary(width,height,0);
        // RenderTexture.ReleaseTemporary(buffer1);
        // buffer1 = buffer2;
        var alphablendMat = AlphaBlendMat;
        alphablendMat.SetTexture("_BlendTex", buffer1);
        var wholeTex = Shader.GetGlobalTexture("_CustomWholeTexture");
        Graphics.Blit(wholeTex, buffer2, alphablendMat);
        alphablendMat.SetTexture("_BlendTex", null);
        var luminanceMat = LuminanceProcessMat;
        luminanceMat.SetFloat("_Saturation", saturation);
        luminanceMat.SetTexture("_Ramp", m_RampTexture);
        luminanceMat.SetTexture("_Ramp2", m_RampTexture2);
        Graphics.Blit(buffer2, dest, luminanceMat);
        luminanceMat.SetTexture("_Ramp", null);
        luminanceMat.SetTexture("_Ramp2", null);

        // alphablendMat.SetTexture("_BlendTex",null);
        // RenderTexture.ReleaseTemporary(buffer3);
        // Graphics.Blit(buffer1,dest);
        // RenderTexture.ReleaseTemporary(buffer1);
        // Graphics.Blit
        // return;
        // if(material!=null){
        // var edgeRT = new RenderTexture(src.width,src.height,24);
        // var onlyEdgeMaterial = OnlyEdgeMaterial;
        // if(onlyEdgeMaterial!=null){
        //     onlyEdgeMaterial.SetFloat("_EdgeOnly",edgeOnly);
        //     onlyEdgeMaterial.SetColor("_EdgeColor",edgeColor);
        //     onlyEdgeMaterial.SetColor("_BackgroundColor",backgroundColor);
        //     onlyEdgeMaterial.SetFloat("_SampleDistance",sampleDistance);
        //     onlyEdgeMaterial.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
        //     Graphics.Blit(src,dest,onlyEdgeMaterial);
        //     // material.SetTexture("_EdgeTex",edgeRT);
        // }
        // RenderTexture buffer1 = RenderTexture.GetTemporary(src.width,src.height,0);
        // material.SetFloat("_EdgeOnly",edgeOnly);
        // material.SetColor("_EdgeColor",edgeColor);
        // material.SetColor("_BackgroundColor",backgroundColor);
        // material.SetFloat("_SampleDistance",sampleDistance);
        // material.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
        // material.SetFloat("_Offset",offSet);
        // Graphics.Blit(src,buffer1,material);


        // RenderTexture buffer2 = RenderTexture.GetTemporary(src.width,src.height,0);
        // var gaussionMat = EdgeGaussionMaterial;
        // gaussionMat.SetFloat("_EdgeOnly",edgeOnly);
        // gaussionMat.SetColor("_EdgeColor",edgeColor);
        // gaussionMat.SetColor("_BackgroundColor",backgroundColor);
        // gaussionMat.SetFloat("_SampleDistance",sampleDistance);
        // gaussionMat.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
        // gaussionMat.SetFloat("_Offset",offSet);
        // gaussionMat.SetFloat("_BlurSize",blurSize);
        // Graphics.Blit(buffer1,buffer2,gaussionMat,0);
        // material.SetFloat
        // Graphics.Blit(buffer2,dest,gaussionMat,1);
        // buffer1.Release();
        // buffer2.Release();

        // var width = src.width;
        // var height = src.height;
        // var gaussionmaterial = EdgeGaussionMaterial;
        // // RenderTexture buffer1 = RenderTexture.GetTemporary(width,height,0);
        // gaussionmaterial.SetFloat("_EdgeOnly",edgeOnly);
        // gaussionmaterial.SetColor("_EdgeColor",edgeColor);
        // gaussionmaterial.SetColor("_BackgroundColor",backgroundColor);
        // gaussionmaterial.SetFloat("_SampleDistance",sampleDistance);
        // gaussionmaterial.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
        // // gaussionmaterial.SetFloat("_Offset",offSet);
        // // gaussionmaterial.SetFloat("_BlurSize",blurSize);
        // // Graphics.Blit(src,buffer1,gaussionmaterial);
        // for(var i =1;i<=iterations;i++)
        // {
        //     var offset = blurSize*i;
        //     gaussionmaterial.SetFloat("_BlurSize",offset);
        //     RenderTexture buffer2 = RenderTexture.GetTemporary(width,height,0);
        //     Graphics.Blit(buffer1,buffer2,gaussionmaterial,0);
        //     RenderTexture.ReleaseTemporary(buffer1);
        //     buffer1 = buffer2;
        //     buffer2 = RenderTexture.GetTemporary(width,height,0);
        //     Graphics.Blit(buffer1,buffer2,gaussionmaterial,1);
        //     RenderTexture.ReleaseTemporary(buffer1);
        //     buffer1 = buffer2;
        // }

        // // RenderTexture buffer3 = RenderTexture.GetTemporary(src.width,src.height,0);
        // // material.SetFloat("_EdgeOnly",edgeOnly);
        // // material.SetColor("_EdgeColor",edgeColor);
        // // material.SetColor("_BackgroundColor",backgroundColor);
        // material.SetFloat("_SampleDistance",innerSampleDistance);
        // // material.SetVector("_Sensitivity",new Vector4(sensitivityNormals,sensitivityDepth,0.0f,0.0f));
        // // material.SetFloat("_Offset",offSet);
        // Graphics.Blit(buffer1,dest,material);


        // // var gaussionMat = EdgeGaussionMaterial;
        // // material.SetFloat
        // // Graphics.Blit(buffer1,dest);
        // RenderTexture.ReleaseTemporary(buffer1);

        // RenderTexture depthrt = Shader.GetGlobalTexture("_CustomDepthTexture") as RenderTexture;
        // edgeRT.Release();
        // RenderTexture.ReleaseTemporary(depthrt);
        // }else{
        //     Graphics.Blit(src,dest);
        // }
    }
}
