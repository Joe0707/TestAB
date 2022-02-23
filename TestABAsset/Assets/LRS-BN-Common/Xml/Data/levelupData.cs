using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LevelUpData : BaseDataObject
    {
        
		public int nextLevelExp = 0;	//下一级需求经验
		public float levelRecruitCost = 0;	//等级招募系数
		public int getNewskill = 0;	//获得新技能概率
		public string learnSkillType = "";	//可学习技能类型
		public string learmSkillTypePro = "";	//学习技能类型权重
		public string upSkillTypePro = "";	//升级技能类型权重
		public float pensionRate = 0;	//退休金系数
		public int monsterExp = 0;	//支线怪物经验
		public int basicWage = 0;	//基础工资
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（等级）
			nextLevelExp = br.ReadInt32();	//下一级需求经验
			levelRecruitCost = br.ReadSingle();	//等级招募系数
			getNewskill = br.ReadInt32();	//获得新技能概率
			learnSkillType = br.ReadString();	//可学习技能类型
			learmSkillTypePro = br.ReadString();	//学习技能类型权重
			upSkillTypePro = br.ReadString();	//升级技能类型权重
			pensionRate = br.ReadSingle();	//退休金系数
			monsterExp = br.ReadInt32();	//支线怪物经验
			basicWage = br.ReadInt32();	//基础工资
			
        }
    } 
} 