using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementActorJobsData : BaseDataObject
    {
        
		public int actorJobID = 0;	//相亲角色职业编号
		public int targetJobID = 0;	//相亲对象职业ID
		public int targetRandomWeight = 0;	//相亲对象随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			actorJobID = br.ReadInt32();	//相亲角色职业编号
			targetJobID = br.ReadInt32();	//相亲对象职业ID
			targetRandomWeight = br.ReadInt32();	//相亲对象随机权重
			
        }
    } 
} 