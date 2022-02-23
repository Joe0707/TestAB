using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ShopWeekData : BaseDataObject
    {
        
		public int countryID = 0;	//特产对应国家
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//星期编号
			countryID = br.ReadInt32();	//特产对应国家
			
        }
    } 
} 