using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SkillStudyConfigData : BaseDataObject
    {
        
		public int skillID = 0;	//技能ID
		public int jobMID = 0;	//职业编号
		public int skillLvMax = 0;	//技能等级上限
		public int skillStudyWeight = 0;	//技能学习权重
		public int skillUpWeight = 0;	//技能升级权重
		public int slotType = 0;	//槽位说明
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//主键
			skillID = br.ReadInt32();	//技能ID
			jobMID = br.ReadInt32();	//职业编号
			skillLvMax = br.ReadInt32();	//技能等级上限
			skillStudyWeight = br.ReadInt32();	//技能学习权重
			skillUpWeight = br.ReadInt32();	//技能升级权重
			slotType = br.ReadInt32();	//槽位说明
			
        }
    } 
} 