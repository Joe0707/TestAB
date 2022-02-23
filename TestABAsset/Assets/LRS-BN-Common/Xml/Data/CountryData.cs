using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class CountryData : BaseDataObject
    {
        
		public uint mName = 0;	//国家名称
		public uint countryDes = 0;	//国家描述
		public string countryIconD = "";	//国家图标大
		public string countryIcon = "";	//国家图标小
		public int tollNum = 0;	//路费数值
		public int open = 0;	//是否开放
		public string containDecent = "";	//贵族血脉
		public int initialPrestige = 0;	//初始声望
		public int prestigeId = 0;	//声望ID
		public int friendlyId = 0;	//友好度ID
		public string experienceRewardDisplay = "";	//历练奖励显示
		public string countryIntroduce = "";	//国家介绍
		public int royalCity = 0;	//王城ID
		public int unlockConscription = 0;	//解锁征兵所需友好度等级
		public string dispalyBloods = "";	//征兵可出现血脉
		public int coreBloods = 0;	//国家核心血脉
		public string conscriptionItem = "";	//征兵获得物品
		public uint countrySender = 0;	//阵亡发件人
		public int rankBlood = 0;	//排行榜对应血脉
		public int npcTraderID = 0;	//npc商人ID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//国家id
			mName = br.ReadUInt32();	//国家名称
			countryDes = br.ReadUInt32();	//国家描述
			countryIconD = br.ReadString();	//国家图标大
			countryIcon = br.ReadString();	//国家图标小
			tollNum = br.ReadInt32();	//路费数值
			open = br.ReadInt32();	//是否开放
			containDecent = br.ReadString();	//贵族血脉
			initialPrestige = br.ReadInt32();	//初始声望
			prestigeId = br.ReadInt32();	//声望ID
			friendlyId = br.ReadInt32();	//友好度ID
			experienceRewardDisplay = br.ReadString();	//历练奖励显示
			countryIntroduce = br.ReadString();	//国家介绍
			royalCity = br.ReadInt32();	//王城ID
			unlockConscription = br.ReadInt32();	//解锁征兵所需友好度等级
			dispalyBloods = br.ReadString();	//征兵可出现血脉
			coreBloods = br.ReadInt32();	//国家核心血脉
			conscriptionItem = br.ReadString();	//征兵获得物品
			countrySender = br.ReadUInt32();	//阵亡发件人
			rankBlood = br.ReadInt32();	//排行榜对应血脉
			npcTraderID = br.ReadInt32();	//npc商人ID
			
        }
    } 
} 