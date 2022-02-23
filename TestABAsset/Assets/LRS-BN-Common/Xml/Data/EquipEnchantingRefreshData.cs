using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipEnchantingRefreshData : BaseDataObject
    {
        
		public int enchantingtimeP = 0;	//附魔次数系数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//附魔刷新阶段次数
			enchantingtimeP = br.ReadInt32();	//附魔次数系数
			
        }
    } 
} 