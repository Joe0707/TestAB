using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipmentAnimatorData : BaseDataObject
    {
        
		public int equipmentID = 0;	//装备ID
		public string equipmentEffect_M = "";	//特效文件（男）
		public string equipmentEffect_F = "";	//特效文件（女）
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			equipmentID = br.ReadInt32();	//装备ID
			equipmentEffect_M = br.ReadString();	//特效文件（男）
			equipmentEffect_F = br.ReadString();	//特效文件（女）
			
        }
    } 
} 