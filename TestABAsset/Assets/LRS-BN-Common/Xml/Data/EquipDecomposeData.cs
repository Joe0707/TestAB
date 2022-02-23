using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipDecomposeData : BaseDataObject
    {
        
		public int item1Id = 0;	//分解获得奖励组ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//装备品质编号
			item1Id = br.ReadInt32();	//分解获得奖励组ID
			
        }
    } 
} 