using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItemController : MonoBehaviour, ICameraController
{
    private Camera m_Camera;
    private Matrix4x4 camera2WorldMat = Matrix4x4.identity;
    private Plane[] mPlanes;
    void Awake()
    {
        m_Camera = GetComponent<Camera>();
        camera2WorldMat = m_Camera.cameraToWorldMatrix;
        mPlanes = GeometryUtility.CalculateFrustumPlanes(m_Camera);
    }
    // Update is called once per frame
    void Update()
    {
        if (camera2WorldMat != m_Camera.cameraToWorldMatrix)
        {
            camera2WorldMat = m_Camera.cameraToWorldMatrix;
            mPlanes = GeometryUtility.CalculateFrustumPlanes(m_Camera);
        }
    }
    //获取相机平面
    public Plane[] GetCameraPlanes()
    {
        return mPlanes;
    }

}
