using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerData : BaseDataObject
    {
        
		public string towerDes = "";	//塔描述
		public int countryID = 0;	//国家ID
		public string openDate = "";	//开放时间
		public int needDescentID = 0;	//获得卡牌血脉id
		public string formationTipsDes = "";	//挑战编队限制提示描述
		public string passReward = "";	//通过可获得奖励
		public int battleMax = 0;	//每天可挑战最大次数
		public int pointID = 0;	//对应点数ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			towerDes = br.ReadString();	//塔描述
			countryID = br.ReadInt32();	//国家ID
			openDate = br.ReadString();	//开放时间
			needDescentID = br.ReadInt32();	//获得卡牌血脉id
			formationTipsDes = br.ReadString();	//挑战编队限制提示描述
			passReward = br.ReadString();	//通过可获得奖励
			battleMax = br.ReadInt32();	//每天可挑战最大次数
			pointID = br.ReadInt32();	//对应点数ID
			
        }
    } 
} 