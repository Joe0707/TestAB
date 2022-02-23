using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; protected set; }
    [Tooltip("离目标最近的距离")]
    public float m_NearDistance = 50;
    [Tooltip("离目标最远的距离")]
    public float m_FarDistance = 100;
    [Tooltip("Y最低点")]
    public float m_LowestPosY = 30;
    [Tooltip("Y最高点")]
    public float m_HighestPosY = 60;
    [Tooltip("摄像机移动速度")]
    public float m_MoveSpeed = 30;
    [Tooltip("原始Y位置")]
    public float m_OriginY = 0;
    [Tooltip("左边界物体")]
    public GameObject m_LeftEdgeObj;
    [Tooltip("右边界物体")]
    public GameObject m_RightEdgeObj;
    [Tooltip("上边界物体")]
    public GameObject m_FarEdgeObj;
    [Tooltip("下边界物体")]
    public GameObject m_NearEdgeObj;
    [Tooltip("震动幅度")]
    public float m_ShakeRange = 0.2f;
    [Tooltip("滑轮移动速度")]
    public float m_WheelMoveCamSpeed = 25;
    [Tooltip("摄像头播放移动的时间")]
    public float m_CameraPlayMoveTime = 1f;
    [Tooltip("摄像头播放移动速度")]
    public float m_CameraPlayMoveSpeed = 35;
    private Vector3 mLimitEdgePos = Vector3.zero;
    public Camera m_EdgeCheckCamera;
    [Tooltip("相机移动插值系数")]
    public float m_LerpScale = 0.1f;
    //控制状态
    enum EControlState
    {
        Default, //默认模式
        Manual, //手动
        LookAtPos, //瞄准位置
        FollowTarget, //跟随目标
        Shaking, //震屏中
    }
    //相机控制状态
    enum ECameraControlState
    {
        None,//无操作
        Move,//平移
        PinchAndMove,//缩放+平移
        Scale//放缩
    }

    //摄像机高度
    public enum EAltitude
    {
        Lowest,
        Low,
        Middle,
        High,
        Highest,
    }

    Vector3[] mRelativePositions; //和目标的相对位置与设点

    Camera mCamera; //摄像机
    EControlState mControlState; //控制状态
    EAltitude mCurAltitude; //当前的距离
    Vector3 mMoveToPos; //摄像机要移动到的目标位置    
    Vector3 mLookAtPos; //摄像机要看的位置
    GameObject mFollowTarget; //跟随的目标
    float mMoveToDistance; //摄像机还要移动的距离
    Vector3 mTargetCameraXZDir; //目标物体到摄像机到方向（只包含XY）
    float mCameraMinHeight;//摄像机最小高度
    float mCameraMaxHeight;//摄像机最大高度
    float mCameraPlayMinHeight;//摄像机播放特写的最小高度
    ECameraControlState mCameraControlState;//相机控制状态
    Vector3 mLastPointerPos;//指针最后的位置
    bool mIsScaleBegin = false;//放缩开始
    float mScaleDistance = 0;//放缩开始的记录长度
    private Coroutine mFollowTargetCoroutine = null;//跟随目标协程
    public float m_CameraSmoothMoveScale = 0.2f;//相机平滑移动比例
    private List<CameraEdgeValue> mEdgeValueList = new List<CameraEdgeValue>();//摄像机边界值列表
    private Vector3 mCameraPosition = Vector3.zero;
    private Vector3 mCameraRotation = Vector3.zero;
    private float mCameraSize = 0;
    public Camera m_SecondCamera;//第二点击相机 用于检测格子点击为了支持凹凸比较大的地形
    private int mGroundLayer = 1; //地面层级
    void Awake()
    {
        mGroundLayer = 1 << LayerMask.NameToLayer("Default");
        Instance = this;
        mCamera = GetComponent<Camera>();
        //计算摄像机相对于目标点的方向（只包含XY）
        mTargetCameraXZDir = transform.position.normalized;
        mTargetCameraXZDir.y = 0;
        //计算预设点
        int altitudeCount = System.Enum.GetValues(typeof(EAltitude)).Length;
        mRelativePositions = new Vector3[altitudeCount];
        //计算步长
        float yStep = (m_HighestPosY - m_LowestPosY) / (altitudeCount - 1); //高度的步长
        float distStep = (m_FarDistance - m_NearDistance) / (altitudeCount - 1); //距离的步长
                                                                                 //计算每个点
        for (var i = 0; i < altitudeCount; i++)
        {
            var pos = Vector3.zero;
            var y = m_LowestPosY + i * yStep; //高度 
            var dist = m_NearDistance + i * distStep; //摄像机和目标点的距离
                                                      //计算这个点的坐标
            var xzDist = Mathf.Sqrt(Mathf.Pow(dist, 2) - Mathf.Pow(y, 2));
            pos = mTargetCameraXZDir * xzDist + new Vector3(0, y, 0);
            mRelativePositions[i] = pos;
        }

        // //加载摄像机最小高度
        // mCameraMinHeight = LevelLoader.Instance.CurLevelConfig.CameraMinHeight;
        // mCameraPlayMinHeight = mCameraMinHeight - 5;
    }

    void Update()
    {
        switch (mControlState)
        {
            case EControlState.Manual:
                UpdateManualState();
                break;
            case EControlState.LookAtPos:
                UpdateLookAtPosState();
                break;
            case EControlState.FollowTarget:
                UpdateFollowTargetState();
                break;
            case EControlState.Shaking:
                break;
        }

    }

    //禁用边界
    public void DisableEdge()
    {
        GameObject.Destroy(m_LeftEdgeObj);
        m_LeftEdgeObj = null;
        GameObject.Destroy(m_RightEdgeObj);
        m_RightEdgeObj = null;
        GameObject.Destroy(m_FarEdgeObj);
        m_FarEdgeObj = null;
        GameObject.Destroy(m_NearEdgeObj);
        m_NearEdgeObj = null;
        mLimitEdgePos = Vector3.zero;
    }
    //启用最新边界
    public void EnableLastEdge(int index)
    {
        var list = mEdgeValueList;
        //刷新边界物体
        if (list.Count > 0)
        {
            var edgevalue = list[index];
            var edgelist = edgevalue.edgePos;
            if (edgelist.Count == 4)
            {
                var upos = edgelist[0];
                var dpos = edgelist[1];
                var lpos = edgelist[2];
                var rpos = edgelist[3];
                var uobj = new GameObject("upedge");
                uobj.layer = LayerMask.NameToLayer("EdgeObj");
                uobj.transform.position = new Vector3(upos.x, upos.y, upos.z);
                var dobj = new GameObject("downedge");
                dobj.layer = LayerMask.NameToLayer("EdgeObj");
                dobj.transform.position = new Vector3(dpos.x, dpos.y, dpos.z);
                var lobj = new GameObject("leftedge");
                lobj.layer = LayerMask.NameToLayer("EdgeObj");
                lobj.transform.position = new Vector3(lpos.x, lpos.y, lpos.z);
                var robj = new GameObject("rightedge");
                robj.layer = LayerMask.NameToLayer("EdgeObj");
                robj.transform.position = new Vector3(rpos.x, rpos.y, rpos.z);
                m_LeftEdgeObj = lobj;
                m_RightEdgeObj = robj;
                m_FarEdgeObj = uobj;
                m_NearEdgeObj = dobj;
            }
            //刷新边界数据
            var limitEdgePosValue = edgevalue.cameraEdgeLimitPosition;
            mLimitEdgePos = new Vector3(limitEdgePosValue.x, limitEdgePosValue.y, limitEdgePosValue.z);
        }
    }

    //相机设置参数
    public void CameraSetParam(Vector3 targetPosition, Quaternion targetRotation, float targetfov)
    {
        transform.position = targetPosition;
        transform.rotation = targetRotation;
        mCamera.fieldOfView = targetfov;
    }

    //相机平滑移动
    public void CameraSmoothMove(Vector3 targetPosition, Quaternion targetRotation, float targetfov, System.Action callback)
    {
        StartCoroutine(CameraSmoothMoveCoroutine(targetPosition, targetRotation, targetfov, callback));
    }

    //相机平滑移动协程
    IEnumerator CameraSmoothMoveCoroutine(Vector3 targetposition, Quaternion targetRotation, float targetFov, System.Action callback)
    {
        var position = transform.position;
        var rotation = transform.rotation;
        var positionoffsetmagnitude = (targetposition - position).magnitude;
        var rotationoffset = Quaternion.Angle(rotation, targetRotation);
        var fovoffset = targetFov - mCamera.fieldOfView;
        while (positionoffsetmagnitude > 0.5 || rotationoffset > 0.5 || fovoffset > 0.2)
        {
            transform.position = Vector3.Lerp(transform.position, targetposition, m_LerpScale);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, m_LerpScale);
            mCamera.fieldOfView = Mathf.Lerp(mCamera.fieldOfView, targetFov, m_LerpScale);
            yield return new WaitForFixedUpdate();
            positionoffsetmagnitude = (targetposition - transform.position).magnitude;
            rotationoffset = Quaternion.Angle(transform.rotation, targetRotation);
            fovoffset = targetFov - mCamera.fieldOfView;
        }
        if (callback != null)
        {
            callback();
        }
    }
    //更新摄像机信息数据
    public void UpdateCameraInfoData(CameraInfoEntity info)
    {
        //更新摄像机数据
        mCameraMinHeight = info.minHeight;
        mCameraPlayMinHeight = mCameraMinHeight - 5;
        mCameraMaxHeight = info.maxHeight;
        mCameraPosition = info.cameraPosition;
        mCameraRotation = info.cameraRotation;
        mCameraSize = info.cameraSize;
        mEdgeValueList = info.edgeValueList;
    }

    //更新摄像机信息
    public void UpdateCameraInfo(CameraInfoEntity info)
    {
        //更新摄像机数据
        UpdateCameraInfoData(info);
        //初始化摄像机
        gameObject.transform.position = mCameraPosition;
        var cameraRotation = Quaternion.Euler(mCameraRotation.x, mCameraRotation.y, mCameraRotation.z);
        gameObject.transform.rotation = cameraRotation;
        mCamera.fieldOfView = mCameraSize;
        m_EdgeCheckCamera.fieldOfView = mCameraSize;
        //更新边界物体
        var list = mEdgeValueList;
        if (list.Count > 0)
        {
            var edgelist = list[0].edgePos;
            if (edgelist.Count == 4)
            {
                var upposValue = edgelist[0];
                var downposValue = edgelist[1];
                var leftposValue = edgelist[2];
                var rightposValue = edgelist[3];
                var uppos = new Vector3(upposValue.x, upposValue.y, upposValue.z);
                var downpos = new Vector3(downposValue.x, downposValue.y, downposValue.z);
                var leftpos = new Vector3(leftposValue.x, leftposValue.y, leftposValue.z);
                var rightpos = new Vector3(rightposValue.x, rightposValue.y, rightposValue.z);
                var upobj = new GameObject("FarObj");
                upobj.layer = LayerMask.NameToLayer("EdgeObj");
                upobj.transform.position = uppos;
                m_FarEdgeObj = upobj;
                var downobj = new GameObject("NearObj");
                downobj.layer = LayerMask.NameToLayer("EdgeObj");
                downobj.transform.position = downpos;
                m_NearEdgeObj = downobj;
                var leftobj = new GameObject("LeftObj");
                leftobj.layer = LayerMask.NameToLayer("EdgeObj");
                leftobj.transform.position = leftpos;
                m_LeftEdgeObj = leftobj;
                var rightobj = new GameObject("RightObj");
                rightobj.layer = LayerMask.NameToLayer("EdgeObj");
                rightobj.transform.position = rightpos;
                m_RightEdgeObj = rightobj;
            }
            else
            {
                DebugUtil.DebugError("边界数据为空");
                if (m_LeftEdgeObj)
                {
                    GameObject.Destroy(m_LeftEdgeObj);
                    m_LeftEdgeObj = null;
                }
                if (m_RightEdgeObj)
                {
                    GameObject.Destroy(m_RightEdgeObj);
                    m_RightEdgeObj = null;
                }
                if (m_FarEdgeObj)
                {
                    GameObject.Destroy(m_FarEdgeObj);
                    m_FarEdgeObj = null;
                }
                if (m_NearEdgeObj)
                {
                    GameObject.Destroy(m_NearEdgeObj);
                    m_NearEdgeObj = null;
                }
            }
            //刷新边界数据
            var limitEdgePosValue = list[0].cameraEdgeLimitPosition;
            mLimitEdgePos = new Vector3(limitEdgePosValue.x, limitEdgePosValue.y, limitEdgePosValue.z);
        }
    }


    //更新手动状态
    // bool mIsMouseDown;
    //Vector3 mMouseDownCameraPos;
    //获得鼠标位置
    Vector3 GetPointerPosition()
    {
        Vector3 result = Vector3.zero;
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0 && Input.touchCount != 2)
            {
                result = Input.GetTouch(0).position;
            }
            if (Input.touchCount == 2)
            {
                var touch0Pos = Input.GetTouch(0).position;
                var touch1Pos = Input.GetTouch(1).position;
                result = new Vector3((touch0Pos.x + touch1Pos.x) * 0.5f, (touch0Pos.y + touch1Pos.y) * 0.5f, 0);
            }
        }
        else
        {
            result = Input.mousePosition;
        }
        return result;
    }
    //是否点击在UI上
    bool IsPointerOverUIObject(Vector3 pos)
    {
        if (H.GetPointerOverUIObjects(pos) == null || H.GetPointerOverUIObjects(pos).Count == 0)
        {
            return false;
        }
        return true;
    }

    //开始移动
    void StartMove(Vector3 touch1DownPos)
    {
        mLastPointerPos = touch1DownPos;
        mCameraControlState = ECameraControlState.Move;
    }
    //停止移动
    void EndMove()
    {
        mCameraControlState = ECameraControlState.None;
    }

    //更新移动位置
    void UpdateMove()
    {
        var curPointerPos = GetPointerPosition();
        //获取当前和上一个屏幕坐标的世界坐标
        Vector3 lastWorldPos = Vector3.zero;
        var islastsuccess = ScreenToWorld(mLastPointerPos, out lastWorldPos);
        Vector3 curWorldPos = Vector3.zero;
        var iscursuccess = ScreenToWorld(curPointerPos, out curWorldPos);
        if (islastsuccess && iscursuccess)
        {
            //计算水平位移量 
            var horizontalOffset = lastWorldPos - curWorldPos;
            horizontalOffset.y = 0;
            var isOver = CheckCameraNextOverBox(horizontalOffset);
            if (!isOver)
            {
                transform.position = transform.position + horizontalOffset;
            }
        }
        //记录位置
        mLastPointerPos = curPointerPos;
    }

    //开始缩放+平移
    void StartPinchMoveMode(Vector3 touch1Pos, Vector3 touch2Pos)
    {
        mLastPointerPos = new Vector3((touch1Pos.x + touch2Pos.x) * 0.5f, (touch1Pos.y + touch2Pos.y) * 0.5f, 0);
        mScaleDistance = Vector2.Distance(touch1Pos, touch2Pos);
        mCameraControlState = ECameraControlState.PinchAndMove;
    }

    //结束缩放+平移
    void EndPinchMove()
    {
        mCameraControlState = ECameraControlState.None;
    }

    //开始放缩
    void StartScale()
    {
        mCameraControlState = ECameraControlState.Scale;
    }
    //结束放缩
    void EndScale()
    {
        mCameraControlState = ECameraControlState.None;
    }


    //更新缩放
    void UpdateScale()
    {
        var wheelvalue = GetMouseScrollWheel();
        if (wheelvalue != 0)
        {
            Vector3 offset = Vector3.zero;
            var offsetLength = wheelvalue * m_WheelMoveCamSpeed;
            if (mLimitEdgePos != Vector3.zero)
            {
                if (offsetLength < 0)
                {
                    var absOffsetLength = Mathf.Abs(offsetLength);
                    var curcampos = transform.position;
                    var subVector = mLimitEdgePos - curcampos;
                    var dir = Vector3.Normalize(subVector);
                    var distance = subVector.magnitude;
                    if (distance > 0.01)
                    {
                        if (absOffsetLength > distance) absOffsetLength = distance;
                        offset = dir * absOffsetLength;
                    }
                }
                else
                {
                    offset = transform.forward * offsetLength;
                }
            }
            else
            {
                offset = transform.forward * offsetLength;
            }
            //最大最小高度判断
            var minHeight = mCameraMinHeight;
            var maxHeight = mCameraMaxHeight;
            var tempposition = transform.position + offset;
            //不可低于最小值
            if (tempposition.y < minHeight)
            {
                return;
            }
            //不可高于最大值
            if (tempposition.y > maxHeight)
            {
                return;
            }
            transform.position = tempposition;

            if (Application.isMobilePlatform)
            {
                //重新对放缩长度赋值
                mScaleDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            }
        }
    }
    void UpdateManualState()
    {
        if (Application.isMobilePlatform)
        {
            switch (mCameraControlState)
            {
                case ECameraControlState.None://无操作
                    if (Input.touchCount > 0)
                    {
                        var checkTouchPos = Input.GetTouch(0).position;
                        //校验是否点击UI是否点击Player
                        if (IsPointerOverUIObject(checkTouchPos) == false && !IsPointerOverActor(checkTouchPos))
                        {
                            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                            {
                                //第一个手指按下，进入平移状态
                                StartMove(Input.GetTouch(0).position);
                            }
                            else if (Input.touchCount >= 2 && Input.GetTouch(1).phase == TouchPhase.Began)
                            {
                                //两个手指按下，进入缩放平移状态
                                StartPinchMoveMode(Input.GetTouch(0).position, Input.GetTouch(1).position);
                            }
                        }
                    }
                    break;
                case ECameraControlState.Move: //平移
                    if (Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
                    {//抬起第一个手指了
                        EndMove();
                    }
                    else if (Input.touchCount >= 2 && Input.GetTouch(1).phase == TouchPhase.Began)
                    {
                        //又多了一个手指
                        StartPinchMoveMode(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    }
                    else if (Input.touchCount == 0)
                    {//没有手指按着了
                        EndMove();
                    }
                    else if (Input.touchCount > 0)
                        //更新平移
                        UpdateMove();
                    break;
                case ECameraControlState.PinchAndMove://缩放+平移
                    if (Input.touchCount < 2)
                    {//手指小于2了
                        EndPinchMove();
                    }
                    else if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended))
                    {//有手指抬起
                     //结束放缩
                        EndPinchMove();
                        //开始移动
                        //获取还在接触的按键点
                        Vector3 touchPos = Vector3.zero;
                        if (Input.GetTouch(0).phase == TouchPhase.Ended)
                        {
                            touchPos = Input.GetTouch(1).position;
                        }
                        else if (Input.GetTouch(1).phase == TouchPhase.Ended)
                        {
                            touchPos = Input.GetTouch(0).position;
                        }
                        StartMove(touchPos);
                    }
                    else if (Input.touchCount == 0)
                    {//没有手指按着了
                        EndPinchMove();
                    }
                    else
                    {
                        //更新平移和缩放
                        UpdateMove();
                        UpdateScale();
                    }
                    break;
            }
        }
        else
        {
            switch (mCameraControlState)
            {
                case ECameraControlState.None://无操作
                    if (H.IsPointerDown())
                    {
                        var checkpos = GetPointerPosition();
                        if (IsPointerOverUIObject(checkpos) == false && !IsPointerOverActor(checkpos))
                        {
                            StartMove(checkpos);
                        }
                    }
                    else if (!H.IsPointerOverUIObject() && GetMouseScrollWheelBegin())
                    {
                        StartScale();
                        UpdateScale();
                    }
                    break;
                case ECameraControlState.Move: //平移
                    if (H.IsPointerUp())
                    {
                        //如果抬起
                        EndMove();
                    }
                    else
                    {
                        UpdateMove();
                    }
                    break;
                case ECameraControlState.Scale://缩放
                    if (GetMouseScrollWheelEnd())
                    {
                        //结束放缩
                        EndScale();
                    }
                    break;
            }
        }
    }

    //屏幕到场景坐标的转换 通过射线 返回是否转换成功
    bool ScreenToWorld(Vector3 screenPos, out Vector3 worldPos)
    {
        var result = false;
        var ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hitInfo;
        var isHit = Physics.Raycast(ray, out hitInfo);
        result = isHit;
        if (isHit)
        {
            worldPos = hitInfo.point;
        }
        else
        {
            worldPos = Vector3.zero;
        }
        return result;
    }


    //鼠标是否在人物上
    private bool IsPointerOverActor(Vector3 mousepos)
    {
        var result = false;
        var ray = Camera.main.ScreenPointToRay(mousepos);
        RaycastHit hitInfo;
        var layermask = 1 << LayerMask.NameToLayer("ActorSlot");
        if (Physics.Raycast(ray, out hitInfo, 1000, layermask))
        {
            var hitobj = hitInfo.collider.gameObject;
            if (hitobj.tag == "Actor")
            {
                result = true;
            }
        }
        return result;
    }


    //检测下一步是否超出边界
    bool CheckCameraNextOverBox(Vector3 moveDelta)
    {
        var result = false;
        //摄像机预移动
        //再按照摄像机y轴的旋转角度旋转一下
        m_EdgeCheckCamera.transform.position = m_EdgeCheckCamera.transform.position + moveDelta;
        //按照摄像机y轴的旋转做逆旋转测试是否超边界
        var cameraMoveDelta = Quaternion.Euler(0, -m_EdgeCheckCamera.transform.rotation.eulerAngles.y, 0) * moveDelta;
        // m_EdgeCheckCamera.transform.position = m_EdgeCheckCamera.transform.position + cameraMoveDelta;
        if (m_LeftEdgeObj != null && m_RightEdgeObj != null && m_FarEdgeObj != null && m_NearEdgeObj != null)
        {
            //判断边界
            if (m_EdgeCheckCamera.WorldToViewportPoint(m_LeftEdgeObj.transform.position).x > 0 && cameraMoveDelta.x < 0)
                result = true;
            else if (m_EdgeCheckCamera.WorldToViewportPoint(m_RightEdgeObj.transform.position).x < 1 && cameraMoveDelta.x > 0)
                result = true;
            if (m_EdgeCheckCamera.WorldToViewportPoint(m_FarEdgeObj.transform.position).y < 1 && cameraMoveDelta.z > 0)
                result = true;
            else if (m_EdgeCheckCamera.WorldToViewportPoint(m_NearEdgeObj.transform.position).y > 0 && cameraMoveDelta.z < 0)
                result = true;
        }
        //重置位置
        m_EdgeCheckCamera.transform.position = transform.position;
        return result;
    }
    //检测相机下一个位置是否超出边界
    bool CheckCameraNextPositionOverBox(Vector3 offset)
    {
        var result = false;
        if (m_EdgeCheckCamera)
        {
            //计算相机空间的偏移
            var cameraSpaceOffset = m_EdgeCheckCamera.worldToCameraMatrix.MultiplyVector(offset);
            //摄像机预移动
            m_EdgeCheckCamera.transform.position = m_EdgeCheckCamera.transform.position + offset;
            if (m_LeftEdgeObj != null && m_RightEdgeObj != null && m_FarEdgeObj != null && m_NearEdgeObj != null)
            {
                //判断边界
                if (m_EdgeCheckCamera.WorldToViewportPoint(m_LeftEdgeObj.transform.position).x > 0 && (cameraSpaceOffset.x < 0 || cameraSpaceOffset.z > 0))
                    result = true;
                else if (m_EdgeCheckCamera.WorldToViewportPoint(m_RightEdgeObj.transform.position).x < 1 && (cameraSpaceOffset.x > 0 || cameraSpaceOffset.z > 0))
                    result = true;
                if (m_EdgeCheckCamera.WorldToViewportPoint(m_FarEdgeObj.transform.position).y < 1 && (cameraSpaceOffset.y > 0 || cameraSpaceOffset.z > 0))
                    result = true;
                else if (m_EdgeCheckCamera.WorldToViewportPoint(m_NearEdgeObj.transform.position).y > 0 && (cameraSpaceOffset.y < 0 || cameraSpaceOffset.z > 0))
                    result = true;
            }
            //重置位置
            m_EdgeCheckCamera.transform.position = transform.position;
        }
        return result;
    }
    //鼠标滚轮开始
    bool GetMouseScrollWheelBegin()
    {
        var result = false;
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount == 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
                {
                    result = true;
                }
            }
        }
        else
        {
            var movedelta = Input.GetAxis("Mouse ScrollWheel");
            if (movedelta != 0)
            {
                result = true;
            }
        }
        return result;
    }
    //鼠标滚轮结束
    bool GetMouseScrollWheelEnd()
    {
        var result = false;
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount != 2)
            {
                result = true;
            }
        }
        else
        {
            var movedelta = Input.GetAxis("Mouse ScrollWheel");
            if (movedelta == 0)
            {
                result = true;
            }
        }
        return result;
    }

    void UpdateCameraByWheel()
    {
        if (mIsScaleBegin == false)
        {
            if (!H.IsPointerOverUIObject() && GetMouseScrollWheelBegin())
            {
                //开始放缩
                mIsScaleBegin = true;
                //记录下来开始放缩的长度
                if (Application.isMobilePlatform)
                {
                    if (Input.touchCount == 2)
                    {
                        mScaleDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                    }
                }
            }
        }
        if (mIsScaleBegin)
        {
            //开始放缩
            if (GetMouseScrollWheelEnd())
            {
                mIsScaleBegin = false;
                return;
            }
            var wheelvalue = GetMouseScrollWheel();
            if (wheelvalue != 0)
            {
                Vector3 offset = Vector3.zero;
                var offsetLength = wheelvalue * m_WheelMoveCamSpeed;
                if (mLimitEdgePos != Vector3.zero)
                {
                    if (offsetLength < 0)
                    {
                        var absOffsetLength = Mathf.Abs(offsetLength);
                        var curcampos = transform.position;
                        var subVector = mLimitEdgePos - curcampos;
                        var dir = Vector3.Normalize(subVector);
                        var distance = subVector.magnitude;
                        if (distance > 0.01)
                        {
                            if (absOffsetLength > distance) absOffsetLength = distance;
                            offset = dir * absOffsetLength;
                        }
                    }
                    else
                    {
                        offset = transform.forward * offsetLength;
                    }
                }
                else
                {
                    offset = transform.forward * offsetLength;
                }
                //最大最小高度判断
                var minHeight = mCameraMinHeight;
                var maxHeight = mCameraMaxHeight;
                var tempposition = transform.position + offset;
                //不可低于最小值
                if (tempposition.y < minHeight)
                {
                    return;
                }
                //不可高于最大值
                if (tempposition.y > maxHeight)
                {
                    return;
                }
                transform.position = tempposition;

                if (Application.isMobilePlatform)
                {
                    //重新对放缩长度赋值
                    mScaleDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                }
            }
        }
    }
    //进入手动控制模式
    public void EnterManualState()
    {
        mControlState = EControlState.Manual;
    }

    //退出手动控制模式
    public void QuitManualState()
    {
        mControlState = EControlState.Default;
        mCameraControlState = ECameraControlState.None;
        mIsScaleBegin = false;
        mScaleDistance = 0;
        mLastPointerPos = Vector3.zero;
        // mIsMouseDown = false;
    }

    //看某点
    public void LookAtPos(Vector3 lookAtPos, EAltitude atAltitude)
    {
        mControlState = EControlState.LookAtPos;
        mCurAltitude = atAltitude;
        //计算要移动到的点
        mMoveToPos = lookAtPos + mRelativePositions[(int)atAltitude];
        mLookAtPos = lookAtPos;
    }
    /// <summary>
    /// 移动到某个位置
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="callback"></param>
    public void MoveToPos(Vector3 pos, System.Action callback)
    {
        StartCoroutine(MoveToPosCoroutine(pos, callback));
    }
    /// <summary>
    /// 移动到某一位置协程
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    IEnumerator MoveToPosCoroutine(Vector3 pos, System.Action callback)
    {
        var ogCameraPos = transform.position;
        var ogX = ogCameraPos.x;
        var ogY = ogCameraPos.y;
        var ogZ = ogCameraPos.z;
        var targetPointX = pos.x;
        var targetPointY = pos.y;
        var targetPointZ = pos.z;
        //计算帧数
        var frameCount = m_CameraPlayMoveTime / Time.deltaTime;
        var offset = pos - ogCameraPos;
        var offsetDistance = offset.magnitude; //需要平移的距离
        var frameNumber = 0;
        while (offsetDistance > 0.5f)
        {
            var t = frameNumber / frameCount;
            transform.position = new Vector3(Mathf.SmoothStep(ogX, targetPointX, t), Mathf.SmoothStep(ogY, targetPointY, t), Mathf.SmoothStep(ogZ, targetPointZ, t));
            offset = pos - transform.position;
            offsetDistance = offset.magnitude; //需要平移的距离
            //等一帧
            yield return null;
            frameNumber++;
        }
        if (callback != null) callback();
    }

    /// <summary>
    /// 聚焦位置
    /// </summary>
    /// <param name="focusPos">聚焦点</param>
    /// <param name="onlyHorizontal">只平移</param>
    /// <param name="callback">回调</param>
    /// <param name="isPlayAttack">是否是播放攻击</param>
    public void Focus2Pos(Vector3 focusPos, bool onlyHorizontal, bool isPlayAttack, System.Action callback)
    {
        float height = -1;
        if (isPlayAttack)
        {
            height = mCameraPlayMinHeight;
        }
        else
        {
            height = mCameraMinHeight;
        }
        StartCoroutine(Focus2PosCoroutine(focusPos, height, onlyHorizontal, callback));
    }

    // /// <summary>
    // /// /// 聚焦到位置协程
    // /// </summary>
    // /// <param name="focusPos"></param>
    // /// <param name="atAltitude"></param>
    // /// <param name="callback"></param>
    // /// <returns></returns>
    // IEnumerator Focus2PosCoroutine(Vector3 focusPos, bool onlyHorizontal, bool isPlayAttack, System.Action callback)
    // {
    //     //计算距离
    //     Ray cameraRay = mCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
    //     var ogCameraPos = transform.position;
    //     var ogX = ogCameraPos.x;
    //     var ogY = ogCameraPos.y;
    //     var ogZ = ogCameraPos.z;
    //     float distance = 0;
    //     if (onlyHorizontal)
    //     {
    //         distance = Mathf.Abs(ogCameraPos.y - focusPos.y) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机移动位置的到目标点的距离
    //     }
    //     else
    //     {
    //         if (isPlayAttack)
    //         {
    //             distance = Mathf.Abs(mCameraPlayMinHeight - focusPos.y) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机移动位置的到目标点的距离
    //         }
    //         else
    //         {
    //             distance = Mathf.Abs(mCameraMinHeight - focusPos.y) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机移动位置的到目标点的距离
    //         }
    //     }
    //     var dir = -cameraRay.direction;
    //     var targetPoint = focusPos + dir * distance;
    //     var targetPointX = targetPoint.x;
    //     var targetPointY = targetPoint.y;
    //     var targetPointZ = targetPoint.z;
    //     //计算帧数
    //     var playMoveTime = Mathf.Max(0.1f, m_CameraPlayMoveTime);
    //     float frameCount = Mathf.RoundToInt(playMoveTime / Time.fixedDeltaTime);
    //     float frameNumber = 0;
    //     var offset = targetPoint - ogCameraPos;
    //     var offsetDistance = offset.magnitude; //需要平移的距离
    //     while (offsetDistance > 0.5f)
    //     {
    //         float t = frameNumber / frameCount;
    //         transform.position = new Vector3(Mathf.SmoothStep(ogX, targetPointX, t), Mathf.SmoothStep(ogY, targetPointY, t), Mathf.SmoothStep(ogZ, targetPointZ, t));
    //         offset = targetPoint - transform.position;
    //         offsetDistance = offset.magnitude; //需要平移的距离
    //         //等一帧
    //         yield return new WaitForFixedUpdate();
    //         frameNumber += 1;
    //     }
    //     if (callback != null) callback();

    // }

    public void Focus2AbsolutePosition(Vector3 focusPos, System.Action callback, bool checkOverBox = false)
    {
        StartCoroutine(Focus2PosCoroutine(focusPos, focusPos.y, false, callback, checkOverBox));
    }

    /// <summary>
    /// 聚焦到位置
    /// </summary>
    /// <param name="focusPos">聚焦位置</param>
    /// <param name="height">距离0的高度线</param>
    /// <param name="onlyHorizontal">是否水平聚焦</param>
    /// <param name="callback">回调</param>
    /// <param name="checkOverBox">是否检测超出边界</param>
    /// <returns></returns>
    IEnumerator Focus2PosCoroutine(Vector3 focusPos, float height, bool onlyHorizontal, System.Action callback, bool checkOverBox = false)
    {
        //计算距离
        Ray cameraRay = mCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        var ogCameraPos = transform.position;
        var ogX = ogCameraPos.x;
        var ogY = ogCameraPos.y;
        var ogZ = ogCameraPos.z;
        float distance = 0;
        if (onlyHorizontal)
        {
            distance = Mathf.Abs(ogCameraPos.y - focusPos.y) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机移动位置的到目标点的距离
        }
        else
        {
            distance = Mathf.Abs(height - focusPos.y) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机移动位置的到目标点的距离
        }
        var dir = -cameraRay.direction;
        var targetPoint = focusPos + dir * distance;
        var targetPointX = targetPoint.x;
        var targetPointY = targetPoint.y;
        var targetPointZ = targetPoint.z;
        //计算帧数
        var playMoveTime = Mathf.Max(0.1f, m_CameraPlayMoveTime);
        float frameCount = Mathf.RoundToInt(playMoveTime / Time.fixedDeltaTime);
        float frameNumber = 0;
        var offset = targetPoint - ogCameraPos;
        var offsetDistance = offset.magnitude; //需要平移的距离
        while (offsetDistance > 0.5f)
        {
            float t = frameNumber / frameCount;
            var newpos = new Vector3(Mathf.SmoothStep(ogX, targetPointX, t), Mathf.SmoothStep(ogY, targetPointY, t), Mathf.SmoothStep(ogZ, targetPointZ, t));
            if (checkOverBox == true)
            {
                var offsetValue = newpos - transform.position;
                if (CheckCameraNextPositionOverBox(offsetValue) == true)
                {
                    break;
                }
            }
            transform.position = newpos;
            offset = targetPoint - transform.position;
            offsetDistance = offset.magnitude; //需要平移的距离
            //等一帧
            yield return new WaitForFixedUpdate();
            frameNumber += 1;
        }
        if (callback != null) callback();

    }

    // public void Move2Pos(Vector3 pos)

    void UpdateLookAtPosState()
    {
        //先进行平移，让物体处于屏幕中间位置后，再进行距离调整
        var pos = transform.position;
        //先平移摄像机，让目标在屏幕中间
        //计算摄像机朝向与地面交点
        Ray cameraRay = mCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        float cameraRayGroundDistance = (transform.position.y - m_OriginY) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机朝向与地面交点的距离
        var crossPoint = transform.position + cameraRay.direction.normalized * cameraRayGroundDistance; //摄像机与地面的交点
        var hTranslationDir = (mLookAtPos - crossPoint);
        hTranslationDir.y = 0; //平移的方向
        var hTranslationDistance = hTranslationDir.magnitude; //需要平移的距离
        if (hTranslationDistance > 0.5f)
        {//需要平移
            var moveDir = hTranslationDir.normalized;
            //计算移动距离
            float moveDelta = Time.deltaTime * m_MoveSpeed;
            if (moveDelta > hTranslationDistance)
                moveDelta = hTranslationDistance;
            pos += moveDir * moveDelta;
            transform.position = pos;
        }
        // else
        // {//已经平移完成
        //  //移动方向
        //     var moveDir = mMoveToPos - pos;
        //     //计算要移动到距离
        //     mMoveToDistance = (mMoveToPos - transform.position).magnitude;
        //     if (mMoveToDistance > 0.5)
        //     {
        //         //计算移动距离
        //         float moveDelta = Time.deltaTime * m_MoveSpeed;
        //         if (moveDelta > mMoveToDistance)
        //             moveDelta = mMoveToDistance;
        //         mMoveToDistance -= moveDelta;
        //         pos += moveDir.normalized * moveDelta;
        //         transform.position = pos;
        //         //更新朝向
        //         UpdateLookAngle();
        //     }
        // }
    }

    //更新观看的角度
    void UpdateLookAngle()
    {
        //当前摄像机角度
        var euler = transform.rotation.eulerAngles;
        //目标摄像机角度
        var dir = transform.position - mLookAtPos;
        var destXAngle = Vector3.Angle(new Vector3(dir.x, 0, dir.z), dir);
        //设定
        transform.rotation = Quaternion.Euler(destXAngle, euler.y, euler.z);
    }


    //跟随某个物体
    public void FollowTarget(GameObject followTarget, EAltitude atAltitude)
    {
        mControlState = EControlState.FollowTarget;
        mCurAltitude = atAltitude;
        //目标物体
        mFollowTarget = followTarget;

    }

    //更新瞄准目标物体模式
    void UpdateFollowTargetState()
    {
        //计算要移动到的点
        mMoveToPos = mFollowTarget.transform.position + mRelativePositions[(int)mCurAltitude];
        mLookAtPos = mFollowTarget.transform.position;
        //先进行平移，让物体处于屏幕中间位置后，再进行距离调整
        var pos = transform.position;
        //先平移摄像机，让目标在屏幕中间
        //计算摄像机朝向与地面交点
        Ray cameraRay = mCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        float cameraRayGroundDistance = transform.position.y / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机朝向与地面交点的距离
        var crossPoint = transform.position + cameraRay.direction.normalized * cameraRayGroundDistance; //摄像机与地面的交点
        var hTranslationDir = (mFollowTarget.transform.position - crossPoint);
        hTranslationDir.y = 0; //平移的方向
        var hTranslationDistance = hTranslationDir.magnitude; //需要平移的距离

        //平移
        {
            var moveDir = hTranslationDir.normalized;
            //计算移动距离
            float moveDelta = Time.deltaTime * m_MoveSpeed;
            if (moveDelta > hTranslationDistance)
                moveDelta = hTranslationDistance;
            pos += moveDir * moveDelta;
            transform.position = pos;
        }
        if (hTranslationDistance < 0.1f)
        {//已经平移完成
         //移动方向
            var moveDir = mMoveToPos - pos;
            //计算要移动到距离
            mMoveToDistance = (mMoveToPos - transform.position).magnitude;
            if (mMoveToDistance > 0.5)
            {
                //计算移动距离
                float moveDelta = Time.deltaTime * m_MoveSpeed;
                if (moveDelta > mMoveToDistance)
                    moveDelta = mMoveToDistance;
                mMoveToDistance -= moveDelta;
                pos += moveDir.normalized * moveDelta;
                transform.position = pos;
                //更新朝向
                UpdateLookAngle();
            }
        }
    }


    Coroutine mShakeCoroutine = null;
    //延迟帧数震屏  
    public void ShakeDelayFrame(int delayframe = 0)
    {
        if (mShakeCoroutine != null)
            return;
        mShakeCoroutine = StartCoroutine(_ShakeAnim((float)delayframe, true));
    }

    public void Shake(float delay = 0)
    {
        if (mShakeCoroutine != null)
            return;
        mShakeCoroutine = StartCoroutine(_ShakeAnim(delay, false));
    }

    //震动动画
    IEnumerator _ShakeAnim(float delay, bool isdelayFrame)
    {
        if (delay > 0)
        {
            if (isdelayFrame)
            {
                while (delay > 0)
                {
                    yield return new WaitForFixedUpdate();
                    delay -= 1.0f;
                }
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
        }
        //记录当前状态
        EControlState oldState = mControlState;
        var oldPos = transform.position;
        //震动参数
        float shakeSpeed = 20f; //震动速度
        Vector3[] shakePosList = new Vector3[5];
        shakePosList[0] = oldPos; shakePosList[0].y += m_ShakeRange * 1f;
        shakePosList[1] = oldPos; shakePosList[1].y -= m_ShakeRange * 0.8f;
        shakePosList[2] = oldPos; shakePosList[2].y += m_ShakeRange * 0.6f;
        shakePosList[3] = oldPos; shakePosList[3].y -= m_ShakeRange * 0.3f;
        shakePosList[4] = oldPos; shakePosList[4].y += m_ShakeRange * 0.2f;
        //震动
        foreach (var toPos in shakePosList)
        {
            var moveDir = toPos - transform.position;
            var totalDistance = moveDir.magnitude;
            moveDir.Normalize();
            var pos = transform.position;
            while (totalDistance > 0)
            {
                var deltaDistance = shakeSpeed * Time.deltaTime;
                if (deltaDistance > totalDistance)
                    deltaDistance = totalDistance;
                totalDistance -= deltaDistance;
                pos += moveDir * deltaDistance;
                transform.position = pos;
                yield return null;
            }
        }
        //恢复状态
        mControlState = oldState;
        transform.position = oldPos;
        mShakeCoroutine = null;
    }

    private Vector2 oldPos1 = Vector2.zero;
    private Vector2 oldPos2 = Vector2.zero;

    //鼠标滚轮/触摸放缩
    public float GetMouseScrollWheel()
    {
        float result = 0;
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount == 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    Vector2 newPos1 = Input.GetTouch(0).position;
                    Vector2 newPos2 = Input.GetTouch(1).position;
                    float distance = Vector2.Distance(newPos1, newPos2);
                    result = distance / mScaleDistance - 1;
                }
            }
        }
        else
        {
            result = Input.GetAxis("Mouse ScrollWheel");
        }
        return result;
    }

    //手势判断
    private bool IsEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        float length1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float length2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (length1 < length2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 聚焦位置
    /// </summary>
    /// <param name="focusPos">聚焦点</param>
    /// <param name="onlyHorizontal">只平移</param>
    /// <param name="callback">回调</param>
    /// <param name="isPlayAttack">是否是播放攻击</param>
    public void StartFocus2Object(GameObject obj, float height)
    {
        QuitManualState();
        mFollowTargetCoroutine = StartCoroutine(Focus2ObjCoroutine(obj, height));
    }

    public void StopFocus2Object()
    {
        if (mFollowTargetCoroutine != null)
        {
            StopCoroutine(mFollowTargetCoroutine);
        }
        EnterManualState();
    }

    /// <summary>
    /// 聚焦到物体
    /// </summary>
    /// <param name="obj">物体</param>
    /// <param name="height">距离0的高度线</param>
    /// <returns></returns>
    IEnumerator Focus2ObjCoroutine(GameObject obj, float height)
    {
        while (true)
        {
            //计算距离
            Ray cameraRay = mCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            var ogCameraPos = transform.position;
            var ogX = ogCameraPos.x;
            var ogY = ogCameraPos.y;
            var ogZ = ogCameraPos.z;
            var focusPos = obj.transform.position;
            float distance = 0;
            distance = Mathf.Abs(height - focusPos.y) / Mathf.Cos(Vector3.Angle(cameraRay.direction, Vector3.down) * Mathf.Deg2Rad); //摄像机移动位置的到目标点的距离
            var dir = -cameraRay.direction;
            var targetPoint = focusPos + dir * distance;
            var targetPointX = targetPoint.x;
            var targetPointY = targetPoint.y;
            var targetPointZ = targetPoint.z;
            var offset = targetPoint - ogCameraPos;
            var offsetDistance = offset.magnitude; //需要平移的距离
            if (offsetDistance > 0.5f)
            {
                var newpos = new Vector3(Mathf.SmoothStep(ogX, targetPointX, m_CameraSmoothMoveScale), Mathf.SmoothStep(ogY, targetPointY, m_CameraSmoothMoveScale), Mathf.SmoothStep(ogZ, targetPointZ, m_CameraSmoothMoveScale));
                var offsetValue = newpos - transform.position;
                if (CheckCameraNextPositionOverBox(offsetValue) == false)
                {
                    transform.position = newpos;
                    offset = targetPoint - transform.position;
                    offsetDistance = offset.magnitude; //需要平移的距离
                }
            }
            //等一帧
            yield return new WaitForFixedUpdate();
        }
    }
    /// <summary>
    /// 获取点击目标,先检测点击地表点，通过地表点
    /// </summary>
    /// <param name="secondcamerahitlayer">第二相机点击层级</param>
    /// <returns></returns>
    public GameObject GetHitTargetInSecondCamera(int secondcamerahitlayer = int.MaxValue)
    {
        var ray = Camera.main.ScreenPointToRay(H.PointerPosition);
        return GetHitTargetInSecondCamera(ray, secondcamerahitlayer);
    }
    public GameObject GetHitTargetInSecondCamera(Ray ray, int secondcamerahitlayer = int.MaxValue)
    {
        GameObject result = null;
        RaycastHit hit;
        if (GetHitTargetInfoInSecondCamera(ray, secondcamerahitlayer, out hit))
        {
            result = hit.collider.gameObject;
        }
        return result;
    }
    public bool GetHitTargetInfoInSecondCamera(Ray ray, int secondcamerahitlayer, out RaycastHit hitInfo)
    {
        bool result = false;
        RaycastHit hit;
        hitInfo = new RaycastHit();
        if (RaycastUtil.Raycast(ray, mGroundLayer, out hit))
        {
            Ray ray2 = new Ray(m_SecondCamera.transform.position, (hit.point - m_SecondCamera.transform.position).normalized);
            result = RaycastUtil.Raycast(ray2, secondcamerahitlayer, out hitInfo);
        }
        return result;
    }

    //获取所有第二相机点击目标
    public GameObject[] GetHitTargetsAllInSecondCamera(int secondcameraHitLayer = int.MaxValue)
    {
        var ray = Camera.main.ScreenPointToRay(H.PointerPosition);
        return GetHitTargetsAllInSecondCamera(ray, secondcameraHitLayer);
    }
    //获取所有第二相机点击目标
    public GameObject[] GetHitTargetsAllInSecondCamera(Ray maincameraRay, int secondcameraHitLayer = int.MaxValue)
    {
        GameObject[] result = null;
        var hits = GetHitTargetsAllInfoInSecondCamera(maincameraRay, secondcameraHitLayer);
        if (hits != null)
        {
            result = new GameObject[hits.Length];
            for (var i = 0; i < hits.Length; i++)
            {
                result[i] = hits[i].collider.gameObject;
            }
        }
        return result;
    }

    public RaycastHit[] GetHitTargetsAllInfoInSecondCamera(Ray maincameraRay, int secondcameraHitLayer = int.MaxValue)
    {
        RaycastHit[] hits = null;
        RaycastHit hit;
        if (RaycastUtil.Raycast(maincameraRay, mGroundLayer, out hit))
        {
            Ray ray2 = new Ray(m_SecondCamera.transform.position, (hit.point - m_SecondCamera.transform.position).normalized);
            hits = Physics.RaycastAll(ray2, 1000, secondcameraHitLayer);
        }
        return hits;
    }
}
