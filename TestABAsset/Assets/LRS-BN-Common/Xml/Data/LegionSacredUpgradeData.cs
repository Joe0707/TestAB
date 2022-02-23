using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LegionSacredUpgradeData : BaseDataObject
    {
        
		public int upgradeExp = 0;	//升级所需经验
		public int sacredEffectAddTimes = 0;	//圣物效果最大可追加次数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//圣物等级
			upgradeExp = br.ReadInt32();	//升级所需经验
			sacredEffectAddTimes = br.ReadInt32();	//圣物效果最大可追加次数
			
        }
    } 
} 