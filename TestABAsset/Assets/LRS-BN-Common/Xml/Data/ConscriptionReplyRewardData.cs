using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ConscriptionReplyRewardData : BaseDataObject
    {
        
		public int rewardItemID = 0;	//奖励物品ID
		public string randomRange = "";	//物品随机范围
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			rewardItemID = br.ReadInt32();	//奖励物品ID
			randomRange = br.ReadString();	//物品随机范围
			
        }
    } 
} 