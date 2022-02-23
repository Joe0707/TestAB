using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class DescentData : BaseDataObject
    {
        
		public string descent_name = "";	//血统名称
		public string country = "";	//所属国家
		public double strup = 0;	//力量成长
		public double dexup = 0;	//技巧成长
		public double agiup = 0;	//敏捷成长
		public double vitup = 0;	//体质成长
		public double perup = 0;	//感知成长
		public double wilup = 0;	//意志成长
		public string descentIcon = "";	//图标
		public string descentDes = "";	//血统描述
		public string color = "";	//血统名字颜色
		public int prestige = 0;	//对应声望ID
		public int royalBlood = 0;	//是否王族血脉
		public int weddingRing = 0;	//婚戒ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（血统类型）
			descent_name = br.ReadString();	//血统名称
			country = br.ReadString();	//所属国家
			strup = br.ReadDouble();	//力量成长
			dexup = br.ReadDouble();	//技巧成长
			agiup = br.ReadDouble();	//敏捷成长
			vitup = br.ReadDouble();	//体质成长
			perup = br.ReadDouble();	//感知成长
			wilup = br.ReadDouble();	//意志成长
			descentIcon = br.ReadString();	//图标
			descentDes = br.ReadString();	//血统描述
			color = br.ReadString();	//血统名字颜色
			prestige = br.ReadInt32();	//对应声望ID
			royalBlood = br.ReadInt32();	//是否王族血脉
			weddingRing = br.ReadInt32();	//婚戒ID
			
        }
    } 
} 