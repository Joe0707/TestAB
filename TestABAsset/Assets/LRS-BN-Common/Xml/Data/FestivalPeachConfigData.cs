using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class FestivalPeachConfigData : BaseDataObject
    {
        
		public string peachRoyalBloodLimit = "";	//香桃节血脉
		public string peachBloodRate = "";	//香桃节血脉随机比例
		public string peachAcrorConsume = "";	//香桃节入场所需物品（每人）
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//爵位等级
			peachRoyalBloodLimit = br.ReadString();	//香桃节血脉
			peachBloodRate = br.ReadString();	//香桃节血脉随机比例
			peachAcrorConsume = br.ReadString();	//香桃节入场所需物品（每人）
			
        }
    } 
} 