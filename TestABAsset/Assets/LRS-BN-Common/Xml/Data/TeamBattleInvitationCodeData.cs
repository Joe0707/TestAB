using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TeamBattleInvitationCodeData : BaseDataObject
    {
        
		public int type = 0;	//类型
		public string element = "";	//元素
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			type = br.ReadInt32();	//类型
			element = br.ReadString();	//元素
			
        }
    } 
} 