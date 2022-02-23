using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class PrestigeData : BaseDataObject
    {
        
		public int ulockPrestige = 0;	//解锁友好度
		public string pretigeDes = "";	//关系描述
		public int openNobility = 0;	//解锁最高爵位
		public int ulockBunction = 0;	//解锁功能
		public string colorConfig = "";	//颜色配置
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//关系等级id
			ulockPrestige = br.ReadInt32();	//解锁友好度
			pretigeDes = br.ReadString();	//关系描述
			openNobility = br.ReadInt32();	//解锁最高爵位
			ulockBunction = br.ReadInt32();	//解锁功能
			colorConfig = br.ReadString();	//颜色配置
			
        }
    } 
} 