using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ArenaBuffData : BaseDataObject
    {
        
		public int type = 0;	//正负面类型
		public int armsType = 0;	//兵种类型
		public string armsName = "";	//兵种名称
		public int buffID = 0;	//buffID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			type = br.ReadInt32();	//正负面类型
			armsType = br.ReadInt32();	//兵种类型
			armsName = br.ReadString();	//兵种名称
			buffID = br.ReadInt32();	//buffID
			
        }
    } 
} 