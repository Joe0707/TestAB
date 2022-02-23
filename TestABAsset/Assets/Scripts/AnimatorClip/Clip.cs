using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip
{
    #region -- 变量定义
    public string clipName;     //动画名称
    public int firstFrame;      //动画第一帧
    public int lastFrame;       //动画最后一帧
    public bool isLoop;         //是否循环
    #endregion

    #region -- 自定义函数
    /// <summary>
    /// 构造动画信息
    /// </summary>
    /// <param name="_clipName">动画名称</param>
    /// <param name="_firstFrame">动画第一帧</param>
    /// <param name="_lastFrame">动画最后一帧</param>
    /// <param name="_isLoop">动画是否循环</param>
    public Clip(string _clipName, int _firstFrame, int _lastFrame, bool _isLoop)
    {
        clipName = _clipName;
        firstFrame = _firstFrame;
        lastFrame = _lastFrame;
        isLoop = _isLoop;
    }
    #endregion
}
