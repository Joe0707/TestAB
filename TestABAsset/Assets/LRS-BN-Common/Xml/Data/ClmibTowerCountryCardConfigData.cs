using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClmibTowerCountryCardConfigData : BaseDataObject
    {
        
		public int bloodRange = 0;	//血脉范围
		public string cardConfig = "";	//卡牌库配置
		public int rewardCardNum = 0;	//获得卡牌张数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			bloodRange = br.ReadInt32();	//血脉范围
			cardConfig = br.ReadString();	//卡牌库配置
			rewardCardNum = br.ReadInt32();	//获得卡牌张数
			
        }
    } 
} 