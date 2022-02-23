using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RateData : BaseDataObject
    {
        
		public float phitdef = 0;	//物理命中值转率
		public float pcritdef = 0;	//物理爆击转化率
		public float agicombo = 0;	//敏捷转连击率
		public float agiignoredef = 0;	//忽略防御转化率
		public float pdevatk = 0;	//偏斜值转率
		public float blkatk = 0;	//格挡值转化率
		public float pryatk = 0;	//招架值转化率
		public float mhitdef = 0;	//法术命中值转率
		public float mcritdef = 0;	//法术爆击转化率
		public int pcritdmgdef = 0;	//物理爆击伤害转化率
		public int mcritdmgdef = 0;	//法术爆击伤害转化率
		public int strtophitatk = 0;	//武器力量惩罚转命中率
		public int strtoblkdef = 0;	//盾牌力量惩罚转格挡率
		public float strtopryatk = 0;	//武器力量惩罚转招架率
		public float wiltodying = 0;	//意志转濒死抵抗率
		public float wilPro = 0;	//意志值转率
		public float wilAddPro = 0;	//意志值加率
		public float spdPro = 0;	//速度值转率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//等级
			phitdef = br.ReadSingle();	//物理命中值转率
			pcritdef = br.ReadSingle();	//物理爆击转化率
			agicombo = br.ReadSingle();	//敏捷转连击率
			agiignoredef = br.ReadSingle();	//忽略防御转化率
			pdevatk = br.ReadSingle();	//偏斜值转率
			blkatk = br.ReadSingle();	//格挡值转化率
			pryatk = br.ReadSingle();	//招架值转化率
			mhitdef = br.ReadSingle();	//法术命中值转率
			mcritdef = br.ReadSingle();	//法术爆击转化率
			pcritdmgdef = br.ReadInt32();	//物理爆击伤害转化率
			mcritdmgdef = br.ReadInt32();	//法术爆击伤害转化率
			strtophitatk = br.ReadInt32();	//武器力量惩罚转命中率
			strtoblkdef = br.ReadInt32();	//盾牌力量惩罚转格挡率
			strtopryatk = br.ReadSingle();	//武器力量惩罚转招架率
			wiltodying = br.ReadSingle();	//意志转濒死抵抗率
			wilPro = br.ReadSingle();	//意志值转率
			wilAddPro = br.ReadSingle();	//意志值加率
			spdPro = br.ReadSingle();	//速度值转率
			
        }
    } 
} 