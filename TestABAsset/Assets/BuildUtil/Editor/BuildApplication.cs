using UnityEngine;
public class BuildApplication
{
    // public static string mActorsResourcePath = "/Resources/Actor/";
    // public static string mEquipmentsResourcePath = "/Resources/Equipment/";
    // public static string mActorsABPath = "/ABPackage/ABTest/Actor/";
    // public static string mEquipmentsABPath = "/ABPackage/ABTest/Equipment/";
    //打包用的ab文件夹路径
    public static string[] mABPaths = { /*"/ABPackage/ABTest/UI/",*//* "/ABPackage/ABTest/Atlas/",  "/ABPackage/ABTest/Xml/", "/ABPackage/ABTest/Data/",*/  "/ABPackage/ABTest/Actor/", "/ABPackage/ABTest/Equipment/" };
    //需要打包的Resources文件夹路径
    public static string[] mResourcePaths = { /*"/Resources/UI/",*/ /*"/Resources/Atlas/",  "/LRS-BN-Common/Resources/Xml/", "/Resources/Data/",*/ "/Resources/Actor/", "/Resources/Equipment/" };
    public static string mOutputABPath = "";

    public static void Init()
    {
        var dataPath = Application.dataPath;
        for (var i = 0; i < mABPaths.Length; i++)
        {
            mABPaths[i] = dataPath + mABPaths[i];
        }
        for (var i = 0; i < mResourcePaths.Length; i++)
        {
            mResourcePaths[i] = dataPath + mResourcePaths[i];
        }
        var rootPath = Application.dataPath;
        rootPath = rootPath.Replace("\\", "/");
        mOutputABPath = rootPath.Substring(0, rootPath.LastIndexOf('/', rootPath.LastIndexOf("/") - 1)) + "/AssetBundles/";
    }
}