using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ActorData : BaseDataObject
    {
        
		public string mName = "";	//角色名字（字符串）
		public int SodierType = 0;	//角色职业ID
		public int FatherID = 0;	//角色父亲ID（actors表内ID）
		public int MatherID = 0;	//角色母亲ID（actors表内ID）
		public int Spouse = 0;	//配偶ID（actors表内ID）
		public int childOrder = 0;	//子嗣顺序
		public int Level = 0;	//角色等级（数值）
		public int Hp = 0;	//角色血量（初始）
		public int Str = 0;	//角色力量（初始）
		public int Dex = 0;	//角色技巧（初始）
		public int Agi = 0;	//角色敏捷（初始）
		public int Vit = 0;	//角色体质（初始）
		public int Per = 0;	//角色感知（初始）
		public int Wil = 0;	//角色意志（初始）
		public float Strup = 0;	//角色力量成长
		public float Dexup = 0;	//角色技巧成长
		public float Agiup = 0;	//角色敏捷成长
		public float Vitup = 0;	//角色体质成长
		public float Perup = 0;	//角色感知成长
		public float Wilup = 0;	//角色意志成长
		public int Gender = 0;	//性别（0未知1男2女）
		public int Age = 0;	//初始年龄（年）
		public int AgeMax = 0;	//最大年龄（年）
		public int OldAge = 0;	//衰老年龄（年）
		public int Premature = 0;	//衰老延迟（年）
		public int Retireage = 0;	//退休年龄（年）
		public int countryId = 0;	//国家ID
		public int Rank = 0;	//爵位等级
		public int Heroid = 0;	//英雄ID（暂不知作用）
		public string Partid = "";	//固定脸模ID
		public string Perk = "";	//特性ID
		public int Weapon = 0;	//武器
		public int Assistant = 0;	//副手
		public int Head = 0;	//头盔
		public int Chest = 0;	//胸甲
		public int Boots = 0;	//靴子
		public int Ornaments = 0;	//饰品
		public int SkillId = 0;	//已装备主动技能1ID
		public int BuffId2 = 0;	//已被动装备技能2ID
		public int BuffId3 = 0;	//已被动装备技能3ID
		public int BuffId4 = 0;	//已被动装备技能4ID
		public int BuffId5 = 0;	//已被动装备技能5ID
		public int BuffId6 = 0;	//已被动装备技能6ID
		public string NoneSkId = "";	//未装备技能ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			mName = br.ReadString();	//角色名字（字符串）
			SodierType = br.ReadInt32();	//角色职业ID
			FatherID = br.ReadInt32();	//角色父亲ID（actors表内ID）
			MatherID = br.ReadInt32();	//角色母亲ID（actors表内ID）
			Spouse = br.ReadInt32();	//配偶ID（actors表内ID）
			childOrder = br.ReadInt32();	//子嗣顺序
			Level = br.ReadInt32();	//角色等级（数值）
			Hp = br.ReadInt32();	//角色血量（初始）
			Str = br.ReadInt32();	//角色力量（初始）
			Dex = br.ReadInt32();	//角色技巧（初始）
			Agi = br.ReadInt32();	//角色敏捷（初始）
			Vit = br.ReadInt32();	//角色体质（初始）
			Per = br.ReadInt32();	//角色感知（初始）
			Wil = br.ReadInt32();	//角色意志（初始）
			Strup = br.ReadSingle();	//角色力量成长
			Dexup = br.ReadSingle();	//角色技巧成长
			Agiup = br.ReadSingle();	//角色敏捷成长
			Vitup = br.ReadSingle();	//角色体质成长
			Perup = br.ReadSingle();	//角色感知成长
			Wilup = br.ReadSingle();	//角色意志成长
			Gender = br.ReadInt32();	//性别（0未知1男2女）
			Age = br.ReadInt32();	//初始年龄（年）
			AgeMax = br.ReadInt32();	//最大年龄（年）
			OldAge = br.ReadInt32();	//衰老年龄（年）
			Premature = br.ReadInt32();	//衰老延迟（年）
			Retireage = br.ReadInt32();	//退休年龄（年）
			countryId = br.ReadInt32();	//国家ID
			Rank = br.ReadInt32();	//爵位等级
			Heroid = br.ReadInt32();	//英雄ID（暂不知作用）
			Partid = br.ReadString();	//固定脸模ID
			Perk = br.ReadString();	//特性ID
			Weapon = br.ReadInt32();	//武器
			Assistant = br.ReadInt32();	//副手
			Head = br.ReadInt32();	//头盔
			Chest = br.ReadInt32();	//胸甲
			Boots = br.ReadInt32();	//靴子
			Ornaments = br.ReadInt32();	//饰品
			SkillId = br.ReadInt32();	//已装备主动技能1ID
			BuffId2 = br.ReadInt32();	//已被动装备技能2ID
			BuffId3 = br.ReadInt32();	//已被动装备技能3ID
			BuffId4 = br.ReadInt32();	//已被动装备技能4ID
			BuffId5 = br.ReadInt32();	//已被动装备技能5ID
			BuffId6 = br.ReadInt32();	//已被动装备技能6ID
			NoneSkId = br.ReadString();	//未装备技能ID
			
        }
    } 
} 