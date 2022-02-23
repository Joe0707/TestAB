using GlobalDefine;
using System.Collections.Generic;
//Buff效果
public class BuffEffect
{
    //目标
    public EEffectTarget EffectTarget;
    //条件集
    public List<BuffEffectCondition> Conditions = new List<BuffEffectCondition>();
    //结果集合
    public List<BuffEffectResult> Results = new List<BuffEffectResult>();
    //从效果内容加载
    public static BuffEffect LoadFromEffectContent(string effect)
    {
        var buffEffect = new BuffEffect();
        var effectcontent = effect.Split('*');
        if (effectcontent.Length >= 1)
        {
            buffEffect.EffectTarget = (EEffectTarget)int.Parse(effectcontent[0]);
            var content = effectcontent[1];
            var contents = content.Split('#');
            if (contents.Length >= 1)
            {
                var conditionList = new List<BuffEffectCondition>();
                var conditioncontent = contents[0];
                var conditions = conditioncontent.Split(';');
                for (var i = 0; i < conditions.Length; i++)
                {
                    var condition = conditions[i];
                    var conditionitems = condition.Split('_');
                    var effectCondition = new BuffEffectCondition();
                    var conditionType = (EEffectConditionType)int.Parse(conditionitems[0]);
                    effectCondition.EffectConditionType = conditionType;
                    var paramList = new List<string>();
                    for (var j = 1; j < conditionitems.Length; j++)
                    {
                        paramList.Add(conditionitems[j]);
                    }
                    effectCondition.Params = paramList.ToArray();
                    conditionList.Add(effectCondition);
                    buffEffect.Conditions = conditionList;
                }
            }
            if (contents.Length >= 2)
            {
                var resultList = new List<BuffEffectResult>();
                var resultcontent = contents[1];
                var results = resultcontent.Split(';');
                for (var i = 0; i < results.Length; i++)
                {
                    var result = results[i];
                    var resultitems = result.Split('_');
                    var effectresult = new BuffEffectResult();
                    var resultType = (EEffectResult)int.Parse(resultitems[0]);
                    effectresult.EEffectResultType = resultType;
                    var paramList = new List<string>();
                    for (var j = 1; j < resultitems.Length; j++)
                    {
                        paramList.Add(resultitems[j]);
                    }
                    effectresult.Params = paramList.ToArray();
                    resultList.Add(effectresult);
                    buffEffect.Results = resultList;
                }
            }
        }
        return buffEffect;
    }

}