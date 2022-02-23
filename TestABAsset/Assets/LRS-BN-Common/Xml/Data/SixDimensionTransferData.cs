using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class SixDimensionTransferData : BaseDataObject
    {
        
		public float limitNum = 0;	//六维成长界线数值
		public string displayDes = "";	//显示描述
		public string displayColour = "";	//显示颜色
		public float wageCoefficient6D = 0;	//六维工资系数
		public int basicPrice6D = 0;	//六维初始评级基数
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//六维成长潜力ID
			limitNum = br.ReadSingle();	//六维成长界线数值
			displayDes = br.ReadString();	//显示描述
			displayColour = br.ReadString();	//显示颜色
			wageCoefficient6D = br.ReadSingle();	//六维工资系数
			basicPrice6D = br.ReadInt32();	//六维初始评级基数
			
        }
    } 
} 