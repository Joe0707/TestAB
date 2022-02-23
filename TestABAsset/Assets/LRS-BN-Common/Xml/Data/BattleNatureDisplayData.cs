using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BattleNatureDisplayData : BaseDataObject
    {
        
		public int natureID_1 = 0;	//战斗显示属性1ID
		public int natureID_2 = 0;	//战斗显示属性2ID
		public int natureID_3 = 0;	//战斗显示属性3ID
		public int natureID_4 = 0;	//战斗显示属性4ID
		public int natureID_5 = 0;	//战斗显示属性5ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//职业
			natureID_1 = br.ReadInt32();	//战斗显示属性1ID
			natureID_2 = br.ReadInt32();	//战斗显示属性2ID
			natureID_3 = br.ReadInt32();	//战斗显示属性3ID
			natureID_4 = br.ReadInt32();	//战斗显示属性4ID
			natureID_5 = br.ReadInt32();	//战斗显示属性5ID
			
        }
    } 
} 