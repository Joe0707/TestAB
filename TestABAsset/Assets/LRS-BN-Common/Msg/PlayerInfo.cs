using System.Collections.Generic;
namespace Msg {
    public class PlayerInfo {
        public string accountGid = "";       //玩家GID
        public string accountId = "";        //玩家绑定的账号
        public string mainActorName = "";    //主角色名称
        public string mainActorGid = "";     //主角色GID
        public string mainTaskGId = "";      //玩家当前主线任务GID
        public string mainTeamName = "";     //玩家当前主角所在的队伍名称
        public string battleGid = "";        //玩家当前所在的战斗场景GID
        /**当前所在大地图唯一ID */
        public string mapGid = "";
        /**当前所在大地图ID */
        public int mapId = 0;
        /** 当前所在大地图城市ID */
        public string mapPointGid = "";//玩家所在城市点唯一ID
        public int mapPointId = 0;//玩家所在城市点ID
        public int funcType = 0;//玩家所在城市点某功能ID
        /** 玩家当前世界时间*/
        public int worldTime = 0;
        /**玩家未解锁节日*/
        public List<int> notUnlockFestival = new List<int>();
        /**已完成的随机战斗任务*/
        public List<int> completeRandomBattleTasks = new List<int>();
        //场景状态
        public int sceneState = 0;
        //场景参数
        public Dictionary<string, string> sceneParam = new Dictionary<string, string>();
        /**玩家特性 id 到期时间*/
        public Dictionary<int, int> specialitys = new Dictionary<int, int>();
        /**玩家属性 id 属性值*/
        public Dictionary<int, int> attrs = new Dictionary<int, int>();
        /**今日接委托任务次数 */
        public int entrustCount = 0;
        /**上次接委托任务时间(时间戳) */
        public int entrustAcceptTime = 0;
        /**今日刷新委托任务次数(免费刷新+钻石刷新次数总和) */
        public int refreshEntrustCount = 0;
        /**上次刷新委托任务次数的时间 */
        public int refreshEntrustLastTime = 0;
        /**vip等级 */
        public int vip = 0;
        /**是月卡玩家,0不是,1是月卡 */
        public int isYueKa = 0;
        /**今日购买接任务次数的次数 */
        public int buyAcceptCount = 0;
        /**上次购买接任务次数的时间 */
        public int buyAcceptTime = 0;
        /**玩家跟踪的任务 任务类型 任务唯一id*/
        public Dictionary<int, string> trackingTask = new Dictionary<int, string>();
        /**战斗点上的任务列表 */
        public List<PlayerBattlePointTaskGidsInfo> battlePointTaskGids = new List<PlayerBattlePointTaskGidsInfo>();
    }
}