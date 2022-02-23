using System.Collections.Generic;
namespace Msg {
    public class ActorInfo {
        public string entityGid = "";                //角色实体唯一ID
        public uint entityId = 0;                    //角色模板ID 配合角色类型进行配置检索？
        public string accountGid = "";               //操控者唯一ID
        public int actorType = 0;                    //角色类型 EActorType
        public string entityName = "";                 //角色名称
        public int level = 0;                        //总等级
        public int exp = 0;                          //当前经验值
        public int inBattle = 0;                     //该角色是否正在战斗
        public int inTeam = 0;                   //该角色位于哪个队伍
        public List<LvInfo> lvInfos = new List<LvInfo>();   //角色各转职阶段等级信息
        public float wageBloodCoefficient = 0;          // 角色工资血脉提升系数
        public NobilityInfo nobilityInfo = new NobilityInfo();  //角色爵位信息
        public int awaitPosition = 0;           //角色当前待命位置
        public int giveSpeciality = 0;                  //节日祈祷赋予特性id
        public int corpsPosition = 0;                  //军团职位
        public long acquireTime = 0;             //获取角色时的时间戳
        public int status = 0; // 角色状态
        public string customTag = ""; // 自定义标签
        public int isWeiTuo = 0;//去做委托任务,0未派遣,1派遣
        public int powerValue = 0;//角色战斗力
    }
}