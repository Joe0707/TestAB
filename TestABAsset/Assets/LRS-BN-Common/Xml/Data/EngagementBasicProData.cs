using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementBasicProData : BaseDataObject
    {
        
		public int nobility1 = 0;	//平民
		public int nobility2 = 0;	//荣誉骑士
		public int nobility3 = 0;	//封号骑士
		public int nobility4 = 0;	//皇家骑士
		public int nobility5 = 0;	//三等爵士
		public int nobility6 = 0;	//二等爵士
		public int nobility7 = 0;	//一等爵士
		public int nobility8 = 0;	//三等男爵
		public int nobility9 = 0;	//二等男爵
		public int nobility10 = 0;	//一等男爵
		public int nobility11 = 0;	//三等子爵
		public int nobility12 = 0;	//二等子爵
		public int nobility13 = 0;	//一等子爵
		public int nobility14 = 0;	//三等伯爵
		public int nobility15 = 0;	//二等伯爵
		public int nobility16 = 0;	//一等伯爵
		public int nobility17 = 0;	//三等侯爵
		public int nobility18 = 0;	//二等侯爵
		public int nobility19 = 0;	//一等侯爵
		public int nobility20 = 0;	//三等公爵
		public int nobility21 = 0;	//二等公爵
		public int nobility22 = 0;	//一等公爵
		public int nobility23 = 0;	//大公爵
		public int nobility24 = 0;	//亲王
		public string ageRange = "";	//年龄范围
		public string ageFloatRange = "";	//历练相亲年龄浮动范围
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//爵位id
			nobility1 = br.ReadInt32();	//平民
			nobility2 = br.ReadInt32();	//荣誉骑士
			nobility3 = br.ReadInt32();	//封号骑士
			nobility4 = br.ReadInt32();	//皇家骑士
			nobility5 = br.ReadInt32();	//三等爵士
			nobility6 = br.ReadInt32();	//二等爵士
			nobility7 = br.ReadInt32();	//一等爵士
			nobility8 = br.ReadInt32();	//三等男爵
			nobility9 = br.ReadInt32();	//二等男爵
			nobility10 = br.ReadInt32();	//一等男爵
			nobility11 = br.ReadInt32();	//三等子爵
			nobility12 = br.ReadInt32();	//二等子爵
			nobility13 = br.ReadInt32();	//一等子爵
			nobility14 = br.ReadInt32();	//三等伯爵
			nobility15 = br.ReadInt32();	//二等伯爵
			nobility16 = br.ReadInt32();	//一等伯爵
			nobility17 = br.ReadInt32();	//三等侯爵
			nobility18 = br.ReadInt32();	//二等侯爵
			nobility19 = br.ReadInt32();	//一等侯爵
			nobility20 = br.ReadInt32();	//三等公爵
			nobility21 = br.ReadInt32();	//二等公爵
			nobility22 = br.ReadInt32();	//一等公爵
			nobility23 = br.ReadInt32();	//大公爵
			nobility24 = br.ReadInt32();	//亲王
			ageRange = br.ReadString();	//年龄范围
			ageFloatRange = br.ReadString();	//历练相亲年龄浮动范围
			
        }
    } 
} 