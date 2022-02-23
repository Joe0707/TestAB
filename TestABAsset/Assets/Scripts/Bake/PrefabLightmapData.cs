using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;
public class PrefabLightmapData : MonoBehaviour
{
    [System.Serializable]
    struct RendererInfo
    {
        public Renderer renderer;
        public int lightmapIndex;
        public Vector4 lightmapOffsetScale;
    }
    //地形渲染信息
    [System.Serializable]
    struct TerrainRendererInfo
    {
        public Terrain terrainRenderer;
        public int lightmapIndex;
        public Vector4 lightmapOffsetScale;
    }

    [SerializeField]
    RendererInfo[] m_RendererInfo;//烘焙物体渲染器信息
    [SerializeField]
    TerrainRendererInfo[] m_TerrainRendererInfo;//烘焙地形渲染器信息
    // [SerializeField]
    // Texture2D[] m_Lightmaps;
    // [SerializeField]
    // public UnityEngine.Rendering.SphericalHarmonicsL2[] m_LightProbesbakedProbes;
    public GameObject root;//根物体
    // void Awake()
    // {
    //     // if ((m_RendererInfo == null || m_RendererInfo.Length == 0) && (m_TerrainRendererInfo == null || m_TerrainRendererInfo.Length == 0))
    //     //     return;

    //     // var combinedLightmaps = new LightmapData[lightmaps.Length + m_Lightmaps.Length];

    //     // lightmaps.CopyTo(combinedLightmaps, 0);
    //     // for (int i = 0; i < m_Lightmaps.Length; i++) {
    //     // 	combinedLightmaps[i + lightmaps.Length] = new LightmapData();
    //     // 	combinedLightmaps[i + lightmaps.Length].lightmapColor = m_Lightmaps[i];
    //     // }

    //     // ApplyRendererInfo(m_RendererInfo, lightmaps.Length);
    //     // ApplyTerrainRendererInfo(m_TerrainRendererInfo);
    //     // var probe = Resources.Load<LightProbes>("lightProbe");
    //     // LightmapSettings.lightProbes = probe;
    //     // LightmapSettings.lightProbes.bakedProbes = this.m_LightProbesbakedProbes;
    //     // LightProbes.Tetrahedralize();
    //     // p.bakedProbes = m_LightProbesbakedProbes;
    //     // LightmapSettings.lightProbes = p;
    //     // // LightmapSettings.lightProbes.bakedProbes = m_LightProbesbakedProbes;
    //     // var probes = LightmapSettings.lightProbes;
    //     // LightProbes.Tetrahedralize();

    //     // var probe = LightmapSettings.lightProbes;
    //     // probe.bakedProbes = this.m_LightProbesbakedProbes;

    // }
    //应用光照数据
    public void ApplyLightData()
    {
        var lightmaps = LightmapSettings.lightmaps;
        ApplyRendererInfo(m_RendererInfo, lightmaps.Length);
        ApplyTerrainRendererInfo(m_TerrainRendererInfo);
    }

    IEnumerator StartLoad()
    {
        yield return null;
        ApplyLightData();
        var probe = Resources.Load<LightProbes>("lightProbe");
        LightmapSettings.lightProbes = probe;

    }

    static void ApplyTerrainRendererInfo(TerrainRendererInfo[] infos)
    {
        for (int i = 0; i < infos.Length; i++)
        {
            var info = infos[i];
            info.terrainRenderer.lightmapIndex = info.lightmapIndex;
            info.terrainRenderer.lightmapScaleOffset = info.lightmapOffsetScale;
        }
    }
    static void ApplyRendererInfo(RendererInfo[] infos, int lightmapOffsetIndex)
    {
        for (int i = 0; i < infos.Length; i++)
        {
            var info = infos[i];
            info.renderer.lightmapIndex = info.lightmapIndex;
            info.renderer.lightmapScaleOffset = info.lightmapOffsetScale;
        }
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Assets/Bake Prefab Lightmaps")]
    static void GenerateLightmapInfo()
    {
        if (UnityEditor.Lightmapping.giWorkflowMode != UnityEditor.Lightmapping.GIWorkflowMode.OnDemand)
        {
            Debug.LogError("ExtractLightmapData requires that you have baked you lightmaps and Auto mode is disabled.");
            return;
        }
        UnityEditor.Lightmapping.Bake();
        var sceneName = SceneManager.GetActiveScene().name;
        var path = string.Format("Assets/Scenes/{0}/lightProbe.asset", sceneName);
        UnityEditor.AssetDatabase.CreateAsset(Instantiate(LightmapSettings.lightProbes), path);
        //生成烘焙配置信息
        var config = new LevelBakeInfo();
        config.LightMapCount = LightmapSettings.lightmaps.Length;
        //写入相应位置
        var filename = string.Format("Assets/Scenes/{0}/light.json", sceneName);
        FileStream fs = new FileStream(filename, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        string json = JsonConvert.SerializeObject(config);
        // string json = JsonConvert.SerializeObject(levelModel);
        sw.Write(json);
        sw.Close();
        PrefabLightmapData[] prefabs = FindObjectsOfType<PrefabLightmapData>();

        //记录渲染器信息
        foreach (var instance in prefabs)
        {
            var gameObject = instance.gameObject;
            var rendererInfos = new List<RendererInfo>();
            // var lightmaps = new List<Texture2D>();
            var terrainInfos = new List<TerrainRendererInfo>();
            var root = instance.root == null ? instance.gameObject : instance.root;
            GenerateLightmapInfo(root, rendererInfos, terrainInfos);

            instance.m_RendererInfo = rendererInfos.ToArray();
            instance.m_TerrainRendererInfo = terrainInfos.ToArray();
            // instance.m_LightProbesbakedProbes = probes.bakedProbes;
            UnityEditor.EditorUtility.SetDirty(instance);
            // instance.m_LightProbes = probes;
            // instance.m_Lightmaps = lightmaps.ToArray();

            // var targetPrefab = UnityEditor.PrefabUtility.GetPrefabParent(gameObject) as GameObject;
            // if (targetPrefab != null) {
            // 	//UnityEditor.Prefab
            // 	UnityEditor.PrefabUtility.ReplacePrefab(gameObject, targetPrefab);
            // }
        }
    }

    static void GenerateLightmapInfo(GameObject root, List<RendererInfo> rendererInfos, List<TerrainRendererInfo> terrainInfos)
    {
        var renderers = root.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in renderers)
        {
            if (renderer.lightmapIndex != -1)
            {
                RendererInfo info = new RendererInfo();
                info.renderer = renderer;
                info.lightmapOffsetScale = renderer.lightmapScaleOffset;
                info.lightmapIndex = renderer.lightmapIndex;
                // Texture2D lightmap = LightmapSettings.lightmaps[renderer.lightmapIndex].lightmapColor;
                // info.lightmapIndex = lightmaps.IndexOf(lightmap);
                // if (info.lightmapIndex == -1) {
                // 	info.lightmapIndex = lightmaps.Count;
                // 	lightmaps.Add(lightmap);
                // }

                rendererInfos.Add(info);
            }
        }
        var terrains = root.GetComponentsInChildren<Terrain>();
        foreach (Terrain terrain in terrains)
        {
            if (terrain.lightmapIndex != -1)
            {
                TerrainRendererInfo terrainInfo = new TerrainRendererInfo();
                terrainInfo.terrainRenderer = terrain;
                terrainInfo.lightmapIndex = terrain.lightmapIndex;
                terrainInfo.lightmapOffsetScale = terrain.lightmapScaleOffset;
                terrainInfos.Add(terrainInfo);
            }
        }
    }
#endif

}