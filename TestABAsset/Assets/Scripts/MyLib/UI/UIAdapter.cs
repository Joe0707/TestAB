using UnityEngine;
using System.Collections;

//主要处理物体根据分辨率变化的缩放 

public class UIAdapter : MonoBehaviour
{

    public enum EObjType
    {
        Simple = 0, //简单、默认
        FullScreenSprite,   //全屏Sprite，一般是背景
    }
    public EObjType m_Type; //对象类型
    public float m_ClampMaxValue = 2f; //限制最大缩放值
    public float m_ClampMinValue = 0.1f;//限制最小缩放值


    bool mAlreadyAdapted = false; //已经适配过了
                                  //参照屏幕比例
    public static float AccrodingScreenRatio
    {//所有UI最初使用2:3屏幕制作，作为一个参考点
        get
        {
            if (Screen.width < Screen.height)
                return 2.0f / 3.0f;
            else
                return 3.0f / 2.0f;
        }
    }

    //当前使用的缩放比例与参照屏幕比例的关系
    public static float ScreenRatioChangedValue
    {
        get
        {
            float screenRatio = (Screen.width * 1.0f) / Screen.height;
            float applyRatio = screenRatio / AccrodingScreenRatio;
            return applyRatio;
        }
    }
    void Start()
    {

    }
    void Awake()
    {
        switch (m_Type)
        {
            case EObjType.Simple:
                AdaptSimpleGameObject();//简易物体。简单使用按屏幕比例缩放的策略
                break;
            case EObjType.FullScreenSprite:
                AdaptFullScreenSprite();//全屏幕sprite。
                break;
        }
    }
    //简易物体。简单使用按屏幕比例缩放的策略
    void AdaptSimpleGameObject()
    {
        if (mAlreadyAdapted == true)
            return;
        mAlreadyAdapted = true;
        float applyRatio = Mathf.Min(m_ClampMaxValue, ScreenRatioChangedValue);
        applyRatio = Mathf.Max(m_ClampMinValue, applyRatio);
        transform.localScale = new Vector3(transform.localScale.x * applyRatio, transform.localScale.y * applyRatio, transform.localScale.z);
    }

    //全屏Sprite缩放
    void AdaptFullScreenSprite()
    {
        if (mAlreadyAdapted == true)
            return;
        mAlreadyAdapted = true;
        //先按简单的方式缩放一次
        AdaptSimpleGameObject();
        //检查四个方向有没有漏边
        SpriteRenderer spRenderer = GetComponent<SpriteRenderer>();
        if (spRenderer == null)
            return;
        if (spRenderer.sprite == null)
            return;
        var spriteMinPosInScreen = Camera.main.WorldToScreenPoint(spRenderer.bounds.min);//图片在屏幕坐标系中的位置
        var spriteMaxPosInScreen = Camera.main.WorldToScreenPoint(spRenderer.bounds.max);
        var spriteScreenWidth = spriteMaxPosInScreen.x - spriteMinPosInScreen.x;//图片在屏幕坐标系中的尺寸
        var spriteScreenHeigth = spriteMaxPosInScreen.y - spriteMinPosInScreen.y;
        float hScale = 1f;//横向应该缩放多少
        float vScale = 1f;//纵向应该缩放多少
        if (spriteMinPosInScreen.x > 0 || spriteMaxPosInScreen.x < Screen.width)
        {//横向漏边了
         //找水平方向漏边的最大值
            var maxHDiff = Mathf.Max(spriteMinPosInScreen.x, Screen.width - spriteMaxPosInScreen.x);
            hScale = 1 + maxHDiff / (spriteScreenWidth * 0.5f);
        }
        if (spriteMinPosInScreen.y > 0 || spriteMaxPosInScreen.y < Screen.height)
        {//纵向漏边了
         //找纵向漏边的最大值
            var maxVDiff = Mathf.Max(spriteMinPosInScreen.y, Screen.height - spriteMaxPosInScreen.y);
            vScale = 1 + maxVDiff / (spriteScreenHeigth * 0.5f);
        }
        float finalScale = Mathf.Max(hScale, vScale);
        transform.localScale = new Vector3(transform.localScale.x * finalScale, transform.localScale.y * finalScale, transform.localScale.z);

    }

}
