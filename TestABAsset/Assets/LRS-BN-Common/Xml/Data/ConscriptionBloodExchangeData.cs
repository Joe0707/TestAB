using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ConscriptionBloodExchangeData : BaseDataObject
    {
        
		public int bloodRate = 0;	//血脉比例
		public string exchangeItem = "";	//获得物品
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			bloodRate = br.ReadInt32();	//血脉比例
			exchangeItem = br.ReadString();	//获得物品
			
        }
    } 
} 