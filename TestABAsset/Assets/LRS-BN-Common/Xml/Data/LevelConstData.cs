using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LevelConstData : BaseDataObject
    {
        
		public string mEditorDes = "";	//编辑器中文备注
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//关卡条件ID
			mEditorDes = br.ReadString();	//编辑器中文备注
			
        }
    } 
} 