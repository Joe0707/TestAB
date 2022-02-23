using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class NatureIdExplainData : BaseDataObject
    {
        
		public string attrStr = "";	//属性字符串
		public string desc = "";	//属性名注释
		public string gameDisplay = "";	//游戏内显示
		public int type = 0;	//参数类型
		public string battleNatureDisplay = "";	//战斗中UI显示文本
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//主键/枚举值
			attrStr = br.ReadString();	//属性字符串
			desc = br.ReadString();	//属性名注释
			gameDisplay = br.ReadString();	//游戏内显示
			type = br.ReadInt32();	//参数类型
			battleNatureDisplay = br.ReadString();	//战斗中UI显示文本
			
        }
    } 
} 