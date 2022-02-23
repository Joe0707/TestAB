using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HotfixFrame.VersionContrller;
using Newtonsoft.Json;
public class UpdateMgr : MonoBehaviour
{
    public Slider m_Progress;
    public Text m_LoadingText;
    public GameObject m_LateUpdateObj;
    private string mAssetBundlePath = "";
    const string HotfixConfigPath = "Load/HotfixConfig";
    void Awake()
    {
        var text = ResourcesManager.Instance.LoadResource<TextAsset>(HotfixConfigPath);
        var config = JsonConvert.DeserializeObject<HotfixConfig>(text.text);
        mAssetBundlePath = config.AssetBundleDownloadUrl;
    }

    void Start()
    {
        Invoke("StartUpadte", 0.1f);
    }

    //开始更新
    void StartUpadte()
    {
        m_LoadingText.text = "apk更新中...";
        m_Progress.value = 0;
        ApkLoader.UpdateFilesFromServer(LoadingProgressCallBackApk);
    }
    //apk进度通知
    void LoadingProgressCallBackApk(float progress)
    {
        m_Progress.value = progress;
        if (progress >= 1)
        {//apk更新完毕,下载Lua
            if (ResourcesManager.Instance.m_LoadFormAssetBundle)
            {
                m_LoadingText.text = "脚本更新中...";
                m_Progress.value = 0;
                LuaFileLoader.UpdateFilesFromServer(LoadingProgressCallBackLua);
            }
            else
            {
                FinishUpdate(false);
            }

            // ApkLoader.UpdateFilesFromServer(LoadingProgressCallBackApk);
        }
        if (progress < 0)
        {//出错了
            if (Application.isEditor)
            {//编辑器的话也进入下一场景
                FinishUpdate(false);
            }
        }
    }

    //Lua进度通知
    void LoadingProgressCallBackLua(float progress)
    {
        m_Progress.value = progress;
        if (progress >= 1f)
        {
            //Lua下载完毕,更新资源
            if (ResourcesManager.Instance.m_LoadFormAssetBundle)
            {
                m_LoadingText.text = "资源更新中...";
                m_Progress.value = 0;
                LoadFromABPackage(() =>
                {
                    LoadHFAsset(() =>
                    {
                        FinishUpdate(true);
                    });
                    // ResourcesManager.Instance.InitAssetBundle();
                    // ShaderManager.Instance.WarmUp();
                    // FinishUpdate();
                });
            }
            else
            {
                FinishUpdate(false);
            }
        }
        if (progress < 0)
        {//出错了
            if (Application.isEditor)
            {//编辑器的话也完成更新
                FinishUpdate(false);
            }
        }
    }
    //从ABPackage加载
    void LoadFromABPackage(System.Action LoadCallback)
    {
        //更新完毕，进行热更加载
        // var url = "http://121.36.54.14:3330";
        // var url = "http://192.168.31.214";

        VersionContorller.Start(UpdateMode.Repair, mAssetBundlePath, ResourcesManager.Instance.assetBundleLoader.ABLoadPath, (i, j) =>
        {
            float process = (float)i / j;
            m_Progress.value = process;
            //下载完毕
            if (process >= 1)
            {
                //BResources.Load(AssetLoadPath.Editor);
                LoadCallback();
            }
        }, (e) =>
        {
            DebugUtil.DebugError(e);
            LoadCallback();
        });
    }
    //数据初始化
    void InitData()
    {
        //加载静态表
        StaticData.StaticDataMgr.Instance.LoadData();
        SkillLoader.Instance.Init();
        SkillRangeDataLoader.Instance.Init();
        JobModel.Instance.Init();
        GameData.GameMgr.Instance.Init();
    }


    //延迟进入下一个场景
    public void DelayGotoNextScene(float seconds)
    {
        StartCoroutine(DelayGotoNextSceneCoroutine(seconds));
    }
    //延迟进入下一个场景的协程
    IEnumerator DelayGotoNextSceneCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneLoader.LoadScene("Login", "");
    }

    //去下一个场景
    void GotoNextScene()
    {
        SceneLoader.LoadScene("Login", "");
    }
    //更新完成
    void FinishUpdate(bool updateFromHF)
    {
        //脚本初始化
        StartCoroutine(UpdateFinishLoadoroutine(() =>
        {
            //数据初始化
            InitData();
            m_LateUpdateObj.SetActive(true);
            DelayGotoNextScene(1);
        }, updateFromHF));
    }
    //更新完成加载逻辑
    IEnumerator UpdateFinishLoadoroutine(System.Action callback, bool updateFromHF)
    {
        m_LoadingText.text = "脚本加载中...";
        m_Progress.value = 0;
        yield return null;
        LuaLoader.Instance.Init(updateFromHF);
        m_Progress.value = 1;
        yield return null;
        if (callback != null)
        {
            callback();
        }
    }

    //热更资源加载
    void LoadHFAsset(System.Action callback)
    {
        StartCoroutine(LoadHFAssetCoroutine(callback));
    }
    //加载热更资源协程
    IEnumerator LoadHFAssetCoroutine(System.Action callback)
    {
        m_LoadingText.text = "资源加载中...";
        m_Progress.value = 0;
        ResourcesManager.Instance.InitAssetBundle();
        m_Progress.value = 0.3f;
        yield return null;
        ShaderManager.Instance.WarmUp();
        m_Progress.value = 1f;
        yield return null;
        if (callback != null)
        {
            callback();
        }
    }

}
