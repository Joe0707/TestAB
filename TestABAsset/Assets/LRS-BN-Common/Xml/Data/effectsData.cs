using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class EffectsData : BaseDataObject
    {
        
		public int Type = 0;	//效果类型ID
		public int Battle = 0;	//是否战场效果
		public string Condition1 = "";	//触发条件
		public string Condition2 = "";	//触发条件
		public string Condition3 = "";	//触发条件
		public string Condition4 = "";	//触发条件
		public string Condition5 = "";	//触发条件
		public string Param1 = "";	//效果参数1
		public string Param2 = "";	//效果参数2
		public string Param3 = "";	//效果参数3
		public string Param4 = "";	//效果参数4
		public string Param5 = "";	//效果参数5
		public string Param6 = "";	//效果参数6
		public string Param7 = "";	//效果参数7
		public string Param8 = "";	//效果参数8
		public int DestoryStatus = 0;	//触发后是否移除状态
		public string View = "";	//光效视图
		public string Bind = "";	//光效位置
		public GlobalDefine.EViewTarget ViewTarget;	//光效目标（1自己2目标3全部），0之前数据为空需确认默认值是否为0
		public int IsAP = 0;	//是否AP技能
		public string MagicView = "";	//改变技能视图
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//效果ID
			Type = br.ReadInt32();	//效果类型ID
			Battle = br.ReadInt32();	//是否战场效果
			Condition1 = br.ReadString();	//触发条件
			Condition2 = br.ReadString();	//触发条件
			Condition3 = br.ReadString();	//触发条件
			Condition4 = br.ReadString();	//触发条件
			Condition5 = br.ReadString();	//触发条件
			Param1 = br.ReadString();	//效果参数1
			Param2 = br.ReadString();	//效果参数2
			Param3 = br.ReadString();	//效果参数3
			Param4 = br.ReadString();	//效果参数4
			Param5 = br.ReadString();	//效果参数5
			Param6 = br.ReadString();	//效果参数6
			Param7 = br.ReadString();	//效果参数7
			Param8 = br.ReadString();	//效果参数8
			DestoryStatus = br.ReadInt32();	//触发后是否移除状态
			View = br.ReadString();	//光效视图
			Bind = br.ReadString();	//光效位置
			ViewTarget = (GlobalDefine.EViewTarget)br.ReadUInt16();	//光效目标（1自己2目标3全部），0之前数据为空需确认默认值是否为0
			IsAP = br.ReadInt32();	//是否AP技能
			MagicView = br.ReadString();	//改变技能视图
			
        }
    } 
} 