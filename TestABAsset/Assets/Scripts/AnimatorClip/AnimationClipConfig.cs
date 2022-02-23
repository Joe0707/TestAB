using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public static class AnimationClipConfig
{
    #region -- 变量定义
    public static string ConfigPath = "/_Scripts/Editor/CutAnimation/Config.xml";
    private static bool mIsInit = false;//配置信息是否初始化
    public static List<ModelFbx> modelList = new List<ModelFbx>();
    #endregion

    #region -- 自定义函数
    public static bool Enable
    {
        get
        {
            string _enable = Read(Application.dataPath + ConfigPath, new string[] { "Root", "Enable" });
            return bool.Parse(_enable);
        }
    }
    /// <summary>
    /// 初始化配置信息
    /// </summary>
    /// <returns>返回初始化是否成功</returns>
    public static bool Init()
    {
        if (mIsInit)
        {
            return true;
        }
        mIsInit = true;

        return InitModeList();
    }
    private static bool InitModeList()
    {
        string _path = Application.dataPath + ConfigPath;
        if (File.Exists(_path))
        {
            XmlDocument _xmlDoc = new XmlDocument();
            XmlReaderSettings _set = new XmlReaderSettings();
            _set.IgnoreComments = true;
            XmlReader _reader = XmlReader.Create(_path, _set);
            _xmlDoc.Load(_reader);
            _reader.Close();
            XmlNodeList _nodeList = _xmlDoc.SelectSingleNode("Root").ChildNodes;
            foreach (XmlElement _xe in _nodeList)
            {
                if (_xe.Name == "ModelFbx")
                {
                    ModelFbx _modelFbx = new ModelFbx();
                    foreach (XmlElement _x1 in _xe.ChildNodes)
                    {
                        if (_x1.Name == "ModelName")
                        {
                            _modelFbx.modelName = _x1.InnerText;
                        }
                        if (_x1.Name == "Clips")
                        {
                            _modelFbx.clips = new Clip[_x1.ChildNodes.Count];
                            int _index = 0;
                            foreach (XmlElement _x2 in _x1.ChildNodes)
                            {
                                string _clipName = "";
                                int _firstFrame = 0;
                                int _lastFrame = 0;
                                bool _isLoop = false;
                                foreach (XmlElement _x3 in _x2.ChildNodes)
                                {
                                    if (_x3.Name == "ClipName")
                                    {
                                        _clipName = _x3.InnerText;
                                    }
                                    if (_x3.Name == "FirstFrame")
                                    {
                                        _firstFrame = int.Parse(_x3.InnerText);
                                    }
                                    if (_x3.Name == "LastFrame")
                                    {
                                        _lastFrame = int.Parse(_x3.InnerText);
                                    }
                                    if (_x3.Name == "IsLoop")
                                    {
                                        _isLoop = bool.Parse(_x3.InnerText);
                                    }
                                }
                                _modelFbx.clips[_index] = new Clip(_clipName, _firstFrame, _lastFrame, _isLoop);
                                _index++;
                            }
                        }
                    }
                    modelList.Add(_modelFbx);
                }
            }
            return true;
        }
        else
        {
            Debug.LogError("无法找打" + _path + "文件，请检查配置文件路径（ConfigPath）是否正确");
            return false;
        }
    }

    /// <summary>
    /// 读取 XML 文件指定子节点数据
    /// </summary>
    /// <param name="_path">文件读取路径</param>
    /// <param name="_xmlNodes">节点数组</param>
    /// <returns></returns>
    private static string Read(string _path, string[] _xmlNodes)
    {
        string _innerstr = "";//返回值
        XmlDocument _xmlDoc = new XmlDocument();
        XmlReaderSettings _set = new XmlReaderSettings();
        _set.IgnoreComments = true;
        //判断文件是否存在
        if (File.Exists(_path))
        {
            _xmlDoc.Load(XmlReader.Create(_path, _set));
        }
        else
        {
            Debug.LogError("目标文件不存在，请检查路径是否有误");
            return null;
        }
        int _nodeNum = _xmlNodes.Length;
        int _counter = 1;
        XmlNodeList _nodelist = _xmlDoc.SelectSingleNode(_xmlNodes[0]).ChildNodes;
        if (_nodelist == null)
        {
            return _innerstr;
        }
        while (_counter < _nodeNum)
        {
            bool _checkok = false;
            foreach (XmlNode _element in _nodelist)
            {
                if (_element.Name == _xmlNodes[_counter])
                {
                    _checkok = true;
                    _counter++;
                    if (_counter >= _nodeNum)
                    {
                        _innerstr = _element.InnerText;
                        _nodelist = null;
                        break;
                    }
                    _nodelist = _element.ChildNodes;
                    break;
                }
            }
            if (!_checkok)
            {
                break;
            }
        }
        return _innerstr;
    }
    #endregion

}