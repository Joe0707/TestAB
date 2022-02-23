using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class CannotRefinementData : BaseDataObject
    {
        
		public string attrStr = "";	//属性字符串
		public string desc = "";	//属性名注释
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//主键/枚举值
			attrStr = br.ReadString();	//属性字符串
			desc = br.ReadString();	//属性名注释
			
        }
    } 
} 