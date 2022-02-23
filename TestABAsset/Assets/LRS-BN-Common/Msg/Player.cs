using System.Collections.Generic;
namespace Msg {
    public class Player {
        public PlayerInfo playerInfo = new PlayerInfo();        //玩家的基础信息
        public PlayerModuleActor actorModule = new PlayerModuleActor(); //玩家的角色模块数据
        public PlayerModuleTeam teamModule = new PlayerModuleTeam();    //玩家的队伍模块数据
        public PlayerModuleTask taskModule = new PlayerModuleTask();    //玩家的任务模块数据
        public PlayerModuleMail mailModule = new PlayerModuleMail();    //玩家的邮件模块数据
        public PlayerModuleMap mapModule = new PlayerModuleMap();    //玩家大地图模块数据
        public List<ItemInfo> itemModule = new List<ItemInfo>();    //玩家背包道具
        public List<Equipment> equipModule = new List<Equipment>();    //玩家装备
        public PlayerModulePrestige prestigeModule = new PlayerModulePrestige();        //玩家的势力友好度模块数据
        public PlayerModuleAttainment attainmentModule = new PlayerModuleAttainment();        //玩家成就目标统计数据
        public PlayerModuleWedding weddingModule = new PlayerModuleWedding();        //玩家婚宴数据
        public List<int> festivalModule = new List<int>();        //当前开启节日
        public PlayerModuleTaskMain taskMainModule = new PlayerModuleTaskMain();//主线、支线任务数据
        public CorpsInfo corpsModule = new CorpsInfo();//军团信息
    }
}