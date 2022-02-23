using UnityEngine;
using System.Collections.Generic;
using System.IO;
//部件资源管理器
public class PartResourceMgr : Singleton<PartResourceMgr>
{
    public string PartResSystemPath = "./Assets/Descent/Resources/Parts";//部件资源的系统路径
    //根据部件资源名异步查找部件图片
    public void AsyncGetPartSpriteByPartResName(string resName, OnAsyncObjFinish dealFinish)
    {
        var names = resName.Split('_');
        var path = "";
        if (names.Length == 4)
        {
            //单一部件
            var descent = names[1];
            var sex = names[3];
            var part = names[0];
            path = string.Format("Parts/{0}/{1}/{2}/{3}", sex, descent, part, resName);
        }
        else if (names.Length == 3)
        {
            //不分血脉的部件
            var sex = names[2];
            var part = names[0];
            path = string.Format("Parts/{0}/{1}/{2}", sex, part, resName);
        }
        else if (names.Length == 5)
        {
            //组合部件里的子部件
            var descent = names[1];
            var sex = names[4];
            var part = names[0];
            var number = names[2];
            var subname = names[3];
            var wholename = string.Format("{0}_{1}_{2}_{3}", part, descent, number, sex);
            path = string.Format("Parts/{0}/{1}/{2}/{3}/{4}", sex, descent, part, wholename, resName);
        }
        ResourcesManager.Instance.AsyncLoadResource(resName, typeof(Sprite), dealFinish);
    }

    //根据部件资源名查找部件图片
    public Sprite GetPartSpriteByPartResName(string resName)
    {
        var names = resName.Split('_');
        var path = "";
        if (names.Length == 4)
        {
            //单一部件
            var descent = names[1];
            var sex = names[3];
            var part = names[0];
            path = string.Format("Parts/{0}/{1}/{2}/{3}", sex, descent, part, resName);
        }
        else if (names.Length == 3)
        {
            //不分血脉的部件
            var sex = names[2];
            var part = names[0];
            path = string.Format("Parts/{0}/{1}/{2}", sex, part, resName);
        }
        else if (names.Length == 5)
        {
            //组合部件里的子部件
            var descent = names[1];
            var sex = names[4];
            var part = names[0];
            var number = names[2];
            var subname = names[3];
            var wholename = string.Format("{0}_{1}_{2}_{3}", part, descent, number, sex);
            path = string.Format("Parts/{0}/{1}/{2}/{3}/{4}", sex, descent, part, wholename, resName);
        }
        return ResourceMgr.Instance.Load<Sprite>(path);
    }

    //根据部件资源名查找部件图片集
    public Sprite[] GetPartSpritesByPartResName(string resName)
    {
        var names = resName.Split('_');
        var descent = names[1];
        var sex = names[3];
        var part = names[0];
        var path = string.Format("Parts/{0}/{1}/{2}/{3}", sex, descent, part, resName);
        return ResourceMgr.Instance.LoadAll<Sprite>(path);
    }
    //根据参数获得图片数量
    public int GetSpriteCountByParams(SexType sex, DescentType descentType, EPartType partType)
    {
        var result = 0;
        var path = string.Format("{0}/{1}/{2}/{3}", PartResSystemPath, sex.ToString(), descentType.ToString(), partType.ToString());
        DirectoryInfo root = new DirectoryInfo(path);
        FileInfo[] files = root.GetFiles();
        for (var i = 0; i < files.Length; i++)
        {
            var file = files[i];
            var fullName = file.FullName;
            var fileName = fullName.Substring(fullName.LastIndexOf('.') + 1).ToUpper();
            if (fileName == "PNG")
            {
                result++;
            }
        }
        return result;
    }

    //根据参数获取部件图片
    public List<Sprite> GetPartSpritesByParam(SexType sex, DescentType descentType, EPartType partType)
    {
        var result = new List<Sprite>();
        var path = string.Format("Parts/{0}/{1}/{2}", sex.ToString(), descentType.ToString(), partType.ToString());
        //防止子文件夹内的图片被加载
        var resources = ResourceMgr.Instance.LoadAll<Sprite>(path);
        for (var i = 0; i < resources.Length; i++)
        {
            var res = resources[i];
            var resNames = res.name.Split('_');
            if (resNames.Length <= 4)
            {
                result.Add(res);
            }
        }
        return result;
    }
    //根据子部件物体类型和整体资源名获取资源
    public Sprite GetPartSpriteByPartObjTypeAndWholeResName(EPartObjType subObjType, string wholeResName)
    {
        var names = wholeResName.Split('_');
        var descent = names[1];
        var sex = names[3];
        var part = names[0];
        var number = names[2];
        var subObjNames = subObjType.ToString().Split('_');
        if (subObjNames.Length == 1)
        {
            DebugUtil.DebugError("正在从非组合部件获取组合子部件资源");
            return null;
        }
        var subName = subObjNames[1];
        var subResName = string.Format("{0}_{1}_{2}_{3}_{4}", part, descent, number, subName, sex);
        return GetPartSpriteByPartResName(subResName);
    }

    //异步根据子部件物体类型和整体资源名获取资源
    public void AsyncGetPartSpriteByPartObjTypeAndWholeResName(EPartObjType subObjType, string wholeResName, OnAsyncObjFinish dealFinish)
    {
        var names = wholeResName.Split('_');
        var descent = names[1];
        var sex = names[3];
        var part = names[0];
        var number = names[2];
        var subObjNames = subObjType.ToString().Split('_');
        if (subObjNames.Length == 1)
        {
            DebugUtil.DebugError("正在从非组合部件获取组合子部件资源");
            return;
        }
        var subName = subObjNames[1];
        var subResName = string.Format("{0}_{1}_{2}_{3}_{4}", part, descent, number, subName, sex);
        AsyncGetPartSpriteByPartResName(subResName, dealFinish);
    }


}