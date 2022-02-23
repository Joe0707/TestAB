using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class MonstersData : BaseDataObject
    {
        
		public uint mName = 0;	//怪物名称
		public GlobalDefine.EMonsterType mMonsterType;	//怪物类型（人形、野兽、建筑）
		public int mOccu = 0;	//怪物职业
		public int mAi = 0;	//AI
		public int mCamp = 0;	//怪物阵营
		public int mLvl = 0;	//等级
		public float mHp = 0;	//血量
		public float mStr = 0;	//力量
		public float mDex = 0;	//技巧
		public float mAgi = 0;	//敏捷
		public float mVit = 0;	//体质
		public float mPer = 0;	//感知
		public float mWil = 0;	//意志
		public float mAtk = 0;	//攻击力
		public float mPdef = 0;	//物理防御
		public float mMdef = 0;	//魔法防御
		public float mHitrate = 0;	//基础命中
		public float mPhit = 0;	//物理命中
		public float mPcrit = 0;	//物理暴击
		public float mPcritdmg = 0;	//物理暴伤
		public float mPdcrit = 0;	//物理抗暴
		public float mMdcrit = 0;	//魔法抗暴
		public float mPdev = 0;	//偏斜
		public float mMove = 0;	//附加移动力
		public int mPerk1 = 0;	//技能1
		public int mPerk2 = 0;	//技能2
		public int mPerk3 = 0;	//技能3
		public int mPerk4 = 0;	//技能4
		public int mPerk5 = 0;	//技能5
		public int mPerk6 = 0;	//技能6
		public int nobility = 0;	//爵位
		public int mMale = 0;	//性别
		public int mMainhand = 0;	//主
		public int mOffhand = 0;	//副
		public int mHead = 0;	//头
		public int mBody = 0;	//胸
		public int mShoes = 0;	//鞋
		public int mOrnament = 0;	//饰
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//怪物ID（调用ID）
			mName = br.ReadUInt32();	//怪物名称
			mMonsterType = (GlobalDefine.EMonsterType)br.ReadUInt16();	//怪物类型（人形、野兽、建筑）
			mOccu = br.ReadInt32();	//怪物职业
			mAi = br.ReadInt32();	//AI
			mCamp = br.ReadInt32();	//怪物阵营
			mLvl = br.ReadInt32();	//等级
			mHp = br.ReadSingle();	//血量
			mStr = br.ReadSingle();	//力量
			mDex = br.ReadSingle();	//技巧
			mAgi = br.ReadSingle();	//敏捷
			mVit = br.ReadSingle();	//体质
			mPer = br.ReadSingle();	//感知
			mWil = br.ReadSingle();	//意志
			mAtk = br.ReadSingle();	//攻击力
			mPdef = br.ReadSingle();	//物理防御
			mMdef = br.ReadSingle();	//魔法防御
			mHitrate = br.ReadSingle();	//基础命中
			mPhit = br.ReadSingle();	//物理命中
			mPcrit = br.ReadSingle();	//物理暴击
			mPcritdmg = br.ReadSingle();	//物理暴伤
			mPdcrit = br.ReadSingle();	//物理抗暴
			mMdcrit = br.ReadSingle();	//魔法抗暴
			mPdev = br.ReadSingle();	//偏斜
			mMove = br.ReadSingle();	//附加移动力
			mPerk1 = br.ReadInt32();	//技能1
			mPerk2 = br.ReadInt32();	//技能2
			mPerk3 = br.ReadInt32();	//技能3
			mPerk4 = br.ReadInt32();	//技能4
			mPerk5 = br.ReadInt32();	//技能5
			mPerk6 = br.ReadInt32();	//技能6
			nobility = br.ReadInt32();	//爵位
			mMale = br.ReadInt32();	//性别
			mMainhand = br.ReadInt32();	//主
			mOffhand = br.ReadInt32();	//副
			mHead = br.ReadInt32();	//头
			mBody = br.ReadInt32();	//胸
			mShoes = br.ReadInt32();	//鞋
			mOrnament = br.ReadInt32();	//饰
			
        }
    } 
} 