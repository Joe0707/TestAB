using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartMgr : MonoBehaviour
{
    public Text companyName;
    public Text hint;
    void Start()
    {
        GameLoadMgr.Instance.Init();
        var loadconfig = GameLoadMgr.Instance.mResourceLoadConfig;
        ResourcesManager.Instance.m_LoadFormAssetBundle = loadconfig.mNeedAssetsHotFix;
        ResourcesManager.Instance.Init(IEnumeratorTool.Instance);
        ResourcesManager.Instance.assetBundleLoader = new AssetBundleManager();
        if (ResourcesManager.Instance.m_LoadFormAssetBundle)
        {
            ResourcesManager.Instance.InitAssetBundle();
        }
        LuaFileLoader.Instance.mLoadFromServer = loadconfig.mNeedAssetsHotFix;
        AtlasLoader.Instance.Init();
        StartCoroutine(CloseHint());
    }
    IEnumerator CloseHint()
    {
        yield return new WaitForSeconds(2);
        companyName.gameObject.SetActive(false);
        hint.gameObject.SetActive(false);
        Invoke("GotoLoginScene", 0.1f);
        if (Application.isMobilePlatform)
        {
            Application.targetFrameRate = 90;
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }
    }
    //切换到登陆场景
    void GotoLoginScene()
    {
        SceneLoader.LoadScene("Update", "");
    }
}
