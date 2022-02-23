using System.Collections.Generic;
namespace Msg {
    //账号战斗点任务唯一ID列表
    public class PlayerBattlePointTaskGidsInfo {
        public int pointId = 0; //城市点ID
        public List<string> taskGids = new List<string>();    //战斗点上任务唯一ID列表
    }
}