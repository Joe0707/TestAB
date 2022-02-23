using UnityEngine;

public class RenderOnlyImage : PostEffectsBase
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

   public Shader _clearShader;
   private Material _clearMat;
   public Material ClearMat
   {
      get
      {
         _clearMat = CheckShaderAndCreateMaterial(_clearShader, _clearMat);
         return _clearMat;
      }
   }

   [SerializeField]
   string targetTexture = "_CustomWholeTexture";
   private RenderTexture _imageTexture;
   // private Camera _camera;
   void OnEnable()
   {

      // _camera = GetComponent<Camera>();
      // _depthTexture = RenderTexture.GetTemporary(Screen.width,Screen.height,24,RenderTextureFormat.Depth);
      // _camera.targetTexture = _depthTexture;

   }

   protected override void OnStart()
   {
      base.OnStart();
      GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
      _imageTexture = new RenderTexture(Screen.width, Screen.height, 0);
   }

   void OnDestroy()
   {
      Shader.SetGlobalTexture(targetTexture, null);
      _imageTexture.Release();
   }


   [ImageEffectOpaque]
   void OnRenderImage(RenderTexture src, RenderTexture dest)
   {
      // _camera.RenderWithShader(shader,string.Empty);
      // var depthTexture = RenderTexture.GetTemporary(src.width,src.height,0);
      Graphics.Blit(_imageTexture, _imageTexture, ClearMat);
      Graphics.Blit(src, _imageTexture);
      Shader.SetGlobalTexture(targetTexture, _imageTexture);
      Graphics.Blit(src, dest);
      // Graphics.Blit(src, dest);
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

}