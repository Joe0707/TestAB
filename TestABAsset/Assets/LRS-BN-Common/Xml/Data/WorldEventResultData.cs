using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WorldEventResultData : BaseDataObject
    {
        
		public string conditionExplain = "";	//结果枚举说明
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			conditionExplain = br.ReadString();	//结果枚举说明
			
        }
    } 
} 