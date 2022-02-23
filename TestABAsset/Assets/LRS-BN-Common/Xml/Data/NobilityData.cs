using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class NobilityData : BaseDataObject
    {
        
		public int nobilityLevel = 0;	//爵位等级
		public string nobilityName = "";	//名称
		public int countryId = 0;	//所属国家
		public string nobilityDes = "";	//描述
		public int unLock = 0;	//兑换声望
		public string useGoodsConfig = "";	//所需物品1ID
		public int marryRewardId = 0;	//结婚奖励id
		public int marryRewardNum = 0;	//奖励数值
		public int expPro = 0;	//经验加成
		public string medalPic = "";	//爵位勋章
		public string dressMan = "";	//爵位服装男
		public string dressWoman = "";	//爵位服装女
		public int palace = 0;	//王宫显示爵位
		public int coldTime = 0;	//冷却时间（个月）
		public int nobilityWages = 0;	//爵位加成工资
		public int retunTime = 0;	//回信时间
		public int weddingLevel = 0;	//婚宴等级
		public int proposePrice = 0;	//表白价格
		public int messagePrice = 0;	//相亲对象信息价格
		public string banquetReward = "";	//举行宴会成功奖励
		public string banquetCountryConsume = "";	//国家宴会消耗物品
		public float bangquetEngagementCoefficient = 0;	//宴会相亲系数
		public int sacredExpConversionRate = 0;	//圣物特效经验与角色经验转化率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			nobilityLevel = br.ReadInt32();	//爵位等级
			nobilityName = br.ReadString();	//名称
			countryId = br.ReadInt32();	//所属国家
			nobilityDes = br.ReadString();	//描述
			unLock = br.ReadInt32();	//兑换声望
			useGoodsConfig = br.ReadString();	//所需物品1ID
			marryRewardId = br.ReadInt32();	//结婚奖励id
			marryRewardNum = br.ReadInt32();	//奖励数值
			expPro = br.ReadInt32();	//经验加成
			medalPic = br.ReadString();	//爵位勋章
			dressMan = br.ReadString();	//爵位服装男
			dressWoman = br.ReadString();	//爵位服装女
			palace = br.ReadInt32();	//王宫显示爵位
			coldTime = br.ReadInt32();	//冷却时间（个月）
			nobilityWages = br.ReadInt32();	//爵位加成工资
			retunTime = br.ReadInt32();	//回信时间
			weddingLevel = br.ReadInt32();	//婚宴等级
			proposePrice = br.ReadInt32();	//表白价格
			messagePrice = br.ReadInt32();	//相亲对象信息价格
			banquetReward = br.ReadString();	//举行宴会成功奖励
			banquetCountryConsume = br.ReadString();	//国家宴会消耗物品
			bangquetEngagementCoefficient = br.ReadSingle();	//宴会相亲系数
			sacredExpConversionRate = br.ReadInt32();	//圣物特效经验与角色经验转化率
			
        }
    } 
} 