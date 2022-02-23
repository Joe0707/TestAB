using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色BuffDebuff更改事件
    public class RoleBuffDebuffAddResultConfig : ResultConfig
    {
        public const string Name = "角色BuffDebuff变更";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>角色Id</UText><URoleSelect>$property$</URoleSelect></UContainer>")]
        public string RoleId = "";   //角色Id
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>添加buffId</UText><UInputField>$property$</UInputField></UContainer>")]
        public string BuffAddId = "";//添加buffId
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>添加debuffId</UText><UInputField>$property$</UInputField></UContainer>")]
        public string DebuffAddId = "";//添加DebuffId
        public override string GetName
        { get { return RoleBuffDebuffAddResultConfig.Name; } }//结果事件名
    }

}