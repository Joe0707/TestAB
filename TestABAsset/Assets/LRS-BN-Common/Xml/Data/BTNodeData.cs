using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class BTNodeData : BaseDataObject
    {
        
		public string name = "";	//节点枚举名
		public string nodeParam = "";	//节点需求的预设参数
		public string treeParam = "";	//节点需求的行为树配置参数
		public string desc = "";	//节点介绍
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//主键节点类型
			name = br.ReadString();	//节点枚举名
			nodeParam = br.ReadString();	//节点需求的预设参数
			treeParam = br.ReadString();	//节点需求的行为树配置参数
			desc = br.ReadString();	//节点介绍
			
        }
    } 
} 