using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BagItemData : BaseDataObject
    {
        
		public uint mName = 0;	//道具名称
		public int propType = 0;	//道具种类
		public int secondType = 0;	//二级分类
		public int propNature = 0;	//道具性质
		public int propEffcet = 0;	//道具效果
		public string bigIcon = "";	//道具大图标
		public string smallIcon = "";	//道具小图标
		public int superposition = 0;	//是否可叠加
		public int use = 0;	//是否可使用
		public int display = 0;	//是否在背包显示
		public int decompose = 0;	//可否可分解
		public uint describe = 0;	//道具描述
		public string propDisplayNature = "";	//道具显示属性
		public int baseSilver = 0;	//商店基础价格(银币)
		public int baseDiamond = 0;	//商店基础价格（钻石）
		public string proposeEffect = "";	//相亲加成效果
		public float engagementBasicNum = 0;	//相亲基数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//道具ID
			mName = br.ReadUInt32();	//道具名称
			propType = br.ReadInt32();	//道具种类
			secondType = br.ReadInt32();	//二级分类
			propNature = br.ReadInt32();	//道具性质
			propEffcet = br.ReadInt32();	//道具效果
			bigIcon = br.ReadString();	//道具大图标
			smallIcon = br.ReadString();	//道具小图标
			superposition = br.ReadInt32();	//是否可叠加
			use = br.ReadInt32();	//是否可使用
			display = br.ReadInt32();	//是否在背包显示
			decompose = br.ReadInt32();	//可否可分解
			describe = br.ReadUInt32();	//道具描述
			propDisplayNature = br.ReadString();	//道具显示属性
			baseSilver = br.ReadInt32();	//商店基础价格(银币)
			baseDiamond = br.ReadInt32();	//商店基础价格（钻石）
			proposeEffect = br.ReadString();	//相亲加成效果
			engagementBasicNum = br.ReadSingle();	//相亲基数
			
        }
    } 
} 