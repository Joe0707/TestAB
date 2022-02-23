using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipmentsData : BaseDataObject
    {
        
		public uint mName = 0;	//装备名称
		public int Type = 0;	//装备类型
		public int Quality = 0;	//装备品质
		public string Source = "";	//获取来源
		public int Str = 0;	//力量需求
		public int Wgt = 0;	//负重
		public int HitRate = 0;	//基础命中率
		public string nature = "";	//属性配置
		public int Skill = 0;	//技能
		public int AdSkill = 0;	//辅助技能
		public int BlockRate = 0;	//格挡率
		public int Effect1 = 0;	//装备效果1
		public int Effect2 = 0;	//装备效果2
		public int Effect3 = 0;	//装备效果3
		public GlobalDefine.EHangPointType hangPointType;	//武器挂点类型
		public string WpnModel = "";	//武器模型
		public string quiverModel = "";	//箭袋模型
		public string Icon = "";	//图标
		public string BigIcon = "";	//大图标
		public int basePrice = 0;	//基础价格
		public string sellPrice = "";	//商会价格
		public int uesPrestige = 0;	//所需声望
		public string Des = "";	//装备描述
		public string sellDisplay = "";	//商会出售显示
		public int trainEquipment = 0;	//训练武器
		public string jobAnimator = "";	//职业动画
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//装备ID（调用ID）
			mName = br.ReadUInt32();	//装备名称
			Type = br.ReadInt32();	//装备类型
			Quality = br.ReadInt32();	//装备品质
			Source = br.ReadString();	//获取来源
			Str = br.ReadInt32();	//力量需求
			Wgt = br.ReadInt32();	//负重
			HitRate = br.ReadInt32();	//基础命中率
			nature = br.ReadString();	//属性配置
			Skill = br.ReadInt32();	//技能
			AdSkill = br.ReadInt32();	//辅助技能
			BlockRate = br.ReadInt32();	//格挡率
			Effect1 = br.ReadInt32();	//装备效果1
			Effect2 = br.ReadInt32();	//装备效果2
			Effect3 = br.ReadInt32();	//装备效果3
			hangPointType = (GlobalDefine.EHangPointType)br.ReadUInt16();	//武器挂点类型
			WpnModel = br.ReadString();	//武器模型
			quiverModel = br.ReadString();	//箭袋模型
			Icon = br.ReadString();	//图标
			BigIcon = br.ReadString();	//大图标
			basePrice = br.ReadInt32();	//基础价格
			sellPrice = br.ReadString();	//商会价格
			uesPrestige = br.ReadInt32();	//所需声望
			Des = br.ReadString();	//装备描述
			sellDisplay = br.ReadString();	//商会出售显示
			trainEquipment = br.ReadInt32();	//训练武器
			jobAnimator = br.ReadString();	//职业动画
			
        }
    } 
} 