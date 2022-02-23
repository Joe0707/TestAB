using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskCityData : BaseDataObject
    {
        
		public string countryType = "";	//国家
		public int taskStar = 0;	//星级
		public int pro = 0;	//掉落权重
		public string reconmmendPlayerLevel = "";	//推荐玩家等级
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//任务ID
			countryType = br.ReadString();	//国家
			taskStar = br.ReadInt32();	//星级
			pro = br.ReadInt32();	//掉落权重
			reconmmendPlayerLevel = br.ReadString();	//推荐玩家等级
			
        }
    } 
} 