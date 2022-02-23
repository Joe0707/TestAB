using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerAnswerData : BaseDataObject
    {
        
		public string answerDes = "";	//答案描述
		public string cardID = "";	//获得对应卡牌
		public int nextQuestion = 0;	//下一个问题
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			answerDes = br.ReadString();	//答案描述
			cardID = br.ReadString();	//获得对应卡牌
			nextQuestion = br.ReadInt32();	//下一个问题
			
        }
    } 
} 