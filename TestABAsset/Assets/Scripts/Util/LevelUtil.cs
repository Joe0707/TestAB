using GlobalDefine;
using UnityEngine;
using System;
public class LevelUtil
{
    //根据木桩类型获取文字
    public static string GetStumpTypeText(EStumpType type)
    {
        var result = "";
        switch (type)
        {
            case EStumpType.Monster:
                result = "怪物";
                break;
            case EStumpType.NpcActor:
                result = "NPC";
                break;
            case EStumpType.PlayerActor:
                result = "玩家";
                break;
        }
        return result;
    }
    //根据木桩队伍获取文字
    public static string GetTeamText(ETeamType team)
    {
        var result = "";
        switch (team)
        {
            case ETeamType.Player:
                result = "玩家";
                break;
            case ETeamType.Enemy:
                result = "敌人";
                break;
            case ETeamType.Neutral:
                result = "中立";
                break;
            case ETeamType.Friend:
                result = "友方";
                break;
        }
        return result;
    }
    //获得格子类型文字
    public static string GetSlotTypeText(ESlotType type)
    {
        var result = "";
        switch (type)
        {
            case ESlotType.PuTong:
                result = "普通";
                break;
            case ESlotType.ZuDang:
                result = "阻挡";
                break;
        }
        return result;
    }
    //获取方向的文字
    public static string GetDirectionText(EDirection direction)
    {
        var result = "";
        switch (direction)
        {
            case EDirection.Up:
                result = "上";
                break;
            case EDirection.Down:
                result = "下";
                break;
            case EDirection.Left:
                result = "左";
                break;
            case EDirection.Right:
                result = "右";
                break;
        }
        return result;
    }
    //获取物体的预览图
    public static Texture GetAssetPreview(GameObject obj, Camera previewcamera)
    {
        GameObject clone = GameObject.Instantiate(obj);
        Transform cloneTransform = clone.transform;

        cloneTransform.position = new Vector3(-1000, -1000, -1000);

        Transform[] all = clone.GetComponentsInChildren<Transform>();
        foreach (Transform trans in all)
        {
            trans.gameObject.layer = 21;
        }


        Bounds bounds = GetBounds(clone);
        Vector3 Min = bounds.min;
        Vector3 Max = bounds.max;
        previewcamera.transform.position = new Vector3((Max.x + Min.x) / 2f, (Max.y + Min.y) / 2f, Max.z + (Max.z - Min.z));
        Vector3 center = new Vector3(cloneTransform.position.x, (Max.y + Min.y) / 2f, cloneTransform.position.z);
        previewcamera.transform.LookAt(center);

        int angle = (int)(Mathf.Atan2((Max.y - Min.y) / 2, (Max.z - Min.z)) * 180 / 3.1415f * 2);
        previewcamera.fieldOfView = angle;
        RenderTexture texture = new RenderTexture(128, 128, 0, RenderTextureFormat.Default);
        previewcamera.targetTexture = texture;

        var tex = RTImage(previewcamera);

        // Object.DestroyImmediate(canvas_obj);
        // Object.DestroyImmediate(cameraObj);

        return tex;
    }

    static Texture2D RTImage(Camera camera)
    {
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        // Render the camera's view.
        //camera.Render();

        camera.Render();
        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        return image;
    }

    public static Bounds GetBounds(GameObject obj)
    {
        Vector3 Min = new Vector3(99999, 99999, 99999);
        Vector3 Max = new Vector3(-99999, -99999, -99999);
        MeshRenderer[] renders = obj.GetComponentsInChildren<MeshRenderer>();
        if (renders.Length > 0)
        {
            for (int i = 0; i < renders.Length; i++)
            {
                if (renders[i].bounds.min.x < Min.x)
                    Min.x = renders[i].bounds.min.x;
                if (renders[i].bounds.min.y < Min.y)
                    Min.y = renders[i].bounds.min.y;
                if (renders[i].bounds.min.z < Min.z)
                    Min.z = renders[i].bounds.min.z;

                if (renders[i].bounds.max.x > Max.x)
                    Max.x = renders[i].bounds.max.x;
                if (renders[i].bounds.max.y > Max.y)
                    Max.y = renders[i].bounds.max.y;
                if (renders[i].bounds.max.z > Max.z)
                    Max.z = renders[i].bounds.max.z;
            }
        }
        else
        {
            RectTransform[] rectTrans = obj.GetComponentsInChildren<RectTransform>();
            Vector3[] corner = new Vector3[4];
            for (int i = 0; i < rectTrans.Length; i++)
            {
                //获取节点的四个角的世界坐标，分别按顺序为左下左上，右上右下
                rectTrans[i].GetWorldCorners(corner);
                if (corner[0].x < Min.x)
                    Min.x = corner[0].x;
                if (corner[0].y < Min.y)
                    Min.y = corner[0].y;
                if (corner[0].z < Min.z)
                    Min.z = corner[0].z;

                if (corner[2].x > Max.x)
                    Max.x = corner[2].x;
                if (corner[2].y > Max.y)
                    Max.y = corner[2].y;
                if (corner[2].z > Max.z)
                    Max.z = corner[2].z;
            }
        }

        Vector3 center = (Min + Max) / 2;
        Vector3 size = new Vector3(Max.x - Min.x, Max.y - Min.y, Max.z - Min.z);
        return new Bounds(center, size);
    }
    /// <summary>
    /// 唯一码生成
    /// </summary>
    /// <returns></returns>
    public static string GenerateID()
    {
        string strDateTimeNumber = DateTime.Now.Ticks.ToString();
        string strRandomResult = NextRandom(1000, 1).ToString();
        return strDateTimeNumber + strRandomResult;
    }

    /// <summary>
    /// 参考：msdn上的RNGCryptoServiceProvider例子
    /// </summary>
    /// <param name="numSeeds"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    private static int NextRandom(int numSeeds, int length)
    {
        // Create a byte array to hold the random value.  
        byte[] randomNumber = new byte[length];
        // Create a new instance of the RNGCryptoServiceProvider.  
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        // Fill the array with a random value.  
        rng.GetBytes(randomNumber);
        // Convert the byte to an uint value to make the modulus operation easier.  
        uint randomResult = 0x0;
        for (int i = 0; i < length; i++)
        {
            randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
        }
        return (int)(randomResult % numSeeds) + 1;
    }

    /// <summary>
    /// 根据索引计算行列号,返回行列索引 0 开始
    /// </summary>
    /// <param name="index"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    public static void ComputeRowColumnByIndex(int index, int ColumnCount, int RowCount, out int row, out int column)
    {
        row = -1;
        column = -1;
        if (index >= 0 && index < ColumnCount * RowCount)
        {
            row = index / ColumnCount;
            column = index - row * ColumnCount;
        }
    }
    /// <summary>
    /// 根据行列号计算格子索引
    /// </summary>
    /// <param name="rowNumber"></param>
    /// <param name="columnNumber"></param>
    /// <param name="columnCount"></param>
    /// <returns></returns>
    public static int ComputeIndexByRowColumn(int rowNumber, int columnNumber, int columnCount, int rowCount)
    {
        var result = -1;
        if (rowNumber >= 0 && rowNumber < rowCount && columnNumber >= 0 && columnNumber < columnCount)
        {
            result = rowNumber * columnCount + columnNumber;
        }
        return result;
    }

}