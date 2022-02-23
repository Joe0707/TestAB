using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WorldEventData : BaseDataObject
    {
        
		public string triggerCondition = "";	//触发条件
		public string eventResult = "";	//触发结果
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			triggerCondition = br.ReadString();	//触发条件
			eventResult = br.ReadString();	//触发结果
			
        }
    } 
} 