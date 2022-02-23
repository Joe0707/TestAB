using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipBuffExtractData : BaseDataObject
    {
        
		public string equipType = "";	//可安装装备类型
		public string buffExtractPrice = "";	//技能提取消耗银币
		public string buffExtractProp = "";	//技能提取道具
		public string buffExtractPropEncap = "";	//技能封装道具
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			equipType = br.ReadString();	//可安装装备类型
			buffExtractPrice = br.ReadString();	//技能提取消耗银币
			buffExtractProp = br.ReadString();	//技能提取道具
			buffExtractPropEncap = br.ReadString();	//技能封装道具
			
        }
    } 
} 