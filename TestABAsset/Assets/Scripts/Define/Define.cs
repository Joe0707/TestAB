namespace Message
{
    //网络请求结果
    public enum Result
    {
        Success, //成功
        Fail    //失败
    }
}
//通知类型
public class NotificationType
{
    public const string ReconnectionSceneTypeChange = "ReconnectionSceneTypeChange";
}
//重连用场景类型定义
public enum ConnectionSceneType
{
    Battle, //战斗
    WorldMap,//世界地图
    City,//城市
    Festival,//节日
    Login//登录
}
//世界菜单事件
public class WorldMenuEvent
{
    public const string ArenaClick = "OnWorldMenuArenaClick"; //世界菜单的竞技场点击
}

//---------------------竞技场-----------------------
public class ArenaEvent
{
    public const string MatchSuccess = "OnArenaEventMatchSuccess";
    public const string UpdateArenaInfo = "OnArenaEventUpdateArenaInfo";
}

public enum InstanceZoneEnterType
{
    CreateTeam,
    JoinTeam,
    RandomMatch
}