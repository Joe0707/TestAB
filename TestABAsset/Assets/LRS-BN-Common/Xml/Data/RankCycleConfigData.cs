using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RankCycleConfigData : BaseDataObject
    {
        
		public string timeName = "";	//周期名称
		public string openTime = "";	//开始时间
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			timeName = br.ReadString();	//周期名称
			openTime = br.ReadString();	//开始时间
			
        }
    } 
} 