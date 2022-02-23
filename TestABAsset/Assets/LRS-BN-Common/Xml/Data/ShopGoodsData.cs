using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ShopGoodsData : BaseDataObject
    {
        
		public int countryID = 0;	//国家id
		public int goodQuality = 0;	//商品品质
		public int goodsID = 0;	//特产编号
		public string numRandomRange = "";	//数量范围
		public int basicPrice = 0;	//基础售价
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			countryID = br.ReadInt32();	//国家id
			goodQuality = br.ReadInt32();	//商品品质
			goodsID = br.ReadInt32();	//特产编号
			numRandomRange = br.ReadString();	//数量范围
			basicPrice = br.ReadInt32();	//基础售价
			
        }
    } 
} 