using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LegionSacredEffectUpgradeData : BaseDataObject
    {
        
		public int addType = 0;	//数据增加类型
		public int effectLevel = 0;	//效果等级
		public int natureNum = 0;	//效果增加值
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			addType = br.ReadInt32();	//数据增加类型
			effectLevel = br.ReadInt32();	//效果等级
			natureNum = br.ReadInt32();	//效果增加值
			
        }
    } 
} 