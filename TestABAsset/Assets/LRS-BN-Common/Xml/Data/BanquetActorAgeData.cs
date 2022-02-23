using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BanquetActorAgeData : BaseDataObject
    {
        
		public int sex = 0;	//性别
		public string ageRange = "";	//相亲者年龄
		public int targetAge = 0;	//相亲对象年龄
		public int RandomWeight = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			sex = br.ReadInt32();	//性别
			ageRange = br.ReadString();	//相亲者年龄
			targetAge = br.ReadInt32();	//相亲对象年龄
			RandomWeight = br.ReadInt32();	//随机权重
			
        }
    } 
} 