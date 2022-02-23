using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TopographyBuffData : BaseDataObject
    {
        
		public string TopographyName = "";	//状态名
		public string chneseName = "";	//中文名
		public int superposition = 0;	//是否可叠加
		public string buffEffect = "";	//buff效果
		public string buffDes = "";	//buff描述
		public string InvalidJob = "";	//无效职业
		public string resourcesName = "";	//对应地形资源
		public string animationEffect = "";	//状态特效资源
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//状态id
			TopographyName = br.ReadString();	//状态名
			chneseName = br.ReadString();	//中文名
			superposition = br.ReadInt32();	//是否可叠加
			buffEffect = br.ReadString();	//buff效果
			buffDes = br.ReadString();	//buff描述
			InvalidJob = br.ReadString();	//无效职业
			resourcesName = br.ReadString();	//对应地形资源
			animationEffect = br.ReadString();	//状态特效资源
			
        }
    } 
} 