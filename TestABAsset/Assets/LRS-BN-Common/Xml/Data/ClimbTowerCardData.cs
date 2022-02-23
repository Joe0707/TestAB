using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerCardData : BaseDataObject
    {
        
		public string cardName = "";	//模版名称
		public string cardTemplate = "";	//图案面模板
		public string buffTemplate = "";	//buff面模板
		public int buffID = 0;	//对应buffID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			cardName = br.ReadString();	//模版名称
			cardTemplate = br.ReadString();	//图案面模板
			buffTemplate = br.ReadString();	//buff面模板
			buffID = br.ReadInt32();	//对应buffID
			
        }
    } 
} 