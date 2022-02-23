using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalDefine;
namespace Levels
{
    public class StumpConfig
    {
        public StumpConfig()
        {
            this.Id = LevelUtil.GenerateID();
        }
        public string Id = "";//唯一码
        public EStumpType Type = EStumpType.Monster; //怪物类型
        public ETeamType Team = ETeamType.Enemy; //队伍
        public EDirection Direction = EDirection.Up;//朝向
        public string ProtoID = ""; //怪物ID 
        public string ActorID = ""; //人物ID 弃用
        public bool IsVip = false; //是否是VIP
        public bool IsLocked = false;//是否锁定
        public int ActOrderNum = 0;//行动顺序
        public int SlotIndex = -1; //格子索引
        public Position Position = new Position(); //怪生成位置
        public int PositionInTeam = -1;//部队中的位置
        public int Level = 1;//怪物等级
        public string InitialAIId = "";//怪物战场初始化AI Id
        //复制
        public StumpConfig Clone()
        {
            var config = new StumpConfig();
            config.Type = Type;
            config.Team = Team;
            config.Direction = Direction;
            config.ProtoID = ProtoID;
            config.ActorID = ActorID;
            config.IsVip = IsVip;
            config.IsLocked = IsLocked;
            config.ActOrderNum = ActOrderNum;
            config.SlotIndex = SlotIndex;
            config.PositionInTeam = PositionInTeam;
            config.Id = Id;
            config.Level = Level;
            config.InitialAIId = InitialAIId;
            return config;
        }

        public void Copy(StumpConfig config)
        {
            this.Type = config.Type;
            this.Team = config.Team;
            this.Direction = config.Direction;
            this.ProtoID = config.ProtoID;
            this.ActorID = config.ActorID;
            this.IsVip = config.IsVip;
            this.IsLocked = config.IsLocked;
            this.ActOrderNum = config.ActOrderNum;
            this.SlotIndex = config.SlotIndex;
            this.Id = config.Id;
            this.Level = config.Level;
            this.PositionInTeam = config.PositionInTeam;
            this.InitialAIId = config.InitialAIId;
        }

        public void CopyValue(StumpConfig config)
        {
            this.Type = config.Type;
            this.Team = config.Team;
            this.Direction = config.Direction;
            this.ProtoID = config.ProtoID;
            this.ActorID = config.ActorID;
            this.IsVip = config.IsVip;
            this.IsLocked = config.IsLocked;
            this.ActOrderNum = config.ActOrderNum;
            this.SlotIndex = config.SlotIndex;
            this.Level = config.Level;
            this.PositionInTeam = config.PositionInTeam;
            this.InitialAIId = config.InitialAIId;
        }
    }
}
