using System.Collections.Generic;
// 排行榜信息
namespace Msg {
    // 通用排行榜列表信息
    public class RankListInfo {
        /**账号唯一ID*/
        public string accountGid = "";
        /**上次排名(无给-1)*/
        public int lastRankList = 0;
        /**榜单分数*/
        public int score = 0;
        /**军团名称*/
        public string corpsName = "";
        /**vip等级*/
        public int vip = 0;
    }

    // 通用玩家排行榜信息
    public class PlayerRankInfo {
        /**当前排名(无给-1)*/
        public int curRankList = 0;
        /**当前积分*/
        public int curScore = 0;
        /**上一名积分(无给-1)*/
        public int topScore = 0;
        /**下一名积分(无给-1)*/
        public int nextScore = 0;
    }

    // 活动榜单信息
    public class ActiveRankInfo {
        /**二级榜单id*/
        public int secondType = 0;
        /**开启时间*/
        public string openTime = "";
        /**结算奖励时间*/
        public string rewardTime = "";
    }

    // 角色榜单列表信息
    public class ActorRankListInfo {
        /**角色唯一id*/
        public string entityGid = "";
        /**角色职业*/
        public int jobId = 0;
        /**战力值*/
        public int powerValue = 0;
        /**军团名称*/
        public string corpsName = "";
        /**角色名称*/
        public string entityName = "";
        /**vip等级*/
        public int vip = 0;
    }

    // 榜单角色详情
    public class RankActorInfo {
        public string entityGid = "";                //角色实体唯一ID
        public string entityName = "";                 //角色名称
        public int level = 0;                        //总等级
        public int jobId = 0;                       // 角色职业
        public int age = 0;             //年龄
        public int sex = 0;             //性别
        public Dictionary<string, float> attrs = new Dictionary<string, float>(); // 六维
        public int powerValue = 0;             //战力值
        public Part partInfo = new Part();              //外观部件信息，立绘
        public List<RankEquipInfo> equipList = new List<RankEquipInfo>();          //装备信息
    }
    // 榜单角色装备详情
    public class RankEquipInfo {
        public int equipId = 0;         //装备ID
        public int equipQuality = 0;        //装备品质
        public int equipStrengthen = 0;     //装备强化等级
        public Dictionary<string, float> attrs = new Dictionary<string, float>(); // 主属性和负重
        public int powerValue = 0;          //战力值
        /**技能效果槽位信息列表 */
        public List<EquipSkillSlotInfo> equipSkillSlotInfos = new List<EquipSkillSlotInfo>();
        /**圣物信息*/
        public Dictionary<int,CorpsSacredAttr> sacredAttr = new Dictionary<int,CorpsSacredAttr>(); //圣物增加属性
        /**装备槽位信息列表 */
        public List<GemSlotInfo> gemSlotInfos = new List<GemSlotInfo>();
    }
    // 玩家榜单角色详情
    public class PlayreRankActorInfo {
        public string entityGid = "";                //角色实体唯一ID
        public string entityName = "";                 //角色名称
        public int powerValue = 0;    //战力值
        public int rankList = 0;//排名
    }
}