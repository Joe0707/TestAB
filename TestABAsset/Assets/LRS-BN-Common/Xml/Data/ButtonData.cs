using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ButtonData : BaseDataObject
    {
        
		public string buttonName = "";	//按钮名称
		public int buttonType = 0;	//按钮类型
		public int redTips = 0;	//红点提示是否显示
		public string gameObjectName = "";	//按钮名称
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//按钮编号
			buttonName = br.ReadString();	//按钮名称
			buttonType = br.ReadInt32();	//按钮类型
			redTips = br.ReadInt32();	//红点提示是否显示
			gameObjectName = br.ReadString();	//按钮名称
			
        }
    } 
} 