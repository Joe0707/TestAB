using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RankRewardData : BaseDataObject
    {
        
		public int rewardType = 0;	//所属排行榜
		public int rank = 0;	//排名
		public string rewardName = "";	//赛季奖励名称
		public string rankReward = "";	//奖励配置
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			rewardType = br.ReadInt32();	//所属排行榜
			rank = br.ReadInt32();	//排名
			rewardName = br.ReadString();	//赛季奖励名称
			rankReward = br.ReadString();	//奖励配置
			
        }
    } 
} 