using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskDropData : BaseDataObject
    {
        
		public int taskType2 = 0;	//任务类型
		public int taskStar = 0;	//任务星级
		public int taskID = 0;	//任务ID
		public int dropPro = 0;	//掉落权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			taskType2 = br.ReadInt32();	//任务类型
			taskStar = br.ReadInt32();	//任务星级
			taskID = br.ReadInt32();	//任务ID
			dropPro = br.ReadInt32();	//掉落权重
			
        }
    } 
} 