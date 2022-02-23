using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class InjuryWorsenData : BaseDataObject
    {
        
		public int worsenAddPro = 0;	//恶化增加概率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			worsenAddPro = br.ReadInt32();	//恶化增加概率
			
        }
    } 
} 