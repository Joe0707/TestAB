using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SchoolChaRandomResultData : BaseDataObject
    {
        
		public int trainingType = 0;	//分类
		public int castlePro = 0;	//城堡库权重
		public int keyTrainingPro = 0;	//重点培养库权重
		public int teacherPro = 0;	//教师库权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			trainingType = br.ReadInt32();	//分类
			castlePro = br.ReadInt32();	//城堡库权重
			keyTrainingPro = br.ReadInt32();	//重点培养库权重
			teacherPro = br.ReadInt32();	//教师库权重
			
        }
    } 
} 