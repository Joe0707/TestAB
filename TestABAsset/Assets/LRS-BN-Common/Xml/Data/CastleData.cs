using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class CastleData : BaseDataObject
    {
        
		public string upgradeConfig = "";	//升级材料配置
		public string castleUpgradeTips = "";	//城堡升级提示
		public int unlockPrestigelevel = 0;	//解锁友好度等级
		public int goodsPriceC = 0;	//市场物资价格系数
		public int unlockQiSheng = 0;	//开放祈神厅上限
		public int unlockYanHui = 0;	//解锁宴庆厅
		public int unlockZhuZhan = 0;	//解锁主战厅
		public int unlockYingShang = 0;	//解锁营商厅
		public int unlockYuYing = 0;	//解锁育鹰厅
		public int position1Num = 0;	//职位1数量
		public int position2Num = 0;	//职位2数量
		public int blankNum = 0;	//封地数量
		public int engagementPeople = 0;	//相亲对象数量
		public int engagementNobility = 0;	//相亲对象最高爵位
		public float engagementCoefficient = 0;	//相亲系数
		public int unlockExperience = 0;	//解锁训练所（解锁历练）
		public int unlockSchoolTeacher = 0;	//解锁学校教师位置
		public int keyTrainingNum = 0;	//解锁重点培养数量
		public int unlockTeach = 0;	//解锁传授
		public int unlockHall = 0;	//解锁主厅
		public int expPondSize = 0;	//经验池容量
		public int tradeGoodsNum = 0;	//通商节货物显示数
		public int tradeSpecialtyNum = 0;	//通商节特产数量
		public int foisonGoodsNum = 0;	//丰饶节货物显示数
		public string castleChaGroup = "";	//城堡特性库
		public string keyTrainingGroup = "";	//重点培养特性库
		public int unlockTaskEntrustLevel = 0;	//委托任务解锁等级
		public int unlockConscription = 0;	//解锁征兵功能
		public int createDailyBattleTimes = 0;	//创建副本次数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//等级
			upgradeConfig = br.ReadString();	//升级材料配置
			castleUpgradeTips = br.ReadString();	//城堡升级提示
			unlockPrestigelevel = br.ReadInt32();	//解锁友好度等级
			goodsPriceC = br.ReadInt32();	//市场物资价格系数
			unlockQiSheng = br.ReadInt32();	//开放祈神厅上限
			unlockYanHui = br.ReadInt32();	//解锁宴庆厅
			unlockZhuZhan = br.ReadInt32();	//解锁主战厅
			unlockYingShang = br.ReadInt32();	//解锁营商厅
			unlockYuYing = br.ReadInt32();	//解锁育鹰厅
			position1Num = br.ReadInt32();	//职位1数量
			position2Num = br.ReadInt32();	//职位2数量
			blankNum = br.ReadInt32();	//封地数量
			engagementPeople = br.ReadInt32();	//相亲对象数量
			engagementNobility = br.ReadInt32();	//相亲对象最高爵位
			engagementCoefficient = br.ReadSingle();	//相亲系数
			unlockExperience = br.ReadInt32();	//解锁训练所（解锁历练）
			unlockSchoolTeacher = br.ReadInt32();	//解锁学校教师位置
			keyTrainingNum = br.ReadInt32();	//解锁重点培养数量
			unlockTeach = br.ReadInt32();	//解锁传授
			unlockHall = br.ReadInt32();	//解锁主厅
			expPondSize = br.ReadInt32();	//经验池容量
			tradeGoodsNum = br.ReadInt32();	//通商节货物显示数
			tradeSpecialtyNum = br.ReadInt32();	//通商节特产数量
			foisonGoodsNum = br.ReadInt32();	//丰饶节货物显示数
			castleChaGroup = br.ReadString();	//城堡特性库
			keyTrainingGroup = br.ReadString();	//重点培养特性库
			unlockTaskEntrustLevel = br.ReadInt32();	//委托任务解锁等级
			unlockConscription = br.ReadInt32();	//解锁征兵功能
			createDailyBattleTimes = br.ReadInt32();	//创建副本次数
			
        }
    } 
} 