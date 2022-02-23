using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BarberPartData : BaseDataObject
    {
        
		public string partType = "";	//部件类型
		public uint partName = 0;	//部件名称
		public int descentType = 0;	//血统类型
		public int nobilityLevel = 0;	//爵位等级
		public int barberPrice = 0;	//理发店价格
		public string pointDataID = "";	//城市路点id
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（调用ID）
			partType = br.ReadString();	//部件类型
			partName = br.ReadUInt32();	//部件名称
			descentType = br.ReadInt32();	//血统类型
			nobilityLevel = br.ReadInt32();	//爵位等级
			barberPrice = br.ReadInt32();	//理发店价格
			pointDataID = br.ReadString();	//城市路点id
			
        }
    } 
} 