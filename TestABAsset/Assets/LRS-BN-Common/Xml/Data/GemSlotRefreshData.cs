using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class GemSlotRefreshData : BaseDataObject
    {
        
		public int DiamonsPirce_1 = 0;	//镶嵌刷新钻石金额
		public int monochromeSolt_2 = 0;	//2纯色槽概率
		public int monochromeSolt_3 = 0;	//3纯色槽概率
		public int colourSolt_2 = 0;	//2彩色槽概率
		public int colourSolt_3 = 0;	//3彩色槽概率
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//刷新次数
			DiamonsPirce_1 = br.ReadInt32();	//镶嵌刷新钻石金额
			monochromeSolt_2 = br.ReadInt32();	//2纯色槽概率
			monochromeSolt_3 = br.ReadInt32();	//3纯色槽概率
			colourSolt_2 = br.ReadInt32();	//2彩色槽概率
			colourSolt_3 = br.ReadInt32();	//3彩色槽概率
			
        }
    } 
} 