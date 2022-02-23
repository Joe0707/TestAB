using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AgeData : BaseDataObject
    {
        
		public float ageRecruitCoefficient = 0;	//年龄招募系数
		public float basicPregnantFemale = 0;	//女性基础怀孕概率
		public float basicPregnantMale = 0;	//男性基础怀孕概率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//年龄ID
			ageRecruitCoefficient = br.ReadSingle();	//年龄招募系数
			basicPregnantFemale = br.ReadSingle();	//女性基础怀孕概率
			basicPregnantMale = br.ReadSingle();	//男性基础怀孕概率
			
        }
    } 
} 