using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static SceneLoader mInstance = null;
    public Image mBlackMask;
    public Text mLoadingText;
    static string mLoadParam = "";//切换场景时的参数
    const string sceneWorld = "World";
    public static bool isWorld = false;
    const string unloadSceneName = "UnloadScene";
    void Awake()
    {

        //设置屏幕自动旋转， 并设置支持的方向

        Screen.orientation = ScreenOrientation.AutoRotation;

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = false;
        SceneManager.sceneUnloaded += OnSceneUnload;
    }

    void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnload;
    }

    void Start()
    {
        mInstance = this;
        if (mBlackMask != null)
            mBlackMask.gameObject.SetActive(false);
    }

    void OnSceneUnload(Scene scene)
    {
        if (scene.name != "UnloadScene")
        {
            //不是卸载场景进行场景资源清空
            SceneAssetsManager.Instance.CleanSceneAssets();
        }
    }

    //切换场景
    public static void LoadScene(string sceneName, string param = "", bool fromAB = false, System.Action sceneLoadCallBack = null)
    {
        mLoadParam = param;
        if (fromAB)
        {
            mInstance.StartCoroutine(mInstance._LoadABScene(sceneName, sceneLoadCallBack));
        }
        else
        {
            mInstance.StartCoroutine(mInstance._LoadScene(sceneName, sceneLoadCallBack));
        }
        // if (mInstance == null)
        // {
        //     SceneManager.LoadScene(sceneName);
        // }
        // else
        // {
        // }
    }

    // IEnumerator StartLoadSceneCoroutine(string sceneName, string param = "", bool fromAB = false)
    // {
    //     mLoadParam = param;
    //     SceneAssetsManager.Instance.CleanSceneAssets();
    //     yield return new WaitForSeconds(5);
    //     if (fromAB == true && ResourcesManager.Instance.m_LoadFormAssetBundle == true)
    //     {
    //         ResourcesManager.Instance.LoadABScene(sceneName);
    //     }
    //     if (mInstance == null)
    //     {
    //         SceneManager.LoadScene(sceneName);
    //     }
    //     else
    //     {
    //         mInstance.StartCoroutine(mInstance._LoadScene(sceneName));
    //     }
    // }

    // IEnumerator _ReleaseScene(System.Action callback)
    // {
    //     yield return new WaitForSeconds(5);
    //     SceneAssetsManager.Instance.CleanSceneAssets();
    //     if (callback != null)
    //     {
    //         callback();
    //     }
    // }
    //加载AB场景
    IEnumerator _LoadABScene(string sceneName, System.Action sceneLoadCallBack = null)
    {
        if (mBlackMask == null)
            yield break;
        mBlackMask.gameObject.SetActive(true);
        var color = mBlackMask.color;
        color.a = 0;
        mBlackMask.color = color;
        //文字颜色
        var textColor = mLoadingText.color;
        textColor.a = 0;
        mLoadingText.color = textColor;
        while (color.a < 1)
        {
            color.a = Mathf.Min(1f, color.a + Time.deltaTime * 2f);
            mBlackMask.color = color;
            textColor.a = color.a;
            mLoadingText.color = textColor;
            yield return null;
        }
        //转到卸载场景
        var async = SceneManager.LoadSceneAsync(unloadSceneName);
        while (!async.isDone)
        {
            yield return null;
        }
        //再转到ab场景
        if (ResourcesManager.Instance.m_LoadFormAssetBundle == true)
        {
            ResourcesManager.Instance.LoadABScene(sceneName);
        }
        AsyncOperation abasync = SceneManager.LoadSceneAsync(sceneName);
        while (!abasync.isDone)
        {
            yield return null;
        }
        if (sceneLoadCallBack != null)
        {
            sceneLoadCallBack();
        }
        while (color.a > 0)
        {
            color.a = Mathf.Max(0f, color.a - Time.deltaTime * 2f);
            mBlackMask.color = color;
            textColor.a = color.a;
            mLoadingText.color = textColor;
            yield return null;
        }
        mBlackMask.gameObject.SetActive(false);
        if (sceneName == "World")
            isWorld = true;
        else
            isWorld = false;
        Debug.Log("场景加载完成");
    }

    IEnumerator _LoadScene(string sceneName, System.Action sceneLoadCallBack = null)
    {

        // mLoadingText.text = StaticData.StringMgr.Get("Loading");
        if (mBlackMask == null)
            yield break;
        mBlackMask.gameObject.SetActive(true);
        var color = mBlackMask.color;
        color.a = 0;
        mBlackMask.color = color;
        //文字颜色
        var textColor = mLoadingText.color;
        textColor.a = 0;
        mLoadingText.color = textColor;

        while (color.a < 1)
        {
            color.a = Mathf.Min(1f, color.a + Time.deltaTime * 2f);
            mBlackMask.color = color;
            textColor.a = color.a;
            mLoadingText.color = textColor;
            yield return null;
        }
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }
        if (sceneLoadCallBack != null)
        {
            sceneLoadCallBack();
        }
        while (color.a > 0)
        {
            color.a = Mathf.Max(0f, color.a - Time.deltaTime * 2f);
            mBlackMask.color = color;
            textColor.a = color.a;
            mLoadingText.color = textColor;
            yield return null;
        }
        mBlackMask.gameObject.SetActive(false);
        if (sceneName == "World")
            isWorld = true;
        else
            isWorld = false;
        Debug.Log("场景加载完成");
    }
    // IEnumerator _LoadScene(string sceneName)
    // {
    //     mLoadingText.text = StaticData.StringMgr.Get("Loading");
    //     if (mBlackMask == null)
    //         yield break;
    //     mBlackMask.gameObject.SetActive(true);
    //     var color = mBlackMask.color;
    //     color.a = 0;
    //     mBlackMask.color = color;
    //     //文字颜色
    //     var textColor = mLoadingText.color;
    //     textColor.a = 0;
    //     mLoadingText.color = textColor;

    //     while (color.a < 1)
    //     {
    //         color.a = Mathf.Min(1f, color.a + Time.deltaTime * 2f);
    //         mBlackMask.color = color;
    //         textColor.a = color.a;
    //         mLoadingText.color = textColor;
    //         yield return null;
    //     }
    //     SceneManager.LoadScene(sceneName);
    //     while (color.a > 0)
    //     {
    //         color.a = Mathf.Max(0f, color.a - Time.deltaTime * 2f);
    //         mBlackMask.color = color;
    //         textColor.a = color.a;
    //         mLoadingText.color = textColor;
    //         yield return null;
    //     }
    //     mBlackMask.gameObject.SetActive(false);
    // }


    //黑色屏幕淡入淡出
    public static void BlackOutAndIn(System.Action action)
    {
        if (mInstance == null)
        {
            if (action != null)
                action();
        }
        else
            mInstance.StartCoroutine(mInstance._BlackOutAndIn(action));
    }

    IEnumerator _BlackOutAndIn(System.Action action)
    {
        Debug.Log("_BlackOutAndIn");
        if (mBlackMask == null)
        {
            if (action != null)
                action();
            yield break;
        }
        mBlackMask.gameObject.SetActive(true);
        var color = mBlackMask.color;
        color.a = 0;
        mBlackMask.color = color;

        while (color.a < 1)
        {
            color.a = Mathf.Min(1f, color.a + Time.deltaTime * 2f);
            mBlackMask.color = color;
            yield return null;
        }
        if (action != null)
            action();
        while (color.a > 0)
        {
            color.a = Mathf.Max(0f, color.a - Time.deltaTime * 2f);
            mBlackMask.color = color;
            yield return null;
        }
        mBlackMask.gameObject.SetActive(false);
    }

    //获取参数
    public static string GetParam()
    {
        var retValue = mLoadParam;
        mLoadParam = "";
        return retValue;
    }
    //销毁场景
    public static void UnloadScene(string sceneName, System.Action callback)
    {
        mInstance.StartCoroutine(mInstance._UnloadSceneAsync(sceneName, callback));
    }
    //销毁场景协程
    IEnumerator _UnloadSceneAsync(string sceneName, System.Action callback)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (!scene.isLoaded)
        {
            Debug.Log("场景没加载: " + sceneName);
            yield break;
        }
        AsyncOperation async = SceneManager.UnloadSceneAsync(scene);
        // Debug.Log("场景卸载进度: " + async.isDone);
        while (!async.isDone)
        {
            Debug.Log("场景卸载进度: " + async.progress);
            yield return async;
        }
        callback();
    }
    public static bool GetAContainB(string strA, string strB)
    {
        //判断A字符串中是否包含B  不区分大小写
        bool contains = strA.IndexOf(strB, System.StringComparison.OrdinalIgnoreCase) >= 0;
        return contains;
    }
}
