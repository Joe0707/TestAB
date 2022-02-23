using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EffectConsData : BaseDataObject
    {
        
		public int Type = 0;	//条件类型
		public string Param1 = "";	//参数1
		public string Param2 = "";	//参数2
		public string Param3 = "";	//参数3
		public string Param4 = "";	//参数4
		public string ParamDesc = "";	//参数详细描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//条件ID
			Type = br.ReadInt32();	//条件类型
			Param1 = br.ReadString();	//参数1
			Param2 = br.ReadString();	//参数2
			Param3 = br.ReadString();	//参数3
			Param4 = br.ReadString();	//参数4
			ParamDesc = br.ReadString();	//参数详细描述
			
        }
    } 
} 