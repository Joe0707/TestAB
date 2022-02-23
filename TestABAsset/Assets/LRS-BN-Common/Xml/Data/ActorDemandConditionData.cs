using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ActorDemandConditionData : BaseDataObject
    {
        
		public string demandCondition = "";	//条件描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//表号
			demandCondition = br.ReadString();	//条件描述
			
        }
    } 
} 