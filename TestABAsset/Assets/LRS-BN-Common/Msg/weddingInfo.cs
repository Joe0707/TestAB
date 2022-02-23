using System.Collections.Generic;
namespace Msg {
    /** 婚宴信息定义*/
    public class WeddingInfo {
        public string entityGid = "";
        public ActorInfo targetInfo = new ActorInfo();
        public BloodInfo bloodInfo = new BloodInfo();       //角色血脉信息
        public int isUseFreeHaircut = 0;
    }
}