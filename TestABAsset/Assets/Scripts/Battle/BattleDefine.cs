//战斗定义
namespace BattleDefine
{
    //格子路线方向
    public enum PathDirection
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    //角色行动状态
    public class ActorActStatus
    {
        public const string StandBy = "StandBy";//待机
        public const string Move = "Move";//移动
        public const string Attack = "Attack";//攻击
        // public const string Drag = "Drag";//拖动
        public const string None = "None";//空状态
        // public const string DragConfirm = "DragConfirm";//拖动确认
        public const string Moving = "Moving";//移动中
        public const string AttackMoving = "AttackMoving";//攻击移动中
        public const string GoBack = "GoBack";//回归状态
        public const string GoBackDrag = "GoBackDrag";//拖拽回归状态
    }
    //角色操控状态
    public class ActorOpStatus
    {
        public const string Action = "Action";//行动状态
        public const string NoDrag = "NoDrag";//不可拖动
        public const string NoDragAndClick = "NoDragAndClick";//不可拖动和点击
    }
    //射线检测状态
    public class RayCheckStatus
    {
        public const string ActorAndSlot = "ActorAndSlot";//角色和格子
        public const string OnlySlot = "OnlySlot";//仅检测格子
    }

    //动画事件类型
    public class AnimationEventType
    {
        public const string AddArrow = "AddArrow";
        public const string RemoveArrow = "RemoveArrow";
    }

    public enum SlotStatusType
    {
        None,    //无状态
        Attack, //攻击
        Gain,   //增益
        Move //移动
    }

}