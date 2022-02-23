using UnityEngine;
public class ShaderManager : Singleton<ShaderManager>
{
    public const string mShadervariantsPath = "Shaders/AllShaderVariants";

    public void WarmUp()
    {
        var shaderCollection = ResourcesManager.Instance.LoadResource<ShaderVariantCollection>(mShadervariantsPath, false);
        shaderCollection.WarmUp();
    }
}