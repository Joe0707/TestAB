using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ColorData : BaseDataObject
    {
        
		public int descentType = 0;	//血脉类型
		public int colorType = 0;	//颜色类型
		public string desc = "";	//血脉备注
		public string rgb = "";	//色值
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID（颜色ID）
			descentType = br.ReadInt32();	//血脉类型
			colorType = br.ReadInt32();	//颜色类型
			desc = br.ReadString();	//血脉备注
			rgb = br.ReadString();	//色值
			
        }
    } 
} 