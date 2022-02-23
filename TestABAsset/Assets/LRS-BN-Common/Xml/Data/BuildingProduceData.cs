using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BuildingProduceData : BaseDataObject
    {
        
		public int buildingType = 0;	//建筑类型
		public int dorpPro = 0;	//掉落概率
		public string randomRange_1 = "";	//1级随机范围
		public string randomRange_2 = "";	//2级随机范围
		public string randomRange_3 = "";	//3级随机范围
		public string randomRange_4 = "";	//4级随机范围
		public string randomRange_5 = "";	//5级随机范围
		public string randomRange_6 = "";	//6级随机范围
		public string randomRange_7 = "";	//7级随机范围
		public string randomRange_8 = "";	//8级随机范围
		public string randomRange_9 = "";	//9级随机范围
		public string randomRange_10 = "";	//10级随机范围
		public string randomRange_11 = "";	//11级随机范围
		public string randomRange_12 = "";	//12级随机范围
		public string randomRange_13 = "";	//13级随机范围
		public string randomRange_14 = "";	//14级随机范围
		public string randomRange_15 = "";	//15级随机范围
		public string randomRange_16 = "";	//16级随机范围
		public string randomRange_17 = "";	//17级随机范围
		public string randomRange_18 = "";	//18级随机范围
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//物品ID
			buildingType = br.ReadInt32();	//建筑类型
			dorpPro = br.ReadInt32();	//掉落概率
			randomRange_1 = br.ReadString();	//1级随机范围
			randomRange_2 = br.ReadString();	//2级随机范围
			randomRange_3 = br.ReadString();	//3级随机范围
			randomRange_4 = br.ReadString();	//4级随机范围
			randomRange_5 = br.ReadString();	//5级随机范围
			randomRange_6 = br.ReadString();	//6级随机范围
			randomRange_7 = br.ReadString();	//7级随机范围
			randomRange_8 = br.ReadString();	//8级随机范围
			randomRange_9 = br.ReadString();	//9级随机范围
			randomRange_10 = br.ReadString();	//10级随机范围
			randomRange_11 = br.ReadString();	//11级随机范围
			randomRange_12 = br.ReadString();	//12级随机范围
			randomRange_13 = br.ReadString();	//13级随机范围
			randomRange_14 = br.ReadString();	//14级随机范围
			randomRange_15 = br.ReadString();	//15级随机范围
			randomRange_16 = br.ReadString();	//16级随机范围
			randomRange_17 = br.ReadString();	//17级随机范围
			randomRange_18 = br.ReadString();	//18级随机范围
			
        }
    } 
} 