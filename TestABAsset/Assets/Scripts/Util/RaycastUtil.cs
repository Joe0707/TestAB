using UnityEngine;
/// <summary>
/// 射线工具
/// </summary>
public class RaycastUtil
{
    /// <summary>
    /// 射线工具
    /// </summary>
    /// <param name="ray">射线</param>
    /// <param name="hit">碰撞</param>
    /// <returns></returns>
    public static bool Raycast(Ray ray, out RaycastHit hit)
    {
        var success = Physics.Raycast(ray, out hit);
        return success;
    }

    public static bool Raycast(Ray ray, int layMask, out RaycastHit hit)
    {
        // LayerMask.NameToLayer("Default")
        var success = Physics.Raycast(ray, out hit, 1000, layMask);
        // hit.transform.gameObject.lay
        return success;
    }

    public static bool RaycastAll(Ray ray, int onlyLayer, out RaycastHit hit)
    {
        var result = false;
        hit = new RaycastHit();
        var hits = Physics.RaycastAll(ray);
        for (var i = 0; i < hits.Length; i++)
        {
            var hititem = hits[i];
            if (hititem.transform.gameObject.layer == onlyLayer)
            {
                result = true;
                hit = hititem;
                break;
            }
        }
        return result;
    }

    public static bool RaycastAllList(Ray ray, int onlyLayer, out RaycastHit[] hit)
    {
        var result = false;
        var hits = Physics.RaycastAll(ray);
        hit = new RaycastHit[hits.Length];
        for (var i = 0; i < hits.Length; i++)
        {
            var hititem = hits[i];
            if (hititem.transform.gameObject.layer == onlyLayer || hititem.transform.gameObject.tag == "Actor")
            {
                result = true;
                hit[i] = hititem;
            }
        }
        return result;
    }
    //获取碰撞地面信息
    public static bool GetHitInfo(Ray ray, int layerMask, out RaycastHit info)
    {
        return Physics.Raycast(ray, out info, 1000, layerMask);
    }

}