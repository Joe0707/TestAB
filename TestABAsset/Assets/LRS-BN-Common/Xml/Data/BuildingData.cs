using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BuildingData : BaseDataObject
    {
        
		public int buildingType = 0;	//建筑类型
		public uint buildingName = 0;	//建筑名称
		public int buildingLevel = 0;	//建筑等级
		public uint buildingDes = 0;	//建筑描述
		public string buildingConsume = "";	//建筑消耗
		public string buildingProduce = "";	//建筑产出数量
		public string buildingIcon = "";	//建筑图标
		public string buildingEffect = "";	//建筑特效
		public string buildingSound = "";	//建筑音效
		public string removePrice = "";	//拆除费用
		public string intoActorNatureConfig1 = "";	//驻守人员属性门槛1配置
		public int addRroduce1 = 0;	//驻守1产出加成
		public string intoActorNatureConfig2 = "";	//驻守人员属性门槛2配置
		public int addRroduce2 = 0;	//驻守2产出加成
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			buildingType = br.ReadInt32();	//建筑类型
			buildingName = br.ReadUInt32();	//建筑名称
			buildingLevel = br.ReadInt32();	//建筑等级
			buildingDes = br.ReadUInt32();	//建筑描述
			buildingConsume = br.ReadString();	//建筑消耗
			buildingProduce = br.ReadString();	//建筑产出数量
			buildingIcon = br.ReadString();	//建筑图标
			buildingEffect = br.ReadString();	//建筑特效
			buildingSound = br.ReadString();	//建筑音效
			removePrice = br.ReadString();	//拆除费用
			intoActorNatureConfig1 = br.ReadString();	//驻守人员属性门槛1配置
			addRroduce1 = br.ReadInt32();	//驻守1产出加成
			intoActorNatureConfig2 = br.ReadString();	//驻守人员属性门槛2配置
			addRroduce2 = br.ReadInt32();	//驻守2产出加成
			
        }
    } 
} 