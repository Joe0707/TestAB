using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FestivalOptionData : BaseDataObject
    {
        
		public int festivalID = 0;	//所属节日
		public string firstOrderDes = "";	//一级选项名称
		public string festivalConsumeItem = "";	//节日效果配置
		public string optionEffect = "";	//选项对应效果
		public string optionDes = "";	//二级选项描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			festivalID = br.ReadInt32();	//所属节日
			firstOrderDes = br.ReadString();	//一级选项名称
			festivalConsumeItem = br.ReadString();	//节日效果配置
			optionEffect = br.ReadString();	//选项对应效果
			optionDes = br.ReadString();	//二级选项描述
			
        }
    } 
} 