using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AgeDifferenceData : BaseDataObject
    {
        
		public int ageDifference = 0;	//年龄差值
		public float male = 0;	//相亲对象（男）
		public float female = 0;	//女
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			ageDifference = br.ReadInt32();	//年龄差值
			male = br.ReadSingle();	//相亲对象（男）
			female = br.ReadSingle();	//女
			
        }
    } 
} 