using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RewardGroupData : BaseDataObject
    {
        
		public string itemReward = "";	//物品奖励
		public string equipmentReward = "";	//装备奖励
		public string actorReward = "";	//角色奖励
		public uint rewardDes = 0;	//奖励描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//奖励组id
			itemReward = br.ReadString();	//物品奖励
			equipmentReward = br.ReadString();	//装备奖励
			actorReward = br.ReadString();	//角色奖励
			rewardDes = br.ReadUInt32();	//奖励描述
			
        }
    } 
} 