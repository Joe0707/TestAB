using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class InjuryData : BaseDataObject
    {
        
		public string injuryName = "";	//伤病名
		public string chneseName = "";	//中文名
		public int injuryType = 0;	//伤病类型
		public string keepMonth = "";	//持续月份
		public string keepMonthWeight = "";	//持续月份随机权重
		public int randomPro = 0;	//伤病随机权重
		public int worsenPro = 0;	//恶化概率
		public string triggerMonth = "";	//出现月份
		public int deathPro = 0;	//夭折概率
		public int contagionPro = 0;	//传染概率
		public string contagionNum = "";	//传染人数
		public string contagionNumPro = "";	//传染人数权重
		public int partID = 0;	//部件id
		public string injuryEffect = "";	//伤病效果
		public string injuryIcon = "";	//伤病图标
		public int recoverySingleItem = 0;	//单体治疗道具id
		public int recoveryWholeItem = 0;	//全体治疗道具id
		public string injuryDes = "";	//伤病描述
		public string chineseDes = "";	//中文描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			injuryName = br.ReadString();	//伤病名
			chneseName = br.ReadString();	//中文名
			injuryType = br.ReadInt32();	//伤病类型
			keepMonth = br.ReadString();	//持续月份
			keepMonthWeight = br.ReadString();	//持续月份随机权重
			randomPro = br.ReadInt32();	//伤病随机权重
			worsenPro = br.ReadInt32();	//恶化概率
			triggerMonth = br.ReadString();	//出现月份
			deathPro = br.ReadInt32();	//夭折概率
			contagionPro = br.ReadInt32();	//传染概率
			contagionNum = br.ReadString();	//传染人数
			contagionNumPro = br.ReadString();	//传染人数权重
			partID = br.ReadInt32();	//部件id
			injuryEffect = br.ReadString();	//伤病效果
			injuryIcon = br.ReadString();	//伤病图标
			recoverySingleItem = br.ReadInt32();	//单体治疗道具id
			recoveryWholeItem = br.ReadInt32();	//全体治疗道具id
			injuryDes = br.ReadString();	//伤病描述
			chineseDes = br.ReadString();	//中文描述
			
        }
    } 
} 