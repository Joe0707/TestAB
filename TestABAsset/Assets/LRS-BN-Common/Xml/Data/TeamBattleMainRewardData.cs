using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TeamBattleMainRewardData : BaseDataObject
    {
        
		public string doneRange = "";	//完成区间
		public int battleID = 0;	//副本编号
		public string rewardConfig = "";	//奖励物品
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			doneRange = br.ReadString();	//完成区间
			battleID = br.ReadInt32();	//副本编号
			rewardConfig = br.ReadString();	//奖励物品
			
        }
    } 
} 