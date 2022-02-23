using Levels;
using UnityEngine;
using System.Collections.Generic;
//相机信息的代理
public class CameraInfoProxy
{
    public static CameraInfoEntity GenerateEntity(LevelConfig config)
    {
        var result = new CameraInfoEntity();
        result.cameraPosition = new Vector3(config.CameraPosition.x, config.CameraPosition.y, config.CameraPosition.z);
        result.cameraRotation = new Vector3(config.CameraRotation.x, config.CameraRotation.y, config.CameraRotation.z);
        result.cameraSize = config.CameraSize;
        result.minHeight = config.CameraMinHeight;
        result.maxHeight = config.CameraMaxHeight;
        var list = config.EdgeValueList;
        var resultedgelist = new List<CameraEdgeValue>();
        for (var i = 0; i < list.Count; i++)
        {
            var item = list[i];
            var edgevalue = new CameraEdgeValue();
            var edgevalueposlist = new List<Vector3>();
            for (var j = 0; j < item.EdgePos.Count; j++)
            {
                var pos = item.EdgePos[j];
                var edge = new Vector3(pos.x, pos.y, pos.z);
                edgevalueposlist.Add(edge);
            }
            edgevalue.edgePos = edgevalueposlist;
            edgevalue.cameraEdgeLimitPosition = new Vector3(item.CameraEdgeLimitPosition.x, item.CameraEdgeLimitPosition.y, item.CameraEdgeLimitPosition.z);
            resultedgelist.Add(edgevalue);
        }
        result.edgeValueList = resultedgelist;
        return result;
    }
}