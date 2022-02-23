using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipmentTypeData : BaseDataObject
    {
        
		public int equipDT = 0;	//装备大类
		public int Type = 0;	//装备类型
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			equipDT = br.ReadInt32();	//装备大类
			Type = br.ReadInt32();	//装备类型
			
        }
    } 
} 