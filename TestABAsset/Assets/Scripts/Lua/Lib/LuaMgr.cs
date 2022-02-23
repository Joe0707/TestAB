using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;

//Lua的全局环境
//应该在第一个场景里被挂载并且不被销毁
public class LuaMgr : MonoBehaviour
{
    static LuaMgr mInstance = null;
    static LuaEnv mLuaEnv = new LuaEnv(); //Lua虚拟机（全局环境）
    public static LuaEnv Env { get { return mLuaEnv; } }
    public TextAsset[] m_GlobalLuaFiles; //全局加载的Lua文件
    float mLastGCTime = 0;
    const float GCInterval = 1;//1 second 
    LuaTable mOthersTable = null; //所有模块Table的一个总表 
    void Awake()
    {
        mInstance = this;
        mOthersTable = mLuaEnv.NewTable();
        mLuaEnv.Global.Set<string, LuaTable>("others", mOthersTable);
        LoadGlobalLuaFiles();
    }
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    void OnDestroy()
    {
        if (mOthersTable != null)
            mOthersTable.Dispose();
        mLuaEnv.Global.Set<string, LuaTable>("others", null);
    }
    void Update()
    {
        //垃圾回收
        if (Time.time - mLastGCTime > GCInterval)
        {
            mLuaEnv.Tick();
            mLastGCTime = Time.time;
        }
    }

    //加载全局lua文件
    public static void LoadGlobalLuaFiles()
    {
        if (mInstance == null)
            return;
        foreach (var txtAsset in mInstance.m_GlobalLuaFiles)
        {
            var name = txtAsset.name;
            //读Lua文件
            string luaFileContent = LuaFileLoader.LoadLuaFile(name + ".txt");
            //如果是Editor，强制使用界面绑定的Lua文件
            if (luaFileContent == "" || Application.isEditor)
            {//从界面绑定的Lua脚本上执行
                luaFileContent = txtAsset.text;
            }
            if (luaFileContent == "")
                Debug.LogError("Empty lua content for file" + name);
            Env.DoString(luaFileContent);
        }
    }
    //添加全局新表
    public static bool AddGlobalNewTable(LuaTable table, string chunk, string className)
    {
        var result = true;
        LuaTable exsitTable = null;
        LuaMgr.Env.Global.Get<string, LuaTable>(className, out exsitTable);
        if (exsitTable != null)
        {
            DebugUtil.DebugError(string.Format("class {0} is existed", className));
            result = false;
        }
        LuaMgr.Env.DoString(chunk, className, table);
        LuaMgr.Env.Global.Set<string, LuaTable>(className, table);
        return result;
    }

    //移除全局新表
    public static void RemoveGlobalTable(string className)
    {
        LuaTable exsitTable = null;
        LuaMgr.Env.Global.Get<string, LuaTable>(className, out exsitTable);
        if (exsitTable != null)
        {
            exsitTable.Dispose(true);
            LuaMgr.Env.Global.Set<string, LuaTable>(className, null);
        }
    }
}



public static class LuaGenConfig
{
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp
    {
        get
        {
            return new List<Type>()
            {
                typeof(System.Object),
                typeof(UnityEngine.Object),
                typeof(Vector2),
                typeof(Vector3),
                typeof(Vector4),
                typeof(Quaternion),
                typeof(Color),
                typeof(Ray),
                typeof(Bounds),
                typeof(Ray2D),
                typeof(Time),
                typeof(GameObject),
                typeof(Component),
                typeof(Behaviour),
                typeof(Transform),
                typeof(Resources),
                typeof(TextAsset),
                typeof(Keyframe),
                typeof(AnimationCurve),
                typeof(AnimationClip),
                typeof(MonoBehaviour),
                typeof(ParticleSystem),
                typeof(SkinnedMeshRenderer),
                typeof(Renderer),
                typeof(WWW),
                typeof(Light),
                typeof(Mathf),
                typeof(System.Collections.Generic.List<int>),
                typeof(Action<string>),
                typeof(UnityEngine.Debug),
                typeof(WaitForSeconds),
            };
        }
    }
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
                typeof(Action),
                typeof(Func<double, double, double>),
                typeof(Action<string>),
                typeof(Action<double>),
                typeof(UnityEngine.Events.UnityAction),
                typeof(UnityEngine.Events.UnityAction<int>),
                typeof(System.Collections.IEnumerator),
                typeof(UnityEngine.Events.UnityAction<UnityEngine.Vector2>),
                 typeof(Func<bool>)
            };
    //黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
                new List<string>(){"System.Xml.XmlNodeList", "ItemOf"},
                new List<string>(){"UnityEngine.WWW", "movie"},
    #if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
    #endif
                new List<string>(){"UnityEngine.Texture2D", "alphaIsTransparency"},
                new List<string>(){"UnityEngine.Security", "GetChainOfTrustValue"},
                new List<string>(){"UnityEngine.CanvasRenderer", "onRequestRebuild"},
                new List<string>(){"UnityEngine.Light", "areaSize"},
                new List<string>(){"UnityEngine.Light", "lightmapBakeType"},
                new List<string>(){"UnityEngine.WWW", "MovieTexture"},
                new List<string>(){"UnityEngine.WWW", "GetMovieTexture"},
                new List<string>(){"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
    #if !UNITY_WEBPLAYER
                new List<string>(){"UnityEngine.Application", "ExternalEval"},
    #endif
                new List<string>(){"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
                new List<string>(){"UnityEngine.Component", "networkView"},  //4.6.2 not support
                new List<string>(){"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
                new List<string>(){"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "CreateSubdirectory", "System.String", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
                new List<string>(){"UnityEngine.MonoBehaviour", "runInEditMode"},
            };
}
