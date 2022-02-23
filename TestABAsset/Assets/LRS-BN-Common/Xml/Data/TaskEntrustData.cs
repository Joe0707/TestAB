using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskEntrustData : BaseDataObject
    {
        
		public int taskType = 0;	//委托类型
		public string taskEntrustName = "";	//委托任务名称
		public string taskEntrustDes = "";	//任务描述
		public int randomWeight = 0;	//随机权重
		public string taskDoneMonth = "";	//任务完成月份
		public string donrMonthWeight = "";	//月份随机权重
		public string taskRewordId = "";	//任务基础奖励配置
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			taskType = br.ReadInt32();	//委托类型
			taskEntrustName = br.ReadString();	//委托任务名称
			taskEntrustDes = br.ReadString();	//任务描述
			randomWeight = br.ReadInt32();	//随机权重
			taskDoneMonth = br.ReadString();	//任务完成月份
			donrMonthWeight = br.ReadString();	//月份随机权重
			taskRewordId = br.ReadString();	//任务基础奖励配置
			
        }
    } 
} 