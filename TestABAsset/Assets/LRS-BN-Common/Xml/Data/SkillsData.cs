using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SkillsData : BaseDataObject
    {
        
		public int skillId = 0;	//技能id
		public string skillName = "";	//技能名
		public string chineseName = "";	//中文名
		public int skillType = 0;	//技能类型
		public int skilllevel = 0;	//技能等级
		public int apConsume = 0;	//消耗AP
		public string damageType = "";	//伤害类型
		public string skillEffect = "";	//技能效果
		public string skillDes = "";	//技能描述
		public string chineseDes = "";	//中文描述
		public string effectParameter = "";	//效果参数
		public int skillRange = 0;	//技能射程
		public int damageScope = 0;	//伤害范围
		public int damageCentrePoint = 0;	//伤害中心
		public string usableJob = "";	//可使用职业
		public int skillDisplay = 0;	//是否在技能栏显示
		public string skillIcon = "";	//技能图标
		public string skilArtlEffect = "";	//技能美术效果
		public int teachSkill = 0;	//技能是否可传授
		public string teachNeedNature = "";	//技能传授所需属性
		public string optionalTarget = "";	//技能触发后可选目标
		public int triggerCounterattack = 0;	//是否可触发反击
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			skillId = br.ReadInt32();	//技能id
			skillName = br.ReadString();	//技能名
			chineseName = br.ReadString();	//中文名
			skillType = br.ReadInt32();	//技能类型
			skilllevel = br.ReadInt32();	//技能等级
			apConsume = br.ReadInt32();	//消耗AP
			damageType = br.ReadString();	//伤害类型
			skillEffect = br.ReadString();	//技能效果
			skillDes = br.ReadString();	//技能描述
			chineseDes = br.ReadString();	//中文描述
			effectParameter = br.ReadString();	//效果参数
			skillRange = br.ReadInt32();	//技能射程
			damageScope = br.ReadInt32();	//伤害范围
			damageCentrePoint = br.ReadInt32();	//伤害中心
			usableJob = br.ReadString();	//可使用职业
			skillDisplay = br.ReadInt32();	//是否在技能栏显示
			skillIcon = br.ReadString();	//技能图标
			skilArtlEffect = br.ReadString();	//技能美术效果
			teachSkill = br.ReadInt32();	//技能是否可传授
			teachNeedNature = br.ReadString();	//技能传授所需属性
			optionalTarget = br.ReadString();	//技能触发后可选目标
			triggerCounterattack = br.ReadInt32();	//是否可触发反击
			
        }
    } 
} 