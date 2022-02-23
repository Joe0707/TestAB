using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerLevelConfigData : BaseDataObject
    {
        
		public int towerType = 0;	//所属塔
		public string floorDes = "";	//层数描述
		public int levelID = 0;	//关卡ID
		public string levelDes = "";	//关卡描述
		public string levelMonsterIcon = "";	//关卡怪物头像
		public string extraReward = "";	//关卡额外奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			towerType = br.ReadInt32();	//所属塔
			floorDes = br.ReadString();	//层数描述
			levelID = br.ReadInt32();	//关卡ID
			levelDes = br.ReadString();	//关卡描述
			levelMonsterIcon = br.ReadString();	//关卡怪物头像
			extraReward = br.ReadString();	//关卡额外奖励
			
        }
    } 
} 