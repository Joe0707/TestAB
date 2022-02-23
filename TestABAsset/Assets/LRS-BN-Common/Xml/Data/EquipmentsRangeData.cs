using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipmentsRangeData : BaseDataObject
    {
        
		public int range = 0;	//射程
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//武器类型编号
			range = br.ReadInt32();	//射程
			
        }
    } 
} 