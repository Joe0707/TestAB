using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetConfigData : BaseDataObject
    {
        
		public int nobilityLevel = 0;	//爵位等级
		public int areaID = 0;	//地区id
		public string banquetConsumeProp = "";	//宴会消耗物品
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			nobilityLevel = br.ReadInt32();	//爵位等级
			areaID = br.ReadInt32();	//地区id
			banquetConsumeProp = br.ReadString();	//宴会消耗物品
			
        }
    } 
} 