using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ActorDemandGoodsData : BaseDataObject
    {
        
		public int type = 0;	//类型
		public int descent = 0;	//血脉
		public int demandRandomWeight = 0;	//需求随机权重
		public int goodId = 0;	//物资ID
		public int goodNumber = 0;	//数量
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			type = br.ReadInt32();	//类型
			descent = br.ReadInt32();	//血脉
			demandRandomWeight = br.ReadInt32();	//需求随机权重
			goodId = br.ReadInt32();	//物资ID
			goodNumber = br.ReadInt32();	//数量
			
        }
    } 
} 