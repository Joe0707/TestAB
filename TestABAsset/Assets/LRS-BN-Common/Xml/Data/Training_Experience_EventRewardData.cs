using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class Training_Experience_EventRewardData : BaseDataObject
    {
        
		public int eventRewardId = 0;	//事件奖励组ID
		public string rewardGoodsConfig = "";	//奖励物品
		public int dorpPro = 0;	//掉落比重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//奖励编号
			eventRewardId = br.ReadInt32();	//事件奖励组ID
			rewardGoodsConfig = br.ReadString();	//奖励物品
			dorpPro = br.ReadInt32();	//掉落比重
			
        }
    } 
} 