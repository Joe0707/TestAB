using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipStrengthenData : BaseDataObject
    {
        
		public int quality = 0;	//所需对应品质
		public int promotePro = 0;	//提升比例
		public int usedProp = 0;	//消耗道具
		public int propNum = 0;	//道具消耗
		public int protectItem = 0;	//保护道具id
		public int strengthenItem = 0;	//强化道具id
		public int spendSC = 0;	//消耗银币
		public int basicPro = 0;	//基础成功率
		public int uplimit = 0;	//成功率上限
		public int failure = 0;	//失败惩罚
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//装备强化等级
			quality = br.ReadInt32();	//所需对应品质
			promotePro = br.ReadInt32();	//提升比例
			usedProp = br.ReadInt32();	//消耗道具
			propNum = br.ReadInt32();	//道具消耗
			protectItem = br.ReadInt32();	//保护道具id
			strengthenItem = br.ReadInt32();	//强化道具id
			spendSC = br.ReadInt32();	//消耗银币
			basicPro = br.ReadInt32();	//基础成功率
			uplimit = br.ReadInt32();	//成功率上限
			failure = br.ReadInt32();	//失败惩罚
			
        }
    } 
} 