using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ArenaSecondConfigData : BaseDataObject
    {
        
		public string arenaLevelSecondName = "";	//竞技场段位二级名称
		public string levelText = "";	//段位文字
		public int promotionIntegral = 0;	//升级所需积分
		public string tampleCondition = "";	//神殿进入条件
		public string promotionReward = "";	//晋级奖励
		public string weeklyRrward = "";	//每周奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			arenaLevelSecondName = br.ReadString();	//竞技场段位二级名称
			levelText = br.ReadString();	//段位文字
			promotionIntegral = br.ReadInt32();	//升级所需积分
			tampleCondition = br.ReadString();	//神殿进入条件
			promotionReward = br.ReadString();	//晋级奖励
			weeklyRrward = br.ReadString();	//每周奖励
			
        }
    } 
} 