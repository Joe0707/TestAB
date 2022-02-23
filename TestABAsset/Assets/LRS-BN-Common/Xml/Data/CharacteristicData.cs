using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class CharacteristicData : BaseDataObject
    {
        
		public int chaId = 0;	//特性id
		public uint chaName = 0;	//特性名
		public int chaLevel = 0;	//特性等级
		public int chaType = 0;	//特性类型
		public string civilianMale = "";	//平民男前缀
		public string civilianFemale = "";	//平民女前缀
		public string knightMale = "";	//骑士以上男前缀
		public string knightFemale = "";	//骑士以上女前缀
		public int countryID = 0;	//所属国家
		public int descentID = 0;	//所属种族
		public int nobilityLevel = 0;	//所需爵位
		public int keepMonth = 0;	//持续月份
		public int randomPro = 0;	//随机权重
		public int parentsWeights = 0;	//亲代加权
		public string openCondition = "";	//开启条件
		public string chaEffect = "";	//特性效果
		public string chaDes = "";	//特性描述
		public string effectParameter = "";	//效果参数
		public int teachCha = 0;	//是否可学习
		public int studyPro = 0;	//学习权重
		public int sex = 0;	//性别
		public int porN = 0;	//正负面判断
		public int birthDispaly = 0;	//出生是否信息
		public string chaIcon = "";	//特性标志
		public string mutexCharacteristic = "";	//互斥特性
		public int pageDisplaySort = 0;	//页面显示优先级
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//特性id
			chaId = br.ReadInt32();	//特性id
			chaName = br.ReadUInt32();	//特性名
			chaLevel = br.ReadInt32();	//特性等级
			chaType = br.ReadInt32();	//特性类型
			civilianMale = br.ReadString();	//平民男前缀
			civilianFemale = br.ReadString();	//平民女前缀
			knightMale = br.ReadString();	//骑士以上男前缀
			knightFemale = br.ReadString();	//骑士以上女前缀
			countryID = br.ReadInt32();	//所属国家
			descentID = br.ReadInt32();	//所属种族
			nobilityLevel = br.ReadInt32();	//所需爵位
			keepMonth = br.ReadInt32();	//持续月份
			randomPro = br.ReadInt32();	//随机权重
			parentsWeights = br.ReadInt32();	//亲代加权
			openCondition = br.ReadString();	//开启条件
			chaEffect = br.ReadString();	//特性效果
			chaDes = br.ReadString();	//特性描述
			effectParameter = br.ReadString();	//效果参数
			teachCha = br.ReadInt32();	//是否可学习
			studyPro = br.ReadInt32();	//学习权重
			sex = br.ReadInt32();	//性别
			porN = br.ReadInt32();	//正负面判断
			birthDispaly = br.ReadInt32();	//出生是否信息
			chaIcon = br.ReadString();	//特性标志
			mutexCharacteristic = br.ReadString();	//互斥特性
			pageDisplaySort = br.ReadInt32();	//页面显示优先级
			
        }
    } 
} 