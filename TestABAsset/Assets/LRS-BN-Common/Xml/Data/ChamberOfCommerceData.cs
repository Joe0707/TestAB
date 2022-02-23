using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ChamberOfCommerceData : BaseDataObject
    {
        
		public int cityLevel = 0;	//城市类型
		public int country = 0;	//所属势力
		public string goodsGroup = "";	//商品组配置
		public string sellEquipment1 = "";	//出售武器
		public string sellEquipment2 = "";	//出售防具
		public string sellEquipment3 = "";	//出售防具
		public string runBusinessConfig = "";	//跑商任务数量配置
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//商会编号
			cityLevel = br.ReadInt32();	//城市类型
			country = br.ReadInt32();	//所属势力
			goodsGroup = br.ReadString();	//商品组配置
			sellEquipment1 = br.ReadString();	//出售武器
			sellEquipment2 = br.ReadString();	//出售防具
			sellEquipment3 = br.ReadString();	//出售防具
			runBusinessConfig = br.ReadString();	//跑商任务数量配置
			
        }
    } 
} 