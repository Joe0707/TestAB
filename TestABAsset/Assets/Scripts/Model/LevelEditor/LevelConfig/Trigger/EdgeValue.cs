using System.Collections.Generic;
namespace Levels.Trigger
{
    //边界值
    public class EdgeValue
    {
        public List<Value3> EdgePos = new List<Value3>(); //边界位置  0上 1下 2左 3右
        public Value3 CameraEdgeLimitPosition = new Value3(0, 0, 0); //相机的边界截取位置 缩放时会聚焦到这个位置
        public EdgeValue(List<Value3> edgePos, Value3 cameraPos)
        {
            this.EdgePos = edgePos;
            this.CameraEdgeLimitPosition = cameraPos;
        }
    }
}