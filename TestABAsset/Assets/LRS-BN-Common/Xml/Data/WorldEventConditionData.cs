using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WorldEventConditionData : BaseDataObject
    {
        
		public string conditionExplain = "";	//条件枚举说明
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			conditionExplain = br.ReadString();	//条件枚举说明
			
        }
    } 
} 