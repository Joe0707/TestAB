using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetQuestionResultData : BaseDataObject
    {
        
		public int sex = 0;	//性别
		public int resultType = 0;	//结果类型
		public int randomWeight = 0;	//随机权重
		public string resultDes = "";	//结果描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//结果编号
			sex = br.ReadInt32();	//性别
			resultType = br.ReadInt32();	//结果类型
			randomWeight = br.ReadInt32();	//随机权重
			resultDes = br.ReadString();	//结果描述
			
        }
    } 
} 