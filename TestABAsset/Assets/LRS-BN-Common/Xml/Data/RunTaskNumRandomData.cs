using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RunTaskNumRandomData : BaseDataObject
    {
        
		public int star1Num = 0;	//1星
		public int star2Num = 0;	//2星
		public int star3Num = 0;	//3星
		public int star4Num = 0;	//4星
		public int star5Num = 0;	//5星
		public int star6Num = 0;	//6星
		public int star7Num = 0;	//7星
		public int star8Num = 0;	//8星
		public int star9Num = 0;	//9星
		public int star10Num = 0;	//10星
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//组编号
			star1Num = br.ReadInt32();	//1星
			star2Num = br.ReadInt32();	//2星
			star3Num = br.ReadInt32();	//3星
			star4Num = br.ReadInt32();	//4星
			star5Num = br.ReadInt32();	//5星
			star6Num = br.ReadInt32();	//6星
			star7Num = br.ReadInt32();	//7星
			star8Num = br.ReadInt32();	//8星
			star9Num = br.ReadInt32();	//9星
			star10Num = br.ReadInt32();	//10星
			
        }
    } 
} 