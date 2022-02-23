using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SkillLevelCoefficientData : BaseDataObject
    {
        
		public float levelCoefficient = 0;	//等级系数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//等级编号
			levelCoefficient = br.ReadSingle();	//等级系数
			
        }
    } 
} 