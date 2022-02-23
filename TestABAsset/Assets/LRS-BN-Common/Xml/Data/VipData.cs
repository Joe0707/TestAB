using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class VipData : BaseDataObject
    {
        
		public int vipLevel = 0;	//vip等级
		public int rechargeNum = 0;	//充值金额
		public int enchantingRefresh = 0;	//附魔刷新上限
		public int expPond = 0;	//经验池加成
		public int addTeam = 0;	//增加编队个数
		public int GemSlotRefreshTimes = 0;	//宝石镶嵌槽刷新次数
		public int refreshDiscount = 0;	//刷新优惠折扣
		public int saodangMax = 0;	//每日扫荡最大次数
		public int shenlingMax = 0;	//每日神令使用上限
		public int entrustBuyTime = 0;	//委托任务购买次数
		public int openImmediatelyDone = 0;	//委托任务立即完成开启
		public int shopItemAddTimes = 0;	//道具商店道具购买增加次数
		public int arenaDailyFreeTime = 0;	//竞技场每天免费次数
		public int buyTimeDaily = 0;	//竞技场每天购买次数
		public int addBattleDailyTimes = 0;	//组队副本额外增加挑战次数
		public int addCreateDailyBattleTimes = 0;	//组队副本额外增加创建次数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			vipLevel = br.ReadInt32();	//vip等级
			rechargeNum = br.ReadInt32();	//充值金额
			enchantingRefresh = br.ReadInt32();	//附魔刷新上限
			expPond = br.ReadInt32();	//经验池加成
			addTeam = br.ReadInt32();	//增加编队个数
			GemSlotRefreshTimes = br.ReadInt32();	//宝石镶嵌槽刷新次数
			refreshDiscount = br.ReadInt32();	//刷新优惠折扣
			saodangMax = br.ReadInt32();	//每日扫荡最大次数
			shenlingMax = br.ReadInt32();	//每日神令使用上限
			entrustBuyTime = br.ReadInt32();	//委托任务购买次数
			openImmediatelyDone = br.ReadInt32();	//委托任务立即完成开启
			shopItemAddTimes = br.ReadInt32();	//道具商店道具购买增加次数
			arenaDailyFreeTime = br.ReadInt32();	//竞技场每天免费次数
			buyTimeDaily = br.ReadInt32();	//竞技场每天购买次数
			addBattleDailyTimes = br.ReadInt32();	//组队副本额外增加挑战次数
			addCreateDailyBattleTimes = br.ReadInt32();	//组队副本额外增加创建次数
			
        }
    } 
} 