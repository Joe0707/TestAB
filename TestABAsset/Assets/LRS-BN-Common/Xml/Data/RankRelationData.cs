using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RankRelationData : BaseDataObject
    {
        
		public string secondRankName = "";	//二级榜名称
		public int firstType = 0;	//一级分类
		public string thirdTimeType = "";	//三级按钮类型
		public string thirdRankID = "";	//下属三级榜ID
		public int display = 0;	//是否显示
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			secondRankName = br.ReadString();	//二级榜名称
			firstType = br.ReadInt32();	//一级分类
			thirdTimeType = br.ReadString();	//三级按钮类型
			thirdRankID = br.ReadString();	//下属三级榜ID
			display = br.ReadInt32();	//是否显示
			
        }
    } 
} 