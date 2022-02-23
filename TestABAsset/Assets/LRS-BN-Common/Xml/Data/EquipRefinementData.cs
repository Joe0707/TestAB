using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EquipRefinementData : BaseDataObject
    {
        
		public int whiteConsume = 0;	//消耗银币（白）
		public int greenConsume = 0;	//消耗银币（绿）
		public int blueConsume = 0;	//消耗银币（蓝）
		public int violetConsume = 0;	//消耗银币（紫）
		public int orangeConsume = 0;	//消耗银币（橙）
		public int redConsume = 0;	//消耗银币(红）
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//洗练次数
			whiteConsume = br.ReadInt32();	//消耗银币（白）
			greenConsume = br.ReadInt32();	//消耗银币（绿）
			blueConsume = br.ReadInt32();	//消耗银币（蓝）
			violetConsume = br.ReadInt32();	//消耗银币（紫）
			orangeConsume = br.ReadInt32();	//消耗银币（橙）
			redConsume = br.ReadInt32();	//消耗银币(红）
			
        }
    } 
} 