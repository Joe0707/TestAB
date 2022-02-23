using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LegionSacredEffectNatureData : BaseDataObject
    {
        
		public int addType = 0;	//类型
		public int number = 0;	//数值
		public int randomWeight = 0;	//权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			addType = br.ReadInt32();	//类型
			number = br.ReadInt32();	//数值
			randomWeight = br.ReadInt32();	//权重
			
        }
    } 
} 