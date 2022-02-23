using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System;
using System.Reflection;
//Lua脚本接口
//作为C#脚本、GameObject对象和lua之间的桥梁
//在每个需要挂载脚本的GameObject上，挂上此脚本，并绑定一个Lua文件
public class LuaBehavior : MonoBehaviour
{
    //注入的类型
    public enum InjectionType
    {
        Material,
        AudioClip,
        TextTure,
        GameObject,
        Transform,
        Camera,
        ParticleSystem,
        TextAsset
    }
    //注入的基本类型
    public enum InjectionBaseType
    {
        String,
        Int,
        Float,
        Bool
    }

    //需要注入到Lua脚本中的对象
    [System.Serializable]
    public class Injection
    {
        [Tooltip("要注入到Lua的对象名称")]
        public string m_Name; //注入的名称
        [Tooltip("要注入到Lua的对象, 如果留空，则使用Name查找")]
        public GameObject m_GameObject; //注入的对象
    }
    [System.Serializable]
    public class InjectionObject
    {
        [Tooltip("要注入到Lua的物体名称")]
        public string m_Name;//注入的物体名称
        [Tooltip("要注入到Lua的物体")]
        public UnityEngine.Object m_Object;//注入的物体
        [Tooltip("要注入的物体类型")]
        public InjectionType m_Type;//注入的物体类型
    }
    //注入物体数组
    [System.Serializable]
    public class InjectionObjectArray
    {
        [Tooltip("要注入到Lua的数组名称")]
        public string m_Name;//注入的物体数组名称
        [Tooltip("要注入到Lua的数组")]
        public UnityEngine.Object[] m_Objects;//注入的物体数组
        [Tooltip("要注入的物体数组的类型")]
        public InjectionType m_Type;//注入的物体数组的类型
    }
    [System.Serializable]
    public class InjectionBaseValue
    {
        [Tooltip("要注入到Lua的基础类型数据")]
        public string m_Name;
        [Tooltip("要注入到Lua的数据")]
        public string m_Value;
        [Tooltip("要注入的数据类型")]
        public InjectionBaseType m_Type;
    }

    [Tooltip("需要绑定的Lua脚本")]
    public TextAsset m_LuaScript;
    [Tooltip("强制在Editor里使用网络更新下来的Lua文件（用来测试）")]
    public bool m_ForceUsingServerLuaInEditor = false;

    [Tooltip("需要注入到Lua的对象")]
    public List<Injection> m_Injections;
    [Tooltip("需要注入到lua的组件")]
    public InjectionObject[] m_InjectionObjects;
    [Tooltip("需要注入到Lua的数组组件")]
    public InjectionObjectArray[] m_InjectionObjectArrays;
    [Tooltip("需要注入到Lua的基础数据")]
    public InjectionBaseValue[] m_InjectionBaseObjects;
    [Tooltip("自动初始化Lua文件")]
    public bool m_AutoInit = true;
    [Tooltip("指定模块的注册名称（在其他lua文件中调用名称）")]
    public string m_ModuleName = "";
    [Tooltip("Lua父类的模块名")]
    public string m_LuaBaseName = "";
    //对应Lua脚本中的响应函数
    private Action<LuaTable> mLuaStart;
    [CSharpCallLua]
    private Action mLuaUpdate;
    private Action<LuaTable> mLuaOnDestroy;
    private Action<LuaTable> mLuaOnEnable;
    private Action<LuaTable> mLuaOnDisable;
    protected LuaTable mScriptEnv; //当前脚本的环境
    [Tooltip("不设置当前table到全局others table里")]
    public bool m_NotSetModuleToOthers = true;
    public bool m_Global;//是否是全局唯一
    private string mLuaTableName;//Lua表名
    void Awake()
    {
        //自动初始化
        if (m_AutoInit)
            Init();
    }

    public virtual void Init()
    {
        if (mScriptEnv != null)
            return; //已经初始化过了
        if (m_LuaScript == null)
            return;
        var name = m_LuaScript.name.Substring(0, m_LuaScript.name.IndexOf(".lua"));
        //全局唯一检测
        if (m_Global)
        {
            var moduleName = m_ModuleName;
            if (string.IsNullOrEmpty(moduleName))
                moduleName = name;
            if (LuaMgr.Env.Global.Get<string, LuaTable>("others").ContainsKey(moduleName))
            {
                //有重名的Table
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(this.gameObject);
        }
        if (m_ForceUsingServerLuaInEditor && Application.isEditor)
        {
            Debug.Log("<color=red>" + gameObject.name + " 正在使用网络端Lua脚本测试</color>");
        }
        //初始化lua脚本
        mScriptEnv = LuaMgr.Env.NewTable();
        mScriptEnv.Set("___classname", name);
        mScriptEnv.Set("___class", mScriptEnv);
        if (string.IsNullOrEmpty(m_LuaBaseName))
        {
            // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
            LuaTable meta = LuaMgr.Env.NewTable();
            meta.Set("__index", LuaMgr.Env.Global);
            mScriptEnv.SetMetaTable(meta);
            meta.Dispose();
        }
        else
        {
            var parentscript = LuaMgr.Env.Global.Get<string, LuaTable>(m_LuaBaseName);
            if (parentscript != null)
            {
                LuaTable meta = LuaMgr.Env.NewTable();
                meta.Set("__index", parentscript);
                mScriptEnv.SetMetaTable(meta);
                meta.Dispose();
                mScriptEnv.Set("___super", parentscript);
                this.CallLuaFunction("constructorChildFromBase", mScriptEnv, mScriptEnv);
            }
            else
            {
                DebugUtil.DebugError("未找到父类");
            }
        }
        //设定Lua脚本的self
        mScriptEnv.Set("gameObject", this.gameObject);
        mScriptEnv.Set("this", this);
        mScriptEnv.Set("self", mScriptEnv);
        //把需要注入到lua脚本的对象注入进去
        foreach (var injection in m_Injections)
        {
            if (injection.m_Name == "")
                continue;
            if (injection.m_GameObject == null)
            {//留空了，使用Find查找
                var findObj = GameObject.Find(injection.m_Name);
                if (findObj != null)
                    mScriptEnv.Set(injection.m_Name, findObj);
            }
            else
                mScriptEnv.Set(injection.m_Name, injection.m_GameObject);
        }
        //把需要注入到lua脚本的组件注入进去
        if (m_InjectionObjects != null)
        {
            foreach (var inject in m_InjectionObjects)
            {
                if (inject.m_Name == "")
                    continue;
                if (inject == null)
                    continue;
                //校验注入的字段名唯一
                var value = mScriptEnv.Get<object>(inject.m_Name);
                if (value != null)
                {
                    DebugUtil.DebugError("注入字段已存在" + gameObject.name + "---" + inject.m_Name);
                    continue;
                }
                UnityEngine.Object injectObj = null;
                switch (inject.m_Type)
                {
                    case InjectionType.Material:
                        injectObj = inject.m_Object as Material;
                        break;
                    case InjectionType.AudioClip:
                        injectObj = inject.m_Object as AudioClip;
                        break;
                    case InjectionType.TextTure:
                        injectObj = inject.m_Object as Texture;
                        break;
                    case InjectionType.GameObject:
                        injectObj = inject.m_Object as GameObject;
                        break;
                    case InjectionType.Transform:
                        injectObj = inject.m_Object as Transform;
                        break;
                    case InjectionType.Camera:
                        injectObj = inject.m_Object as Camera;
                        break;
                    case InjectionType.ParticleSystem:
                        injectObj = inject.m_Object as ParticleSystem;
                        break;
                    case InjectionType.TextAsset:
                        injectObj = inject.m_Object as TextAsset;
                        break;
                }
                if (injectObj == null)
                {
                    DebugUtil.DebugError("注入物体转换类型失败" + inject.m_Name);
                }
                // Type typevalue = inject.m_Object.GetType();
                mScriptEnv.Set(inject.m_Name, injectObj);
            }
        }
        //把需要注入到lua脚本的组件注入进去
        if (m_InjectionObjectArrays != null)
        {
            foreach (var inject in m_InjectionObjectArrays)
            {
                if (inject.m_Name == "")
                    continue;
                if (inject == null)
                    continue;
                //校验注入的字段名唯一
                var value = mScriptEnv.Get<object>(inject.m_Name);
                if (value != null)
                {
                    DebugUtil.DebugError("注入字段已存在" + gameObject.name + "---" + inject.m_Name);
                    continue;
                }
                UnityEngine.Object[] injectObjs = new UnityEngine.Object[inject.m_Objects.Length];
                for (var i = 0; i < inject.m_Objects.Length; i++)
                {
                    var injectItem = inject.m_Objects[i];
                    switch (inject.m_Type)
                    {
                        case InjectionType.Material:
                            injectItem = injectItem as Material;
                            break;
                        case InjectionType.AudioClip:
                            injectItem = injectItem as AudioClip;
                            break;
                        case InjectionType.TextTure:
                            injectItem = injectItem as Texture;
                            break;
                        case InjectionType.GameObject:
                            injectItem = injectItem as GameObject;
                            break;
                        case InjectionType.Camera:
                            injectItem = injectItem as Camera;
                            break;
                        case InjectionType.ParticleSystem:
                            injectItem = injectItem as ParticleSystem;
                            break;
                    }
                    injectObjs[i] = injectItem;
                }
                if (injectObjs == null)
                {
                    DebugUtil.DebugError("注入物体转换类型失败" + inject.m_Name);
                }
                // Type typevalue = inject.m_Object.GetType();
                mScriptEnv.Set(inject.m_Name, injectObjs);
            }
        }
        //把需要注入到lua脚本的组件注入进去
        if (m_InjectionBaseObjects != null)
        {
            foreach (var inject in m_InjectionBaseObjects)
            {
                if (inject.m_Name == "")
                    continue;
                if (inject == null)
                    continue;
                //校验注入的字段名唯一
                var value = mScriptEnv.Get<object>(inject.m_Name);
                if (value != null)
                {
                    DebugUtil.DebugError("注入字段已存在" + gameObject.name + "---" + inject.m_Name);
                    continue;
                }
                switch (inject.m_Type)
                {
                    case InjectionBaseType.String:
                        mScriptEnv.Set(inject.m_Name, inject.m_Value.ToString());
                        break;
                    case InjectionBaseType.Int:
                        int intvalue = 0;
                        if (int.TryParse(inject.m_Value, out intvalue))
                        {
                            mScriptEnv.Set(inject.m_Name, intvalue);
                        }
                        else
                        {
                            DebugUtil.DebugError(string.Format("数据转换Int类型失败{0}{1}", gameObject.name, inject.m_Name));
                            continue;
                        }
                        break;
                    case InjectionBaseType.Float:
                        float floatValue = 0;
                        if (float.TryParse(inject.m_Value, out floatValue))
                        {
                            mScriptEnv.Set(inject.m_Name, floatValue);
                        }
                        else
                        {
                            DebugUtil.DebugError(string.Format("数据转换Float类型失败{0}{1}", gameObject.name, inject.m_Name));
                            continue;
                        }
                        break;
                    case InjectionBaseType.Bool:
                        bool boolValue = false;
                        if (bool.TryParse(inject.m_Value, out boolValue))
                        {
                            mScriptEnv.Set(inject.m_Name, boolValue);
                        }
                        else
                        {
                            DebugUtil.DebugError(string.Format("数据转换Bool类型失败{0}{1}", gameObject.name, inject.m_Name));
                            continue;
                        }
                        break;
                }
            }
        }

        //加载Lua文件
        LoadLuaFile();

        Action<LuaTable> luaAwake = mScriptEnv.Get<Action<LuaTable>>("Awake");
        mScriptEnv.Get("Start", out mLuaStart);
        mScriptEnv.Get("Update", out mLuaUpdate);
        mScriptEnv.Get("OnDestroy", out mLuaOnDestroy);
        mScriptEnv.Get("OnEnable", out mLuaOnEnable);
        mScriptEnv.Get("OnDisable", out mLuaOnDisable);

        if (luaAwake != null)
        {
            luaAwake(mScriptEnv);
        }
    }
    //加载Lua文件
    void LoadLuaFile()
    {
        if (m_LuaScript == null)
            return;
        var name = m_LuaScript.name;
        //读Lua文件
        string luaFileContent = "";
        if (LuaFileLoader.Instance && LuaFileLoader.Instance.mLoadFromServer == true)
        {
            luaFileContent = LuaFileLoader.LoadLuaFile(name + ".txt");
        }
        if (luaFileContent == "")
        {
            luaFileContent = m_LuaScript.text;
        }
        // //|| (Application.isEditor && m_ForceUsingServerLuaInEditor == false)
        // if (luaFileContent == "")
        // {
        //     //从界面绑定的Lua脚本上执行
        //     luaFileContent = m_LuaScript.text;
        // }
        if (luaFileContent == "")
            Debug.LogError("Empty lua content for object:" + gameObject);
        LuaMgr.Env.DoString(luaFileContent, name, mScriptEnv);
        mLuaTableName = m_LuaScript.name;
        //加入到全局表中
        if (!m_NotSetModuleToOthers)
        {
            var moduleName = m_ModuleName;
            if (string.IsNullOrEmpty(moduleName))
                moduleName = name.Substring(0, name.IndexOf(".lua"));
            if (LuaMgr.Env.Global.Get<string, LuaTable>("others").ContainsKey(moduleName))
            {//有重名的模块
                Debug.LogError("LuaMgr.Evn already constains a module named:" + moduleName);
            }
            LuaMgr.Env.Global.Get<string, LuaTable>("others").Set(moduleName, mScriptEnv);
        }
    }
    void Start()
    {
        if (mLuaStart != null)
        {
            mLuaStart(this.mScriptEnv);
        }
    }
    void Update()
    {
        if (mLuaUpdate != null)
        {
            mLuaUpdate();
        }
    }
    void OnDestroy()
    {
        if (mLuaOnDestroy != null)
        {
            mLuaOnDestroy(this.mScriptEnv);
        }
        DeleteLuaModule();
    }
    //luaModel清除
    public virtual void DeleteLuaModule()
    {
        if (m_Global)
        {
            //如果是全局唯一的判断当前物体是否是全局的Table物体
            var moduleName = m_ModuleName;
            if (string.IsNullOrEmpty(moduleName))
            {
                var name = m_LuaScript.name.Substring(0, m_LuaScript.name.IndexOf(".lua"));
                moduleName = name;
            }
            var others = LuaMgr.Env.Global.Get<string, LuaTable>("others");
            if (others != null)
            {
                var globalTable = others.Get<string, LuaTable>(moduleName);
                if (globalTable != null)
                {
                    if (globalTable.Get<GameObject>("gameObject") != gameObject)
                    {
                        //说明当前物体不是全局的物体 不进行后续销毁
                        return;
                    }
                }
            }
        }
        // var name = m_LuaScript.name;
        if (!m_NotSetModuleToOthers)
        {
            var moduleName = m_ModuleName;
            if (string.IsNullOrEmpty(moduleName))
                moduleName = mLuaTableName.Substring(0, mLuaTableName.IndexOf(".lua"));
            //从全局表中清除
            var othersTable = LuaMgr.Env.Global.Get<string, LuaTable>("others");
            if (othersTable != null)
                othersTable.Set<string, LuaTable>(moduleName, null);
        }
        mLuaOnDestroy = null;
        mLuaUpdate = null;
        mLuaStart = null;
        mLuaOnEnable = null;
        mLuaOnDisable = null;
        if (mScriptEnv != null)
        {
            mScriptEnv.Dispose();
        }
        m_Injections = null;
    }
    void OnEnable()
    {
        if (mLuaOnEnable != null)
        {
            mLuaOnEnable(this.mScriptEnv);
        }
    }

    void OnDisable()
    {
        if (mLuaOnDisable != null)
        {
            mLuaOnDisable(this.mScriptEnv);
        }
    }

    //调试接口
    public void DebugValue(object obj, string info = "")
    {
        if (info != null)
            Debug.Log(info + " : " + obj == null ? "null" : obj.ToString());
        else
            Debug.Log(info);
    }

    //调用Lua函数
    public void CallLuaFunction(string functionName, params object[] ps)
    {
        LuaFunction luaFunction = mScriptEnv.Get<LuaFunction>(functionName);
        if (luaFunction == null)
        {
            Debug.LogError("lua file (" + m_LuaScript.name + ") doesn't have a function named:" + functionName);
            return;
        }
        luaFunction.Call(ps);
    }

    //获取Lua中的变量值
    public TValue Get<TValue>(string varName)
    {
        return mScriptEnv.GetInPath<TValue>(varName);
    }
    // [LuaCallCSharp]
    public object GetValue(string varName)
    {
        return mScriptEnv.GetInPath<object>(varName);
    }


    //给lua变量赋值
    public void Set<TValue>(string varName, TValue value)
    {
        mScriptEnv.SetInPath<TValue>(varName, value);
    }

    public Array GetEnumArry(string enumName)
    {
        var t = System.Type.GetType(enumName);
        if (t == null)
        {
            Debug.LogError("GetEnumArray: Enum not found:" + enumName);
            return new string[0];
        }
        else
            return System.Enum.GetValues(t);
    }
    /// <summary>
    /// 获取Lua表
    /// </summary>
    /// <returns></returns>
    public LuaTable GetTable()
    {
        return this.mScriptEnv;
    }

}
