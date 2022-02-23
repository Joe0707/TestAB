using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RankConfigData : BaseDataObject
    {
        
		public string rankName = "";	//排行榜名称
		public int timeType = 0;	//计时类型
		public int displayType = 0;	//显示类型
		public int peopleNumber = 0;	//统计最大人数
		public int peopleNumberDisplay = 0;	//显示人数
		public int onListCondition = 0;	//上榜条件
		public int rewardType = 0;	//奖励类型
		public string myRankDes = "";	//排行榜我的变量描述
		public string rankNatureDes = "";	//排行依据属性描述
		public string rankTips = "";	//备注说明
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			rankName = br.ReadString();	//排行榜名称
			timeType = br.ReadInt32();	//计时类型
			displayType = br.ReadInt32();	//显示类型
			peopleNumber = br.ReadInt32();	//统计最大人数
			peopleNumberDisplay = br.ReadInt32();	//显示人数
			onListCondition = br.ReadInt32();	//上榜条件
			rewardType = br.ReadInt32();	//奖励类型
			myRankDes = br.ReadString();	//排行榜我的变量描述
			rankNatureDes = br.ReadString();	//排行依据属性描述
			rankTips = br.ReadString();	//备注说明
			
        }
    } 
} 