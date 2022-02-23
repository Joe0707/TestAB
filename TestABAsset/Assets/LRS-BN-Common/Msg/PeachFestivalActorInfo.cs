using System.Collections.Generic;
namespace Msg {
    public class PeachFestivalActorInfoList{
        public List<PeachFestivalActorInfo> list = new List<PeachFestivalActorInfo>();
    }

    public class PeachFestivalActorInfo {
        public string entityGid = "";                //角色实体唯一ID
        public string entityName = "";                 //角色名称
        public int age = 0;                          // 角色年龄
        public NobilityInfo nobilityInfo = new NobilityInfo();  //角色爵位信息
        public Part partInfo = new Part();              //外观部件信息
    }
}