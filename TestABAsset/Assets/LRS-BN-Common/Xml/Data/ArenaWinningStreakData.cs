using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class ArenaWinningStreakData : BaseDataObject
    {
        
		public int winningStreakTimes = 0;	//连胜场次
		public int addIntrgral = 0;	//增加积分
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			winningStreakTimes = br.ReadInt32();	//连胜场次
			addIntrgral = br.ReadInt32();	//增加积分
			
        }
    } 
} 