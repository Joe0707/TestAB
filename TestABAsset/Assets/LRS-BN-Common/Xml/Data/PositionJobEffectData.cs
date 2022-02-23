using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class PositionJobEffectData : BaseDataObject
    {
        
		public int positionID = 0;	//职位
		public int jobID = 0;	//职业
		public int chaID = 0;	//特性效果ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			positionID = br.ReadInt32();	//职位
			jobID = br.ReadInt32();	//职业
			chaID = br.ReadInt32();	//特性效果ID
			
        }
    } 
} 