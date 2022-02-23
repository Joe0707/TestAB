using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TeachSuccessRateData : BaseDataObject
    {
        
		public string skillSlotType = "";	//技能槽位类型
		public int skillLevel = 0;	//技能等级
		public string successRandomRange = "";	//成功率随机范围
		public string successRateDes = "";	//描述
		public int upgradeSkillPro = 0;	//升级技能权重乘算比例
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			skillSlotType = br.ReadString();	//技能槽位类型
			skillLevel = br.ReadInt32();	//技能等级
			successRandomRange = br.ReadString();	//成功率随机范围
			successRateDes = br.ReadString();	//描述
			upgradeSkillPro = br.ReadInt32();	//升级技能权重乘算比例
			
        }
    } 
} 