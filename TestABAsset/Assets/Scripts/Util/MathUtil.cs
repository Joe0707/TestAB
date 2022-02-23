using System;
using UnityEngine;
public class MathUtil
{
    const int DefaultPercision = 2;//默认精度是两位小数
                                   //数字近似相等
    public static bool NearlyEquals(float a, float b, int percision = DefaultPercision)
    {
        var percisionValue = Math.Pow(10, percision);
        return Math.Round(a * percisionValue) == Math.Round(b * percisionValue);
    }
    //位置近似相等
    public static bool Vector2NearlyEquals(Vector2 a, Vector2 b, int percision = DefaultPercision)
    {
        return NearlyEquals(a.x, b.x, percision) && NearlyEquals(a.y, b.y, percision);
    }
    //角度转弧度
    public static float Degree2Radian(float degree)
    {
        return (float)(degree * Math.PI / 180);
    }
    //计算源向目标的旋转角
    public static float ComputeOrientationFaceToPos(Vector3 sourcePosition, Vector3 targetPosition)
    {
        var dir = new Vector3(targetPosition.x - sourcePosition.x, targetPosition.y - sourcePosition.y, targetPosition.z - sourcePosition.z);
        return ComputeOrientationFaceToDir(Vector3.forward, dir);
    }
    //计算源向方向的旋转角
    public static float ComputeOrientationFaceToDir(Vector3 sourceDir, Vector3 toDir)
    {
        toDir.y = 0;
        var angle = Vector3.Angle(sourceDir, toDir);
        var cross = Vector3.Cross(sourceDir, toDir);
        if (cross.y < 0)
        {
            angle = -angle;
        }
        if (angle < 0)
        {
            angle = angle + 360;
        }
        return angle;
    }

    //位置字符串转向量
    public static Vector2 PositionStr2Vector(string position)
    {
        var result = Vector2.zero;
        var positions = position.Split(',');
        if (positions.Length == 2)
        {
            var position1 = positions[0];
            var position2 = positions[1];
            float x = 0;
            float.TryParse(position1, out x);
            float y = 0;
            float.TryParse(position2, out y);
            result = new Vector2(x, y);
        }
        return result;
    }

}