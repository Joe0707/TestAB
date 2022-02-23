using UnityEngine;
using UnityEngine.Rendering;
public class LuminanceProcess : PostEffectsBase
{

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

    public Texture m_RampTexture;//梯度图
    public Texture m_RampTexture2;//梯度图2


    protected override void OnStart()
    {
        LuminanceProcessMat.SetTexture("_Ramp", m_RampTexture);
        LuminanceProcessMat.SetTexture("_Ramp2", m_RampTexture2);
    }


    void OnEnable()
    {

    }

    void OnDestroy()
    {
        LuminanceProcessMat.SetTexture("_Ramp", null);
        LuminanceProcessMat.SetTexture("_Ramp2", null);

    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (LuminanceProcessMat != null)
        {
            Graphics.Blit(src, dest, LuminanceProcessMat);
        }
        else
        {
            Debug.Log("RenderImage shader is not loaded");
        }
    }

}