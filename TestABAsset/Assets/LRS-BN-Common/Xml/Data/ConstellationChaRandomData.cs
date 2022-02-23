using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ConstellationChaRandomData : BaseDataObject
    {
        
		public int month = 0;	//月份
		public int chaID = 0;	//特性ID
		public int randomWeight = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			month = br.ReadInt32();	//月份
			chaID = br.ReadInt32();	//特性ID
			randomWeight = br.ReadInt32();	//随机权重
			
        }
    } 
} 