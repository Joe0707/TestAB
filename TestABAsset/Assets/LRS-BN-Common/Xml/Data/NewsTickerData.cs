using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class NewsTickerData : BaseDataObject
    {
        
		public int type = 0;	//类型
		public string Condition = "";	//触发条件
		public string textDes = "";	//发送内容描述
		public int displayLength = 0;	//显示时长
		public string colour = "";	//字体颜色
		public int dispalyPriority = 0;	//显示优先级
		public int displayInterval = 0;	//显示间隔
		public string beginTime = "";	//开始时间
		public string overTime = "";	//结束时间
		public int effectiveTime = 0;	//有效时限
		public int frequencyMax = 0;	//最大播放次数(小时)
		public int effective = 0;	//是否生效
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			type = br.ReadInt32();	//类型
			Condition = br.ReadString();	//触发条件
			textDes = br.ReadString();	//发送内容描述
			displayLength = br.ReadInt32();	//显示时长
			colour = br.ReadString();	//字体颜色
			dispalyPriority = br.ReadInt32();	//显示优先级
			displayInterval = br.ReadInt32();	//显示间隔
			beginTime = br.ReadString();	//开始时间
			overTime = br.ReadString();	//结束时间
			effectiveTime = br.ReadInt32();	//有效时限
			frequencyMax = br.ReadInt32();	//最大播放次数(小时)
			effective = br.ReadInt32();	//是否生效
			
        }
    } 
} 