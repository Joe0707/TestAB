using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ArenaLevelData : BaseDataObject
    {
        
		public string arenaLevelName = "";	//段位名称
		public string levelMin = "";	//段位最低级描述
		public string levelMax = "";	//段位最高级描述
		public string secondLevelID = "";	//匹配二级段位ID
		public string levelPic = "";	//段位图片
		public string seasonRewrad = "";	//赛季奖励
		public int victoryBasicIntegral = 0;	//胜利基础积分
		public int loseBasicIntrgral = 0;	//失利基础积分
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			arenaLevelName = br.ReadString();	//段位名称
			levelMin = br.ReadString();	//段位最低级描述
			levelMax = br.ReadString();	//段位最高级描述
			secondLevelID = br.ReadString();	//匹配二级段位ID
			levelPic = br.ReadString();	//段位图片
			seasonRewrad = br.ReadString();	//赛季奖励
			victoryBasicIntegral = br.ReadInt32();	//胜利基础积分
			loseBasicIntrgral = br.ReadInt32();	//失利基础积分
			
        }
    } 
} 