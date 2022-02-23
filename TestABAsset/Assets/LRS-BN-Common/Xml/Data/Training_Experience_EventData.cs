using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class Training_Experience_EventData : BaseDataObject
    {
        
		public int eaperienceType = 0;	//历练类型
		public int countryId = 0;	//国家ID
		public int eventType = 0;	//事件类型
		public int triggerId = 0;	//开启触发器
		public uint event_Des = 0;	//事件描述
		public uint eventOption1 = 0;	//事件选项1文字
		public uint eventOption2 = 0;	//事件选项2文字
		public uint eventOption3 = 0;	//事件选项3文字
		public uint eventResult1_Des = 0;	//事件1结果描述
		public uint eventResult2_Des = 0;	//事件2结果描述
		public uint eventResult3_Des = 0;	//事件3结果描述
		public string eventPic = "";	//事件配图
		public string eventResult1pic = "";	//结果1配图
		public string eventResult2pic = "";	//结果2配图
		public string eventResult3pic = "";	//结果3配图
		public int dropPro = 0;	//随机权重
		public string dailogGroup = "";	//事件对话组
		public string resultRewardConfig = "";	//结果奖励配置
		public string eventSound = "";	//事件音效
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//事件编号
			eaperienceType = br.ReadInt32();	//历练类型
			countryId = br.ReadInt32();	//国家ID
			eventType = br.ReadInt32();	//事件类型
			triggerId = br.ReadInt32();	//开启触发器
			event_Des = br.ReadUInt32();	//事件描述
			eventOption1 = br.ReadUInt32();	//事件选项1文字
			eventOption2 = br.ReadUInt32();	//事件选项2文字
			eventOption3 = br.ReadUInt32();	//事件选项3文字
			eventResult1_Des = br.ReadUInt32();	//事件1结果描述
			eventResult2_Des = br.ReadUInt32();	//事件2结果描述
			eventResult3_Des = br.ReadUInt32();	//事件3结果描述
			eventPic = br.ReadString();	//事件配图
			eventResult1pic = br.ReadString();	//结果1配图
			eventResult2pic = br.ReadString();	//结果2配图
			eventResult3pic = br.ReadString();	//结果3配图
			dropPro = br.ReadInt32();	//随机权重
			dailogGroup = br.ReadString();	//事件对话组
			resultRewardConfig = br.ReadString();	//结果奖励配置
			eventSound = br.ReadString();	//事件音效
			
        }
    } 
} 