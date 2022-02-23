using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SchoolChaDropData : BaseDataObject
    {
        
		public int groupType = 0;	//所属库
		public int castleLevel = 0;	//城堡等级
		public int chaId = 0;	//特性ID
		public int randomPro = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			groupType = br.ReadInt32();	//所属库
			castleLevel = br.ReadInt32();	//城堡等级
			chaId = br.ReadInt32();	//特性ID
			randomPro = br.ReadInt32();	//随机权重
			
        }
    } 
} 