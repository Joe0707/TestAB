using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class PageData : BaseDataObject
    {
        
		public string pageName = "";	//界面名称
		public string pageDes = "";	//界面描述
		public string buttonID = "";	//按钮ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//页面id
			pageName = br.ReadString();	//界面名称
			pageDes = br.ReadString();	//界面描述
			buttonID = br.ReadString();	//按钮ID
			
        }
    } 
} 