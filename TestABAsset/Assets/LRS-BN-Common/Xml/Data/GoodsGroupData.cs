using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GoodsGroupData : BaseDataObject
    {
        
		public string goodsConfig = "";	//商品配置
		public int dropPro = 0;	//掉落权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//商品组
			goodsConfig = br.ReadString();	//商品配置
			dropPro = br.ReadInt32();	//掉落权重
			
        }
    } 
} 