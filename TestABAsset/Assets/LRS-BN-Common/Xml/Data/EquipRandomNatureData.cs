using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipRandomNatureData : BaseDataObject
    {
        
		public string natureConfig = "";	//属性
		public int randomPro = 0;	//随机权重
		public string configDes = "";	//描述
		public string randomRange = "";	//随机区间
		public string randomWeight = "";	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			natureConfig = br.ReadString();	//属性
			randomPro = br.ReadInt32();	//随机权重
			configDes = br.ReadString();	//描述
			randomRange = br.ReadString();	//随机区间
			randomWeight = br.ReadString();	//随机权重
			
        }
    } 
} 