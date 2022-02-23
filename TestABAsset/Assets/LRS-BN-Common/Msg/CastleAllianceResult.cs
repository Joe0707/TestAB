using System.Collections.Generic;
namespace Msg {
    /** 相亲结果信息定义*/
    public class CastleAllianceResult {
        public string entityGid = "";
        public ActorInfo targetInfo = new ActorInfo();
        public BloodInfo bloodInfo = new BloodInfo();       //角色血脉信息
        public int isUseFreeHaircut = 0;
        //结果状态 0成功 1基本判定失败 2声望判定失败
        public int state = 0;
        public int type = 0;
    }
}