using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipSourceData : BaseDataObject
    {
        
		public int source = 0;	//来源
		public int TopQuality = 0;	//可升最高品质
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			source = br.ReadInt32();	//来源
			TopQuality = br.ReadInt32();	//可升最高品质
			
        }
    } 
} 