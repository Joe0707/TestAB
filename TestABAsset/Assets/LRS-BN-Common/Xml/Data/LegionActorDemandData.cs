using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class LegionActorDemandData : BaseDataObject
    {
        
		public int type = 0;	//类型
		public int sex = 0;	//性别
		public string triggerCondition = "";	//触发条件
		public int doneMonth = 0;	//完成月份
		public string demandDes = "";	//需求描述
		public int agreeMoraleNum = 0;	//同意(完成)士气变化值
		public int refuseMoraleNum = 0;	//拒绝（未完成）士气变化值
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//id
			type = br.ReadInt32();	//类型
			sex = br.ReadInt32();	//性别
			triggerCondition = br.ReadString();	//触发条件
			doneMonth = br.ReadInt32();	//完成月份
			demandDes = br.ReadString();	//需求描述
			agreeMoraleNum = br.ReadInt32();	//同意(完成)士气变化值
			refuseMoraleNum = br.ReadInt32();	//拒绝（未完成）士气变化值
			
        }
    } 
} 