using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RankFirstConfigData : BaseDataObject
    {
        
		public string rankFirstName = "";	//排行榜名称
		public int displaySort = 0;	//显示顺序
		public int clientDisplay = 0;	//是否显示
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			rankFirstName = br.ReadString();	//排行榜名称
			displaySort = br.ReadInt32();	//显示顺序
			clientDisplay = br.ReadInt32();	//是否显示
			
        }
    } 
} 