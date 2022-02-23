using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AirFloatData : BaseDataObject
    {
        
		public string airFloatTips = "";	//提示文本
		public int montlyNotice = 0;	//到月通知
		public int noticeRank = 0;	//主页面通知排序
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			airFloatTips = br.ReadString();	//提示文本
			montlyNotice = br.ReadInt32();	//到月通知
			noticeRank = br.ReadInt32();	//主页面通知排序
			
        }
    } 
} 