using StaticData.Data;
namespace StaticData
{
    public class StaticDataProxy : Singleton<StaticDataProxy>
    {
        public JobsData GetJobDataById(uint JobId)
        {
            JobsData result = null;
            StaticDataMgr.Instance.mJobsDataMap.TryGetValue(JobId, out result);
            return result;
        }

        public ActorData GetActorDataById(uint actorId)
        {
            ActorData result = null;
            StaticDataMgr.Instance.mActorDataMap.TryGetValue(actorId, out result);
            return result;
        }

        public MonstersData GetMonsterDataById(uint monsterId)
        {
            MonstersData result = null;
            StaticDataMgr.Instance.mMonstersDataMap.TryGetValue(monsterId, out result);
            return result;
        }

        public EquipmentsData GetEquipDataById(uint equipId)
        {
            EquipmentsData result = null;
            StaticDataMgr.Instance.mEquipmentsDataMap.TryGetValue(equipId, out result);
            return result;
        }

        public BuffsData GetBuffsDataById(uint buffId)
        {
            BuffsData buff = null;
            StaticDataMgr.Instance.mBuffsDataMap.TryGetValue(buffId, out buff);
            return buff;
        }

        public TopographyBuffData GetTopographyBuffById(uint buffId)
        {
            TopographyBuffData buff = null;
            StaticDataMgr.Instance.mTopographyBuffDataMap.TryGetValue(buffId, out buff);
            return buff;
        }

    }
}
