using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ExteriorPartData : BaseDataObject
    {
        
		public string partType = "";	//部件类型
		public uint partName = 0;	//部件名称
		public string partChineseName = "";	//部件中文名
		public int descentType = 0;	//血统类型
		public int needWeights = 0;	//需要权重
		public int maxWeights = 0;	//封顶权重
		public int giveWeights = 0;	//赋予权重
		public int randomWeights = 0;	//随机权重
		public int parentsWeights = 0;	//亲代加权
		public int nobilityLevel = 0;	//爵位等级
		public string maleRes = "";	//男性资源
		public string femaleRes = "";	//女性资源
		public uint colorId = 0;	//颜色ID
		public int giveBuff = 0;	//赋予状态
		public int isOnBeard2 = 0;	//适配大胡子
		public int isOnHairJewelry = 0;	//适配发饰
		public string maleModelRes = "";	//男性发型模型
		public string femaleModelRes = "";	//女性发型模型
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（调用ID）
			partType = br.ReadString();	//部件类型
			partName = br.ReadUInt32();	//部件名称
			partChineseName = br.ReadString();	//部件中文名
			descentType = br.ReadInt32();	//血统类型
			needWeights = br.ReadInt32();	//需要权重
			maxWeights = br.ReadInt32();	//封顶权重
			giveWeights = br.ReadInt32();	//赋予权重
			randomWeights = br.ReadInt32();	//随机权重
			parentsWeights = br.ReadInt32();	//亲代加权
			nobilityLevel = br.ReadInt32();	//爵位等级
			maleRes = br.ReadString();	//男性资源
			femaleRes = br.ReadString();	//女性资源
			colorId = br.ReadUInt32();	//颜色ID
			giveBuff = br.ReadInt32();	//赋予状态
			isOnBeard2 = br.ReadInt32();	//适配大胡子
			isOnHairJewelry = br.ReadInt32();	//适配发饰
			maleModelRes = br.ReadString();	//男性发型模型
			femaleModelRes = br.ReadString();	//女性发型模型
			
        }
    } 
} 