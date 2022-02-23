using UnityEngine;
using System.Collections.Generic;
//摄像机信息实体
public class CameraInfoEntity
{
    public List<CameraEdgeValue> edgeValueList = new List<CameraEdgeValue>();//摄像机边界值
    public Vector3 cameraPosition = Vector3.zero; //摄像机位置
    public Vector3 cameraRotation = Vector3.one;//摄像机旋转
    public float cameraSize = 0;//摄像机尺寸
    public float minHeight = 0;//摄像机最小高度
    public float maxHeight = 0;//摄像机最大高度
}
//摄像机边界值
public class CameraEdgeValue
{
    public List<Vector3> edgePos = new List<Vector3>(); //边界位置  0上 1下 2左 3右 
    public Vector3 cameraEdgeLimitPosition = new Vector3(0, 0, 0);//相机的边界截取位置 缩放时会聚焦到这个位置

    public CameraEdgeValue(List<Vector3> edgePos, Vector3 cameraPos)
    {
        this.edgePos = edgePos;
        this.cameraEdgeLimitPosition = cameraPos;
    }

    public CameraEdgeValue()
    {

    }
}