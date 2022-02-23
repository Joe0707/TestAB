using System;
using GlobalDefine;
using System.Collections.Generic;
//重连命令
public class ConnectionCommand
{
    public EPlayerSceneState mType = EPlayerSceneState.battle;//重连类型
    public Dictionary<string, string> mParam;//参数
    public bool mIsReconnected = false;//是否是主动重连的
}