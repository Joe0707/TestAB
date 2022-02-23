using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorAnimController : MonoBehaviour
{
    public float m_WalkSpeed = 10f;
    [Tooltip("走路音效")]
    public AudioClip m_AudioClipWalkL;
    public AudioClip m_AudioClipWalkR;
    [Tooltip("走路音效间隔")]
    public float m_WalkAudioInterval = 0.5f;
    [Tooltip("死亡音效")]
    public AudioClip m_AudioClipDie;
    [Tooltip("死亡音效延时")]
    public float m_DieAudioDelay = 0.2f;
    [Tooltip("攻击音效")]
    public AudioClip m_AudioClipAttack;
    [Tooltip("攻击音效延时")]
    public float m_AttackAudioDelay = 0.1f;

    Animator mAnimator = null;
    AudioSource mAudioSrcWalkL; //脚步左播放组件
    AudioSource mAudioSrcWalkR; //脚步右播放组件
    AudioSource mAudioSrcDefault; //默认播放组件

    void Start()
    {
        mAnimator = gameObject.GetComponentInChildren<Animator>();
        if (mAnimator == null)
        {
            Debug.LogError("No animator component on the Acotr object: " + name);
        }
        //创建音效播放组件
        mAudioSrcWalkL = gameObject.AddComponent<AudioSource>();
        mAudioSrcWalkL.clip = m_AudioClipWalkL;
        mAudioSrcWalkR = gameObject.AddComponent<AudioSource>();
        mAudioSrcWalkR.clip = m_AudioClipWalkR;
        mAudioSrcDefault = gameObject.AddComponent<AudioSource>();
    }

    //攻击动作
    public void Attack()
    {
        if (mAnimator != null)
            mAnimator.SetTrigger("Attack");
        //播放特效
        var eff = EffectCreator.CreateEffect("LargeSlash");
        GameObject.Destroy(eff, 1);
        eff.transform.position = transform.position;
        eff.transform.rotation = transform.rotation;
        //音效
        mAudioSrcDefault.clip = m_AudioClipAttack;
        mAudioSrcDefault.PlayDelayed(m_AttackAudioDelay);
    }

    //走到某地
    Coroutine mWalkCoroutine = null;
    public void WalkTo(Vector3 toWorlPos, System.Action onWalkEndAction)
    {
        WalkTo(new Vector3[] { toWorlPos }, onWalkEndAction);
    }
    public void WalkTo(Vector3[] toWorldPosList, System.Action onWalkEndAction)
    {
        if (toWorldPosList.Length == 0)
            return;
        if (mAnimator == null)
            return;
        FaceToPos(toWorldPosList[0]);
        if (mWalkCoroutine != null)
            StopCoroutine(mWalkCoroutine);
        mWalkCoroutine = StartCoroutine(_WalkProcess(toWorldPosList, onWalkEndAction));
    }

    IEnumerator _WalkProcess(Vector3[] toWorldPosList, System.Action onWalkEndAction)
    {
        mAnimator.SetBool("Moving", true);
        foreach (var toPos in toWorldPosList)
        {
            //调整朝向
            FaceToPos(toPos);
            //位移
            var dir = toPos - transform.position;
            var distance = dir.magnitude;
            dir.y = 0; //高度不发生变化
            dir.Normalize();
            var speed = m_WalkSpeed * transform.lossyScale.x;
            //走路声音
            float walkTime = 0f; //走路的时间
            bool walkLAudio = true;
            while (distance > 0)
            {
                var moveDelta = speed * Time.deltaTime;
                if (moveDelta > distance)
                    moveDelta = distance;
                transform.position = transform.position + dir * moveDelta;
                distance -= moveDelta;
                //走路声音
                if (walkTime == 0)
                {
                    if (walkLAudio)
                        mAudioSrcWalkL.Play();
                    else
                        mAudioSrcWalkR.Play();
                    walkLAudio = !walkLAudio;
                }
                walkTime += Time.deltaTime;
                if (walkTime > m_WalkAudioInterval)
                    walkTime = 0;
                yield return null;
            }
        }
        mAnimator.SetBool("Moving", false);
        if (onWalkEndAction != null)
            onWalkEndAction();
        mWalkCoroutine = null;
    }
    //被击
    Coroutine mBehitCoroutine = null;
    public void Behit(float delay)
    {
        if (mAnimator == null)
            return;
        if (mBehitCoroutine != null)
            StopCoroutine(mBehitCoroutine);
        mBehitCoroutine = StartCoroutine(DelayBehitAnim(delay));
    }

    IEnumerator DelayBehitAnim(float delay)
    {
        yield return new WaitForSeconds(delay);
        mAnimator.SetTrigger("Behit");
        mBehitCoroutine = null;
        //特效
        var eff = EffectCreator.CreateEffect("Behit");
        eff.transform.position = transform.position;
        GameObject.Destroy(eff, 2f);
    }

    //死亡
    public void Die(float delay = 0)
    {
        StartCoroutine(DelayDieAnim(delay));
    }

    IEnumerator DelayDieAnim(float delay)
    {
        if (delay > 0)
            yield return new WaitForSeconds(delay);
        if (mAnimator != null)
            mAnimator.SetBool("Dead", true);
        //音效
        mAudioSrcDefault.clip = m_AudioClipDie;
        mAudioSrcDefault.PlayDelayed(m_DieAudioDelay);
        //特效
        var eff = EffectCreator.CreateEffect("Die");
        eff.transform.position = transform.position;
        GameObject.Destroy(eff, 2f);
    }

    //复活
    public void Relife()
    {
        if (mAnimator != null)
            mAnimator.SetBool("Dead", false);
    }

    //格挡
    public void Block()
    {
        if (mAnimator != null)
            mAnimator.SetTrigger("Block");
    }

    //特殊待机动作
    public void SpecialIdle()
    {
        if (mAnimator != null)
            mAnimator.SetTrigger("SpecialIdle");
    }

    //朝向某个位置
    public void FaceToPos(Vector3 toWorldPos)
    {
        var dir = toWorldPos - transform.position;
        FaceToDir(dir);
    }

    //朝向某个方向
    public void FaceToDir(Vector3 toDir)
    {
        toDir.y = 0;
        var angle = Vector3.Angle(Vector3.forward, toDir);
        if (toDir.x < 0)
            angle = -angle;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
