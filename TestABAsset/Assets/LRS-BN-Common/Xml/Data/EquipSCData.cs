using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipSCData : BaseDataObject
    {
        
		public int targetPropID = 0;	//目标物品
		public int uesdPropID = 0;	//所需材料
		public int uesdNum = 0;	//所需合成数量
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			targetPropID = br.ReadInt32();	//目标物品
			uesdPropID = br.ReadInt32();	//所需材料
			uesdNum = br.ReadInt32();	//所需合成数量
			
        }
    } 
} 