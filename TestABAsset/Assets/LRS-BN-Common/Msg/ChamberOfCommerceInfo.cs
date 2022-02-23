using System.Collections.Generic;
namespace Msg {
    /** 商会信息定义*/
    public class ChamberOfCommerceInfo {
        public uint chamberOfCommerceId = 0;           //商会ID
        public long nextUpdateTaskTime = 0;     //任务列表下次更新的服务器现实时间
        public long nextTaskUpdateTime = 0;     //任务列表下次更新的游戏世界时间
        public List<ChamberOfCommerceTaskInfo> taskIdList = new List<ChamberOfCommerceTaskInfo>();    //当前可接受任务列表
        public List<ChamberOfCommerceTaskInfo> acceptTaskList = new List<ChamberOfCommerceTaskInfo>();    //当前已接受任务列表
        public List<ChamberOfCommerceGoodsInfo> goodsList = new List<ChamberOfCommerceGoodsInfo>(); //当前商品列表
        public Dictionary<uint, float> randomArgs = new Dictionary<uint, float>();  //随机参数字典，0是随机系数，物资类型的1~N为每个物资类型的季节系数
    }
}