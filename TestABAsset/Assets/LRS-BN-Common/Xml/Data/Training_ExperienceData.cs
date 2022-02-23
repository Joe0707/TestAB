using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class Training_ExperienceData : BaseDataObject
    {
        
		public int eaperienceType = 0;	//历练类型
		public int experienceMonth = 0;	//历练时间
		public int rewardNum = 0;	//历练奖励数量
		public int trainRewerdPro = 0;	//历练奖励触发概率
		public int engagementPro = 0;	//触发相亲概率
		public int basicExpReward = 0;	//基础经验奖励
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			eaperienceType = br.ReadInt32();	//历练类型
			experienceMonth = br.ReadInt32();	//历练时间
			rewardNum = br.ReadInt32();	//历练奖励数量
			trainRewerdPro = br.ReadInt32();	//历练奖励触发概率
			engagementPro = br.ReadInt32();	//触发相亲概率
			basicExpReward = br.ReadInt32();	//基础经验奖励
			
        }
    } 
} 