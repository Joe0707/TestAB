using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskData : BaseDataObject
    {
        
		public GlobalDefine.ETaskFunctionType taskType2;	//任务类型2
		public uint taskName = 0;	//任务名称
		public uint taskDes = 0;	//任务描述
		public uint taskTarget = 0;	//任务目标
		public int taskStar = 0;	//任务星级
		public string taskRecommandLevel = "";	//任务推荐等级
		public int taskFinishTime = 0;	//任务完成限时
		public int earnestMoney = 0;	//保证金
		public int isUrgent = 0;	//是否为紧急任务
		public string isUpdated = "";	//是否刷新
		public string penaltyValue = "";	//失败惩罚
		public int useTime = 0;	//任务耗时(月)
		public int giveup = 0;	//是否可放弃
		public int triggersParam = 0;	//进入场景触发器配置
		public int monAdd = 0;	//触发增加月份
		public int bettleLevel = 0;	//战斗关卡
		public int rewardGain = 0;	//奖励增益道具id
		public string mapPoint = "";	//交任务配置
		public string lootTarget = "";	//跑商任务目标物品
		public int rewrdGroup = 0;	//奖励组1
		public int countryType = 0;	//国家类型
		public int check = 0;	//查询方式
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//任务ID
			taskType2 = (GlobalDefine.ETaskFunctionType)br.ReadUInt16();	//任务类型2
			taskName = br.ReadUInt32();	//任务名称
			taskDes = br.ReadUInt32();	//任务描述
			taskTarget = br.ReadUInt32();	//任务目标
			taskStar = br.ReadInt32();	//任务星级
			taskRecommandLevel = br.ReadString();	//任务推荐等级
			taskFinishTime = br.ReadInt32();	//任务完成限时
			earnestMoney = br.ReadInt32();	//保证金
			isUrgent = br.ReadInt32();	//是否为紧急任务
			isUpdated = br.ReadString();	//是否刷新
			penaltyValue = br.ReadString();	//失败惩罚
			useTime = br.ReadInt32();	//任务耗时(月)
			giveup = br.ReadInt32();	//是否可放弃
			triggersParam = br.ReadInt32();	//进入场景触发器配置
			monAdd = br.ReadInt32();	//触发增加月份
			bettleLevel = br.ReadInt32();	//战斗关卡
			rewardGain = br.ReadInt32();	//奖励增益道具id
			mapPoint = br.ReadString();	//交任务配置
			lootTarget = br.ReadString();	//跑商任务目标物品
			rewrdGroup = br.ReadInt32();	//奖励组1
			countryType = br.ReadInt32();	//国家类型
			check = br.ReadInt32();	//查询方式
			
        }
    } 
} 