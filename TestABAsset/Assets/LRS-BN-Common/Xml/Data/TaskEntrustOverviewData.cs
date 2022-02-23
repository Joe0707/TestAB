using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskEntrustOverviewData : BaseDataObject
    {
        
		public string taskEntrusType = "";	//委托任务类型名
		public int dailyMaxNum = 0;	//每天最大可接取任务数
		public int taskEntrusTypeWeight = 0;	//任务品质随机权重
		public string containTaskType = "";	//包含任务类型
		public string profitAddConfig = "";	//收益加成配置
		public string starPic = "";	//星级图片
		public string entrustAddEffectDes = "";	//委托任务加成效果描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//任务品质
			taskEntrusType = br.ReadString();	//委托任务类型名
			dailyMaxNum = br.ReadInt32();	//每天最大可接取任务数
			taskEntrusTypeWeight = br.ReadInt32();	//任务品质随机权重
			containTaskType = br.ReadString();	//包含任务类型
			profitAddConfig = br.ReadString();	//收益加成配置
			starPic = br.ReadString();	//星级图片
			entrustAddEffectDes = br.ReadString();	//委托任务加成效果描述
			
        }
    } 
} 