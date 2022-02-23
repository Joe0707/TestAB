using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GemUpgradeData : BaseDataObject
    {
        
		public int mGemId = 0;	//宝石编号
		public int level = 0;	//等级
		public string addNatureConfig = "";	//增加属性配置
		public string upGradeNeedNum = "";	//升级所需低级宝石数量
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			mGemId = br.ReadInt32();	//宝石编号
			level = br.ReadInt32();	//等级
			addNatureConfig = br.ReadString();	//增加属性配置
			upGradeNeedNum = br.ReadString();	//升级所需低级宝石数量
			
        }
    } 
} 