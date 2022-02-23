using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TriggersData : BaseDataObject
    {
        
		public string triggersDsc = "";	//触发器描述
		public int type = 0;	//触发器类型
		public string parameterConfig = "";	//触发器类型参数
		public string triggersIcon = "";	//触发器图标
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//触发器ID
			triggersDsc = br.ReadString();	//触发器描述
			type = br.ReadInt32();	//触发器类型
			parameterConfig = br.ReadString();	//触发器类型参数
			triggersIcon = br.ReadString();	//触发器图标
			
        }
    } 
} 