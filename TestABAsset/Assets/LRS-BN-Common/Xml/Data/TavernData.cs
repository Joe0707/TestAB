using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TavernData : BaseDataObject
    {
        
		public int countryID = 0;	//所属国家
		public int tavernType = 0;	//酒馆类型
		public string actorDisplayRange = "";	//银币显示角色范围
		public int diamondRecruitActorNum = 0;	//钻石招募角色数量
		public int silverCoinRecruitType = 0;	//银币招募类型
		public int diamondRecruitType = 0;	//钻石招募类型
		public string silverCoinFristDrop = "";	//银币首次掉落英雄ID
		public string diamondFristDrop = "";	//钻石首次掉落英雄ID
		public int silverCoinRefreshMax = 0;	//酒馆银币刷新上限
		public string silverCoinRefreshPrice = "";	//银币刷新价格
		public int diamondRecruitPrice = 0;	//钻石招募价格
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//酒馆ID
			countryID = br.ReadInt32();	//所属国家
			tavernType = br.ReadInt32();	//酒馆类型
			actorDisplayRange = br.ReadString();	//银币显示角色范围
			diamondRecruitActorNum = br.ReadInt32();	//钻石招募角色数量
			silverCoinRecruitType = br.ReadInt32();	//银币招募类型
			diamondRecruitType = br.ReadInt32();	//钻石招募类型
			silverCoinFristDrop = br.ReadString();	//银币首次掉落英雄ID
			diamondFristDrop = br.ReadString();	//钻石首次掉落英雄ID
			silverCoinRefreshMax = br.ReadInt32();	//酒馆银币刷新上限
			silverCoinRefreshPrice = br.ReadString();	//银币刷新价格
			diamondRecruitPrice = br.ReadInt32();	//钻石招募价格
			
        }
    } 
} 