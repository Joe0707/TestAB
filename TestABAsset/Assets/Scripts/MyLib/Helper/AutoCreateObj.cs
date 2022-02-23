using UnityEngine;
using System.Collections;

public class AutoCreateObj : MonoBehaviour {
    [System.Serializable]
    public class ObjData
    {
        public GameObject mPrefab = null;  //预制
        public Transform mAnchor = null;//父节点,或是参考结点
        public bool mIsChildOfAnchor;//是否是子物体
        public Vector3 mRelativePos = Vector3.zero; //
        public Vector3 mRelativeAngles = Vector3.zero;//
        public float mCreateTime = 0;//创建时间点
        public float mLifeTime = 0;//0表示永久存在
        public string mConditionEvent = "";//触发条件, 当收到这个名字的事件，才会触发
        public bool mEatEvent = false;//创建时是否吃掉出发条件。
        
        private bool mCreated = false;//状态:是否已经创建过了
        public bool IsCreated() { return mCreated; }
        public void SetCreateState(bool created) { mCreated = created; }

    };

    public ObjData[] objDataList;//创建对象的数据
    public bool autoUpdateTime = true;//自动累加时间，如果否，则由SetElapsedTime控制
    public string dynamicObjKey = "";//如果创建的对象是DynamicObj，则使用这个key
    private float elapsedTime = 0;//当前运行时间
    public bool destroyWhenFinish = false;//运行完毕是否自动销毁
    private float latestTime = 0.1f;//最后一个时间
    private ArrayList mEvents = new ArrayList();//当前的事件

	// Use this for initialization
	void Start ()
    {
        //保存下来最后一个时间点
        for(int i = 0; i < objDataList.Length; i++)
        {
            if (objDataList[i].mCreateTime > latestTime)
                latestTime = objDataList[i].mCreateTime;
            latestTime += 0.1f;
        }
	}
	// Update is called once per frame
	void Update ()
    {
        if (autoUpdateTime == false)
            return;
        if(elapsedTime < latestTime)
        {//仍在运行中
            elapsedTime += Time.deltaTime;
            foreach (ObjData objData in objDataList)
            {
                if(elapsedTime > objData.mCreateTime && objData.IsCreated() == false)
                {
                    if(objData.mConditionEvent == "" || (objData.mConditionEvent != "" && mEvents.Contains(objData.mConditionEvent) == true))
                        CreateObj(objData);
                }
            }
        }
        else if(destroyWhenFinish)
        {//运行完毕，自动销毁
            Destroy(gameObject);
        }
    }

    //创建对象
    void CreateObj(ObjData objData)
    {
        if (objData.IsCreated() == true)
            return;
        objData.SetCreateState(true);
        if (objData.mPrefab == null)
        {
            Debug.LogError("AutoCreateObj: obj data error:Prefab can't be null");
            return;
        }
        if (objData.mAnchor == null)
        {
            Debug.LogError("AutoCreateObj: obj data error:Anchor can't be null");
            return;
        }
        GameObject newObj = (GameObject)GameObject.Instantiate(objData.mPrefab, objData.mAnchor.position, objData.mAnchor.rotation);
        if (objData.mIsChildOfAnchor)
        {//子对象
            newObj.transform.parent = objData.mAnchor;
            newObj.transform.localPosition = objData.mRelativePos;
            newObj.transform.localRotation = Quaternion.Euler(objData.mRelativeAngles);
        }
        else
        {//非子对象
            newObj.transform.Rotate(objData.mRelativeAngles);
            Vector3 moveDir = Quaternion.Euler(objData.mRelativeAngles) * objData.mRelativePos;
            newObj.transform.Translate(moveDir);
        }
        //生存时间
        if (objData.mLifeTime > 0)
            Destroy(newObj, objData.mLifeTime);
        //是否抹掉事件参数
        if (objData.mEatEvent == true)
            RemoveEvent(objData.mConditionEvent);
        //是否是DynamicObj, 如果是，设定keyname
        DynamicObj dynamicObj = newObj.GetComponent<DynamicObj>();
        if (dynamicObjKey != "" && dynamicObj != null)
            dynamicObj.keyName = dynamicObjKey;
    }
    public float GetElapsedTime()
    {
        return elapsedTime;
    }
    public void SetElapsedTime(float newTime)
    {
        if (elapsedTime < latestTime)
        {//仍在运行中
            elapsedTime = newTime;
            foreach (ObjData objData in objDataList)
            {
                if (elapsedTime > objData.mCreateTime && objData.IsCreated() == false)
                {
                    if(objData.mConditionEvent == "" || (objData.mConditionEvent != "" && mEvents.Contains(objData.mConditionEvent) == true))
                        CreateObj(objData);
                }
            }
        }
        if (elapsedTime >= newTime && destroyWhenFinish)
        {//运行完毕，自动销毁
            Destroy(gameObject);
        }
    }
    //设定锚点
    public void SetAnchor(Transform anchor)
    {
        if (anchor == null)
            return;
        foreach (ObjData objData in objDataList)
        {
            objData.mAnchor = anchor;
        }
    }
    //增加事件
    public void AddEvent(string eventName)
    {
        if(mEvents.Contains(eventName) == false)
            mEvents.Add(eventName);
    }
    //移除事件
    public void RemoveEvent(string eventName)
    {
        if(mEvents.Contains(eventName) == true)
            mEvents.Remove(eventName);
    }

}
