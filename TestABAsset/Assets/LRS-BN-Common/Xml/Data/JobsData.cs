using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class JobsData : BaseDataObject
    {
        
		public string JobType = "";	//职业类型ID
		public uint mName = 0;	//职业名称
		public string EditorJob = "";	//编辑器调用职业
		public string JobModelM = "";	//职业模型男
		public string JobModelF = "";	//职业模型女
		public int Hp = 0;	//初始生命
		public float Str = 0;	//初始力量
		public float Dex = 0;	//初始技巧
		public float Agi = 0;	//初始敏捷
		public float Vit = 0;	//初始体质
		public float Per = 0;	//初始感知
		public float Wil = 0;	//初始意志
		public float StrUp = 0;	//力量成长
		public float DexUp = 0;	//技巧成长
		public float AgiUp = 0;	//敏捷成长
		public float VitUp = 0;	//体质成长
		public float PerUp = 0;	//感知成长
		public float WilUp = 0;	//意志成长
		public float JobPerk1 = 0;	//初始被动技能1
		public int JobPerk2 = 0;	//初始被动技能2
		public int JobPerk3 = 0;	//初始被动技能3
		public int ArmorType = 0;	//可用护甲类型
		public string WeaponType = "";	//可用装备类型
		public int ulockCityId = 0;	//解锁条件
		public int ReqStr = 0;	//需求力量
		public int ReqDex = 0;	//需求技巧
		public int ReqAgi = 0;	//需求敏捷
		public int ReqVit = 0;	//需求体质
		public int ReqPer = 0;	//需求感知
		public int ReqWil = 0;	//需求意志
		public string transferPropId = "";	//转职道具id
		public int specialCountryId = 0;	//兵种特产国家
		public int RetireLoot = 0;	//退休返还道具
		public string jobDes = "";	//职业描述
		public string DetailDes = "";	//成长描述
		public string UpPropDes = "";	//成长率描述
		public int AAtkNum = 0;	//默认反击次数1
		public int RecruiPro = 0;	//招募概率
		public int RecruiCost = 0;	//招募价格
		public string Body_M = "";	//身体_男
		public string Clothes_M = "";	//衣服_男
		public string Body_F = "";	//身体_女
		public string Clothes_F = "";	//衣服_女
		public string MoveStyle = "";	//移动音效类型
		public int DefWpn = 0;	//默认武器
		public int ReqLvl = 0;	//最低等级
		public int PreJob = 0;	//前置职业
		public int DefSlot = 0;	//默认数值技能槽位
		public string UnlockDes = "";	//解锁描述
		public int Move = 0;	//移动力
		public int Horseshoe = 0;	//马蹄印
		public string equipmentType = "";	//武器类型
		public string armorType = "";	//防具类型
		public string ulockSkills = "";	//解锁技能
		public string natureGrowUp = "";	//属性成长
		public string teachConsumeItem = "";	//传授所需消耗物品
		public string jobIcon = "";	//职业图标Icon
		public string helmetModel_M = "";	//敌方男性头盔模型
		public string helmetModel_F = "";	//敌方女性头盔模型
		public int jobDamageType = 0;	//职业伤害类型
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//职业ID
			JobType = br.ReadString();	//职业类型ID
			mName = br.ReadUInt32();	//职业名称
			EditorJob = br.ReadString();	//编辑器调用职业
			JobModelM = br.ReadString();	//职业模型男
			JobModelF = br.ReadString();	//职业模型女
			Hp = br.ReadInt32();	//初始生命
			Str = br.ReadSingle();	//初始力量
			Dex = br.ReadSingle();	//初始技巧
			Agi = br.ReadSingle();	//初始敏捷
			Vit = br.ReadSingle();	//初始体质
			Per = br.ReadSingle();	//初始感知
			Wil = br.ReadSingle();	//初始意志
			StrUp = br.ReadSingle();	//力量成长
			DexUp = br.ReadSingle();	//技巧成长
			AgiUp = br.ReadSingle();	//敏捷成长
			VitUp = br.ReadSingle();	//体质成长
			PerUp = br.ReadSingle();	//感知成长
			WilUp = br.ReadSingle();	//意志成长
			JobPerk1 = br.ReadSingle();	//初始被动技能1
			JobPerk2 = br.ReadInt32();	//初始被动技能2
			JobPerk3 = br.ReadInt32();	//初始被动技能3
			ArmorType = br.ReadInt32();	//可用护甲类型
			WeaponType = br.ReadString();	//可用装备类型
			ulockCityId = br.ReadInt32();	//解锁条件
			ReqStr = br.ReadInt32();	//需求力量
			ReqDex = br.ReadInt32();	//需求技巧
			ReqAgi = br.ReadInt32();	//需求敏捷
			ReqVit = br.ReadInt32();	//需求体质
			ReqPer = br.ReadInt32();	//需求感知
			ReqWil = br.ReadInt32();	//需求意志
			transferPropId = br.ReadString();	//转职道具id
			specialCountryId = br.ReadInt32();	//兵种特产国家
			RetireLoot = br.ReadInt32();	//退休返还道具
			jobDes = br.ReadString();	//职业描述
			DetailDes = br.ReadString();	//成长描述
			UpPropDes = br.ReadString();	//成长率描述
			AAtkNum = br.ReadInt32();	//默认反击次数1
			RecruiPro = br.ReadInt32();	//招募概率
			RecruiCost = br.ReadInt32();	//招募价格
			Body_M = br.ReadString();	//身体_男
			Clothes_M = br.ReadString();	//衣服_男
			Body_F = br.ReadString();	//身体_女
			Clothes_F = br.ReadString();	//衣服_女
			MoveStyle = br.ReadString();	//移动音效类型
			DefWpn = br.ReadInt32();	//默认武器
			ReqLvl = br.ReadInt32();	//最低等级
			PreJob = br.ReadInt32();	//前置职业
			DefSlot = br.ReadInt32();	//默认数值技能槽位
			UnlockDes = br.ReadString();	//解锁描述
			Move = br.ReadInt32();	//移动力
			Horseshoe = br.ReadInt32();	//马蹄印
			equipmentType = br.ReadString();	//武器类型
			armorType = br.ReadString();	//防具类型
			ulockSkills = br.ReadString();	//解锁技能
			natureGrowUp = br.ReadString();	//属性成长
			teachConsumeItem = br.ReadString();	//传授所需消耗物品
			jobIcon = br.ReadString();	//职业图标Icon
			helmetModel_M = br.ReadString();	//敌方男性头盔模型
			helmetModel_F = br.ReadString();	//敌方女性头盔模型
			jobDamageType = br.ReadInt32();	//职业伤害类型
			
        }
    } 
} 