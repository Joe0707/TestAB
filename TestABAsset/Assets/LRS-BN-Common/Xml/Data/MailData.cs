using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class MailData : BaseDataObject
    {
        
		public string from = "";	//发件人ID
		public string sendingTime = "";	//发件时间
		public int type = 0;	//邮件类型
		public int reply = 0;	//适配回信ID
		public string itemConfig = "";	//物品配置
		public uint mailTitle = 0;	//标题
		public string chineseTitle = "";	//中文标题
		public uint text = 0;	//内容
		public string chineseText = "";	//中文内容
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//邮件编号
			from = br.ReadString();	//发件人ID
			sendingTime = br.ReadString();	//发件时间
			type = br.ReadInt32();	//邮件类型
			reply = br.ReadInt32();	//适配回信ID
			itemConfig = br.ReadString();	//物品配置
			mailTitle = br.ReadUInt32();	//标题
			chineseTitle = br.ReadString();	//中文标题
			text = br.ReadUInt32();	//内容
			chineseText = br.ReadString();	//中文内容
			
        }
    } 
} 