using GlobalDefine;
public class EditorUtil
{
    //获取技能类型文字
    public static string GetSkillTypeText(ESkillType skillType)
    {
        var result = "";
        switch (skillType)
        {
            case ESkillType.GNERAL_SKILL:
                result = "普通";
                break;
            case ESkillType.BUFFER_SKILL:
                result = "Buffer";
                break;
            case ESkillType.WHIRLWIND_TARGET_SKILL:
                result = "旋风斩目标为中心";
                break;
            case ESkillType.WHIRLWIND_SELF_SKILL:
                result = "旋风斩自己为中心";
                break;
            case ESkillType.CHARGE_SKILL:
                result = "冲锋";
                break;
            case ESkillType.DOUBLE_SKILL:
                result = "暴击";
                break;
        }
        return result;
    }

    public static string GetSkillTargetType(ESkillTargetType targetType)
    {
        var result = "";
        switch (targetType)
        {
            case ESkillTargetType.Enemy:
                result = "敌人";
                break;
            case ESkillTargetType.Friend:
                result = "友方";
                break;
            case ESkillTargetType.Neutral:
                result = "中立";
                break;
        }
        return result;
    }

    //获取技能伤害类型
    public static string GetSkillDamageTypeText(ESkillDamageType damageType)
    {
        var result = "";
        switch (damageType)
        {
            // case ESkillDamageType.AnWei:
            //    result = "按位";
            //    break;
            case ESkillDamageType.ZhanJi:
                result = "斩击";
                break;
            case ESkillDamageType.TuCi:
                result = "突刺";
                break;
            // case ESkillDamageType.DaJi:
            //    result = "打击";
            //    break;
            case ESkillDamageType.YuanCheng:
                result = "远程";
                break;
            case ESkillDamageType.FaShu:
                result = "法术";
                break;
            case ESkillDamageType.ZhiLiao:
                result = "治疗";
                break;
                // case ESkillDamageType.AddBuff:
                //    result = "加Buff";
                //    break;
        }
        return result;
    }

    /// <summary>
    /// 返回停止状态的文字
    /// </summary>
    /// <param name="stop"></param>
    /// <returns></returns>
    public static string GetStatusStopText(EEffectStatusStop1 stop)
    {
        var result = "";
        switch (stop)
        {
            case EEffectStatusStop1.None:
                result = "无";
                break;
            case EEffectStatusStop1.Battle:
                result = "战斗过";
                break;
            case EEffectStatusStop1.RoundStart:
                result = "回合开始";
                break;
            case EEffectStatusStop1.RoundNotMove:
                result = "回合内没移动";
                break;
            case EEffectStatusStop1.RoundNotAction:
                result = "回合内没行动";
                break;
        }
        return result;
    }
}