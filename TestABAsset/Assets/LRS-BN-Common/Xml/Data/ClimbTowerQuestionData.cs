using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerQuestionData : BaseDataObject
    {
        
		public string questionDes = "";	//问题描述
		public string answerOption = "";	//答案选项
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			questionDes = br.ReadString();	//问题描述
			answerOption = br.ReadString();	//答案选项
			
        }
    } 
} 