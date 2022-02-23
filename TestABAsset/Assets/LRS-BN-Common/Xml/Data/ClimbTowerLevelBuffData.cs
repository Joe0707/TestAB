using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerLevelBuffData : BaseDataObject
    {
        
		public string loopDes = "";	//循环描述
		public string buffID = "";	//添加buff
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			loopDes = br.ReadString();	//循环描述
			buffID = br.ReadString();	//添加buff
			
        }
    } 
} 