using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ClimbTowerShopData : BaseDataObject
    {
        
		public int towerType = 0;	//所属塔
		public int refeshType = 0;	//刷新类型
		public string goodsConfig = "";	//商品配置
		public int weight = 0;	//掉落权重
		public int exchangeDailyTimes = 0;	//每日可兑换最大次数
		public int consumePiont = 0;	//消耗点数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			towerType = br.ReadInt32();	//所属塔
			refeshType = br.ReadInt32();	//刷新类型
			goodsConfig = br.ReadString();	//商品配置
			weight = br.ReadInt32();	//掉落权重
			exchangeDailyTimes = br.ReadInt32();	//每日可兑换最大次数
			consumePiont = br.ReadInt32();	//消耗点数
			
        }
    } 
} 