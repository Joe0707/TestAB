using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetQuestionData : BaseDataObject
    {
        
		public int sex = 0;	//性别
		public string banquetQuestionDes = "";	//宴会问题描述
		public string givePropConfig = "";	//赠送物品配置
		public string answerRewaed = "";	//回答奖励基数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//问题id
			sex = br.ReadInt32();	//性别
			banquetQuestionDes = br.ReadString();	//宴会问题描述
			givePropConfig = br.ReadString();	//赠送物品配置
			answerRewaed = br.ReadString();	//回答奖励基数
			
        }
    } 
} 