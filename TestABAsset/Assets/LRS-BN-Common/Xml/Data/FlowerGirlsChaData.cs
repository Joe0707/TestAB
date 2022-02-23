using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FlowerGirlsChaData : BaseDataObject
    {
        
		public int randomWeight = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//特性ID
			randomWeight = br.ReadInt32();	//随机权重
			
        }
    } 
} 