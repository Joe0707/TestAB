using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GoodsFluctuateData : BaseDataObject
    {
        
		public int goodsType = 0;	//类型ID
		public int countryId = 0;	//国家ID
		public string spring = "";	//春季波动系数
		public string summer = "";	//夏季波动系数
		public string autumn = "";	//春季波动系数
		public string wintre = "";	//春季波动系数
		public int areaRare = 0;	//区域稀有度
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号ID
			goodsType = br.ReadInt32();	//类型ID
			countryId = br.ReadInt32();	//国家ID
			spring = br.ReadString();	//春季波动系数
			summer = br.ReadString();	//夏季波动系数
			autumn = br.ReadString();	//春季波动系数
			wintre = br.ReadString();	//春季波动系数
			areaRare = br.ReadInt32();	//区域稀有度
			
        }
    } 
} 