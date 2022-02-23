using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementBloodRuleData : BaseDataObject
    {
        
		public int countryId = 0;	//国家
		public int nobilityId = 0;	//社会地位
		public int descent1Id = 0;	//指定血统类型1ID
		public int blood1Pro = 0;	//血脉1权重
		public int descent2Id = 0;	//指定血统类型2ID
		public int blood2Pro = 0;	//血脉2权重
		public int descent3Id = 0;	//指定血统类型3ID
		public int blood3Pro = 0;	//血脉3权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryId = br.ReadInt32();	//国家
			nobilityId = br.ReadInt32();	//社会地位
			descent1Id = br.ReadInt32();	//指定血统类型1ID
			blood1Pro = br.ReadInt32();	//血脉1权重
			descent2Id = br.ReadInt32();	//指定血统类型2ID
			blood2Pro = br.ReadInt32();	//血脉2权重
			descent3Id = br.ReadInt32();	//指定血统类型3ID
			blood3Pro = br.ReadInt32();	//血脉3权重
			
        }
    } 
} 