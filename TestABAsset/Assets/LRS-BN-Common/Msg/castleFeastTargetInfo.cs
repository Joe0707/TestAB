using System.Collections.Generic;
namespace Msg {
    /** 城堡宴会目标信息*/
    public class CastleFeastTargetInfo {
        //唯一标识
        public string id = "";
        public BloodInfo bloodInfo = new BloodInfo();       
        //角色爵位信息
        public NobilityInfo nobilityInfo = new NobilityInfo();
        public Part partInfo = new Part();
        public string entityName = "";
    }
}