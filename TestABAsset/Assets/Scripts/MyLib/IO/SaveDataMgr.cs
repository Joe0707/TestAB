using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DataSaver
{
    //用户数据存储
    public class SaveDataMgr : MonoBehaviour
    {
        static SaveDataMgr mInstance = null;
        string mGlobalDataPageName = "GlobalDataPage"; //存储全局数据的文件名
        public string[] m_DataPageNames;//数据页名称,每一个页对应一个文件,每个存储槽都有一份
        public float m_AutoSaveInterval = 50; //自动保存的间隔

        Dictionary<string, DataPage> mDataPageDic = new Dictionary<string, DataPage>();
        DataPage mGlobalDataPage = null;//全局数据
        int mCurSlotIndex = 0; //当前的存档槽

        public static string SavePath = "";

        void Awake()
        {
            SavePath = Application.persistentDataPath + "/SaveData";
            if (Directory.Exists(SavePath) == false)
                Directory.CreateDirectory(SavePath);
            mInstance = this;
            LoadGlobal();
        }
        void Start()
        {
            StartCoroutine(_AutoSave());
        }
        void OnDestroy()
        {
            StopAllCoroutines();
            SaveGlobal();
            SaveAll();
        }

        void OnApplicationPause(bool pauseStatus)
        {
            if(pauseStatus)
            {
                Debug.Log("OnApplicationPause Trigger SaveData");
                SaveAll();
            }
        }

        IEnumerator _AutoSave()
        {
            while(true)
            {
                yield return new WaitForSeconds(m_AutoSaveInterval);
                SaveAllAsync();
                SaveGlobalAsync();
            }
        }

        //加载全局存档
        public static void LoadGlobal()
        {
            if(mInstance == null)
                return;
            if(mInstance.mGlobalDataPage != null)
            {
                return;
            }
            mInstance.mGlobalDataPage = new DataPage(mInstance.mGlobalDataPageName, DataPage.GlobalSlotIndex);
        }

        public static void LoadAll(int slot)
        {
            if (mInstance == null)
                return;
            if(mInstance.mDataPageDic.Count > 0)
            {
                Debug.LogWarning("SaveDataMgr.LoadAll:Already called, data page count > 0");
                return;
            }
            if(slot < 0)
            {
                Debug.LogWarning("SaveDataMgr.LoadAll:slot can't be < 0");
                return;
            }
            //先将当前的都保存
            UnloadAll();
            //加载新的存档
            mInstance.mCurSlotIndex = slot;
            //创建文件
            foreach(var name in mInstance.m_DataPageNames) 
            {
                AddDataPage(name);
            }
        }

        public static void UnloadAll()
        {
            if (mInstance == null)
                return;
            foreach(var pair in mInstance.mDataPageDic)
            {
                pair.Value.Save();
            }
            mInstance.mDataPageDic.Clear();
        }
        
        //增添一个data文件
        public static void AddDataPage(string pageName)
        {
            if (mInstance == null)
                return;
            if(mInstance.mDataPageDic.ContainsKey(pageName))
            {
                Debug.LogError("SaveDataMgr.AddDataPage file name exist:" + pageName);
                return;
            }
            mInstance.mDataPageDic.Add(pageName , new DataPage(pageName, mInstance.mCurSlotIndex));
        }

        //是否有data文件
        public static bool HasPage(string pageName)
        {
            if (mInstance == null)
                return false;
            return mInstance.mDataPageDic.ContainsKey(pageName);
        }

        //保存所有
        public static void SaveAll()
        {
            if (mInstance == null)
                return;
            foreach(var pair in mInstance.mDataPageDic)
            {
                pair.Value.Save();  
            }
        }

        public static void SaveAllAsync()
        {
            if(mInstance == null)
                return;
            System.Threading.ThreadPool.QueueUserWorkItem(delegate { SaveAll(); });
        }
        public static void SaveGlobal()
        {
            if(mInstance == null)
                return;
            if(mInstance.mGlobalDataPage != null)
                mInstance.mGlobalDataPage.Save();
        }
        public static void SaveGlobalAsync()
        {
           if(mInstance == null)
                return;
            System.Threading.ThreadPool.QueueUserWorkItem(delegate { SaveGlobal(); });
        }

        //保存某一页
        public static void SavePage(string pageName)
        {
            if (mInstance == null)
                return;
            if (mInstance.mDataPageDic.ContainsKey(pageName) == false)
            {
                Debug.LogError("SaveDataMgr.SavePage no data page named:" + pageName);
                return;
            }
            mInstance.mDataPageDic[pageName].Save();
        }

        //删除数据页
        public static void DeleteDataPage(string pageName)
        {
            if (mInstance == null)
                return;
            if (mInstance.mDataPageDic.ContainsKey(pageName) == false)
            {
                Debug.LogError("SaveDataMgr.DeleteDataPage no data page named:" + pageName);
                return;
            }
            var dataPage = mInstance.mDataPageDic[pageName];
            mInstance.mDataPageDic.Remove(pageName);
            dataPage.DeleteAll();
        }

        //删除所有
        public static void DeleteAll()
        {
            if (mInstance == null)
                return;
            foreach(var pair in mInstance.mDataPageDic)
            {
                pair.Value.DeleteAll();
            }
            mInstance.mDataPageDic.Clear();
        }

        //删除全局数据
        public static void DeleteGlobal()
        {
           if (mInstance == null)
                return; 
            if(mInstance.mGlobalDataPage != null)
            {
                mInstance.mGlobalDataPage.DeleteAll();
                mInstance.mGlobalDataPage = null;
            }
        }

        //删除一条数据
        public static void DeleteOne(string pageName, string key, bool forceSave = false)
        {
            if (mInstance == null)
                return;
            if (mInstance.mDataPageDic.ContainsKey(pageName) == false)
            {
                Debug.LogError("SaveDataMgr.DeleteOne no data page named:" + pageName);
                return;
            }
            var dataPage = mInstance.mDataPageDic[pageName];
            dataPage.DeleteKey(key, forceSave);
        }
        //删除全局数据里的一条数据
        public static void DeleteGlobalOne(string key, bool forceSave = false)
        {
            if (mInstance == null)
                return;
            if (mInstance.mGlobalDataPage == null)
            {
                Debug.LogError("SaveDataMgr.DeleteGlobalOne: mGlobalDataPage==null" );
                return;
            }
            mInstance.mGlobalDataPage.DeleteKey(key, forceSave);
        }

        //设定值
        public static void SetString(string page, string key, string value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetString(key, value, forceSave);
        }
        public static void SetByte(string page, string key, byte value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetByte(key, value, forceSave);
        }
        public static void SetShort(string page, string key, short value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetShort(key, value, forceSave);
        }
        public static void SetUShort(string page, string key, ushort value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetUShort(key, value, forceSave);
        }
        public static void SetInt(string page, string key, int value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetInt(key, value, forceSave);
        }
        public static void SetUInt(string page, string key, uint value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetUInt(key, value, forceSave);
        }
        public static void SetLong(string page, string key, long value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetLong(key, value, forceSave);
        }
        public static void SetULong(string page, string key, ulong value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetULong(key, value, forceSave);
        }
        public static void SetBool(string page, string key, bool value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetBool(key, value, forceSave);
        }
        public static void SetFloat(string page, string key, float value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetFloat(key, value, forceSave);
        }
        public static void SetDouble(string page, string key, double value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.SetValue no data page named:" + page); return; }
            mInstance.mDataPageDic[page].SetDouble(key, value, forceSave);
        }

        //查询值
        public static string GetString(string page, string key, string defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetString no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetString(key, defaltValue);
        }
        public static byte GetByte(string page, string key, byte defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetByte no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetByte(key, defaltValue);
        }
        public static short GetShort(string page, string key, short defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetShort no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetShort(key, defaltValue);
        } 
        public static ushort GetUShort(string page, string key, ushort defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetUShort no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetUShort(key, defaltValue);
        } 
        public static int GetInt(string page, string key, int defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetInt no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetInt(key, defaltValue);
        } 
        public static uint GetUInt(string page, string key, uint defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetUInt no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetUInt(key, defaltValue);
        } 
        public static long GetLong(string page, string key, long defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetLong no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetLong(key, defaltValue);
        } 
        public static ulong GetULong(string page, string key, ulong defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetULong no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetULong(key, defaltValue);
        }
        public static bool GetBool(string page, string key, bool defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetBool no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetBool(key, defaltValue);
        }  
        public static float GetFloat(string page, string key, float defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetFloat no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetFloat(key, defaltValue);
        } 
        public static double GetDouble(string page, string key, double defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mDataPageDic.ContainsKey(page) == false) { Debug.LogError("SaveDataMgr.GetDouble no data page named:" + page); return defaltValue; }
            return mInstance.mDataPageDic[page].GetDouble(key, defaltValue);
        } 








        
        //设定值
        public static void SetGlobalString(string key, string value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetString(key, value, forceSave);
        }
        public static void SetGlobalByte(string key, byte value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetByte(key, value, forceSave);
        }
        public static void SetGlobalShort(string key, short value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetShort(key, value, forceSave);
        }
        public static void SetGlobalUShort(string key, ushort value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetUShort(key, value, forceSave);
        }
        public static void SetGlobalInt(string key, int value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetInt(key, value, forceSave);
        }
        public static void SetGlobalUInt(string key, uint value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetUInt(key, value, forceSave);
        }
        public static void SetGlobalLong(string key, long value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetLong(key, value, forceSave);
        }
        public static void SetGlobalULong(string key, ulong value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetULong(key, value, forceSave);
        }
        public static void SetGlobalBool(string key, bool value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetBool(key, value, forceSave);
        }
        public static void SetGlobalFloat(string key, float value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetFloat(key, value, forceSave);
        }
        public static void SetGlobalDouble(string key, double value, bool forceSave = false)
        {
            if (mInstance == null) return;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return; }
            mInstance.mGlobalDataPage.SetDouble(key, value, forceSave);
        }

        //查询值
        public static string GetGlobalString(string key, string defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetString(key, defaltValue);
        }
        public static byte GetGlobalByte(string key, byte defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetByte(key, defaltValue);
        }
        public static short GetGlobalShort(string key, short defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetShort(key, defaltValue);
        } 
        public static ushort GetGlobalUShort(string key, ushort defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetUShort(key, defaltValue);
        } 
        public static int GetGlobalInt(string key, int defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetInt(key, defaltValue);
        } 
        public static uint GetGlobalUInt(string key, uint defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetUInt(key, defaltValue);
        } 
        public static long GetGlobalLong(string key, long defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetLong(key, defaltValue);
        } 
        public static ulong GetGlobalULong(string key, ulong defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetULong(key, defaltValue);
        }
        public static bool GetGlobalBool(string key, bool defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetBool(key, defaltValue);
        }  
        public static float GetGlobalFloat(string key, float defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetFloat(key, defaltValue);
        } 
        public static double GetGlobalDouble(string key, double defaltValue)
        {
            if (mInstance == null) return defaltValue;
            if (mInstance.mGlobalDataPage == null) { Debug.LogError("SaveDataMgr.mGlobalDataPage==null"); return defaltValue; }
            return mInstance.mGlobalDataPage.GetDouble(key, defaltValue);
        } 










//----------------------------------------
#region DataPage
        //数据文件
        class DataPage
        {
            public string mName = "";
            public Dictionary<string, DataItem> mDataItemDic = new Dictionary<string, DataItem>(); //数据字典
            bool mLoaded = false; //加载成功
            int mDataSlotIndex = 0;//存档槽索引 -1是全局的
            public const int GlobalSlotIndex = -1; //全局的槽索引
            bool mDirty = false; //脏标志
            object mSaveLock = new object(); //保存文件时的锁

            public DataPage(string pageName, int slotIndex)
            {
                mDataSlotIndex = slotIndex;
                mName = pageName;
                Load();
            }
            //从文件加载
            void Load()
            {
                if(mLoaded)
                    return;
                if(File.Exists(FileFullPath))
                {//如果文件存在
                    try
                    {
                        var fs = new FileStream(FileFullPath, FileMode.Open);
                        var br = new BinaryReader(fs);
                        int count = br.ReadInt32();
                        for(int i = 0; i < count; i++)
                        {
                            var name = br.ReadString();
                            var type = (EDataItemType)br.ReadByte();
                            DataItem dataItem = null;
                            switch(type)
                            {
                                case EDataItemType.String: {
                                    var value = br.ReadString();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Byte: {
                                    var value = br.ReadByte();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Short: {
                                    var value = br.ReadInt16();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.UShort: {
                                    var value = br.ReadUInt16();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Int: {
                                    var value = br.ReadInt32();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.UInt: {
                                    var value = br.ReadUInt32();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Long: {
                                    var value = br.ReadInt64();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.ULong: {
                                    var value = br.ReadUInt64();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Bool: {
                                    var value = br.ReadByte()==1;
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Float: {
                                    var value = br.ReadSingle();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                                case EDataItemType.Double: {
                                    var value = br.ReadDouble();
                                    dataItem = DataItem.Create(name, value);
                                } break;
                            }
                            //插入列表
                            if(dataItem != null)
                                mDataItemDic.Add(name, dataItem);
                            else
                                Debug.Log("DataItem==null for name" + name);
                        }
                        mLoaded = true;
                        br.Close();
                    }
                    catch(System.Exception e)
                    {
                        Debug.LogError("DataPage.Load() failed for " + FileFullPath + " | " + e.ToString());
                    }
                    
                }
                else//文件不存在
                    mLoaded = true; 
            }

            //完整路径
            string FileFullPath { get {
                    if(mDataSlotIndex == GlobalSlotIndex)
                        return SavePath + "/" + mName + ".sv";
                    else
                    {
                        var path = SavePath + "/" + mDataSlotIndex;
                        if(Directory.Exists(path) == false)
                            Directory.CreateDirectory(path);
                        return SavePath + "/" + mDataSlotIndex + "/" + mName + ".sv";
                    }
                }
            }

            //保存到文件
            public void Save()
            {
                if (mDirty == false)
                    return;
                mDirty = false;
                if (mDataItemDic.Count == 0)
                    return;
                var ms = new MemoryStream();
                var bw = new BinaryWriter(ms);
                lock (mDataItemDic)
                {
                    int count = mDataItemDic.Count;
                    bw.Write(count);
                    foreach (var pair in mDataItemDic)
                    {
                        var dataItem = pair.Value;
                        bw.Write(dataItem.mKey);
                        bw.Write((byte)dataItem.mType);
                        switch (dataItem.mType)
                        {
                            case EDataItemType.String:
                                bw.Write(dataItem.mValue as string);
                                break;
                            case EDataItemType.Byte:
                                bw.Write((byte)dataItem.mValue);
                                break;
                            case EDataItemType.Short:
                                bw.Write((short)dataItem.mValue);
                                break;
                            case EDataItemType.UShort:
                                bw.Write((ushort)dataItem.mValue);
                                break;
                            case EDataItemType.Int:
                                bw.Write((int)dataItem.mValue);
                                break;
                            case EDataItemType.UInt:
                                bw.Write((uint)dataItem.mValue);
                                break;
                            case EDataItemType.Long:
                                bw.Write((long)dataItem.mValue);
                                break;
                            case EDataItemType.ULong:
                                bw.Write((ulong)dataItem.mValue);
                                break;
                            case EDataItemType.Bool:
                                bool v = (bool)dataItem.mValue;
                                bw.Write((byte)(v ? 1 : 0));
                                break;
                            case EDataItemType.Float:
                                bw.Write((float)dataItem.mValue);
                                break;
                            case EDataItemType.Double:
                                bw.Write((double)dataItem.mValue);
                                break;
                        }
                    }
                }

                lock (mSaveLock)
                {
                    try
                    {
                        //存入文件
                        var fs = new FileStream(FileFullPath, FileMode.Create);
                        bw.BaseStream.Position = 0;
                        bw.BaseStream.CopyTo(fs);
                        bw.Close();
                        fs.Close();
                        // if (Application.isEditor)
                        //     Debug.Log("DataPage Saved:" + FileFullPath);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError("Failed to save file " + FileFullPath + "| " + e.ToString());
                    }
                }

            }

            //删除所有
            public void DeleteAll()
            {
                mDataItemDic.Clear();
                //删除文件 
                try
                {
                    File.Delete(FileFullPath);
                }
                catch { }
            }

            //删除数据
            public void DeleteKey(string key, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key))
                {
                    mDataItemDic.Remove(key);
                    if (forceSave)
                        Save();
                }
            }

            //设定值
            public void SetString(string key, string value, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key) == false)
                {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else
                {
                    if ((string)(mDataItemDic[key].mValue) != value)
                    {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if (forceSave)//保存 
                    Save();
            }
            public void SetByte(string key, byte value, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key) == false)
                {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else
                {
                    if ((byte)(mDataItemDic[key].mValue) != value)
                    {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if (forceSave)//保存 
                    Save();
            }
            public void SetShort(string key, short value, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key) == false)
                {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else
                {
                    if ((short)(mDataItemDic[key].mValue) != value)
                    {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if (forceSave)//保存 
                    Save();
            }
            public void SetUShort(string key, ushort value, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key) == false)
                {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else
                {
                    if ((ushort)(mDataItemDic[key].mValue) != value)
                    {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if (forceSave)//保存 
                    Save();
            }
            public void SetInt(string key, int value, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key) == false)
                {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else
                {
                    if ((int)(mDataItemDic[key].mValue) != value)
                    {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if (forceSave)//保存 
                    Save();
            }
            public void SetUInt(string key, uint value, bool forceSave = false)
            {
                if (mDataItemDic.ContainsKey(key) == false)
                {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else
                {
                    if ((uint)(mDataItemDic[key].mValue) != value)
                    {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if(forceSave)//保存 
                    Save();
            }
            public void SetLong(string key, long value, bool forceSave = false) {
                if (mDataItemDic.ContainsKey(key) == false) {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else {
                    if((long)(mDataItemDic[key].mValue) != value) {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if(forceSave)//保存 
                    Save();
            }
            public void SetULong(string key, ulong value, bool forceSave = false) {
                if (mDataItemDic.ContainsKey(key) == false) {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else {
                    if((ulong)(mDataItemDic[key].mValue) != value) {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if(forceSave)//保存 
                    Save();
            }
            public void SetBool(string key, bool value, bool forceSave = false) {
                if (mDataItemDic.ContainsKey(key) == false) {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else {
                    if((bool)(mDataItemDic[key].mValue) != value) {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if(forceSave)//保存 
                    Save();
            }
            public void SetFloat(string key, float value, bool forceSave = false) {
                if (mDataItemDic.ContainsKey(key) == false) {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else {
                    if((float)(mDataItemDic[key].mValue) != value) {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if(forceSave)//保存 
                    Save();
            }
            public void SetDouble(string key, double value, bool forceSave = false) {
               if (mDataItemDic.ContainsKey(key) == false) {
                    mDataItemDic.Add(key, DataItem.Create(key, value)); //创建新的
                    mDirty = true;
                }
                else {
                    if((double)(mDataItemDic[key].mValue) != value) {
                        mDataItemDic[key].SetValue(value); //修改
                        mDirty = true;
                    }
                }
                if(forceSave)//保存 
                    Save();
            }

            //查询值
            public string GetString(string key, string defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.String)
                        return item.mValue as string;
                    else { Debug.LogError("DataItem type is not string for key: " + key); return defaltValue; }
                }
            }
            public byte GetByte(string key, byte defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Byte)
                        return (byte)item.mValue;
                    else { Debug.LogError("DataItem type is not byte for key: " + key); return defaltValue; }
                }
            }
            public short GetShort(string key, short defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Short)
                        return (short)item.mValue;
                    else { Debug.LogError("DataItem type is not short for key: " + key); return defaltValue; }
                }
            }
            public ushort GetUShort(string key, ushort defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.UShort)
                        return (ushort)item.mValue;
                    else { Debug.LogError("DataItem type is not ushort for key: " + key); return defaltValue; }
                }
            }
            public int GetInt(string key, int defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Int)
                        return (int)item.mValue;
                    else { Debug.LogError("DataItem type is not int for key: " + key); return defaltValue; }
                }
            }
            public uint GetUInt(string key, uint defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.UInt)
                        return (uint)item.mValue;
                    else { Debug.LogError("DataItem type is not uint for key: " + key); return defaltValue; }
                }
            }
            public long GetLong(string key, long defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Long)
                        return (long)item.mValue;
                    else { Debug.LogError("DataItem type is not long for key: " + key); return defaltValue; }
                }
            }
            public ulong GetULong(string key, ulong defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.ULong)
                        return (ulong)item.mValue;
                    else { Debug.LogError("DataItem type is not ulong for key: " + key); return defaltValue; }
                }
            }
            public bool GetBool(string key, bool defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Bool)
                        return (bool)item.mValue;
                    else { Debug.LogError("DataItem type is not bool for key: " + key); return defaltValue; }
                }
            }
           public float GetFloat(string key, float defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Float)
                        return (float)item.mValue;
                    else { Debug.LogError("DataItem type is not float for key: " + key); return defaltValue; }
                }
            }
            public double GetDouble(string key, double defaltValue)
            {
                if (mDataItemDic.ContainsKey(key) == false) 
                    return defaltValue;
                else {
                    var item = mDataItemDic[key];
                    if (item.mType == EDataItemType.Double)
                        return (double)item.mValue;
                    else { Debug.LogError("DataItem type is not double for key: " + key); return defaltValue; }
                }
            }
        }



        //数据类型定义
        public enum EDataItemType { String, Byte, Short, UShort, Int, UInt, Long, ULong, Bool, Float, Double, }  //数据类型
        #endregion




        //----------------------------------------
        #region DataItem
        //数据条目
        class DataItem
        {
            public string mKey = "";
            public EDataItemType mType = EDataItemType.String;
            public object mValue = null;
            private DataItem(string key, EDataItemType type, object value) { mKey = key; mType = type; mValue = value; }
            public static DataItem Create(string key, string value) { return new DataItem(key, EDataItemType.String, value); }
            public static DataItem Create(string key, byte value) { return new DataItem(key, EDataItemType.Byte, value); }
            public static DataItem Create(string key, short value) { return new DataItem(key, EDataItemType.Short, value); }
            public static DataItem Create(string key, ushort value) { return new DataItem(key, EDataItemType.UShort, value); }
            public static DataItem Create(string key, int value) { return new DataItem(key, EDataItemType.Int, value); }
            public static DataItem Create(string key, uint value) { return new DataItem(key, EDataItemType.UInt, value); }
            public static DataItem Create(string key, long value) { return new DataItem(key, EDataItemType.Long, value); }
            public static DataItem Create(string key, ulong value) { return new DataItem(key, EDataItemType.ULong, value); }
            public static DataItem Create(string key, bool value) { return new DataItem(key, EDataItemType.Bool, value); }
            public static DataItem Create(string key, float value) { return new DataItem(key, EDataItemType.Float, value); }
            public static DataItem Create(string key, double value) { return new DataItem(key, EDataItemType.Double, value); }
            public void SetValue(string value){mValue = value; mType = EDataItemType.String;}
            public void SetValue(byte value){mValue = value; mType = EDataItemType.Byte;}
            public void SetValue(short value){mValue = value; mType = EDataItemType.Short;}
            public void SetValue(ushort value){mValue = value; mType = EDataItemType.UShort;}
            public void SetValue(int value){mValue = value; mType = EDataItemType.Int;}
            public void SetValue(uint value){mValue = value; mType = EDataItemType.UInt;}
            public void SetValue(long value){mValue = value; mType = EDataItemType.Long;}
            public void SetValue(ulong value){mValue = value; mType = EDataItemType.ULong;}
            public void SetValue(bool value){mValue = value; mType = EDataItemType.Bool;}
            public void SetValue(float value){mValue = value; mType = EDataItemType.Float;}
            public void SetValue(double value){mValue = value; mType = EDataItemType.Double;}
        }
        #endregion
    }
}
