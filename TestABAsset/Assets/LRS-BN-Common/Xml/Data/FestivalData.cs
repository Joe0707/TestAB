using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FestivalData : BaseDataObject
    {
        
		public string festivalName = "";	//名称
		public int month = 0;	//月份
		public int festivalType = 0;	//节日类型
		public int timeMax = 0;	//最大祈祷次数
		public string openDes = "";	//开启描述
		public string openCity = "";	//开放地
		public string bg = "";	//背景图
		public string bgDes = "";	//背景描述
		public string bgm = "";	//背景音效
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//节日ID
			festivalName = br.ReadString();	//名称
			month = br.ReadInt32();	//月份
			festivalType = br.ReadInt32();	//节日类型
			timeMax = br.ReadInt32();	//最大祈祷次数
			openDes = br.ReadString();	//开启描述
			openCity = br.ReadString();	//开放地
			bg = br.ReadString();	//背景图
			bgDes = br.ReadString();	//背景描述
			bgm = br.ReadString();	//背景音效
			
        }
    } 
} 