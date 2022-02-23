using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class Training_Experience_EventTriggerData : BaseDataObject
    {
        
		public int eventTriggerPro = 0;	//触发随机事件概率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			eventTriggerPro = br.ReadInt32();	//触发随机事件概率
			
        }
    } 
} 