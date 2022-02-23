using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WeddingData : BaseDataObject
    {
        
		public int countryID = 0;	//所属国家
		public int weddingLevel = 0;	//婚宴等级id
		public string weddingConsume = "";	//婚宴消耗
		public string weddingDes = "";	//婚礼描述
		public int weddingshortBuff = 0;	//婚宴短期特性加成
		public int groomsmanBuff = 0;	//伴郎伴娘获得特性
		public int bouquetReward = 0;	//获得捧花奖励
		public int flowerGirlsRate = 0;	//花童特性随机比例
		public string bg = "";	//婚礼背景图
		public string bgm = "";	//婚礼背景音乐
		public string groomDailogID = "";	//新郎讲话
		public string brideDailogID = "";	//新娘讲话
		public string weddingEndText = "";	//婚礼结束描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryID = br.ReadInt32();	//所属国家
			weddingLevel = br.ReadInt32();	//婚宴等级id
			weddingConsume = br.ReadString();	//婚宴消耗
			weddingDes = br.ReadString();	//婚礼描述
			weddingshortBuff = br.ReadInt32();	//婚宴短期特性加成
			groomsmanBuff = br.ReadInt32();	//伴郎伴娘获得特性
			bouquetReward = br.ReadInt32();	//获得捧花奖励
			flowerGirlsRate = br.ReadInt32();	//花童特性随机比例
			bg = br.ReadString();	//婚礼背景图
			bgm = br.ReadString();	//婚礼背景音乐
			groomDailogID = br.ReadString();	//新郎讲话
			brideDailogID = br.ReadString();	//新娘讲话
			weddingEndText = br.ReadString();	//婚礼结束描述
			
        }
    } 
} 