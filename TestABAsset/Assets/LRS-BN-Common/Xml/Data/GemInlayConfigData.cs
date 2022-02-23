using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GemInlayConfigData : BaseDataObject
    {
        
		public int upgradePrice = 0;	//纯色槽升级所需银币
		public int upgradePro = 0;	//升级成功率
		public int upgradePrice_2 = 0;	//彩色槽升级所需银币
		public int upgradePro_2 = 0;	//升级成功率
		public int addSuccessProp = 0;	//提升成功率道具
		public int propAddLimit = 0;	//道具提升上限
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//等级编号
			upgradePrice = br.ReadInt32();	//纯色槽升级所需银币
			upgradePro = br.ReadInt32();	//升级成功率
			upgradePrice_2 = br.ReadInt32();	//彩色槽升级所需银币
			upgradePro_2 = br.ReadInt32();	//升级成功率
			addSuccessProp = br.ReadInt32();	//提升成功率道具
			propAddLimit = br.ReadInt32();	//道具提升上限
			
        }
    } 
} 