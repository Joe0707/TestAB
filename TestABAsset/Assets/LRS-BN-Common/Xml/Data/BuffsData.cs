using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BuffsData : BaseDataObject
    {
        
		public int mbuffId = 0;	//状态id
		public string buffName = "";	//状态名
		public int buffLevel = 0;	//状态等级
		public int buffType = 0;	//状态类型
		public string damageType = "";	//伤害类型
		public int keepType = 0;	//持续类型
		public int keep = 0;	//持续回合
		public int superposition = 0;	//是否可叠加
		public int refresh = 0;	//是否可刷新
		public string buffEffect = "";	//buff效果
		public string buffDes = "";	//buff描述
		public string chineseDes = "";	//中文描述
		public string effectParameter = "";	//效果参数
		public string buffIcon = "";	//buff图标
		public string buffArtEffect = "";	//buff美术特效
		public int suspend = 0;	//暂停动作
		public string text = "";	//备注
		public int buffRange = 0;	//buff射程
		public int buffScope = 0;	//影响范围
		public string usableJob = "";	//可用职业id
		public string skillSlot = "";	//可用技能槽
		public int skillDisplay = 0;	//是否在技能栏显示
		public string teachNeedNature = "";	//技能传授所需属性
		public int teachSkill = 0;	//技能是否可传授
		public int clientIconDisplay = 0;	//客户端是否展示
		public string soundEffect = "";	//buff音效
		public int clientEffectDisplay = 0;	//客户端是否展示特效
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//状态id
			mbuffId = br.ReadInt32();	//状态id
			buffName = br.ReadString();	//状态名
			buffLevel = br.ReadInt32();	//状态等级
			buffType = br.ReadInt32();	//状态类型
			damageType = br.ReadString();	//伤害类型
			keepType = br.ReadInt32();	//持续类型
			keep = br.ReadInt32();	//持续回合
			superposition = br.ReadInt32();	//是否可叠加
			refresh = br.ReadInt32();	//是否可刷新
			buffEffect = br.ReadString();	//buff效果
			buffDes = br.ReadString();	//buff描述
			chineseDes = br.ReadString();	//中文描述
			effectParameter = br.ReadString();	//效果参数
			buffIcon = br.ReadString();	//buff图标
			buffArtEffect = br.ReadString();	//buff美术特效
			suspend = br.ReadInt32();	//暂停动作
			text = br.ReadString();	//备注
			buffRange = br.ReadInt32();	//buff射程
			buffScope = br.ReadInt32();	//影响范围
			usableJob = br.ReadString();	//可用职业id
			skillSlot = br.ReadString();	//可用技能槽
			skillDisplay = br.ReadInt32();	//是否在技能栏显示
			teachNeedNature = br.ReadString();	//技能传授所需属性
			teachSkill = br.ReadInt32();	//技能是否可传授
			clientIconDisplay = br.ReadInt32();	//客户端是否展示
			soundEffect = br.ReadString();	//buff音效
			clientEffectDisplay = br.ReadInt32();	//客户端是否展示特效
			
        }
    } 
} 