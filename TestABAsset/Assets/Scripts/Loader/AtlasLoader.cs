using UnityEngine.U2D;
using UnityEngine;
using UnityEngine.Events;
//图集加载器
public class AtlasLoader : Singleton<AtlasLoader>
{
    public UnityAction RequestFinish;
    public override void Init()
    {
        SpriteAtlasManager.atlasRequested += OnAtlasRequested;
    }


    void OnAtlasRequested(string str, System.Action<SpriteAtlas> act)
    {
        var atlas = ResourcesManager.Instance.LoadResource<SpriteAtlas>("Atlas/" + str, false);
        act(atlas);
        // var url = "http://127.0.0.1";
        // VersionContorller.Start(UpdateMode.Repair, url, Application.persistentDataPath, (i, j) =>
        // {
        //     //下载完毕
        //     if (i == j)
        //     {
        //         //BResources.Load(AssetLoadPath.Editor);
        //         IAssetBundleLoader loader = new AssetBundleManager();
        //         ResourcesManager.Instance.m_LoadFormAssetBundle = true;
        //         ResourcesManager.Instance.InitAssetBundleLoader(loader);
        //         ResourcesManager.Instance.InitAssetBundle();
        //         var atlas = ResourcesManager.Instance.LoadResource<SpriteAtlas>("Image/Formation/New Sprite Atlas");
        //         act(atlas);
        //         RequestFinish();
        //         // if (ResourcesManager.Instance.LoadResource<Object>("testabscene") == null)
        //         // {
        //         //     SceneManager.LoadScene("testabscene");
        //         // }
        //         // var dajian = ResourcesManager.Instance.LoadResource<GameObject>("Scene/chengwai");
        //         // var dajianin = Instantiate(dajian);
        //         // var cube = ObjectManager.Instance.InstantiateObject("Scene/chengwai");

        //         // StartCoroutine(StartClean(new GameObject[] { dajianin }));
        //         //ObjectManager.Instance.Init();
        //         //1.同步加载
        //         //var go2 = BResources.Load<GameObject>("abtest/actor/m_dajianshi");
        //         //var load5 = GameObject.Instantiate(go2);
        //         //ObjectManager.Instance.InstantiateObject("abtest/actor/m_dajianshi");
        //         // var res = ResourcesManager.Instance.LoadResource<GameObject>("Canvas");
        //         // GameObject.Instantiate(res);
        //         // ResourcesManager.Instance.LoadResource<Sprite>("Image/Formation/dajianshi");
        //         // var aSprite = Sprite.Create(go, new Rect(0, 0, go.width, go.height), new Vector2(0.5f, 0.5f), 100f);
        //         // m_UI.sprite = go;
        //         // var load1 = GameObject.Instantiate(go);
        //         //var go2 = ResourcesManager.Instance.LoadResource<GameObject>("actor/cube");
        //         //var load2 = GameObject.Instantiate(go2);
        //         //go = ResourcesManager.Instance.LoadResource<GameObject>("Test/Cube");
        //         //var load2 = GameObject.Instantiate(go);
        //         //go = ResourcesManager.Instance.LoadResource<GameObject>("AssetTest/Particle");
        //         //var load3 = GameObject.Instantiate(go);
        //         //go = ResourcesManager.Instance.LoadResource<GameObject>("Char/001");
        //         //var go1 = ResourcesManager.Instance.LoadResource<GameObject>("Char/001");
        //         //var loadModel = GameObject.Instantiate(go);
        //     }
        // }, (e) => { });
    }
}