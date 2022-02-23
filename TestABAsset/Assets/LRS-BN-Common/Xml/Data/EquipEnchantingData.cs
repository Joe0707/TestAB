using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipEnchantingData : BaseDataObject
    {
        
		public int coolingTime = 0;	//附魔冷却时间
		public int successRate = 0;	//附魔成功率
		public int addRange = 0;	//附魔提升幅度
		public string upgradeConfig = "";	//附魔所需材料配置
		public int upgradePrice = 0;	//附魔消耗银币
		public string natureRefreshWeight = "";	//属性类型刷新权重
		public int enchantingAddId = 0;	//附魔成功率提升道具
		public int enchantingProtectId = 0;	//附魔保护道具
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//等级
			coolingTime = br.ReadInt32();	//附魔冷却时间
			successRate = br.ReadInt32();	//附魔成功率
			addRange = br.ReadInt32();	//附魔提升幅度
			upgradeConfig = br.ReadString();	//附魔所需材料配置
			upgradePrice = br.ReadInt32();	//附魔消耗银币
			natureRefreshWeight = br.ReadString();	//属性类型刷新权重
			enchantingAddId = br.ReadInt32();	//附魔成功率提升道具
			enchantingProtectId = br.ReadInt32();	//附魔保护道具
			
        }
    } 
} 