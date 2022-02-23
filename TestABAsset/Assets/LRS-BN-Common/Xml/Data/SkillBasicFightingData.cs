using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SkillBasicFightingData : BaseDataObject
    {
        
		public int basicFighting = 0;	//基础战力
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			basicFighting = br.ReadInt32();	//基础战力
			
        }
    } 
} 