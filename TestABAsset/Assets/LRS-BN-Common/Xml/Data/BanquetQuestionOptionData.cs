using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetQuestionOptionData : BaseDataObject
    {
        
		public int questionID = 0;	//对应问题
		public string optionName = "";	//选项名称
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//选项编号
			questionID = br.ReadInt32();	//对应问题
			optionName = br.ReadString();	//选项名称
			
        }
    } 
} 