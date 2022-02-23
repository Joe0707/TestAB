using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LevelData : BaseDataObject
    {
        
		public int levelType = 0;	//关卡种类
		public uint mName = 0;	//关卡名称
		public GlobalDefine.ELevelType mLevelType;	//关卡类型
		public GlobalDefine.EThemeType mThemeType;	//场景主题
		public int mStrengthLevel = 0;	//关卡等级
		public int expReward = 0;	//基础经验奖励
		public int rewardId = 0;	//掉落奖励组ID
		public string mBgm = "";	//背景音乐（BGM）
		public int mEnemyLevel = 0;	//敌人等级
		public int mProfession1EnemyCount = 0;	//1转敌人数量
		public int mProfession2EnemyCount = 0;	//2转敌人数量
		public int mProfession3EnemyCount = 0;	//3转敌人数量
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//关卡ID（调用ID）
			levelType = br.ReadInt32();	//关卡种类
			mName = br.ReadUInt32();	//关卡名称
			mLevelType = (GlobalDefine.ELevelType)br.ReadUInt16();	//关卡类型
			mThemeType = (GlobalDefine.EThemeType)br.ReadUInt16();	//场景主题
			mStrengthLevel = br.ReadInt32();	//关卡等级
			expReward = br.ReadInt32();	//基础经验奖励
			rewardId = br.ReadInt32();	//掉落奖励组ID
			mBgm = br.ReadString();	//背景音乐（BGM）
			mEnemyLevel = br.ReadInt32();	//敌人等级
			mProfession1EnemyCount = br.ReadInt32();	//1转敌人数量
			mProfession2EnemyCount = br.ReadInt32();	//2转敌人数量
			mProfession3EnemyCount = br.ReadInt32();	//3转敌人数量
			
        }
    } 
} 