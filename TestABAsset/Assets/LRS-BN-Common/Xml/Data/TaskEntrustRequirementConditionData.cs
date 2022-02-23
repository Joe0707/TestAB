using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskEntrustRequirementConditionData : BaseDataObject
    {
        
		public string conditionTypeText = "";	//条件类型枚举
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			conditionTypeText = br.ReadString();	//条件类型枚举
			
        }
    } 
} 