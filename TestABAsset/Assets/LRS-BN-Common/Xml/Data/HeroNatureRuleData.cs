using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class HeroNatureRuleData : BaseDataObject
    {
        
		public int cardType = 0;	//招募类型
		public string leveRange = "";	//等级范围
		public int nobilityLevel = 0;	//爵位
		public string ageRange = "";	//年龄
		public string sexWeight = "";	//性别权重
		public int jobsRange = 0;	//兵种
		public int dorpPro = 0;	//掉落权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			cardType = br.ReadInt32();	//招募类型
			leveRange = br.ReadString();	//等级范围
			nobilityLevel = br.ReadInt32();	//爵位
			ageRange = br.ReadString();	//年龄
			sexWeight = br.ReadString();	//性别权重
			jobsRange = br.ReadInt32();	//兵种
			dorpPro = br.ReadInt32();	//掉落权重
			
        }
    } 
} 