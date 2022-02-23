using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class DialogData : BaseDataObject
    {
        
		public GlobalDefine.ESeatType seat;	//说话方
		public GlobalDefine.EDispalyType dispaly;	//显示方
		public uint dialogueText = 0;	//对话内容
		public string speakerLeft = "";	//左讲述人
		public uint speakerNameLeft = 0;	//左讲述人名字
		public string speakerRight = "";	//右讲述人
		public uint speakerNameRight = 0;	//右讲述人名字
		public string triggerNextRefName = "";	//触发下一个对话
		public int unlockTaskID = 0;	//解锁条件
		public string getPropID = "";	//获得物品
		public string acceptTaskID = "";	//接取任务ID
		public string triggerID = "";	//触发器ID
		public string background = "";	//对话背景图
		public string audio = "";	//音乐
		public string effects = "";	//特效
		public string option1 = "";	//选项1显示内容
		public string option2 = "";	//选项2显示内容
		public string option3 = "";	//选项3显示内容
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			seat = (GlobalDefine.ESeatType)br.ReadUInt16();	//说话方
			dispaly = (GlobalDefine.EDispalyType)br.ReadUInt16();	//显示方
			dialogueText = br.ReadUInt32();	//对话内容
			speakerLeft = br.ReadString();	//左讲述人
			speakerNameLeft = br.ReadUInt32();	//左讲述人名字
			speakerRight = br.ReadString();	//右讲述人
			speakerNameRight = br.ReadUInt32();	//右讲述人名字
			triggerNextRefName = br.ReadString();	//触发下一个对话
			unlockTaskID = br.ReadInt32();	//解锁条件
			getPropID = br.ReadString();	//获得物品
			acceptTaskID = br.ReadString();	//接取任务ID
			triggerID = br.ReadString();	//触发器ID
			background = br.ReadString();	//对话背景图
			audio = br.ReadString();	//音乐
			effects = br.ReadString();	//特效
			option1 = br.ReadString();	//选项1显示内容
			option2 = br.ReadString();	//选项2显示内容
			option3 = br.ReadString();	//选项3显示内容
			
        }
    } 
} 