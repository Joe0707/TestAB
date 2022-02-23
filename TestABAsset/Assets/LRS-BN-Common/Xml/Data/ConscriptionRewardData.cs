using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ConscriptionRewardData : BaseDataObject
    {
        
		public int countryID = 0;	//国家id
		public int SixDimension = 0;	//六维评级ID
		public string conscriptionReward = "";	//征兵道具奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryID = br.ReadInt32();	//国家id
			SixDimension = br.ReadInt32();	//六维评级ID
			conscriptionReward = br.ReadString();	//征兵道具奖励
			
        }
    } 
} 