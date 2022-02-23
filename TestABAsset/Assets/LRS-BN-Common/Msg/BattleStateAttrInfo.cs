using System.Collections.Generic;
namespace Msg {
    public class BattleStateAttrInfo {
        public Dictionary<string, float> attrs = new Dictionary<string, float>();
        public int isDead = 0;        //死亡状态
        public List<int> status = new List<int>();  //状态列表
    }
}