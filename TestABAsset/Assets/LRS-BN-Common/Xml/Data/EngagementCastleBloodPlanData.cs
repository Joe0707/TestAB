using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementCastleBloodPlanData : BaseDataObject
    {
        
		public int countryId = 0;	//国家
		public string bloodPlan = "";	//血脉配置
		public int castleBloodWeight = 0;	//城堡相亲血脉配置权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryId = br.ReadInt32();	//国家
			bloodPlan = br.ReadString();	//血脉配置
			castleBloodWeight = br.ReadInt32();	//城堡相亲血脉配置权重
			
        }
    } 
} 