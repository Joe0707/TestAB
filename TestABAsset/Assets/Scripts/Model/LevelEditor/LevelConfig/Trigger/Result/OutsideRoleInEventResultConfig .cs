using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //场外角色入场
    public class OutsideRoleInEventResultConfig : ResultConfig
    {
        public const string Name = "角色入场";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>场外角色Id</UText><URoleSelect id='1'>$property$</URoleSelect></UContainer>")]
        public string OutsideRoleId;//场外角色Id
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>入场格子索引</UText><UInputField valuetype='int'>$property$</UInputField></UContainer>")]
        public int SlotIndex;//入场格子索引
        public override string GetName { get { return OutsideRoleInEventResultConfig.Name; } }//结果事件名
    }
}