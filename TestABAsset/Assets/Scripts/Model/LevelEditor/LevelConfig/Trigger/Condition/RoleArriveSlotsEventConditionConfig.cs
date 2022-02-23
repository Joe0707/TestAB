using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    public class RoleArriveSlotsEventConditionConfig : ConditionConfig
    {
        public const string Name = "角色到达多格子";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>角色Id</UText><URoleSelect>$property$</URoleSelect></UContainer>")]
        public string RoleId;//角色Id
        [ConfigAttribute("<USlotIndexes title='抵达格子(行列使用,分割)'>$property$</USlotIndexes>")]
        public string SlotIndexes;//格子索引 多格子使用","分割
        public override string GetName { get { return RoleArriveSlotsEventConditionConfig.Name; } }
    }
}