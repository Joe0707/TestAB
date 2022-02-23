using GlobalDefine;
public class SkillItemConfig
{
    public string UId = "";//技能配置项唯一ID
    public uint Id = 0;//技能ID
    public uint JobId = 0;//职业ID
    public EGender Sex = EGender.Male;//性别
    public EquipmentType EquipType = EquipmentType.DanShouJian;//装备类型
    public string Name = "";//技能名
    public string ActionName = "";//动作名
    public string EffectName = "";//特效名
    public string EffectFollowTarget = "0";//特效跟随目标
    public string AudioName = "";//音效名
    public string EffectPlayFrame = "0";//特效起始帧
    public string AudioPlayFrame = "0";//音效起始帧
    public bool IsShake = false;//是否震动
    public ushort ShakePlayFrame = 0;//震屏起始帧
    public string HitFrame = "0";//动作着力帧
    public string HitEffects = "";//受击特效
    public string HitEffectsFrames = "";//受击特效开始帧
    public bool isFrozen = false;//受击动作暂停
    public int AttackNumber = 1;//攻击次数
    public bool CritNeedPerformance = false;//暴击是否需要表现
    public string CritActionName = "";//暴击动作名
    public string CritEffectName = "";//暴击特效名
    public string CritEffectFollowTarget = "0";//暴击特效跟随目标
    public string CritAudioName = "";//暴击音效名
    public string CritEffectPlayFrame = "0";//暴击特效起始帧
    public string CritAudioPlayFrame = "0";//暴击音效起始帧
    public bool CritIsShake = false;//暴击是否震动
    public ushort CritShakePlayFrame = 0;//暴击震屏起始帧
    public string CritHitFrame = "0";//暴击动作着力帧
    public string CritHitEffects = "";//暴击受击特效
    public string CritHitEffectsFrames = "";//暴击受击特效开始帧
    public bool AttackMove = false;//攻击是否移动
    public bool AttackFinishMove = false;//攻击结束移动
    public AttackMovePositionType AttackMovePositionType = AttackMovePositionType.Front;//攻击移动位置类型
    public int AttackMoveStartFrame = 0;//开始移动帧数
    public int AttackMoveEndFrame = 0;//结束移动帧数
    public bool BehitMove = false;//受击是否移动
    public int BehitDelayFrame = 0;//受击延迟移动
    public BeHitMovePositionType beHitMovePositionType = BeHitMovePositionType.Slot;//受击移动位置类型
    //是否是击退
    public bool isReple()
    {
        return BehitMove == true && beHitMovePositionType == BeHitMovePositionType.Slot;
    }
    public SkillItemConfig()
    {
        this.UId = LevelUtil.GenerateID();
    }
    public SkillItemConfig Clone()
    {
        var result = new SkillItemConfig();
        result.UId = UId;
        result.Id = Id;
        result.Sex = Sex;
        result.JobId = JobId;
        result.EquipType = EquipType;
        result.Name = Name;
        result.ActionName = ActionName;
        result.EffectName = EffectName;
        result.EffectFollowTarget = EffectFollowTarget;
        result.AudioName = AudioName;
        result.EffectPlayFrame = EffectPlayFrame;
        result.AudioPlayFrame = AudioPlayFrame;
        result.IsShake = IsShake;
        result.ShakePlayFrame = ShakePlayFrame;
        result.HitFrame = HitFrame;
        result.HitEffects = HitEffects;
        result.HitEffectsFrames = HitEffectsFrames;
        result.isFrozen = isFrozen;
        result.AttackNumber = AttackNumber;
        result.CritNeedPerformance = CritNeedPerformance;
        result.CritActionName = CritActionName;
        result.CritEffectName = CritEffectName;
        result.CritEffectFollowTarget = CritEffectFollowTarget;
        result.CritAudioName = CritAudioName;
        result.CritEffectPlayFrame = CritEffectPlayFrame;
        result.CritAudioPlayFrame = CritAudioPlayFrame;
        result.CritIsShake = CritIsShake;
        result.CritShakePlayFrame = CritShakePlayFrame;
        result.CritHitFrame = CritHitFrame;
        result.CritHitEffects = CritHitEffects;
        result.CritHitEffectsFrames = CritHitEffectsFrames;
        result.AttackMove = AttackMove;
        result.AttackFinishMove = AttackFinishMove;
        result.AttackMovePositionType = AttackMovePositionType;
        result.BehitMove = BehitMove;
        result.beHitMovePositionType = beHitMovePositionType;
        result.BehitDelayFrame = BehitDelayFrame;
        result.AttackMoveStartFrame = AttackMoveStartFrame;
        result.AttackMoveEndFrame = AttackMoveEndFrame;
        return result;
    }

    public void Copy(SkillItemConfig value)
    {
        Id = value.Id;
        JobId = value.JobId;
        Sex = value.Sex;
        EquipType = value.EquipType;
        Name = value.Name;
        ActionName = value.ActionName;
        EffectName = value.EffectName;
        EffectFollowTarget = value.EffectFollowTarget;
        AudioName = value.AudioName;
        EffectPlayFrame = value.EffectPlayFrame;
        AudioPlayFrame = value.AudioPlayFrame;
        IsShake = value.IsShake;
        ShakePlayFrame = value.ShakePlayFrame;
        HitFrame = value.HitFrame;
        HitEffects = value.HitEffects;
        HitEffectsFrames = value.HitEffectsFrames;
        isFrozen = value.isFrozen;
        AttackNumber = value.AttackNumber;
        CritNeedPerformance = value.CritNeedPerformance;
        CritActionName = value.CritActionName;
        CritEffectName = value.CritEffectName;
        CritEffectFollowTarget = value.CritEffectFollowTarget;
        CritAudioName = value.CritAudioName;
        CritEffectPlayFrame = value.CritEffectPlayFrame;
        CritAudioPlayFrame = value.CritAudioPlayFrame;
        CritIsShake = value.CritIsShake;
        CritShakePlayFrame = value.CritShakePlayFrame;
        CritHitFrame = value.CritHitFrame;
        CritHitEffects = value.CritHitEffects;
        CritHitEffectsFrames = value.CritHitEffectsFrames;
        AttackMove = value.AttackMove;
        AttackFinishMove = value.AttackFinishMove;
        AttackMovePositionType = value.AttackMovePositionType;
        BehitMove = value.BehitMove;
        beHitMovePositionType = value.beHitMovePositionType;
        BehitDelayFrame = value.BehitDelayFrame;
        AttackMoveStartFrame = value.AttackMoveStartFrame;
        AttackMoveEndFrame = value.AttackMoveEndFrame;
    }
}