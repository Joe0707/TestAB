using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetResultCoefficientData : BaseDataObject
    {
        
		public int resultType = 0;	//结果类型
		public float randomCoefficient = 0;	//随机取值系数
		public int dorpWeight = 0;	//掉落权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			resultType = br.ReadInt32();	//结果类型
			randomCoefficient = br.ReadSingle();	//随机取值系数
			dorpWeight = br.ReadInt32();	//掉落权重
			
        }
    } 
} 