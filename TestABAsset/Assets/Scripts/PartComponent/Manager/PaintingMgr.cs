using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
//立绘管理器
public class PaintingMgr : MonoSingleton<PaintingMgr>
{

    public Camera m_PaintCamera;//立绘摄像机
    public Camera m_FaceCamera;//脸部摄像机
    private Texture2D m_PaintTexture;//立绘图片
    private Texture2D m_FaceTexture;//脸部图片
    private Dictionary<SexType, Dictionary<EPartObjType, SpriteRenderer>> paintRenders = new Dictionary<SexType, Dictionary<EPartObjType, SpriteRenderer>>();
    public void Init()
    {
        var femaleobjs = new Dictionary<EPartObjType, SpriteRenderer>();
        paintRenders.Add(SexType.f, femaleobjs);
        var maleobjs = new Dictionary<EPartObjType, SpriteRenderer>();
        paintRenders.Add(SexType.m, maleobjs);
        foreach (EPartObjType partType in Enum.GetValues(typeof(EPartObjType)))
        {
            //根据位置管理器生成不同部件
            var partObj = new GameObject(SexType.m.ToString() + partType.ToString());
            partObj.layer = LayerMask.NameToLayer("PartPaint");
            partObj.transform.parent = transform;
            var partposition2 = PartPositionMgr.Instance.GetPartPositionByTypeAndSex(partType, SexType.m);
            var localposition = new Vector3(partposition2.x, partposition2.y, 0.1f * (int)partType);
            partObj.transform.localPosition = localposition;
            var spriterender = partObj.AddComponent<SpriteRenderer>();
            maleobjs.Add(partType, spriterender);
        }

        foreach (EPartObjType partType in Enum.GetValues(typeof(EPartObjType)))
        {
            //根据位置管理器生成不同部件
            var partObj = new GameObject(SexType.f.ToString() + partType.ToString());
            partObj.layer = LayerMask.NameToLayer("PartPaint");
            partObj.transform.parent = transform;
            var partposition2 = PartPositionMgr.Instance.GetPartPositionByTypeAndSex(partType, SexType.f);
            var localposition = new Vector3(partposition2.x, partposition2.y, 0.1f * (int)partType);
            partObj.transform.localPosition = localposition;
            var spriterender = partObj.AddComponent<SpriteRenderer>();
            femaleobjs.Add(partType, spriterender);
        }
        m_FaceCamera.enabled = false;
        m_PaintCamera.enabled = false;
        m_PaintTexture = new Texture2D(m_PaintCamera.targetTexture.width, m_PaintCamera.targetTexture.height, TextureFormat.RGBA32, false);
        m_FaceTexture = new Texture2D(m_FaceCamera.targetTexture.width, m_FaceCamera.targetTexture.height, TextureFormat.RGBA32, false);
    }

    //根据性别对精灵进行激活
    void SetSpritesActiveBySexType(SexType sex, bool isActive)
    {
        var sprites = paintRenders[sex];
        foreach (var pair in sprites)
        {
            pair.Value.gameObject.SetActive(isActive);
        }
    }
    //生成身体绘制
    public Texture2D GenerateBodyPaint(PaintConfig config)
    {
        ReFreshPaintConfig(config);
        m_PaintCamera.Render();
        var cameraTarget = m_PaintCamera.targetTexture;
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = cameraTarget;
        m_PaintTexture.ReadPixels(new Rect(0, 0, cameraTarget.width, cameraTarget.height), 0, 0);
        m_PaintTexture.Apply();
        RenderTexture.active = currentActiveRT;
        return m_PaintTexture;
    }

    public Texture2D GenerateFacePaint(PaintConfig config)
    {
        ReFreshPaintConfig(config);
        m_FaceCamera.Render();
        var cameraTarget = m_FaceCamera.targetTexture;
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = cameraTarget;
        m_FaceTexture.ReadPixels(new Rect(0, 0, cameraTarget.width, cameraTarget.height), 0, 0);
        m_FaceTexture.Apply();
        RenderTexture.active = currentActiveRT;
        return m_FaceTexture;
    }
    //异步生成身体绘制
    public void AsyncGenerateBodyPaint(PaintConfig config, Action<Texture2D> callback)
    {
        StartCoroutine(AsyncGenerateBodyPaintCoroutine(config, callback));
    }
    public IEnumerator AsyncGenerateBodyPaintCoroutine(PaintConfig config, Action<Texture2D> callback)
    {
        bool refreshfinish = false;
        AsyncRefreshPaintConfig(config, () =>
        {
            refreshfinish = true;
        });
        while (refreshfinish == false)
        {
            yield return null;
        }
        m_PaintCamera.Render();
        var cameraTarget = m_PaintCamera.targetTexture;
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = cameraTarget;
        m_PaintTexture.ReadPixels(new Rect(0, 0, cameraTarget.width, cameraTarget.height), 0, 0);
        m_PaintTexture.Apply();
        RenderTexture.active = currentActiveRT;
        if (callback != null)
        {
            callback(m_PaintTexture);
        }
    }

    //异步生成头像绘制
    public void AsyncGenerateFacePaint(PaintConfig config, Action<Texture2D> callback)
    {
        StartCoroutine(AsyncGenerateFacePaintCoroutine(config, callback));
    }

    public IEnumerator AsyncGenerateFacePaintCoroutine(PaintConfig config, Action<Texture2D> callback)
    {
        bool refreshfinish = false;
        AsyncRefreshPaintConfig(config, () =>
        {
            refreshfinish = true;
        });
        while (refreshfinish == false)
        {
            yield return null;
        }
        m_FaceCamera.Render();
        var cameraTarget = m_FaceCamera.targetTexture;
        RenderTexture currentActiveRT = RenderTexture.active;
        RenderTexture.active = cameraTarget;
        m_FaceTexture.ReadPixels(new Rect(0, 0, cameraTarget.width, cameraTarget.height), 0, 0);
        m_FaceTexture.Apply();
        RenderTexture.active = currentActiveRT;
        if (callback != null)
        {
            callback(m_FaceTexture);
        }
    }

    //生成身体绘制Sprite
    public Sprite GenerateBodyPaintSprite(PaintConfig config, float width, float height)
    {
        var texture = GenerateBodyPaint(config);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
    }

    //生成面部绘制Sprite
    public Sprite GenerateFacePaintSprite(PaintConfig config, float width, float height)
    {
        var texture = GenerateFacePaint(config);
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
    }
    //异步生成头像精灵
    public void AsyncGenerateFacePaintSprite(PaintConfig config, float width, float height, Action<Sprite> callback)
    {
        AsyncGenerateFacePaint(config, (texture) =>
        {
            var sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f), 100f);
            if (callback != null)
            {
                callback(sprite);
            }
        });
    }
    //异步生成立绘精灵
    public void AsyncGenerateBodyPaintSprite(PaintConfig config, float width, float height, Action<Sprite> callback)
    {
        AsyncGenerateBodyPaint(config, (texture) =>
        {
            var sprite = Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f), 100f);
            if (callback != null)
            {
                callback(sprite);
            }
        });
    }

    //异步根据模板数据刷新界面
    public void AsyncRefreshPaintConfig(PaintConfig config, Action callback)
    {
        StartCoroutine(AsyncRefreshPaintConfigCoroutine(config, callback));
    }

    //异步根据模板数据刷新界面
    public IEnumerator AsyncRefreshPaintConfigCoroutine(PaintConfig config, Action callback)
    {
        var sex = config.Sex;
        var othersex = sex == SexType.m ? SexType.f : SexType.m;
        SetSpritesActiveBySexType(sex, true);
        SetSpritesActiveBySexType(othersex, false);
        int freshCount = 13;
        Action fun = () =>
        {
            freshCount--;
        };
        AsyncReFreshPart(EPartType.hair, config.Hair, sex, fun);
        AsyncReFreshPart(EPartType.ear, config.Ear, sex, fun);
        AsyncReFreshPart(EPartType.eyebrow, config.EyeBrow, sex, fun);
        AsyncReFreshPart(EPartType.eye, config.Eye, sex, fun);
        AsyncReFreshPart(EPartType.nose, config.Nose, sex, fun);
        AsyncReFreshPart(EPartType.beard, config.Beard, sex, fun);
        AsyncReFreshPart(EPartType.bigbeard, config.BigBeard, sex, fun);
        AsyncReFreshPart(EPartType.mouth, config.Mouth, sex, fun);
        AsyncReFreshPart(EPartType.tattoo, config.Tattoo, sex, fun);
        AsyncReFreshPart(EPartType.face, config.Face, sex, fun);
        AsyncReFreshPart(EPartType.clothes, config.Clothes, sex, fun);
        AsyncReFreshPart(EPartType.body, config.Body, sex, fun);
        AsyncReFreshPart(EPartType.stigma, config.Stigma, sex, fun);
        ReFreshPartColorByColorValue(EColorPartType.skincolor, config.SkinColor, sex);
        ReFreshPartColorByColorValue(EColorPartType.beardcolor, config.BeardColor, sex);
        ReFreshPartColorByColorValue(EColorPartType.eyebrowcolor, config.EyebrowColor, sex);
        ReFreshPartColorByColorValue(EColorPartType.haircolor, config.Haircolor, sex);
        while (freshCount > 0)
        {
            yield return null;
        }
        if (callback != null)
        {
            callback();
        }
    }

    //根据模板数据刷新界面
    public void ReFreshPaintConfig(PaintConfig config)
    {
        var sex = config.Sex;
        var othersex = sex == SexType.m ? SexType.f : SexType.m;
        SetSpritesActiveBySexType(sex, true);
        SetSpritesActiveBySexType(othersex, false);
        ReFreshPart(EPartType.hair, config.Hair, sex);
        ReFreshPart(EPartType.ear, config.Ear, sex);
        ReFreshPart(EPartType.eyebrow, config.EyeBrow, sex);
        ReFreshPart(EPartType.eye, config.Eye, sex);
        ReFreshPart(EPartType.nose, config.Nose, sex);
        ReFreshPart(EPartType.beard, config.Beard, sex);
        ReFreshPart(EPartType.bigbeard, config.BigBeard, sex);
        ReFreshPart(EPartType.mouth, config.Mouth, sex);
        ReFreshPart(EPartType.tattoo, config.Tattoo, sex);
        ReFreshPart(EPartType.face, config.Face, sex);
        ReFreshPart(EPartType.clothes, config.Clothes, sex);
        ReFreshPart(EPartType.body, config.Body, sex);
        ReFreshPart(EPartType.stigma, config.Stigma, sex);
        ReFreshPartColorByColorValue(EColorPartType.skincolor, config.SkinColor, sex);
        ReFreshPartColorByColorValue(EColorPartType.beardcolor, config.BeardColor, sex);
        ReFreshPartColorByColorValue(EColorPartType.eyebrowcolor, config.EyebrowColor, sex);
        ReFreshPartColorByColorValue(EColorPartType.haircolor, config.Haircolor, sex);
    }

    //刷新组件颜色
    public void ReFreshPartColorByColorValue(EColorPartType type, string color, SexType sex)
    {
        if (string.IsNullOrEmpty(color) == true)
        {
            color = "FFFFFF";
        }
        var curPaintRenders = paintRenders[sex];
        switch (type)
        {
            case EColorPartType.beardcolor:
                if (curPaintRenders[EPartObjType.beard] != null)
                {
                    Color beardcolor = ColorUtil.GetColor(color);
                    curPaintRenders[EPartObjType.beard].color = beardcolor;
                }
                break;
            case EColorPartType.eyebrowcolor:
                if (curPaintRenders[EPartObjType.eyebrow] != null)
                {
                    Color eyebrowcolor = ColorUtil.GetColor(color);
                    curPaintRenders[EPartObjType.eyebrow].color = eyebrowcolor;
                }
                break;
            case EColorPartType.haircolor:
                Color haircolor = ColorUtil.GetColor(color);
                if (curPaintRenders[EPartObjType.hair_a] != null) curPaintRenders[EPartObjType.hair_a].color = haircolor;
                if (curPaintRenders[EPartObjType.hair_b] != null) curPaintRenders[EPartObjType.hair_b].color = haircolor;
                if (curPaintRenders[EPartObjType.hair_c] != null) curPaintRenders[EPartObjType.hair_c].color = haircolor;
                if (curPaintRenders[EPartObjType.hair_d] != null) curPaintRenders[EPartObjType.hair_d].color = haircolor;
                if (curPaintRenders[EPartObjType.hair_e] != null) curPaintRenders[EPartObjType.hair_e].color = haircolor;
                if (curPaintRenders[EPartObjType.hair_f] != null) curPaintRenders[EPartObjType.hair_f].color = haircolor;
                break;
            case EColorPartType.skincolor:
                Color skincolor = ColorUtil.GetColor(color);
                if (curPaintRenders[EPartObjType.body] != null) curPaintRenders[EPartObjType.body].color = skincolor;
                if (curPaintRenders[EPartObjType.clothes_b] != null) curPaintRenders[EPartObjType.clothes_b].color = skincolor;
                if (curPaintRenders[EPartObjType.clothes_c] != null) curPaintRenders[EPartObjType.clothes_c].color = skincolor;
                if (curPaintRenders[EPartObjType.face] != null) curPaintRenders[EPartObjType.face].color = skincolor;
                if (curPaintRenders[EPartObjType.nose] != null) curPaintRenders[EPartObjType.nose].color = skincolor;
                if (curPaintRenders[EPartObjType.ear_b] != null) curPaintRenders[EPartObjType.ear_b].color = skincolor;
                break;
        }
    }

    //刷新组件颜色
    public void ReFreshPartColor(EColorPartType type, uint colorId, SexType sex)
    {
        var colorvalue = "";
        if (DescentColorMgr.Instance.TryGetColorValueByColorId(colorId, out colorvalue))
        {
            ReFreshPartColorByColorValue(type, colorvalue, sex);
        }
        else
        {
            DebugUtil.DebugError(string.Format("未查找到颜色值 id {0}", colorId));
        }
    }
    //异步刷新部件
    public void AsyncReFreshPart(EPartType part, string partResName, SexType sex, Action callback)
    {
        StartCoroutine(AsyncReFreshPartCoroutine(part, partResName, sex, callback));
    }

    private IEnumerator AsyncReFreshPartCoroutine(EPartType part, string partResName, SexType sex, Action callback)
    {
        //获取精灵渲染器
        var spriterenderdict = GetSpriteRendersByPartType(part, sex);
        if (spriterenderdict != null && spriterenderdict.Count > 0)
        {
            if (spriterenderdict.Count > 1)
            {
                //说明为组部件
                foreach (var pair in spriterenderdict)
                {
                    //获取部件
                    var spriterender = pair.Value;
                    if (string.IsNullOrEmpty(partResName) == false)
                    {
                        //单独部件
                        bool loadFinish = false;
                        Sprite sprite = null;
                        PartResourceMgr.Instance.AsyncGetPartSpriteByPartObjTypeAndWholeResName(pair.Key, partResName, (path, obj, p1) =>
                        {
                            sprite = obj as Sprite;
                            loadFinish = true;
                        });
                        while (loadFinish == false)
                        {
                            yield return null;
                        }
                        spriterender.sprite = sprite;
                    }
                    else
                    {
                        spriterender.sprite = null;
                    }
                }
            }
            else
            {
                foreach (var pair in spriterenderdict)
                {
                    //获取部件
                    var spriterender = pair.Value;
                    if (string.IsNullOrEmpty(partResName) == false)
                    {
                        bool loadFinish = false;
                        Sprite sprite = null;
                        //单独部件
                        PartResourceMgr.Instance.AsyncGetPartSpriteByPartResName(partResName, (path, obj, param) =>
                        {
                            loadFinish = true;
                            sprite = obj as Sprite;
                        });
                        while (loadFinish == false)
                        {
                            yield return null;
                        }
                        spriterender.sprite = sprite;
                    }
                    else
                    {
                        spriterender.sprite = null;
                    }

                }
            }
        }
        if (callback != null)
        {
            callback();
        }
    }

    //根据部件和部件资源名刷新部件显示
    public void ReFreshPart(EPartType part, string partResName, SexType sex)
    {
        //获取精灵渲染器
        var spriterenderdict = GetSpriteRendersByPartType(part, sex);
        if (spriterenderdict != null && spriterenderdict.Count > 0)
        {
            if (spriterenderdict.Count > 1)
            {
                //说明为组部件
                foreach (var pair in spriterenderdict)
                {
                    //获取部件
                    var spriterender = pair.Value;
                    if (string.IsNullOrEmpty(partResName) == false)
                    {
                        //单独部件
                        var sprite = PartResourceMgr.Instance.GetPartSpriteByPartObjTypeAndWholeResName(pair.Key, partResName);
                        spriterender.sprite = sprite;
                    }
                    else
                    {
                        spriterender.sprite = null;
                    }
                }
            }
            else
            {
                foreach (var pair in spriterenderdict)
                {
                    //获取部件
                    var spriterender = pair.Value;
                    if (string.IsNullOrEmpty(partResName) == false)
                    {

                        //单独部件
                        var sprite = PartResourceMgr.Instance.GetPartSpriteByPartResName(partResName);
                        spriterender.sprite = sprite;
                    }
                    else
                    {
                        spriterender.sprite = null;
                    }

                }
            }
        }
    }

    //根据部件类型查找组件集
    private Dictionary<EPartObjType, SpriteRenderer> GetSpriteRendersByPartType(EPartType type, SexType sex)
    {
        Dictionary<EPartObjType, SpriteRenderer> result = new Dictionary<EPartObjType, SpriteRenderer>();
        //部件类型转部件物体类型
        EPartObjType[] types = DataRelationMgr.Instance.GetPartObjTypesFromPartType(type);
        var curpaintRenders = paintRenders[sex];
        for (var i = 0; i < types.Length; i++)
        {
            var objtype = types[i];
            SpriteRenderer render = null;
            curpaintRenders.TryGetValue(objtype, out render);
            if (render != null)
            {
                result.Add(objtype, render);
            }
        }
        return result;
    }



}
