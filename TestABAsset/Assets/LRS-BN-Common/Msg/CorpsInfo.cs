using System.Collections.Generic;
namespace Msg {
    // 军团信息
    public class CorpsInfo {
        public string corpsName = "";                //军团名称
        public CorpsFlagInfo flagInfo = new CorpsFlagInfo(); //军团旗帜
        public Dictionary<int,CorpsPositionSlotInfo> positionSlot = new Dictionary<int,CorpsPositionSlotInfo>(); //军团职位
        public List<string> corpsSacredList = new List<string>(); //军团圣物
        public List<CorpsSkillInfo> corpsSkillList = new List<CorpsSkillInfo>(); //军团技能
        public List<CorpsDemandInfo> corpsDemandList = new List<CorpsDemandInfo>(); //军团需求
    }
    //军团旗帜
    public class CorpsFlagInfo {
        public int shape = 0;                //旗帜形状
        public int shapeColor = 0;           //旗帜颜色
        public int pattern = 0;              //图案
        public int patternColor = 0;         //图案颜色
    }
    //军团职位
    public class CorpsPositionSlotInfo{
        public int level = 0; //职位等级
        public int index = 0;//槽位下标
        public string entityGid = ""; //任职角色
        public int time = 0; // 任职时间
    }
    //军团圣物信息
    public class CorpsSacredInfo {
        public string name = "";//圣物名
        public string bindingEntity = "";//绑定角色
        public int bindingTime = 0;//绑定时间
        public int level = 0;//圣物等级
        public int exp = 0;//当前经验
        public int addCount = 0;//追加次数
        public int awaitBreak = 0;//等待突破 0不等待,1等待
        public Dictionary<int,CorpsSacredAttr> sacredAttr = new Dictionary<int,CorpsSacredAttr>(); //圣物增加属性
    }
    //圣物增加属性
    public class CorpsSacredAttr {
        public Dictionary<int, int> attr = new Dictionary<int, int>(); // 属性id 属性值
    }
    //军团技能
    public class CorpsSkillInfo {
        public int id = 0;//技能唯一id
        public int status = 0;//技能状态 0未解锁 1未激活 2激活
    }
    //军团要求
    public class CorpsDemandInfo {
        public string entityGid = ""; // 角色唯一Gid
        public int demandId = 0;// 需求id
        public int endTime = 0;// 结束时间
        public Dictionary<int, int> needItem = new Dictionary<int, int>(); // 需要道具
        public int continuousJoinTimes = 1; // 连续参加次数
    }
}