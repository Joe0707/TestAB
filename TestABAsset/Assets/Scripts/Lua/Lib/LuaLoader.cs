using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class LuaLoader : MonoSingleton<LuaLoader>
{
    public static string Name = "112233";
    public TextAsset[] m_LuaFiles; //加载的Lua文件
    // public bool m_UseFromServer;//使用下载的Lua文件
    // public TextAsset m_Class;//加载的类型
    private Dictionary<string, LuaTable> tabledict = new Dictionary<string, LuaTable>();//加载的luaTables
                                                                                        // Start is called before the first frame update
                                                                                        // void Start()
                                                                                        // {
                                                                                        //     Init();
                                                                                        // }
                                                                                        //加载Lua类模板
    public void Init(bool loadFromHF)
    {
        // LuaTable classtable = LuaMgr.Env.NewTable();
        // LuaTable classmeta = LuaMgr.Env.NewTable();
        // classmeta.Set("__index", LuaMgr.Env.Global);
        // // table.Set("__index", LuaMgr.Env.Global);
        // var classluaFile = m_Class;
        // var classname = classluaFile.name.Substring(0, classluaFile.name.IndexOf(".lua"));
        // classtable.Set("___self", classtable);
        // classtable.Set("___super", LuaMgr.Env.Global);
        // classtable.Set("___classname", classname);
        // classtable.SetMetaTable(classmeta);
        // if (LuaMgr.AddGlobalNewTable(classtable, classluaFile.text, classname))
        // {
        //     tabledict.Add(classname, classtable);
        // }

        for (var i = 0; i < m_LuaFiles.Length; i++)
        {
            var luaFile = m_LuaFiles[i];
            var name = luaFile.name;
            string luaFileContent = "";
            if (loadFromHF)
            {
                //读Lua文件
                luaFileContent = LuaFileLoader.LoadLuaFile(name + ".txt");
                //如果是Editor，强制使用界面绑定的Lua文件
                if (luaFileContent == "")
                {//从界面绑定的Lua脚本上执行
                    luaFileContent = luaFile.text;
                }
            }
            else
            {
                luaFileContent = luaFile.text;
            }
            if (luaFileContent == "")
            {
                Debug.LogError("Empty lua content for object:" + gameObject);
                continue;
            }

            LuaTable table = LuaMgr.Env.NewTable();
            LuaTable meta = LuaMgr.Env.NewTable();
            meta.Set("__index", LuaMgr.Env.Global);
            name = luaFile.name.Substring(0, luaFile.name.IndexOf(".lua"));
            table.Set("___self", table);
            table.Set("___super", LuaMgr.Env.Global);
            table.Set("___classname", name);
            table.SetMetaTable(meta);
            if (LuaMgr.AddGlobalNewTable(table, luaFileContent, name))
            {
                tabledict.Add(name, table);
            }
        }
    }

    void OnDestroy()
    {
        foreach (KeyValuePair<string, LuaTable> pair in tabledict)
        {
            LuaMgr.RemoveGlobalTable(pair.Key);
        }
        tabledict.Clear();
    }

}
