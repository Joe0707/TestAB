using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WeddingRewardData : BaseDataObject
    {
        
		public int nobilityLevel = 0;	//爵位等级
		public int countryID = 0;	//国家ID
		public string weddingLevel1 = "";	//婚宴等级1
		public string weddingLevel2 = "";	//婚宴等级2
		public string weddingLevel3 = "";	//婚宴等级3
		public string weddingLevel4 = "";	//婚宴等级4
		public string weddingLevel5 = "";	//婚宴等级5
		public string weddingLevel6 = "";	//婚宴等级6
		public string weddingLevel7 = "";	//婚宴等级7
		public string weddingLevel8 = "";	//婚宴等级8
		public string weddingLevel = "";	//可执行婚礼
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			nobilityLevel = br.ReadInt32();	//爵位等级
			countryID = br.ReadInt32();	//国家ID
			weddingLevel1 = br.ReadString();	//婚宴等级1
			weddingLevel2 = br.ReadString();	//婚宴等级2
			weddingLevel3 = br.ReadString();	//婚宴等级3
			weddingLevel4 = br.ReadString();	//婚宴等级4
			weddingLevel5 = br.ReadString();	//婚宴等级5
			weddingLevel6 = br.ReadString();	//婚宴等级6
			weddingLevel7 = br.ReadString();	//婚宴等级7
			weddingLevel8 = br.ReadString();	//婚宴等级8
			weddingLevel = br.ReadString();	//可执行婚礼
			
        }
    } 
} 