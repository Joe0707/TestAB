using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HotfixFrame.VersionContrller;
using UnityEngine.SceneManagement;
using HotfixFrame.Core.Tools;
public class Test : MonoBehaviour
{
    string serverUrl = "http://127.0.0.1";
    string downLoadPath = "";
    void Awake()
    {
        Debug.LogError("1231232");
        downLoadPath = Application.persistentDataPath + HFApplication.GetPlatformPath(Application.platform);
    }
    // Start is called before the first frame update
    void Start()
    {
        VersionContorller.Start(UpdateMode.Repair, serverUrl, downLoadPath, (i, j) =>
        {
            print(i + "" + j);
            if (i == j)
            {
                ResourcesManager.Instance.m_LoadFormAssetBundle = true;
                ResourcesManager.Instance.Init(IEnumeratorTool.Instance);
                ResourcesManager.Instance.assetBundleLoader = new AssetBundleManager();
                if (ResourcesManager.Instance.m_LoadFormAssetBundle)
                {
                    ResourcesManager.Instance.InitAssetBundle();
                }
                Debug.Log("LoadABScene");
                ResourcesManager.Instance.LoadABScene("ProcessScene");
                Debug.Log("LoadABSceneFinish");
                SceneManager.LoadScene("ProcessScene");
            }
        }, (error) =>
        {

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
