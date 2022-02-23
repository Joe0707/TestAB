using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class RefinementRandomProData : BaseDataObject
    {
        
		public int stochastic = 0;	//随机项
		public int randomPro = 0;	//随机权重
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			stochastic = br.ReadInt32();	//随机项
			randomPro = br.ReadInt32();	//随机权重
			
        }
    } 
} 