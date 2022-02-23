using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ArenaWinningStreakRewardData : BaseDataObject
    {
        
		public int pkTimes = 0;	//战斗场次
		public string rewardConfig = "";	//奖励配置
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			pkTimes = br.ReadInt32();	//战斗场次
			rewardConfig = br.ReadString();	//奖励配置
			
        }
    } 
} 