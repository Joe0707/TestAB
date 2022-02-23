using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FunctionExplainData : BaseDataObject
    {
        
		public string BGM = "";	//背景图片
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//功能ID
			BGM = br.ReadString();	//背景图片
			
        }
    } 
} 