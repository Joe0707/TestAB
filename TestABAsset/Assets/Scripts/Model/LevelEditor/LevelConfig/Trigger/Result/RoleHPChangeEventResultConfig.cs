using GlobalDefine;
using System.Collections.Generic;
namespace Levels.Trigger
{
    //角色HP更改事件
    public class RoleHPChangeEventResultConfig : ResultConfig
    {
        public const string Name = "角色HP变更";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>角色Id</UText><URoleSelect>$property$</URoleSelect></UContainer>")]
        public string RoleId = "";   //角色Id
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>变更值</UText><UInputField valuetype='float'>$property$</UInputField></UContainer>")]
        public float ChangeValue = -1;//变更值
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>变更百分比</UText><UInputField valuetype='float'>$property$</UInputField></UContainer>")]
        public float ChangePercent = -1;//变更百分比
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>血量变化类型</UText><UDropdown defaultvalue='$property$'>伤害;治疗</UDropdown></UContainer>")]
        public ESkillUseType ChangeType = ESkillUseType.Damage;//血量变化类型
        public override string GetName
        { get { return RoleHPChangeEventResultConfig.Name; } }//结果事件名
    }

}