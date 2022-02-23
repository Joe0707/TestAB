using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class WrinkleData : BaseDataObject
    {
        
		public string partFaceType = "";	//脸型血脉类型
		public string maleWrinkleRes = "";	//男性资源
		public string femaleWrinkleRes = "";	//女性资源
		public string startAge = "";	//启动年龄
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			partFaceType = br.ReadString();	//脸型血脉类型
			maleWrinkleRes = br.ReadString();	//男性资源
			femaleWrinkleRes = br.ReadString();	//女性资源
			startAge = br.ReadString();	//启动年龄
			
        }
    } 
} 