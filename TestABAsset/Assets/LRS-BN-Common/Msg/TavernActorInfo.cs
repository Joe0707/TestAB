using System.Collections.Generic;
namespace Msg {
    public class TavernActorInfo {
        public string entityGid = "";                //角色实体唯一ID
        public string entityName = "";                 //角色名称
        public int age = 0;                          // 角色年龄
        public int level = 0;                        //总等级
        public int sex = 0;                          //角色性别
        public int jobId = 0;                        //角色职业
        public float wageBloodCoefficient = 0;          // 角色工资血脉提升系数
        public NobilityInfo nobilityInfo = new NobilityInfo();  //角色爵位信息
        public Part partInfo = new Part();              //外观部件信息
    }
}