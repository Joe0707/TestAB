using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FestivalExchangeData : BaseDataObject
    {
        
		public int festivalType = 0;	//节日类型
		public int countryId = 0;	//特产国家
		public int dropPro = 0;	//特产掉落权重
		public int exchangeItems = 0;	//兑换物品
		public int targetItem = 0;	//目标物品
		public string exchangeConfig = "";	//兑换配置
		public string exchangeTime = "";	//目标物品可兑换次数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			festivalType = br.ReadInt32();	//节日类型
			countryId = br.ReadInt32();	//特产国家
			dropPro = br.ReadInt32();	//特产掉落权重
			exchangeItems = br.ReadInt32();	//兑换物品
			targetItem = br.ReadInt32();	//目标物品
			exchangeConfig = br.ReadString();	//兑换配置
			exchangeTime = br.ReadString();	//目标物品可兑换次数
			
        }
    } 
} 