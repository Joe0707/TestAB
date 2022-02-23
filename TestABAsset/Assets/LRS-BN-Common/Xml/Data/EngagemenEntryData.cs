using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagemenEntryData : BaseDataObject
    {
        
		public int descentId = 0;	//种族
		public int sex = 0;	//性别
		public int entryType = 0;	//词条类型
		public string nobilityRange = "";	//对应爵位
		public int characteristicID = 0;	//特性ID
		public string ageRange = "";	//年龄范围
		public string entryDes = "";	//词条描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//词条ID
			descentId = br.ReadInt32();	//种族
			sex = br.ReadInt32();	//性别
			entryType = br.ReadInt32();	//词条类型
			nobilityRange = br.ReadString();	//对应爵位
			characteristicID = br.ReadInt32();	//特性ID
			ageRange = br.ReadString();	//年龄范围
			entryDes = br.ReadString();	//词条描述
			
        }
    } 
} 