using UnityEngine;
//using UnityEditor;

public class CutAnimation //: AssetPostprocessor
{
    // #region -- 系统函数
    // /// <summary>
    // /// 模型导入之前调用
    // /// </summary>
    // public void OnPreprocessModel()
    // {
    //     //是否启用动画切割
    //     if (!AnimationClipConfig.Enable)
    //     {
    //         return;
    //     }

    //     //当前正在导入的模型
    //     ModelImporter _modelImporter = (ModelImporter)assetImporter;

    //     if (AnimationClipConfig.Init())
    //     {
    //         foreach (ModelFbx item in AnimationClipConfig.modelList)
    //         {
    //             //当前导入模型的路径包含AnimationClipConfig.modelList数据表中的模型名字，那就要对这个模型的动画进行切割  
    //             if (assetPath.Contains(item.modelName))
    //             {
    //                 _modelImporter.animationType = ModelImporterAnimationType.Generic;
    //                 _modelImporter.generateAnimations = ModelImporterGenerateAnimations.GenerateAnimations;
    //                 ModelImporterClipAnimation[] _animations = new ModelImporterClipAnimation[item.clips.Length];
    //                 for (int i = 0; i < item.clips.Length; i++)
    //                 {
    //                     _animations[i] = SetClipAnimation(item.clips[i].clipName, item.clips[i].firstFrame, item.clips[i].lastFrame, item.clips[i].isLoop);
    //                 }
    //                 _modelImporter.clipAnimations = _animations;
    //             }
    //         }
    //     }
    //     else
    //     {
    //         Debug.LogError("无法找打" + Application.dataPath + AnimationClipConfig.ConfigPath + "文件，请检查配置文件路径（mCofigPath）是否正确");
    //     }
    // }
    // #endregion

    // #region -- 自定义函数
    // private ModelImporterClipAnimation SetClipAnimation(string _clipName, int _firstFrame, int _lastFrame, bool _isLoop)
    // {
    //     ModelImporterClipAnimation _clip = new ModelImporterClipAnimation();
    //     _clip.name = _clipName;
    //     _clip.firstFrame = _firstFrame;
    //     _clip.lastFrame = _lastFrame;
    //     _clip.loop = _isLoop;
    //     if (_isLoop)
    //     {
    //         _clip.wrapMode = WrapMode.Loop;
    //     }
    //     else
    //     {
    //         _clip.wrapMode = WrapMode.Default;
    //     }
    //     return _clip;
    // }
    // #endregion

}