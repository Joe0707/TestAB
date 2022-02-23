using System.Collections.Generic;
namespace Msg {
    //角色血脉信息
    public class BloodInfo {
        public int birthTime = 0;       //出生时间
        public int title = 0;           //先天称号
        public int age = 0;             //年龄
        public int sex = 0;             //性别
        public StrPair spouse = new StrPair();      //配偶角色GID？ 配偶血脉信息GID？ 父母、子女等同配置方式
        public int spouseBearNum = 0;   //和配偶的生育次数
        public int createType = 0;      //血脉的创建类型 
        public int createSocialStatus = 0;//先天社会地位
        public int createBearIndex = 0; //该角色是亲代的第几次生育时出生
        public int marryState = 0;  //婚姻状态
        public Dictionary<string, float> growAttr = new Dictionary<string, float>();  //血脉的属性成长
        public List<StrPair> children = new List<StrPair>();  //[子女GID1, 子女GID2....]
        public List<StrPair> parent = new List<StrPair>();    //[父GID,母GID]
        public List<ActorBloodlineInfo> hideBloodlines = new List<ActorBloodlineInfo>();    //隐性血脉信息
        public List<ActorBloodlineInfo> showBloodlines = new List<ActorBloodlineInfo>();    //显性血脉信息
    }
}