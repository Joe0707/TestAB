using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class MoraleActionData : BaseDataObject
    {
        
		public string eventConfig = "";	//事件配置
		public int moraleNum = 0;	//士气值变化
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//事件id
			eventConfig = br.ReadString();	//事件配置
			moraleNum = br.ReadInt32();	//士气值变化
			
        }
    } 
} 