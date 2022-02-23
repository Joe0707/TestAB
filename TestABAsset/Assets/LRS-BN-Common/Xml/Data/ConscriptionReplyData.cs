using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ConscriptionReplyData : BaseDataObject
    {
        
		public int randomWeight = 0;	//随机权重
		public int rewardNum = 0;	//奖品数量
		public int rewardID = 0;	//必出物品ID
		public string rewardConfig = "";	//随机奖励ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			randomWeight = br.ReadInt32();	//随机权重
			rewardNum = br.ReadInt32();	//奖品数量
			rewardID = br.ReadInt32();	//必出物品ID
			rewardConfig = br.ReadString();	//随机奖励ID
			
        }
    } 
} 