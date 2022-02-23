using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskEntrustRequirementRandomData : BaseDataObject
    {
        
		public int taskQuality = 0;	//任务品质
		public int randomWeight = 0;	//随机权重
		public string taskRequirementConfig = "";	//任务追加要求配置
		public string taskRequirementDes = "";	//任务追加要求描述
		public int randomRewardItemID = 0;	//追加要求奖励
		public string numberRandomRange = "";	//数量随机范围
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			taskQuality = br.ReadInt32();	//任务品质
			randomWeight = br.ReadInt32();	//随机权重
			taskRequirementConfig = br.ReadString();	//任务追加要求配置
			taskRequirementDes = br.ReadString();	//任务追加要求描述
			randomRewardItemID = br.ReadInt32();	//追加要求奖励
			numberRandomRange = br.ReadString();	//数量随机范围
			
        }
    } 
} 