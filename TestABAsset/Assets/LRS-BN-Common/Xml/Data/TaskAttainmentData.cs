using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskAttainmentData : BaseDataObject
    {
        
		public GlobalDefine.ETargetType targetType;	//目标类型
		public GlobalDefine.ETargetRewardType conditionType;	//达成的目标条件类型
		public int displayType = 0;	//显示结果类型
		public string conditionConfig = "";	//达成的目标条件数量
		public string param = "";	//完成成就参数
		public string display = "";	//显示参数
		public string rewrdGroup1 = "";	//奖励组
		public uint taskName = 0;	//任务名称
		public uint taskDes = 0;	//任务描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//任务ID
			targetType = (GlobalDefine.ETargetType)br.ReadUInt16();	//目标类型
			conditionType = (GlobalDefine.ETargetRewardType)br.ReadUInt16();	//达成的目标条件类型
			displayType = br.ReadInt32();	//显示结果类型
			conditionConfig = br.ReadString();	//达成的目标条件数量
			param = br.ReadString();	//完成成就参数
			display = br.ReadString();	//显示参数
			rewrdGroup1 = br.ReadString();	//奖励组
			taskName = br.ReadUInt32();	//任务名称
			taskDes = br.ReadUInt32();	//任务描述
			
        }
    } 
} 