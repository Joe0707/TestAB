using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class AvatarsData : BaseDataObject
    {
        
		public int sex = 0;	//性别
		public int clothes = 0;	//衣服
		public int face = 0;	//脸型
		public int body = 0;	//身体
		public int skinColor = 0;	//肤色
		public int eyebrow = 0;	//眉毛
		public int eye = 0;	//眼睛
		public int nose = 0;	//鼻子
		public int mouth = 0;	//嘴巴
		public int ear = 0;	//耳朵
		public int hair = 0;	//发型
		public int hairColor = 0;	//发色
		public int eyebrowColor = 0;	//眉毛颜色
		public int stigma = 0;	//圣痕
		public int tattoo = 0;	//刺青
		public int scar = 0;	//伤疤
		public int beard = 0;	//胡子(男性）
		public int beardColor = 0;	//胡子颜色（男性）
		public int accessory = 0;	//装饰
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//ID
			sex = br.ReadInt32();	//性别
			clothes = br.ReadInt32();	//衣服
			face = br.ReadInt32();	//脸型
			body = br.ReadInt32();	//身体
			skinColor = br.ReadInt32();	//肤色
			eyebrow = br.ReadInt32();	//眉毛
			eye = br.ReadInt32();	//眼睛
			nose = br.ReadInt32();	//鼻子
			mouth = br.ReadInt32();	//嘴巴
			ear = br.ReadInt32();	//耳朵
			hair = br.ReadInt32();	//发型
			hairColor = br.ReadInt32();	//发色
			eyebrowColor = br.ReadInt32();	//眉毛颜色
			stigma = br.ReadInt32();	//圣痕
			tattoo = br.ReadInt32();	//刺青
			scar = br.ReadInt32();	//伤疤
			beard = br.ReadInt32();	//胡子(男性）
			beardColor = br.ReadInt32();	//胡子颜色（男性）
			accessory = br.ReadInt32();	//装饰
			
        }
    } 
} 