using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AiData : BaseDataObject
    {
        
		public int Group = 0;	//组ID
		public int Type = 0;	//ai类型
		public string Desc = "";	//触发器描述
		public int Param1 = 0;	//参数1
		public int Param2 = 0;	//参数2
		public int Param3 = 0;	//参数3
		public int Param4 = 0;	//参数4
		public int Param5 = 0;	//参数5
		public string Param = "";	//撤退点参数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（调用ID）
			Group = br.ReadInt32();	//组ID
			Type = br.ReadInt32();	//ai类型
			Desc = br.ReadString();	//触发器描述
			Param1 = br.ReadInt32();	//参数1
			Param2 = br.ReadInt32();	//参数2
			Param3 = br.ReadInt32();	//参数3
			Param4 = br.ReadInt32();	//参数4
			Param5 = br.ReadInt32();	//参数5
			Param = br.ReadString();	//撤退点参数
			
        }
    } 
} 