using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FestivalWrestleData : BaseDataObject
    {
        
		public string festivalName = "";	//节日名称
		public string festivalConsume = "";	//消耗物品
		public string levelConfig = "";	//战斗关卡配置
		public string prestigeReward = "";	//声望奖励
		public string rewardExplain = "";	//奖励说明
		public string aranaRewardDes = "";	//奖励描述
		public string battleExplain = "";	//连胜说明
		public string battleTips = "";	//战斗提示
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			festivalName = br.ReadString();	//节日名称
			festivalConsume = br.ReadString();	//消耗物品
			levelConfig = br.ReadString();	//战斗关卡配置
			prestigeReward = br.ReadString();	//声望奖励
			rewardExplain = br.ReadString();	//奖励说明
			aranaRewardDes = br.ReadString();	//奖励描述
			battleExplain = br.ReadString();	//连胜说明
			battleTips = br.ReadString();	//战斗提示
			
        }
    } 
} 