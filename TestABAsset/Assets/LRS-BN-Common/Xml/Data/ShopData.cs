using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ShopData : BaseDataObject
    {
        
		public string ascriptionTab = "";	//所属页签
		public int type = 0;	//类型
		public string propName = "";	//物品名称
		public string itemConfig = "";	//包含物品配置
		public int countryID = 0;	//所属国家
		public int diamondPrice = 0;	//物品钻石原价
		public int dailyBuyTimes = 0;	//每日限购次数
		public int discountRate = 0;	//折扣率
		public string giftIcon = "";	//礼包图标
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			ascriptionTab = br.ReadString();	//所属页签
			type = br.ReadInt32();	//类型
			propName = br.ReadString();	//物品名称
			itemConfig = br.ReadString();	//包含物品配置
			countryID = br.ReadInt32();	//所属国家
			diamondPrice = br.ReadInt32();	//物品钻石原价
			dailyBuyTimes = br.ReadInt32();	//每日限购次数
			discountRate = br.ReadInt32();	//折扣率
			giftIcon = br.ReadString();	//礼包图标
			
        }
    } 
} 