using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//延时任务安排器
public class TaskScheduler : MonoBehaviour {

    class Task
    {
        public Action mAction;
        public float mTimeLeft;
        public bool mUseFixedTime;
    }
    public static TaskScheduler mInstance = null;
    private List<Task> mTaskList = new List<Task>();

    void Awake()
    {
        mInstance = this;
    }

    //更新
	void Update () {
        //走时
        int i = 0;
        while (i < mTaskList.Count)
        {
            var task = mTaskList[i];
            //走时
            if (task.mUseFixedTime == true)
                task.mTimeLeft -= Time.fixedDeltaTime;
            else
                task.mTimeLeft -= Time.deltaTime;
            if (task.mTimeLeft <= 0)
            {//时间到，处理
                mTaskList.RemoveAt(i);
                try
                {
                    task.mAction();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            }
            else
                i++;
        }
    }

    //安排一个任务
    public static void Schedule(Action action, float time, bool useFixedTime = false)
    {
        if (mInstance == null)
        {
            Debug.LogError("TaskScheduler is not initialized. Add it to a Global GameObject");
            return;
        }
        var task = new Task();
        task.mAction = action;
        task.mTimeLeft = time;
        task.mUseFixedTime = useFixedTime;
        mInstance.mTaskList.Add(task);
    }


}
