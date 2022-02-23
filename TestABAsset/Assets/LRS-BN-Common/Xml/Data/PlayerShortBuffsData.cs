using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class PlayerShortBuffsData : BaseDataObject
    {
        
		public string festivalEffectName = "";	//效果名
		public string chneseName = "";	//中文名
		public int keepMonth = 0;	//持续月份
		public string pageId = "";	//展示页面
		public string festivalEffectEffect = "";	//节日效果配置
		public string festivalEffectDes = "";	//节日效果描述
		public int surplus = 0;	//是否有剩余提示
		public string surplusTipsText = "";	//剩余提示文本
		public string chineseText = "";	//剩余恢复提示中文
		public string effectIcon = "";	//状态图标
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			festivalEffectName = br.ReadString();	//效果名
			chneseName = br.ReadString();	//中文名
			keepMonth = br.ReadInt32();	//持续月份
			pageId = br.ReadString();	//展示页面
			festivalEffectEffect = br.ReadString();	//节日效果配置
			festivalEffectDes = br.ReadString();	//节日效果描述
			surplus = br.ReadInt32();	//是否有剩余提示
			surplusTipsText = br.ReadString();	//剩余提示文本
			chineseText = br.ReadString();	//剩余恢复提示中文
			effectIcon = br.ReadString();	//状态图标
			
        }
    } 
} 