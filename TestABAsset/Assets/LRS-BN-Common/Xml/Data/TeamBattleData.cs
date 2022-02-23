using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TeamBattleData : BaseDataObject
    {
        
		public int countryId = 0;	//国家
		public int difficultyLevel = 0;	//难度等级
		public int ublockTeamBattle = 0;	//组队副本解锁友好度等级
		public string difficultyDes = "";	//难度描述
		public string createBattleConsume = "";	//创建副本所需资源
		public int npcLevel = 0;	//敌人等级
		public string levelIcon = "";	//等级图标
		public int mainLevelID = 0;	//主线关卡配置
		public string mainClientDes = "";	//主线界面描述
		public int branchLevelID = 0;	//支线关卡配置
		public string branchClientDes = "";	//支线界面描述
		public string buffID = "";	//可获得副本buffID
		public string mainReward = "";	//主线奖励
		public string branchReward = "";	//支线奖励
		public string extraReward = "";	//额外奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryId = br.ReadInt32();	//国家
			difficultyLevel = br.ReadInt32();	//难度等级
			ublockTeamBattle = br.ReadInt32();	//组队副本解锁友好度等级
			difficultyDes = br.ReadString();	//难度描述
			createBattleConsume = br.ReadString();	//创建副本所需资源
			npcLevel = br.ReadInt32();	//敌人等级
			levelIcon = br.ReadString();	//等级图标
			mainLevelID = br.ReadInt32();	//主线关卡配置
			mainClientDes = br.ReadString();	//主线界面描述
			branchLevelID = br.ReadInt32();	//支线关卡配置
			branchClientDes = br.ReadString();	//支线界面描述
			buffID = br.ReadString();	//可获得副本buffID
			mainReward = br.ReadString();	//主线奖励
			branchReward = br.ReadString();	//支线奖励
			extraReward = br.ReadString();	//额外奖励
			
        }
    } 
} 