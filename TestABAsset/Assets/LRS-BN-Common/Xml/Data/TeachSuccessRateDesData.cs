using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TeachSuccessRateDesData : BaseDataObject
    {
        
		public string successRateDes = "";	//描述
		public string judgeRange = "";	//判定
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			successRateDes = br.ReadString();	//描述
			judgeRange = br.ReadString();	//判定
			
        }
    } 
} 