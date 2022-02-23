using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LegionBuffUnlockData : BaseDataObject
    {
        
		public string unlockConsume = "";	//解锁消耗
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			unlockConsume = br.ReadString();	//解锁消耗
			
        }
    } 
} 