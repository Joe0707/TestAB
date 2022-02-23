using System.Collections.Generic;
using StaticData;
//职业模型
public class JobModel : Singleton<JobModel>
{
    public Dictionary<uint, List<uint>> jobGroupDict = new Dictionary<uint, List<uint>>();
    public override void Init()
    {
        var jobMap = StaticDataMgr.Instance.mJobsDataMap;
        foreach (var pair in jobMap)
        {
            var jobGroupIdContent = pair.Value.JobType;
            var jobGroupIds = jobGroupIdContent.Split(',');
            for (var j = 0; j < jobGroupIds.Length; j++)
            {
                var jobGroupId = uint.Parse(jobGroupIds[j]);
                if (!jobGroupDict.ContainsKey(jobGroupId))
                {
                    var jobs = new List<uint>();
                    jobs.Add(pair.Key);
                    jobGroupDict.Add(jobGroupId, jobs);
                }
                else
                {
                    var jobs = jobGroupDict[jobGroupId];
                    if (!jobs.Contains(pair.Key))
                    {
                        jobs.Add(pair.Key);
                    }
                }
            }
        }
    }
}