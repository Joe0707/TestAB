using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipPromoteData : BaseDataObject
    {
        
		public int qualityType = 0;	//品质类型
		public string equipPromoteDes = "";	//品质描述
		public string equiptType = "";	//装备类型
		public int promoteUpgrade = 0;	//升品成功率
		public string qualityColor = "";	//品质文字颜色
		public int basicNatureAdd = 0;	//基础属性提升
		public int skillDownLimit = 0;	//技能槽下限
		public int skillUpLimit = 0;	//技能槽上限
		public int enchantUpLimit = 0;	//附魔级别上限
		public int inlayDownLimt = 0;	//镶嵌孔下限
		public int inlayUpLimt = 0;	//镶嵌孔上限
		public int promptequalityNum = 0;	//提升品质杀敌数
		public int promoteDownLimit = 0;	//提升概率下限
		public int promoteUpLimit = 0;	//提升概率上限
		public int propId = 0;	//提升成功率道具id
		public int propAddPro = 0;	//道具强化提供概率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//品质ID
			qualityType = br.ReadInt32();	//品质类型
			equipPromoteDes = br.ReadString();	//品质描述
			equiptType = br.ReadString();	//装备类型
			promoteUpgrade = br.ReadInt32();	//升品成功率
			qualityColor = br.ReadString();	//品质文字颜色
			basicNatureAdd = br.ReadInt32();	//基础属性提升
			skillDownLimit = br.ReadInt32();	//技能槽下限
			skillUpLimit = br.ReadInt32();	//技能槽上限
			enchantUpLimit = br.ReadInt32();	//附魔级别上限
			inlayDownLimt = br.ReadInt32();	//镶嵌孔下限
			inlayUpLimt = br.ReadInt32();	//镶嵌孔上限
			promptequalityNum = br.ReadInt32();	//提升品质杀敌数
			promoteDownLimit = br.ReadInt32();	//提升概率下限
			promoteUpLimit = br.ReadInt32();	//提升概率上限
			propId = br.ReadInt32();	//提升成功率道具id
			propAddPro = br.ReadInt32();	//道具强化提供概率
			
        }
    } 
} 