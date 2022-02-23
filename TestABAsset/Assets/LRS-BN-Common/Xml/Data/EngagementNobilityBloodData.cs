using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EngagementNobilityBloodData : BaseDataObject
    {
        
		public string royalBloodLimit = "";	//王血比例极限
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//爵位等级
			royalBloodLimit = br.ReadString();	//王血比例极限
			
        }
    } 
} 