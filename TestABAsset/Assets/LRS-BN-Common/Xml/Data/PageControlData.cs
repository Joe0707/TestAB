using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class PageControlData : BaseDataObject
    {
        
		public int pageID = 0;	//界面编号
		public int displayAreaType = 0;	//显示区域编号
		public int displayNatureID = 0;	//显示属性ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			pageID = br.ReadInt32();	//界面编号
			displayAreaType = br.ReadInt32();	//显示区域编号
			displayNatureID = br.ReadInt32();	//显示属性ID
			
        }
    } 
} 