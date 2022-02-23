using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GoodsNumRandomData : BaseDataObject
    {
        
		public int goodId = 0;	//商品编号
		public int cityType = 0;	//城市类型
		public string goodsNumDrop = "";	//商品数量
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			goodId = br.ReadInt32();	//商品编号
			cityType = br.ReadInt32();	//城市类型
			goodsNumDrop = br.ReadString();	//商品数量
			
        }
    } 
} 