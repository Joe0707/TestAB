using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StaticData.Data
{
    public class TransferConfigData : BaseDataObject
    {
        
		public int qingBuBing = 0;	//轻步兵
		public int zhanShi = 0;	//战士
		public int chiHou = 0;	//斥候
		public int kuangZhanShi = 0;	//狂战士
		public int daJianShi = 0;	//大剑士
		public int ciKe = 0;	//刺客
		public int jianSheng = 0;	//剑圣
		public int zhongBuBing = 0;	//重步兵
		public int fangZhenBuBing = 0;	//方阵步兵
		public int zhogJiaQiangBing = 0;	//重甲枪兵
		public int wangShiJinWei = 0;	//王室禁卫
		public int tieJiaJunShi = 0;	//铁甲军士
		public int zhongJiaSengLv = 0;	//重甲僧侣
		public int shengTangTieWei = 0;	//圣堂铁卫
		public int jianXiQiBing = 0;	//见习骑兵
		public int qingQiBing = 0;	//轻骑兵
		public int zhongQiBing = 0;	//重骑兵
		public int huangJiaQiBing = 0;	//皇家骑兵
		public int zhongZhuangQiBing = 0;	//重装骑兵
		public int lueXiQiBing = 0;	//掠袭骑兵
		public int tongYuQiShi = 0;	//统御骑士
		public int lieRen = 0;	//猎人
		public int gongJianShou = 0;	//弓箭手
		public int nuShou = 0;	//弩手
		public int changGongShou = 0;	//长弓手
		public int youXia = 0;	//游侠
		public int dunNuShou = 0;	//盾弩手
		public int zhongNuShou = 0;	//重弩手
		public int ziXueWuShi = 0;	//自学巫师
		public int moFaShi = 0;	//魔法师
		public int muShi = 0;	//牧师
		public int moDaoShi = 0;	//魔导师
		public int zhuJiao = 0;	//主教
		public int yinYouShiRen = 0;	//吟游诗人
		public int lianJinShuShi = 0;	//炼金术士
		
        public override void ReadFromStream(BinaryReader br)
        {
            mID = br.ReadUInt32();	//城市ID
			qingBuBing = br.ReadInt32();	//轻步兵
			zhanShi = br.ReadInt32();	//战士
			chiHou = br.ReadInt32();	//斥候
			kuangZhanShi = br.ReadInt32();	//狂战士
			daJianShi = br.ReadInt32();	//大剑士
			ciKe = br.ReadInt32();	//刺客
			jianSheng = br.ReadInt32();	//剑圣
			zhongBuBing = br.ReadInt32();	//重步兵
			fangZhenBuBing = br.ReadInt32();	//方阵步兵
			zhogJiaQiangBing = br.ReadInt32();	//重甲枪兵
			wangShiJinWei = br.ReadInt32();	//王室禁卫
			tieJiaJunShi = br.ReadInt32();	//铁甲军士
			zhongJiaSengLv = br.ReadInt32();	//重甲僧侣
			shengTangTieWei = br.ReadInt32();	//圣堂铁卫
			jianXiQiBing = br.ReadInt32();	//见习骑兵
			qingQiBing = br.ReadInt32();	//轻骑兵
			zhongQiBing = br.ReadInt32();	//重骑兵
			huangJiaQiBing = br.ReadInt32();	//皇家骑兵
			zhongZhuangQiBing = br.ReadInt32();	//重装骑兵
			lueXiQiBing = br.ReadInt32();	//掠袭骑兵
			tongYuQiShi = br.ReadInt32();	//统御骑士
			lieRen = br.ReadInt32();	//猎人
			gongJianShou = br.ReadInt32();	//弓箭手
			nuShou = br.ReadInt32();	//弩手
			changGongShou = br.ReadInt32();	//长弓手
			youXia = br.ReadInt32();	//游侠
			dunNuShou = br.ReadInt32();	//盾弩手
			zhongNuShou = br.ReadInt32();	//重弩手
			ziXueWuShi = br.ReadInt32();	//自学巫师
			moFaShi = br.ReadInt32();	//魔法师
			muShi = br.ReadInt32();	//牧师
			moDaoShi = br.ReadInt32();	//魔导师
			zhuJiao = br.ReadInt32();	//主教
			yinYouShiRen = br.ReadInt32();	//吟游诗人
			lianJinShuShi = br.ReadInt32();	//炼金术士
			
        }
    } 
} 