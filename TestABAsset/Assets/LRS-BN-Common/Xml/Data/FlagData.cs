using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FlagData : BaseDataObject
    {
        
		public string FlagpartDes = "";	//部件描述
		public int flagType = 0;	//类型
		public int typeNum = 0;	//类型编号
		public string colour = "";	//颜色RGB值
		public string picID = "";	//图片id
		public string price = "";	//价格
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			FlagpartDes = br.ReadString();	//部件描述
			flagType = br.ReadInt32();	//类型
			typeNum = br.ReadInt32();	//类型编号
			colour = br.ReadString();	//颜色RGB值
			picID = br.ReadString();	//图片id
			price = br.ReadString();	//价格
			
        }
    } 
} 