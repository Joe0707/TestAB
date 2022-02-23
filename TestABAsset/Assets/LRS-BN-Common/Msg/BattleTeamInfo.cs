using System.Collections.Generic;
namespace Msg {
    // 战斗队伍信息
    public class BattleTeamInfo {
        public int id = 0;
        public string name = "";    //队伍名称
        public string leader = "";  //队长角色GID
        public List<BattleTeamActorInfo> team = new List<BattleTeamActorInfo>();
    }

    public class BattleTeamActorInfo {
        public string entityGid = "";
        public int index = 0;
        public List<string> equipList = new List<string>();
        public List<Skill> skillList = new List<Skill>();
    }
}