using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class DescentCoefficientData : BaseDataObject
    {
        
		public int decentId = 0;	//种族
		public int descentPro = 0;	//血脉比例
		public float descentWageCoefficient = 0;	//血脉薪资系数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			decentId = br.ReadInt32();	//种族
			descentPro = br.ReadInt32();	//血脉比例
			descentWageCoefficient = br.ReadSingle();	//血脉薪资系数
			
        }
    } 
} 