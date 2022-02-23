using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetBloodPlanData : BaseDataObject
    {
        
		public int countryID = 0;	//国家id
		public int areaID = 0;	//地区
		public string bloodPlan = "";	//血脉配置
		public int banquetCountryBloodWeight = 0;	//宴会相亲血脉配置权重
		public int banquetAreaBloodWeight = 0;	//宴会相亲血脉配置权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryID = br.ReadInt32();	//国家id
			areaID = br.ReadInt32();	//地区
			bloodPlan = br.ReadString();	//血脉配置
			banquetCountryBloodWeight = br.ReadInt32();	//宴会相亲血脉配置权重
			banquetAreaBloodWeight = br.ReadInt32();	//宴会相亲血脉配置权重
			
        }
    } 
} 