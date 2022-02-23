using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AreaData : BaseDataObject
    {
        
		public string areaName = "";	//地区名称
		public int countryID = 0;	//所属国家
		public int descentID = 0;	//核心血脉
		public string prestigeLevel = "";	//宴会解锁友好度等级
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//地区ID
			areaName = br.ReadString();	//地区名称
			countryID = br.ReadInt32();	//所属国家
			descentID = br.ReadInt32();	//核心血脉
			prestigeLevel = br.ReadString();	//宴会解锁友好度等级
			
        }
    } 
} 