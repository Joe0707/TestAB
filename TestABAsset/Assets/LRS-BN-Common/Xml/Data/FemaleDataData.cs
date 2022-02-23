using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FemaleDataData : BaseDataObject
    {
        
		public double strUpModify = 0;	//力量成长修正
		public double dexUpModify = 0;	//技巧成长修正
		public double agiUpModify = 0;	//敏捷成长修正
		public double vitUpModify = 0;	//体质成长修正
		public double perUpModify = 0;	//感知成长修正
		public double wilUpModify = 0;	//意志成长修正
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			strUpModify = br.ReadDouble();	//力量成长修正
			dexUpModify = br.ReadDouble();	//技巧成长修正
			agiUpModify = br.ReadDouble();	//敏捷成长修正
			vitUpModify = br.ReadDouble();	//体质成长修正
			perUpModify = br.ReadDouble();	//感知成长修正
			wilUpModify = br.ReadDouble();	//意志成长修正
			
        }
    } 
} 