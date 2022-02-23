using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WeddingRingData : BaseDataObject
    {
        
		public string sixDimensions = "";	//六维数量
		public string valueRange = "";	//取值范围
		public string weddingDes = "";	//婚礼描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//婚礼等级
			sixDimensions = br.ReadString();	//六维数量
			valueRange = br.ReadString();	//取值范围
			weddingDes = br.ReadString();	//婚礼描述
			
        }
    } 
} 