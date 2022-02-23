using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ValueRangeRandomData : BaseDataObject
    {
        
		public int weddingRingID = 0;	//戒指方案id
		public int value = 0;	//取值
		public int randomWeith = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			weddingRingID = br.ReadInt32();	//戒指方案id
			value = br.ReadInt32();	//取值
			randomWeith = br.ReadInt32();	//随机权重
			
        }
    } 
} 