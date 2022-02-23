using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ChaMixedRaceData : BaseDataObject
    {
        
		public string descentConfig = "";	//血脉种族
		public int descentPro = 0;	//需求血脉种族比例
		public int chaID = 0;	//特性ID
		public int randomWeight = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			descentConfig = br.ReadString();	//血脉种族
			descentPro = br.ReadInt32();	//需求血脉种族比例
			chaID = br.ReadInt32();	//特性ID
			randomWeight = br.ReadInt32();	//随机权重
			
        }
    } 
} 