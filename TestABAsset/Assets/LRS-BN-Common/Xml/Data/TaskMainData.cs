using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskMainData : BaseDataObject
    {
        
		public GlobalDefine.ETaskFunctionType taskType;	//任务类型2
		public uint taskName = 0;	//任务名称
		public uint taskDes = 0;	//任务描述
		public uint taskTarget = 0;	//任务目标
		public string storyID = "";	//主线剧情ID
		public string conParam = "";	//解锁条件配置
		public int access = 0;	//接取方式
		public int nextId = 0;	//下一个任务
		public int useTime = 0;	//完成任务耗时(月)
		public string jobsID = "";	//进入关卡职业限制
		public string noJobsID = "";	//进入关卡不能用出现职业
		public int rewrdGroup = 0;	//任务奖励组
		public int check = 0;	//查询方式
		public string doneCondition = "";	//完成条件
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//任务ID
			taskType = (GlobalDefine.ETaskFunctionType)br.ReadUInt16();	//任务类型2
			taskName = br.ReadUInt32();	//任务名称
			taskDes = br.ReadUInt32();	//任务描述
			taskTarget = br.ReadUInt32();	//任务目标
			storyID = br.ReadString();	//主线剧情ID
			conParam = br.ReadString();	//解锁条件配置
			access = br.ReadInt32();	//接取方式
			nextId = br.ReadInt32();	//下一个任务
			useTime = br.ReadInt32();	//完成任务耗时(月)
			jobsID = br.ReadString();	//进入关卡职业限制
			noJobsID = br.ReadString();	//进入关卡不能用出现职业
			rewrdGroup = br.ReadInt32();	//任务奖励组
			check = br.ReadInt32();	//查询方式
			doneCondition = br.ReadString();	//完成条件
			
        }
    } 
} 