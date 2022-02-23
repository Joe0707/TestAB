using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class lvleffectData : BaseDataObject
    {
        
		public int effectGroup = 0;	//效果组
		public int lvl = 0;	//最低等级
		public int strPro = 0;	//力量成长比例
		public int dexPro = 0;	//技巧成长比例
		public int agiPro = 0;	//敏捷成长比例
		public int vitPro = 0;	//体质成长比例
		public int prePro = 0;	//感知成长比例
		public int wilPro = 0;	//意志成长比例
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（调用ID）
			effectGroup = br.ReadInt32();	//效果组
			lvl = br.ReadInt32();	//最低等级
			strPro = br.ReadInt32();	//力量成长比例
			dexPro = br.ReadInt32();	//技巧成长比例
			agiPro = br.ReadInt32();	//敏捷成长比例
			vitPro = br.ReadInt32();	//体质成长比例
			prePro = br.ReadInt32();	//感知成长比例
			wilPro = br.ReadInt32();	//意志成长比例
			
        }
    } 
} 