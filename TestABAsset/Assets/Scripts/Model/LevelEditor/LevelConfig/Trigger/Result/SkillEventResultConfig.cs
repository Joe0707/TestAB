using GlobalDefine;
namespace Levels.Trigger
{
    //攻击事件配置
    public class SkillEventResultConfig : ResultConfig
    {
        public const string Name = "技能释放";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>来源角色ID</UText><URoleSelect id='1'>$property$</URoleSelect></UContainer>")]

        public string FromId = "";//来源角色ID
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>目标角色ID</UText><URoleSelect id='2'>$property$</URoleSelect></UContainer>")]
        public string ToId = "";//目标角色ID
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>攻击技能ID</UText><UInputField>$property$</UInputField></UContainer>")]
        public string SkillId = "";//攻击技能ID
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>伤害值</UText><UInputField valuetype='float'>$property$</UInputField></UContainer>")]
        public float DamageValue = -1;//伤害值
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>伤害百分比</UText><UInputField valuetype='float'>$property$</UInputField></UContainer>")]
        public float DamagePercent = -1;//伤害百分比
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>技能使用类型</UText><UDropdown defaultvalue='$property$'>伤害;治疗</UDropdown></UContainer>")]
        public ESkillUseType UseType = ESkillUseType.Damage;//技能使用类型
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>技能受击类型</UText><UDropdown defaultvalue='$property$'>无状态;正常;偏斜;暴击;格挡;招架;死亡</UDropdown></UContainer>")]
        public ESkillBeHitType BeHitType = ESkillBeHitType.Normal;//技能受击类型
        public override string GetName { get { return SkillEventResultConfig.Name; } }//结果事件名

    }

}