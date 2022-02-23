using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Levels;
using UnityEngine.Events;
//控制状态
enum EControlState
{
    Default, //默认模式
    Manual, //手动
    LookAtPos, //瞄准位置
    FollowTarget, //跟随目标
    Shaking, //震屏中
}

//场景摄像机控制器
public class LevelEditorCameraController : MonoSingleton<LevelEditorCameraController>
{
    // const int MaxWheelValue = 200;//滑轮最大值
    // const int MinWheelValue = 1;//滑轮最小值
    public int mCameraSizeFactor = 10;//摄像机尺寸变化系数
                                      //是否是按下鼠标
    private bool mIsMouseDown;
    public bool mManualController = false; //是否可以手动拖拽摄像机
    public bool m_ManualChangeFOVByWheel = true;//滚轮是否更改fov;
    public bool m_ManualChangeCamByWheel = false;//滚轮是否更改摄像机位置;
    public bool m_ManualChangeCamRotation = false;//是否可以手动更改相机旋转
    public bool m_ManualChangeCamTranslation = true;//是否可以手动更改相机平移
    public bool m_ManualUpWheel2LimitPos = false;//是否手动上滑滚轮到限制位置
                                                 //最后的鼠标位置
    public Camera m_EdgeCheckCamera;//边界检测摄像机
    private Vector3 mLastPointerPos;
    //拖动屏幕的移动系数
    float mDragScreenRatio = 0.05f;
    //摄像机
    private Camera mCamera;
    //左边界物体
    [HideInInspector]
    public GameObject m_LeftEdgeObj;
    //右边界物体
    [HideInInspector]
    public GameObject m_RightEdgeObj;
    //远边界物体
    [HideInInspector]
    public GameObject m_FarEdgeObj;
    //近边界物体
    [HideInInspector]
    public GameObject m_NearEdgeObj;
    private Vector3 mLimitEdgePos = Vector3.zero;
    public GraphicRaycaster m_UIRaycaster;   //UI的射线触发器
    private PointerEventData mEventData; //鼠标事件数据
    private List<RaycastResult> mResultList;//鼠标事件结果
    [HideInInspector]
    public Transform mFightViewTrans;//战斗视角位置
    [HideInInspector]
    public Transform mVerticalViewTrans;//垂直视角位置
    [Tooltip("震动幅度")]
    public float m_ShakeRange = 0.2f;
    private bool mIsRotate = false;
    public float m_RotateSpeed = 10f;//相机旋转的速度
    public float m_WheelMoveCamSpeed = 10f;   //滚轮移动相机的速度
    public UnityAction<float> OnWheel;//滚轮事件
    protected override void OnStart()
    {
        mCamera = GetComponent<Camera>();
        mEventData = new PointerEventData(EventSystem.current);
        mResultList = new List<RaycastResult>();
    }
    //刷新相机信息
    public void UpdateCameraInfo()
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var position = curconfig.CameraPosition;
        var rotation = curconfig.CameraRotation;
        var size = curconfig.CameraSize;
        mCamera.transform.position = new Vector3(position.x, position.y, position.z);
        mCamera.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        mCamera.fieldOfView = size;
        var edgeCamera = GetEdgeCamera();
        if (edgeCamera)
        {
            edgeCamera.fieldOfView = size;
        }
    }

    //根据配置刷新边界信息
    public void UpdateEdgeObj()
    {
        var curconfig = LevelLoader.Instance.CurLevelConfig;
        var list = curconfig.EdgeValueList;
        if (list.Count > 0)
        {
            var edgeposlist = list[0].EdgePos;
            //刷新边界物体
            if (edgeposlist.Count == 4)
            {
                var upos = edgeposlist[0];
                var dpos = edgeposlist[1];
                var lpos = edgeposlist[2];
                var rpos = edgeposlist[3];
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
            else
            {
                GameObject.Destroy(m_LeftEdgeObj);
                m_LeftEdgeObj = null;
                GameObject.Destroy(m_RightEdgeObj);
                m_RightEdgeObj = null;
                GameObject.Destroy(m_FarEdgeObj);
                m_FarEdgeObj = null;
                GameObject.Destroy(m_NearEdgeObj);
                m_NearEdgeObj = null;
            }
            //刷新边界数据
            var limitEdgePosValue = list[0].CameraEdgeLimitPosition;
            mLimitEdgePos = new Vector3(limitEdgePosValue.x, limitEdgePosValue.y, limitEdgePosValue.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mManualController)
        {
            if (m_ManualChangeFOVByWheel)
            {
                UpdateCameraDepth();
            }
            else if (m_ManualChangeCamByWheel)
            {
                UpdateCameraByWheel();
            }
            if (m_ManualChangeCamTranslation)
            {
                UpdateTranslation();
            }
            if (m_ManualChangeCamRotation)
            {
                UpdateRotation();
            }
        }
    }
    //更改为战斗视角
    public void Change2FightView()
    {
        if (mFightViewTrans)
        {
            transform.position = mFightViewTrans.position;
            transform.rotation = mFightViewTrans.rotation;
        }
    }
    //更改为垂直视角
    public void Change2VerticalView()
    {
        if (mVerticalViewTrans)
        {
            transform.position = mVerticalViewTrans.position;
            transform.rotation = mVerticalViewTrans.rotation;
        }
    }

    //鼠标在UI物体上
    private bool IsPointerOverUIObject()
    {
        mResultList.Clear();
        var mousepos = H.PointerPosition;
        mEventData.position = mousepos;
        m_UIRaycaster.Raycast(mEventData, mResultList);
        if (mResultList.Count > 0) return true;
        return false;
    }


    void UpdateCameraByWheel()
    {
        if (!IsPointerOverUIObject())
        {
            var wheelvalue = Input.GetAxis("Mouse ScrollWheel");
            if (wheelvalue != 0)
            {
                Vector3 offset = Vector3.zero;
                var offsetLength = wheelvalue * m_WheelMoveCamSpeed;
                if (m_ManualUpWheel2LimitPos && mLimitEdgePos != Vector3.zero)
                {
                    if (wheelvalue < 0)
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
                var tempposition = transform.position + offset;
                //最大最小高度判断
                var curConfig = LevelLoader.Instance.CurLevelConfig;
                if (curConfig != null)
                {
                    var minHeight = curConfig.CameraMinHeight;
                    var maxHeight = curConfig.CameraMaxHeight;
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
                }
                if (offset != Vector3.zero && OnWheel != null)
                {
                    OnWheel(wheelvalue);
                }
                transform.position = tempposition;
            }
        }
    }



    void UpdateCameraDepth()
    {
        if (!IsPointerOverUIObject())
        {
            var wheelvalue = -Input.GetAxis("Mouse ScrollWheel");
            if (wheelvalue != 0)
            {
                var ogsize = mCamera.fieldOfView;
                wheelvalue *= mCameraSizeFactor;
                var size = mCamera.fieldOfView;
                size += wheelvalue;
                // //上滑
                // if (wheelvalue > 0 && size > MaxWheelValue)
                // {
                //    return;
                // }
                // //下滑
                // else if (wheelvalue < 0 && size < MinWheelValue)
                // {
                //    return;
                // }
                var levelconfig = LevelLoader.Instance.CurLevelConfig;
                if (CheckOverBox() && wheelvalue > 0)
                {
                    //说明超出边界并且是外扩趋势
                    return;
                }
                mCamera.fieldOfView = size;
                var edgeCamera = GetEdgeCamera();
                if (edgeCamera)
                {
                    edgeCamera.fieldOfView = size;
                }
            }
        }
    }
    //获取边界相机
    Camera GetEdgeCamera()
    {
        Camera edgecamera = null;
        if (mCamera.transform.childCount > 0)
        {
            //获得截取边界摄像机
            edgecamera = mCamera.transform.GetChild(0).GetComponent<Camera>();
        }
        return edgecamera;
    }

    void UpdateRotation()
    {
        if (IsPointerOverUIObject() == false && Input.GetMouseButtonDown(1))
        {
            mIsRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            mIsRotate = false;
        }
        if (mIsRotate)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                var hitPos = hitInfo.point;
                transform.RotateAround(hitPos, Vector3.up, m_RotateSpeed * Input.GetAxis("Mouse X"));
                Vector3 originPosition = transform.position;
                Quaternion originRotation = transform.rotation;
                transform.RotateAround(hitPos, transform.right, -m_RotateSpeed * Input.GetAxis("Mouse Y"));
                //如果超出范围则返回
                if (transform.eulerAngles.x < -70 || transform.eulerAngles.x > 70)
                {
                    transform.position = originPosition;
                    transform.rotation = originRotation;
                }
            }
        }
    }

    void UpdateTranslation()
    {
        if (mIsMouseDown == false)
        {
            // print("MouseNotDown");
            // print("IsPointerOverUIObject" + H.IsPointerOverUIObject());
            if (H.IsPointerDown() && IsPointerOverUIObject() == false)
            {//按下
                mIsMouseDown = true;
                mLastPointerPos = H.PointerPosition;
            }
        }
        if (mIsMouseDown)
        {
            if (H.IsPointerUp())
            {//抬起
                mIsMouseDown = false;
            }
            //移动
            var screenDelta = (H.PointerPosition - mLastPointerPos);
            var cameraPos = transform.localPosition;
            var moveDelta = Vector3.zero;
            moveDelta.x = -screenDelta.x * mDragScreenRatio;
            moveDelta.z = -screenDelta.y * mDragScreenRatio;
            var isOver = CheckCameraNextOverBox(moveDelta);
            if (!isOver)
            {
                moveDelta = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * moveDelta;
                transform.position = transform.position + moveDelta;
            }
            // moveDelta = ComputeMoveDeltaWithCheckOverBox(moveDelta);
            // var isOver = CheckOverBox();
            // if (isOver)
            // {
            //     transform.position = ogposition;
            // }
            // //再按照摄像机y轴的旋转角度旋转一下
            // moveDelta = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * moveDelta;
            // transform.position = transform.position + moveDelta;
            //记录位置
            mLastPointerPos = H.PointerPosition;
        }
    }
    //结合移动变量检测是否超出边界
    private Vector3 ComputeMoveDeltaWithCheckOverBox(Vector3 moveDelta)
    {
        if (m_LeftEdgeObj != null && m_RightEdgeObj != null && m_FarEdgeObj != null && m_NearEdgeObj != null)
        {
            //判断边界
            if (mCamera.WorldToViewportPoint(m_LeftEdgeObj.transform.position).x > 0 && moveDelta.x < 0)
                moveDelta.x = 0;
            else if (mCamera.WorldToViewportPoint(m_RightEdgeObj.transform.position).x < 1 && moveDelta.x > 0)
                moveDelta.x = 0;
            if (mCamera.WorldToViewportPoint(m_FarEdgeObj.transform.position).y < 1 && moveDelta.z > 0)
                moveDelta.z = 0;
            else if (mCamera.WorldToViewportPoint(m_NearEdgeObj.transform.position).y > 0 && moveDelta.z < 0)
                moveDelta.z = 0;
        }
        return moveDelta;
    }

    //检测下一步是否超出边界
    bool CheckCameraNextOverBox(Vector3 moveDelta)
    {
        var result = false;
        if (m_EdgeCheckCamera)
        {
            //摄像机预移动
            //再按照摄像机y轴的旋转角度旋转一下
            var cameraMoveDelta = Quaternion.Euler(0, m_EdgeCheckCamera.transform.rotation.eulerAngles.y, 0) * moveDelta;
            m_EdgeCheckCamera.transform.position = m_EdgeCheckCamera.transform.position + cameraMoveDelta;
            if (m_LeftEdgeObj != null && m_RightEdgeObj != null && m_FarEdgeObj != null && m_NearEdgeObj != null)
            {
                //判断边界
                if (m_EdgeCheckCamera.WorldToViewportPoint(m_LeftEdgeObj.transform.position).x > 0 && moveDelta.x < 0)
                    result = true;
                else if (m_EdgeCheckCamera.WorldToViewportPoint(m_RightEdgeObj.transform.position).x < 1 && moveDelta.x > 0)
                    result = true;
                if (m_EdgeCheckCamera.WorldToViewportPoint(m_FarEdgeObj.transform.position).y < 1 && moveDelta.z > 0)
                    result = true;
                else if (m_EdgeCheckCamera.WorldToViewportPoint(m_NearEdgeObj.transform.position).y > 0 && moveDelta.z < 0)
                    result = true;
            }
            //重置位置
            m_EdgeCheckCamera.transform.position = transform.position;
        }
        return result;
    }


    //检测超过范围
    private bool CheckOverBox()
    {
        // return false;
        var result = false;
        if (m_LeftEdgeObj != null && m_RightEdgeObj != null && m_FarEdgeObj != null && m_NearEdgeObj != null)
        {
            var leftViewPortPosition = mCamera.WorldToViewportPoint(m_LeftEdgeObj.transform.position);
            var rightViewPortPosition = mCamera.WorldToViewportPoint(m_RightEdgeObj.transform.position);
            var farViewPortPosition = mCamera.WorldToViewportPoint(m_FarEdgeObj.transform.position);
            var nearViewPortPosition = mCamera.WorldToViewportPoint(m_NearEdgeObj.transform.position);
            if (m_LeftEdgeObj && leftViewPortPosition.x > 0)
                result = true;
            else if (m_RightEdgeObj && rightViewPortPosition.x < 1)
                result = true;
            if (m_FarEdgeObj && farViewPortPosition.y < 1)
                result = true;
            else if (m_NearEdgeObj && nearViewPortPosition.y > 0)
                result = true;
        }
        return result;
    }

    Coroutine mShakeCoroutine = null;
    public void Shake(float delay = 0)
    {
        if (mShakeCoroutine != null)
            return;
        mShakeCoroutine = StartCoroutine(_ShakeAnim(delay, false));
    }

    public void ShakeDelayFrame(int delayFrame = 0)
    {
        if (mShakeCoroutine != null)
            return;
        mShakeCoroutine = StartCoroutine(_ShakeAnim(delayFrame, true));
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
        // EControlState oldState = mControlState;
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
        // mControlState = oldState;
        transform.position = oldPos;
        mShakeCoroutine = null;
    }

}
