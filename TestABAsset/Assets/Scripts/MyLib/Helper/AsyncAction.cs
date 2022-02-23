using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
namespace Helper
{
    public class AsyncAction : MonoBehaviour
    {
		private class TaskInfo
		{
			private bool	mIsDone		= false;
			private object	mIsDoneLock	= new object();
			public bool IsDone
			{
				get
				{
					bool rtn;
					lock (mIsDoneLock)
					{
						rtn = mIsDone;
					}
					return rtn;
				}
				set
				{
					lock (mIsDoneLock)
					{
						mIsDone = value;
					}
				}
			}
		}
        private TaskInfo mTaskInfo = null;
		private System.Action	mOnFinishedCallback;
		private Thread mThread = null;

		void OnDestroy()
		{
			if(mThread != null)
				mThread.Abort();
		}
        void Update()
        {
			if (mTaskInfo != null && mTaskInfo.IsDone)
            {
                mOnFinishedCallback();
                Destroy(gameObject);
            }
        }
		public static AsyncAction Start(System.Action runAction, System.Action onFinishedCallback)
		{
			var aa = new GameObject("AsyncAction", typeof(AsyncAction)).GetComponent<AsyncAction>();
			aa.Run(runAction, onFinishedCallback);
			return aa;
		}

        void Run(System.Action runAction, System.Action onFinishedCallback)
		{
			this.mOnFinishedCallback = onFinishedCallback;

			mTaskInfo = new TaskInfo();
			mThread = new Thread(() =>
			{
				runAction();
                mTaskInfo.IsDone = true;
				mThread = null;
			});

			mThread.Start();
		}

		public void Stop()
		{
			try{
                if (mThread != null)
                    mThread.Abort();
            }
			catch(System.Exception e)
			{
				Debug.Log(e.ToString());
			}
        }
    }
}
