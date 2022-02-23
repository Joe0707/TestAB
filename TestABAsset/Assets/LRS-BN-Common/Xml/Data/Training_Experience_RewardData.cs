using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class Training_Experience_RewardData : BaseDataObject
    {
        
		public int eaperienceType = 0;	//历练类型
		public string rewardConfig = "";	//奖品配置
		public int dorpPro = 0;	//掉落概率
		public string countryAddeffect = "";	//国家加成效果
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			eaperienceType = br.ReadInt32();	//历练类型
			rewardConfig = br.ReadString();	//奖品配置
			dorpPro = br.ReadInt32();	//掉落概率
			countryAddeffect = br.ReadString();	//国家加成效果
			
        }
    } 
} 