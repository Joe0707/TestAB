using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EffectResultsData : BaseDataObject
    {
        
		public string chineseDes = "";	//结果中文描述
		public int sevres = 0;	//服务器是否实现
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			chineseDes = br.ReadString();	//结果中文描述
			sevres = br.ReadInt32();	//服务器是否实现
			
        }
    } 
} 