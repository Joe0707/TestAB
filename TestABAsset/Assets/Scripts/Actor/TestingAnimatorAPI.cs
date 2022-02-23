using System.Text;
using UnityEngine;

public class TestingAnimatorAPI : MonoBehaviour
{
    private MeshRenderer[] meshesRenderer;
    private SkinnedMeshRenderer[] skinnedMeshesRenderer;

    private Animator animator;
    public LuaBehavior m_ClothLua;
    public LuaBehavior m_ActorLua;
    public GameObject ActorSnapshotObj;//actor快照物体
    // Start is called before the first frame update
    void Start()
    {
        meshesRenderer = transform.GetComponentsInChildren<MeshRenderer>();
        skinnedMeshesRenderer = transform.GetComponentsInChildren<SkinnedMeshRenderer>();
        // print("角度" + transform.rotation.eulerAngles.y);
        var toWorldPos = Vector3.zero;
        var position = transform.position;
        var dir = new Vector3(toWorldPos.x - position.x, toWorldPos.y - position.y, toWorldPos.z - position.z);
        dir.y = 0;
        dir = new Vector3(1, 0, 0);
        var angle = Vector3.Angle(Vector3.forward, dir);
        var cross = Vector3.Cross(Vector3.forward, dir);
        if (cross.y < 0)
        {
            angle = -angle;
        }
        if (angle < 0)
        {
            angle += 360;
        }
        print("角度" + angle);

        Snapshot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int counter;

    private void Snapshot()
    {
        GameObject pGo = new GameObject($"SkinnedMeshSnapshot_{++counter}");
        pGo.transform.position = gameObject.transform.position;
        pGo.transform.rotation = gameObject.transform.rotation;
        pGo.transform.localScale = gameObject.transform.localScale;

        // meshes
        if (meshesRenderer != null && meshesRenderer.Length > 0)
        {
            for (int i = 0; i < meshesRenderer.Length; i++)
            {
                var ownGo = meshesRenderer[i].gameObject;
                var ownGoMeshFilter = ownGo.GetComponent<MeshFilter>();
                if (ownGoMeshFilter == null)
                {
                    continue;
                }
                GameObject go = new GameObject(meshesRenderer[i].gameObject.name);
                go.transform.SetParent(pGo.transform);

                MeshFilter meshFilter = go.AddComponent<MeshFilter>();

                MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
#if UNITY_EDITOR
                //go.hideFlags = HideFlags.HideAndDontSave; // 调试时，想在hierarchy看到，就注释掉吧
#else
                go.hideFlags = HideFlags.HideAndDontSave;
#endif
                Material[] materials = new Material[meshesRenderer[i].materials.Length];
                for (int j = 0; j < meshesRenderer[i].materials.Length; j++)
                {
                    var newMat = new Material(Shader.Find("Custom/New Toon Shading Shadow"));
                    newMat.CopyPropertiesFromMaterial(meshesRenderer[i].materials[j]);
                    newMat.SetFloat("_AlphaValue", 0.4f);
                    materials[j] = newMat;
                }
                meshRenderer.materials = materials;
                meshFilter.sharedMesh = ownGoMeshFilter.sharedMesh;
                go.transform.position = meshesRenderer[i].transform.position;
                go.transform.rotation = meshesRenderer[i].transform.rotation;
                go.transform.localScale = meshesRenderer[i].transform.localScale;
            }
        }

        // skinnedMeshes
        if (skinnedMeshesRenderer != null && skinnedMeshesRenderer.Length > 0)
        {
            for (int i = 0; i < skinnedMeshesRenderer.Length; i++)
            {
                Mesh mesh = new Mesh();
                skinnedMeshesRenderer[i].BakeMesh(mesh);

                GameObject go = new GameObject(skinnedMeshesRenderer[i].gameObject.name);
                go.transform.SetParent(pGo.transform);

                MeshFilter meshFilter = go.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
#if UNITY_EDITOR
                //go.hideFlags = HideFlags.HideAndDontSave; // 调试时，想在hierarchy看到，就注释掉吧
#else
                go.hideFlags = HideFlags.HideAndDontSave;
#endif
                Material[] materials = new Material[skinnedMeshesRenderer[i].materials.Length];
                for (int j = 0; j < skinnedMeshesRenderer[i].materials.Length; j++)
                {
                    var newMat = new Material(Shader.Find("Custom/New Toon Shading Shadow"));
                    newMat.CopyPropertiesFromMaterial(skinnedMeshesRenderer[i].materials[j]);
                    newMat.SetFloat("_AlphaValue", 0.4f);
                    materials[j] = newMat;
                }
                meshRenderer.materials = materials;
                meshFilter.sharedMesh = mesh;

                go.transform.position = skinnedMeshesRenderer[i].transform.position;
                go.transform.rotation = skinnedMeshesRenderer[i].transform.rotation;
                go.transform.localScale = skinnedMeshesRenderer[i].transform.localScale;
            }
        }
        pGo.SetActive(false);
        // m_ClothLua.Set<GameObject>("ActorSnapshot", pGo);
        // m_ActorLua.Set<GameObject>("ActorSnapshot", pGo);
        ActorSnapshotObj = pGo;
    }
    //获取actor快照物体
    public GameObject GetActorSnapshotObj()
    {
        if (ActorSnapshotObj != null)
            return ActorSnapshotObj;
        else
            return null;

    }
}