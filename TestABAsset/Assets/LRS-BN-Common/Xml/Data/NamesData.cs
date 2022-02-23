using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class NamesData : BaseDataObject
    {
        
		public int descentType = 0;	//种族血脉
		public int descentRate = 0;	//血脉比例
		public int sex = 0;	//性别
		public string name = "";	//名称
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（调用ID）
			descentType = br.ReadInt32();	//种族血脉
			descentRate = br.ReadInt32();	//血脉比例
			sex = br.ReadInt32();	//性别
			name = br.ReadString();	//名称
			
        }
    } 
} 