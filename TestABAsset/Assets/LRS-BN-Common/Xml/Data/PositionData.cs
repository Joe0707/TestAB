using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class PositionData : BaseDataObject
    {
        
		public string positionName = "";	//职位名称
		public string positionDes = "";	//职位描述
		public string unlockDes = "";	//职位解锁描述
		public string unlockConfig = "";	//解锁物品配置
		public int addWages = 0;	//增加基础工资
		public string positionIcon = "";	//职位图标
		public int activationSacredEffectNum = 0;	//激活圣物效果数量
		public int sacredEffectLevelLimit = 0;	//圣物特效等级上限
		public string breakConsume = "";	//突破消耗
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			positionName = br.ReadString();	//职位名称
			positionDes = br.ReadString();	//职位描述
			unlockDes = br.ReadString();	//职位解锁描述
			unlockConfig = br.ReadString();	//解锁物品配置
			addWages = br.ReadInt32();	//增加基础工资
			positionIcon = br.ReadString();	//职位图标
			activationSacredEffectNum = br.ReadInt32();	//激活圣物效果数量
			sacredEffectLevelLimit = br.ReadInt32();	//圣物特效等级上限
			breakConsume = br.ReadString();	//突破消耗
			
        }
    } 
} 