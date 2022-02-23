using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GoodsData : BaseDataObject
    {
        
		public int goodQuality = 0;	//商品品质
		public int basicPrice = 0;	//基础价格
		public string nativeCountry = "";	//特产国家
		public int goodsType = 0;	//商品类型
		public string markSellMax = "";	//市场出售上限
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//商品编号
			goodQuality = br.ReadInt32();	//商品品质
			basicPrice = br.ReadInt32();	//基础价格
			nativeCountry = br.ReadString();	//特产国家
			goodsType = br.ReadInt32();	//商品类型
			markSellMax = br.ReadString();	//市场出售上限
			
        }
    } 
} 