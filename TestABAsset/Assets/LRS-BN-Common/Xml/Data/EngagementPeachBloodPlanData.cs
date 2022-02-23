using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementPeachBloodPlanData : BaseDataObject
    {
        
		public int countryId = 0;	//国家
		public string bloodPlan = "";	//血脉配置
		public int peachBloodWeight = 0;	//香桃节相亲血脉配置权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryId = br.ReadInt32();	//国家
			bloodPlan = br.ReadString();	//血脉配置
			peachBloodWeight = br.ReadInt32();	//香桃节相亲血脉配置权重
			
        }
    } 
} 