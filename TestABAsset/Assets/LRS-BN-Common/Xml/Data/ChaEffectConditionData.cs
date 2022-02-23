using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ChaEffectConditionData : BaseDataObject
    {
        
		public string chaTypeStr = "";	//特性类型字符串
		public string typeDes = "";	//触发条件类型描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			chaTypeStr = br.ReadString();	//特性类型字符串
			typeDes = br.ReadString();	//触发条件类型描述
			
        }
    } 
} 