using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ReplyData : BaseDataObject
    {
        
		public int replyType = 0;	//回信类型
		public int sex = 0;	//性别
		public string letterText = "";	//回信内容
		public string peachResultDes = "";	//香桃节回话
		public int dropWeight = 0;	//掉落权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			replyType = br.ReadInt32();	//回信类型
			sex = br.ReadInt32();	//性别
			letterText = br.ReadString();	//回信内容
			peachResultDes = br.ReadString();	//香桃节回话
			dropWeight = br.ReadInt32();	//掉落权重
			
        }
    } 
} 