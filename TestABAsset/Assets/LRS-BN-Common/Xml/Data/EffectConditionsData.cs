using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EffectConditionsData : BaseDataObject
    {
        
		public string chineseDes = "";	//条件中文描述，条件的默认主体都为BUFF的挂载者
		public int server = 0;	//服务器是否实现
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			chineseDes = br.ReadString();	//条件中文描述，条件的默认主体都为BUFF的挂载者
			server = br.ReadInt32();	//服务器是否实现
			
        }
    } 
} 