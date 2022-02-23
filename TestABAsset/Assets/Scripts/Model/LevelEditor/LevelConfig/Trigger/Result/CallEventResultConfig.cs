using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色离开事件配置
    public class CallEventResultConfig : ResultConfig
    {
        public const string Name = "召唤事件";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>召唤角色ID</UText><URoleSelect id='1'>$property$</URoleSelect></UContainer>")]
        public string CallRoleId;//召唤角色ID
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>召唤方式</UText><UDropdown defaultvalue='$property$'>指定格子;自身周边;随机</UDropdown></UContainer>")]
        public ECallType CallType;//召唤方式 
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>格子索引</UText><UInputField valuetype='int'>$property$</UInputField></UContainer>")]
        public int SlotIndex;//格子索引
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>被召唤角色ID</UText><URoleSelect id='2'>$property$</URoleSelect></UContainer>")]
        public string RoleIdCalled;//被召唤角色
        public override string GetName { get { return CallEventResultConfig.Name; } }//结果事件名
    }
}