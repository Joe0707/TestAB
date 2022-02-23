using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TaskMainStoryData : BaseDataObject
    {
        
		public int chapterId = 0;	//章节ID
		public int actionType = 0;	//动作类型
		public string config = "";	//表现参数配置
		public int autoClosed = 0;	//是否自动关闭动画
		public int skip = 0;	//能否可跳过
		public int taskPointData = 0;	//任务路点
		public int clientRequest = 0;	//客户端主动请求
		public int startTrigger = 0;	//开始触发器
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			chapterId = br.ReadInt32();	//章节ID
			actionType = br.ReadInt32();	//动作类型
			config = br.ReadString();	//表现参数配置
			autoClosed = br.ReadInt32();	//是否自动关闭动画
			skip = br.ReadInt32();	//能否可跳过
			taskPointData = br.ReadInt32();	//任务路点
			clientRequest = br.ReadInt32();	//客户端主动请求
			startTrigger = br.ReadInt32();	//开始触发器
			
        }
    } 
} 