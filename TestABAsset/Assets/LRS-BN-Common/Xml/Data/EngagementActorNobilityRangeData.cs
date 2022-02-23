using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementActorNobilityRangeData : BaseDataObject
    {
        
		public int nobilityLevel1 = 0;	//爵位-1
		public int nobilityLevel2 = 0;	//爵位相同（0）
		public int nobilityLevel3 = 0;	//爵位+1
		public int nobilityLevel4 = 0;	//爵位+2
		public int nobilityUp_1 = 0;	//爵位+1基础成功率
		public int nobilityUp_2 = 0;	//爵位+2基础成功率
		public int engagementUnlockPrestigeLevel = 0;	//联姻国家解锁声望等级
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			nobilityLevel1 = br.ReadInt32();	//爵位-1
			nobilityLevel2 = br.ReadInt32();	//爵位相同（0）
			nobilityLevel3 = br.ReadInt32();	//爵位+1
			nobilityLevel4 = br.ReadInt32();	//爵位+2
			nobilityUp_1 = br.ReadInt32();	//爵位+1基础成功率
			nobilityUp_2 = br.ReadInt32();	//爵位+2基础成功率
			engagementUnlockPrestigeLevel = br.ReadInt32();	//联姻国家解锁声望等级
			
        }
    } 
} 