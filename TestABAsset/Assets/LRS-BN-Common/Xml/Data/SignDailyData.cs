using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SignDailyData : BaseDataObject
    {
        
		public string dailyDes = "";	//每日签到描述
		public string rewardConfig = "";	//奖励配置
		public string monthCradRewardConfig = "";	//月卡奖励配置
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			dailyDes = br.ReadString();	//每日签到描述
			rewardConfig = br.ReadString();	//奖励配置
			monthCradRewardConfig = br.ReadString();	//月卡奖励配置
			
        }
    } 
} 