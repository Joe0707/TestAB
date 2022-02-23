using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class HerosData : BaseDataObject
    {
        
		public int recruitType = 0;	//招募类型
		public int countryID = 0;	//所属国家
		public int weight = 0;	//随机权重
		public int descentID1 = 0;	//指定血统1ID
		public int descentBrooldPro1 = 0;	//血脉1权重
		public int descentID2 = 0;	//指定血统2ID
		public int descentBrooldPro2 = 0;	//血脉2权重
		public int descentID3 = 0;	//指定血统3ID
		public int descentBrooldPro3 = 0;	//血脉3权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//英雄ID
			recruitType = br.ReadInt32();	//招募类型
			countryID = br.ReadInt32();	//所属国家
			weight = br.ReadInt32();	//随机权重
			descentID1 = br.ReadInt32();	//指定血统1ID
			descentBrooldPro1 = br.ReadInt32();	//血脉1权重
			descentID2 = br.ReadInt32();	//指定血统2ID
			descentBrooldPro2 = br.ReadInt32();	//血脉2权重
			descentID3 = br.ReadInt32();	//指定血统3ID
			descentBrooldPro3 = br.ReadInt32();	//血脉3权重
			
        }
    } 
} 