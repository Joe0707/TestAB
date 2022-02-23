using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
//播放动画项
public class AnimatorItem
{
    public AnimatorItem(Animator animator, string trigger, float delayTime)
    {
        this.animator = animator;
        this.trigger = trigger;
        this.delayTime = delayTime;
    }
    public Animator animator;//动画播放器
    public string trigger;//动画名
    public float delayTime;//动画之间的延迟事件
}
//动画管理器
public class AnimatorMgr : MonoSingleton<AnimatorMgr>
{
    //动画播放序列
    private Queue<AnimatorItem> mAnimationQueue = new Queue<AnimatorItem>();
    private bool isPlaying = false;
    public void AddSequenceAnimator(AnimatorItem item)
    {
        mAnimationQueue.Enqueue(item);
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false && mAnimationQueue.Count > 0)
        {
            var item = mAnimationQueue.Dequeue();
            PlayAnimationCoroutine(item);
        }
        // Task.Delay(1).GetAwaiter()
    }

    /// <summary>
    /// 协程播放动画
    /// </summary>
    /// <param name="item"></param>
    public void PlayAnimationCoroutine(AnimatorItem item)
    {
        isPlaying = true;
        StartCoroutine(DelayPlayAnimation(item));
    }
    /// <summary>
    /// 延迟播放动画
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    IEnumerator DelayPlayAnimation(AnimatorItem item)
    {
        yield return new WaitForSeconds(item.delayTime);
        item.animator.SetTrigger(item.trigger);
        isPlaying = false;
    }

}
