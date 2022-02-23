using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipEnchantingResultsData : BaseDataObject
    {
        
		public string natureRange = "";	//可附魔属性
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//装备类型
			natureRange = br.ReadString();	//可附魔属性
			
        }
    } 
} 