using System.Collections.Generic;
namespace Msg {
    public class Actor {
        public ActorInfo actorInfo = new ActorInfo();   //角色信息
        public AttrInfo attrInfo = new AttrInfo();      //属性信息
        public Part partInfo = new Part();              //外观部件信息，怪物可能没这部分数据，会给null
        public BloodInfo bloodInfo = new BloodInfo();       //角色血脉信息
        public List<string> equipList = new List<string>();
        public ActorModuleSkill skillModule = new ActorModuleSkill(); //角色技能模块信息
        public ActorModuleSpeciality specialityModule = new ActorModuleSpeciality(); //角色特性模块信息
        public ActorModuleInjury injuryModule = new ActorModuleInjury(); //角色伤病模块信息

    }
}