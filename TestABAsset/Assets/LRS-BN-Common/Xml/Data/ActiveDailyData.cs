using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ActiveDailyData : BaseDataObject
    {
        
		public int type = 0;	//类型
		public int activeValue = 0;	//活跃值
		public string rewardIcon = "";	//奖励图标
		public string rewardItemID = "";	//奖励ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			type = br.ReadInt32();	//类型
			activeValue = br.ReadInt32();	//活跃值
			rewardIcon = br.ReadString();	//奖励图标
			rewardItemID = br.ReadString();	//奖励ID
			
        }
    } 
} 