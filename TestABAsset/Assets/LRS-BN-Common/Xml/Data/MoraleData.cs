using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class MoraleData : BaseDataObject
    {
        
		public string moraleDes = "";	//士气描述
		public int moraleNum = 0;	//士气值
		public int triggerInjuryPro = 0;	//触发精神创伤概率
		public string effectConfig = "";	//效果配置
		public string moraleIntroduce = "";	//士气简介
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			moraleDes = br.ReadString();	//士气描述
			moraleNum = br.ReadInt32();	//士气值
			triggerInjuryPro = br.ReadInt32();	//触发精神创伤概率
			effectConfig = br.ReadString();	//效果配置
			moraleIntroduce = br.ReadString();	//士气简介
			
        }
    } 
} 