using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SignCycleRewardData : BaseDataObject
    {
        
		public int signDays = 0;	//连续签到天数
		public string IconID = "";	//图标配置
		public string cycleReward = "";	//连续签到奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			signDays = br.ReadInt32();	//连续签到天数
			IconID = br.ReadString();	//图标配置
			cycleReward = br.ReadString();	//连续签到奖励
			
        }
    } 
} 