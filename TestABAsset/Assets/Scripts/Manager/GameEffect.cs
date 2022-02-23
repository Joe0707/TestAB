using UnityEngine;
using System.Collections;
public class GameEffect : MonoBehaviour
{
    //配置文件
    // public conf_effect conf { get; private set; }
    //粒子系统
    ParticleSystem[] ps;
    Animator mAnimator;
    //播放时间
    float playTime;
    //跟随物体，如果此物体不为空，特效会跟随父物体移动，直到父物体变为null
    public GameObject parent;
    public GameObject effectObj; //特效物体
    private Vector3 ogLocalPos = Vector3.zero;//原始本地位置
    public Vector3 OgLocalPos
    {
        get
        {
            // if (ogLocalPos == Vector3.zero)
            // {
            //     return transform.position;
            // }
            return ogLocalPos;
        }
    }
    private Quaternion ogLocalRotation = Quaternion.identity;
    public Quaternion OgLocalRotation
    {
        get
        {
            // if (ogLocalRotation == Quaternion.identity)
            // {
            //     return transform.rotation;
            // }
            return ogLocalRotation;
        }
    }

    private int delayFrame = 0;
    private int curFrame = 0;
    private bool startPlay = false;
    private bool psRealPlay = false;//粒子系统实际开始播放
    private bool keepParentPosition = true;//保持位置跟随父节点
    public void Init(GameObject effectObj)
    {
        // this.conf = conf;
        // ps = transform.GetComponent<ParticleSystem>();
        if (ps == null) ps = transform.GetComponentsInChildren<ParticleSystem>();
        if (ps == null) Debug.LogError("没有粒子系统");
        if (mAnimator == null) mAnimator = transform.GetComponentInChildren<Animator>();
        effectObj.SetActive(false);
        gameObject.SetActive(false);
        this.ogLocalRotation = transform.rotation;
        this.ogLocalPos = transform.position;
        this.effectObj = effectObj;
    }

    //获取粒子系统
    public ParticleSystem[] GetParticalSystem()
    {
        return this.ps;
    }
    public void Play(float scale, int delayFrame = 0, bool keepparentposition = true, GameObject parent = null)
    {
        gameObject.SetActive(true);
        SetScale(transform, scale);
        this.delayFrame = delayFrame;
        playTime = 0;
        curFrame = 0;
        startPlay = true;
        keepParentPosition = keepparentposition;
        //初始化位置
        if (parent != null)
        {
            this.transform.parent = parent.transform;
            this.parent = parent;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            // var parenttransform = parent.transform;
            // transform.position = parenttransform.position + parenttransform.rotation * ogLocalPos;
            // transform.rotation = parenttransform.rotation * OgLocalRotation;
            // this.parent = parent;
        }
    }

    public void SetScale(Transform t, float scale)
    {
        // for (int i = 0; i < t.childCount; i++)
        // {
        //     SetScale(t.GetChild(i), scale);
        // }
        t.localScale = new Vector3(scale, scale, scale);
    }

    void FixedUpdate()
    {
        if (startPlay)
        {
            curFrame++;
            if (psRealPlay == true)
            {
                playTime += Time.deltaTime;
                // if (parent != null && keepParentPosition)
                // {
                //     var parenttransform = parent.transform;
                //     transform.position = parenttransform.position + parenttransform.rotation * ogLocalPos;
                //     transform.rotation = parenttransform.rotation * OgLocalRotation;
                // }
                if (CheckIsFXFinish())
                {
                    Die();
                    return;
                }
                // if (playTime >= ps.main.startLifetime.constant)
                // {
                //     Die();
                //     return;
                // }
            }
            if (psRealPlay == false && curFrame >= delayFrame)
            {
                PlayFX();
            }
        }
    }
    //检查特效是否播放结束
    bool CheckIsFXFinish()
    {
        var psfinish = true;
        for (var i = 0; i < ps.Length; i++)
        {
            var psitem = ps[i];
            psfinish = psfinish && psitem.isStopped;
        }
        var animatorfinish = true;
        if (mAnimator != null)
        {
            var curstateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);
            animatorfinish = curstateInfo.normalizedTime >= 1;
        }
        return animatorfinish && psfinish;
    }
    //特效播放
    void PlayFX()
    {
        // //特效进行播放
        // for (var i = 0; i < ps.Length; i++)
        // {
        //     var psitem = ps[i];
        //     psitem.Play();
        // }
        // if (mAnimator != null)
        // {
        //     //动画激活
        //     mAnimator.enabled = true;
        // }
        //特效进行播放
        effectObj.SetActive(true);
        psRealPlay = true;
    }

    // public void SetParent(GameObject obj)
    // {
    //     this.parent = obj;
    // }

    public void Die()
    {
        if (parent != null)
        {
            transform.parent = null;
            parent = null;
        }
        playTime = 0;
        curFrame = 0;
        startPlay = false;
        psRealPlay = false;
        effectObj.SetActive(false);
        gameObject.SetActive(false);
    }

    //是否是激活的
    public bool isActive()
    {
        return gameObject.activeSelf;
    }
    //停止
    public virtual void Stop()
    {
        //停止特效
        // for (var i = 0; i < ps.Length; i++)
        // {
        //     ps[i].Stop();
        // }
        Die();
    }
    void OnDestroy()
    {
    }

    public void Dispose()
    {
        parent = null;
        ogLocalPos = Vector3.zero;
        ps = null;
        mAnimator = null;
        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
}

