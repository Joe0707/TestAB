using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskdailyData : BaseDataObject
    {
        
		public uint mName = 0;	//任务名称
		public string chineseName = "";	//名称备注
		public string taskAttainment = "";	//任务配置
		public string reward = "";	//任务奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//任务id
			mName = br.ReadUInt32();	//任务名称
			chineseName = br.ReadString();	//名称备注
			taskAttainment = br.ReadString();	//任务配置
			reward = br.ReadString();	//任务奖励
			
        }
    } 
} 