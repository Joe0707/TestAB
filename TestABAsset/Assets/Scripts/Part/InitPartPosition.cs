using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPartPosition : MonoBehaviour
{
    //各部件的初始位置
    static Vector2 [] PartPos = {
        new Vector2(-0.008f,-0.662f),//后发
        new Vector2(0.026f,-1.82f),//身
        new Vector2(0.75f,-3.16f),//衣服
        new Vector2(0.275f,-1.318f),//项链
        new Vector2(0.864f,-0.079f),//中发
        new Vector2(0.159f,0.801f),//脸
        new Vector2(0.615f,0.665f),//面纹
        new Vector2(0.615f,0.56f),//圣痕
        new Vector2(0.515f,0.755f),//眼
        new Vector2(0.474f,0.912f),//眉
        new Vector2(0.565f,0.52f),//鼻
        new Vector2(0.462f,-0.003f),//嘴
        new Vector2(0.585f,0.615f),//皱纹
        new Vector2(0.475f,-0.1f),//胡须
        new Vector2(0.04f,-0.045f),//前发
        new Vector2(0.56f,1.731f),//头饰
        new Vector2(-0.574f,0.695f),//耳
        new Vector2(-0.585f,0.515f),//耳环
        new Vector2(-0.283f,-0.179f)//前前发
    };
    static InitPartPosition mInstance = null;
    void Awake()
    {
        mInstance = this; 
    }
    public static Vector2 GetPartPosition(int PartType)
    {
        return PartPos[PartType];
    }
}
