using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class StringsData : BaseDataObject
    {
        
		public string mRefName = "";	//引用名称
		public string[] mStrings = new string[3];	//StringTable
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			mRefName = br.ReadString();	//引用名称
			ushort cnt3_2 = br.ReadUInt16();
			for(ushort i = 0; i < cnt3_2; i++)
				mStrings[i] = br.ReadString();	//StringTable
			
        }
    } 
} 