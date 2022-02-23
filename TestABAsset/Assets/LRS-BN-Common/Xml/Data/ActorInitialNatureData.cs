using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ActorInitialNatureData : BaseDataObject
    {
        
		public int actorLevel = 0;	//初始等级
		public int ageMax = 0;	//最大年龄
		public int oldAge = 0;	//衰老年龄
		public int premature = 0;	//衰老延迟年龄
		public int retireage = 0;	//退休年龄
		public int initialStr = 0;	//初始基础力量
		public int initialVit = 0;	//初始基础体质
		public int initialDex = 0;	//初始基础技巧
		public int initialAgi = 0;	//初始基础敏捷
		public int initialPer = 0;	//初始基础感知
		public int initialWil = 0;	//初始基础意志
		public int HP = 0;	//初始HP
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//初始种族ID
			actorLevel = br.ReadInt32();	//初始等级
			ageMax = br.ReadInt32();	//最大年龄
			oldAge = br.ReadInt32();	//衰老年龄
			premature = br.ReadInt32();	//衰老延迟年龄
			retireage = br.ReadInt32();	//退休年龄
			initialStr = br.ReadInt32();	//初始基础力量
			initialVit = br.ReadInt32();	//初始基础体质
			initialDex = br.ReadInt32();	//初始基础技巧
			initialAgi = br.ReadInt32();	//初始基础敏捷
			initialPer = br.ReadInt32();	//初始基础感知
			initialWil = br.ReadInt32();	//初始基础意志
			HP = br.ReadInt32();	//初始HP
			
        }
    } 
} 