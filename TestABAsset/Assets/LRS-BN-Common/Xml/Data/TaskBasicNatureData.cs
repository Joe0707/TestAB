using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskBasicNatureData : BaseDataObject
    {
        
		public string starIcon = "";	//星级图标
		public int displayNum = 0;	//显示数量
		public int needPrestige = 0;	//领取任务声望
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//星级ID
			starIcon = br.ReadString();	//星级图标
			displayNum = br.ReadInt32();	//显示数量
			needPrestige = br.ReadInt32();	//领取任务声望
			
        }
    } 
} 