//场景资源管理器
public class SceneAssetsManager : Singleton<SceneAssetsManager>
{
    //清空场景资源
    public void CleanSceneAssets()
    {
        ObjectManager.Instance.ClearSceneCache();
        ResourcesManager.Instance.CleanSceneCache();
        System.GC.Collect();
    }
}