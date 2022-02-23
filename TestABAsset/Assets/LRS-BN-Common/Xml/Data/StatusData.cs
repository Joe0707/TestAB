using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class StatusData : BaseDataObject
    {
        
		public string mName = "";	//状态名称
		public string Desc = "";	//状态描述
		public int Type = 0;	//状态类型
		public int IsDebuff = 0;	//增益减益
		public int View = 0;	//是否显示
		public string Icon = "";	//状态图标
		public int Turns = 0;	//持续回合
		public int Unique = 0;	//唯一
		public int Effect1 = 0;	//添加效果1
		public int Effect2 = 0;	//添加效果2
		public int Effect3 = 0;	//添加效果3
		public int Effect4 = 0;	//添加效果4
		public int Effect5 = 0;	//添加效果5
		public GlobalDefine.EEffectStatusStop1 Stop1;	//删除状态条件（0无，1战斗过，2回合开始，3回合内没移动，4回合内没行动）
		public int Stop2 = 0;	//删除状态条件2，OR
		public int IsAP = 0;	//是否显示AP值
		public string MagicView = "";	//获得光效
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//状态ID
			mName = br.ReadString();	//状态名称
			Desc = br.ReadString();	//状态描述
			Type = br.ReadInt32();	//状态类型
			IsDebuff = br.ReadInt32();	//增益减益
			View = br.ReadInt32();	//是否显示
			Icon = br.ReadString();	//状态图标
			Turns = br.ReadInt32();	//持续回合
			Unique = br.ReadInt32();	//唯一
			Effect1 = br.ReadInt32();	//添加效果1
			Effect2 = br.ReadInt32();	//添加效果2
			Effect3 = br.ReadInt32();	//添加效果3
			Effect4 = br.ReadInt32();	//添加效果4
			Effect5 = br.ReadInt32();	//添加效果5
			Stop1 = (GlobalDefine.EEffectStatusStop1)br.ReadUInt16();	//删除状态条件（0无，1战斗过，2回合开始，3回合内没移动，4回合内没行动）
			Stop2 = br.ReadInt32();	//删除状态条件2，OR
			IsAP = br.ReadInt32();	//是否显示AP值
			MagicView = br.ReadString();	//获得光效
			
        }
    } 
} 