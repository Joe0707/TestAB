using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LegionSacredEffectData : BaseDataObject
    {
        
		public int effectId = 0;	//效果id
		public string equipmentType = "";	//装备类型
		public int effectLevel = 0;	//效果等级
		public int natureID = 0;	//效果属性ID
		public int addType = 0;	//数据增加类型
		public int natureNum = 0;	//效果属性值
		public int randomWeight = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			effectId = br.ReadInt32();	//效果id
			equipmentType = br.ReadString();	//装备类型
			effectLevel = br.ReadInt32();	//效果等级
			natureID = br.ReadInt32();	//效果属性ID
			addType = br.ReadInt32();	//数据增加类型
			natureNum = br.ReadInt32();	//效果属性值
			randomWeight = br.ReadInt32();	//随机权重
			
        }
    } 
} 