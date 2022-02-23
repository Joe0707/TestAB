using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TeamBattleBuffsData : BaseDataObject
    {
        
		public int doneType = 0;	//完成类型
		public int conditionParameter = 0;	//条件参数
		public int playerBranchBuffID = 0;	//主线玩家获得buffID
		public int playerMainBuffID = 0;	//其他玩家获得buffID
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//编号
			doneType = br.ReadInt32();	//完成类型
			conditionParameter = br.ReadInt32();	//条件参数
			playerBranchBuffID = br.ReadInt32();	//主线玩家获得buffID
			playerMainBuffID = br.ReadInt32();	//其他玩家获得buffID
			
        }
    } 
} 