using System.Collections.Generic;
namespace Msg {
    /** 随机生子测试接口*/
    public class ChildBuildTestRequest : MsgBase {
        public Part fatherPartInfo = new Part();                                              //父亲部件信息
        public List<ActorBloodlineInfo> fatherBloodlines = new List<ActorBloodlineInfo>();    //父亲隐性血脉信息
        public Part motherPartInfo = new Part();                                              //母亲部件信息
        public List<ActorBloodlineInfo> motherBloodlines = new List<ActorBloodlineInfo>();    //母亲隐性血脉信息
        public int randomNum = 1;                                                             //随机次数
        
    }

    /** 随机生子测试接口返回*/
    public class ChildBuildTestResponse : MsgBase {
        public List<Actor> infos = new List<Actor>();             //随机结果组
    }

    /** 随机英雄测试接口*/
    public class HeroBuildTestRequest : MsgBase {
        public int heroId = 0;      //英雄表ID
        public int randomNum = 1;                                 //随机次数
    }

    /** 随机英雄测试接口返回*/
    public class HeroBuildTestResponse : MsgBase {
        public List<Actor> infos = new List<Actor>();             //随机结果组
    }

    public class AllLvAttrCountRequest : MsgBase {
        public int sex = 0;
        public int maxLv = 0;
        public List<ActorBloodlineInfo> showBloodlines = new List<ActorBloodlineInfo>();
        public List<LvInfo> jobInfo = new List<LvInfo>();
        public AttrInfo randomBaseAttr = new AttrInfo();
        public AttrInfo randomGrowAttr = new AttrInfo();
    }

    public class AllLvAttrCountResponse : MsgBase {
        public Dictionary<int, AttrInfo> lvHash = new Dictionary<int, AttrInfo>();
    }
}