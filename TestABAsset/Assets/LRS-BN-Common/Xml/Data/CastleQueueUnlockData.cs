using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class CastleQueueUnlockData : BaseDataObject
    {
        
		public int funtionType = 0;	//功能类型
		public int queueSeat = 0;	//页面队列数
		public int unlockCastleLevel = 0;	//解锁城堡等级
		public string teachSeatUnlockDes = "";	//解锁描述
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			funtionType = br.ReadInt32();	//功能类型
			queueSeat = br.ReadInt32();	//页面队列数
			unlockCastleLevel = br.ReadInt32();	//解锁城堡等级
			teachSeatUnlockDes = br.ReadString();	//解锁描述
			
        }
    } 
} 