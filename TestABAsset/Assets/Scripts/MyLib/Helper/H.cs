using UnityEngine;
using System.Collections;

public class H
{

    #region Resources
    //加载一个Resources下的对象，如果包含多层子目录，使用/斜线,如“Abc/def"
    public static Object GetResource(string resourceName, string subPath = "", bool muteOnFailed = false)
    {
        string name = resourceName;
        if (subPath != "")
            name = subPath + "/" + name;
        // Object obj = Resources.Load(name);
        Object obj = ResourcesManager.Instance.LoadResource<Object>(name);
        if (obj != null)
            return obj;
        else if (muteOnFailed == false)
            Debug.LogError("Didn't find resource at:" + name);
        return null;
    }
    public static Sprite GetResourceSprite(string resourceName, string subPath = "", bool muteOnFailed = false)
    {
        string name = resourceName;
        if (subPath != "")
            name = subPath + "/" + name;
        // Sprite spr = Resources.Load<Sprite>(name);
        Sprite spr = ResourcesManager.Instance.LoadResource<Sprite>(name);
        if (spr != null)
            return spr;
        else if (muteOnFailed == false)
            Debug.LogError("Didn't find Sprite resource at:" + name);
        return null;
    }
    // public static Texture GetResourceSprite(string resourceName, string subPath = "", bool muteOnFailed = false)
    //     {
    //         string name = resourceName;
    //         if (subPath != "")
    //             name = subPath + "/" + name;
    //         Texture spr = Resources.Load<Texture>(name);
    //         if (spr != null)
    //             return spr;
    //         else if(muteOnFailed == false)
    //             Debug.LogError("Didn't find Sprite resource at:" + name);
    //         return null;
    //     }
    #endregion

    #region Text
    public static string GetTimeString(long totalSeconds)
    {
        string retValue = "";
        //更新时间显示
        long hour = (long)(totalSeconds / 3600);
        long minute = (long)((totalSeconds / 60f) - (hour * 60));
        long second = (long)(totalSeconds % 60);
        if (second >= 10)
            retValue = minute.ToString() + ":" + second.ToString();
        else
            retValue = minute.ToString() + ":0" + second.ToString();
        if (hour > 0)
        {
            if (minute >= 10)
                retValue = hour.ToString() + ":" + retValue;
            else
                retValue = hour.ToString() + ":0" + retValue;
        }
        return retValue;
    }
    //返回3h2m3s时间 
    public static string GetHMSTimeString(long totalSeconds)
    {
        string retValue = "";
        //更新时间显示
        long hour = (long)(totalSeconds / 3600);
        long minute = (long)((totalSeconds / 60f) - (hour * 60));
        long second = (long)(totalSeconds % 60);
        retValue = second.ToString() + "s";

        if (hour > 0)
            retValue = hour.ToString() + "h" + minute + "m" + retValue;
        else
        {
            if (minute > 0)
                retValue = minute + "m" + retValue;
        }
        return retValue;
    }

    //将数字计作K\M\G\T
    public static string GetShortNumberString(long number, uint floatCount = 2)
    {
        if (number > 9999 && number <= 999999)
        {//计作K
            return (number / 1000.0).ToString("f" + floatCount) + "K";
        }
        else if (number > 999999 && number <= 999999999)
        {//计作M
            return (number / 1000000.0).ToString("f" + floatCount) + "M";
        }
        else if (number > 999999999 && number <= 999999999999)
        {
            return (number / 1000000000.0).ToString("f" + floatCount) + "G";
        }
        else if (number > 999999999999 && number <= 999999999999999)
        {
            return (number / 1000000000000.0).ToString("f" + floatCount) + "T";
        }
        else if (number > 999999999999999)
        {
            return (number / 1000000000000000.0).ToString("f" + floatCount) + "Z";
        }
        else
            return number.ToString();
    }
    #endregion

    #region PointerAndUI
    //判断是否点到UI上了
    public static bool IsPointerOverUIObject()
    {
        if (GetPointerOverUIObjects() == null || GetPointerOverUIObjects().Count == 0)
        {
            return false;
        }
        return true;
    }
    public static bool IsPointerOverUIObject(Vector3 pointerPos)
    {
        return GetPointerOverUIObjects(pointerPos).Count > 0;
    }

    //点中的UI
    public static System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> GetPointerOverUIObjects(Vector3 pointerPos)
    {
        System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> results = null;
        if (UnityEngine.EventSystems.EventSystem.current == null)
            return results;
        if (Application.isEditor)
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false)
            {
                return results;
            }
        }
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount == 0)
                return results;
        }

        // Referencing this code for GraphicRaycaster https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        results = new System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult>();
        UnityEngine.EventSystems.PointerEventData eventDataCurrentPosition = new UnityEngine.EventSystems.PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        var pointer = pointerPos;
        eventDataCurrentPosition.position = new Vector2(pointer.x, pointer.y);
        UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results;
    }
    public static System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> GetPointerOverUIObjects()
    {
        return GetPointerOverUIObjects(PointerPosition);
    }
    //鼠标(左)/触摸(0)按下
    public static bool IsPointerDown()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                return true;
            else
                return false;
        }
        else
        {
            return Input.GetMouseButtonDown(0);
        }
    }
    //鼠标(左)/触摸(0)抬起
    public static bool IsPointerUp()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                return true;
            else
                return false;
        }
        else
        {
            return Input.GetMouseButtonUp(0);
        }
    }

    //指针是否被持续按下
    public static bool IsPointerHeldDown()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved))
                return true;
            else
                return false;
        }
        else
        {
            return Input.GetMouseButton(0);
        }
    }

    //查询当前是否鼠标和触摸都抬起了
    public static bool GetPointerDownState()
    {
        if (Application.isMobilePlatform)
        {
            if (Input.touchCount == 0)
                return false;
            else
                return true;
        }
        else
        {
            return Input.GetMouseButton(0);
        }
    }
    //指针的位置
    public static Vector3 PointerPosition
    {
        get
        {
            if (Application.isMobilePlatform)
            {
                if (Input.touchCount > 0)
                    return Input.GetTouch(0).position;
                else
                    return Vector3.zero;
            }
            else
            {
                return Input.mousePosition;
            }
        }
    }
    //把UI位置换算成屏幕位置
    public static Vector2 UIPosToScreenPos(GameObject uiObj)
    {
        var canvas = GetCanvas(uiObj);
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            return RectTransformUtility.WorldToScreenPoint(null, uiObj.transform.position);
        else
            return RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, uiObj.transform.position);
    }

    //把屏幕位置换算成UI本地位置
    public static Vector2 UIScreenPosToUILocalPos(GameObject uiParentObj, Vector2 screenPos)
    {
        var canvas = GetCanvas(uiParentObj);
        Vector2 localPos;

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(uiParentObj.GetComponent<RectTransform>(),
                                                            screenPos, null, out localPos);
        }
        else
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(uiParentObj.GetComponent<RectTransform>(),
                                                            screenPos, canvas.worldCamera, out localPos);
        }
        return localPos;
    }

    //得到UI物件的Canvas
    public static Canvas GetCanvas(GameObject uiObj)
    {
        Canvas canvas = null;
        var curObj = uiObj;
        while (canvas == null)
        {
            curObj = curObj.transform.parent.gameObject;
            canvas = curObj.GetComponent<Canvas>();
        }
        return canvas;
    }
    #endregion

    #region Texture
    //拷贝Texture2D到另一个Texture2D上
    //Texture 坐标从左下角开始
    //srcUVRect用的是UV坐标，取值范围0-1，左下角开始
    //destX和destY是目标的X像素坐标
    public static void CopyTexture2D(Texture2D srcTex, Rect srcUVRect, Texture2D destText, int destX, int destY)
    {
        //防止源超界
        if (srcUVRect.width + srcUVRect.x > 1f)
            srcUVRect.width = 1f - srcUVRect.x;
        if (srcUVRect.height + srcUVRect.y > 1f)
            srcUVRect.height = 1f - srcUVRect.y;
        int srcX = Mathf.FloorToInt(srcTex.width * srcUVRect.x); //源X
        int srcY = Mathf.FloorToInt(srcTex.height * srcUVRect.y);//源Y
                                                                 //源的宽度
        int srcWidth = Mathf.FloorToInt(srcTex.width * srcUVRect.width);
        srcWidth = Mathf.Min(srcWidth, destText.width - destX);//防止目标超界
        //源的高度
        int srcHeight = Mathf.FloorToInt(srcTex.height * srcUVRect.height);
        srcHeight = Mathf.Min(srcHeight, destText.height - destY);//防止目标超界

        for (int x = 0; x < srcWidth; x++)
        {
            for (int y = 0; y < srcHeight; y++)
            {
                destText.SetPixel(destX + x, destY + y, srcTex.GetPixel(x + srcX, y + srcY));
            }
        }
        destText.Apply();
    }

    //清除所有像素，用透明色填充	
    public static void ClearPixels(Texture2D texture, Color fillColor)
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                texture.SetPixel(x, y, fillColor);
            }
        }
        texture.Apply();
    }

    //从Texture2D创建一个Sprite
    public static Sprite CreateSprite(Texture2D texture)
    {
        var sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return sprite;
    }

    //保存Texture成PNG
    public static void SaveTextureToPNG(Texture2D saveTexture, string fileName)
    {
        try
        {
            Texture2D newTexture = new Texture2D(saveTexture.width, saveTexture.height, TextureFormat.ARGB32, false);
            newTexture.SetPixels(0, 0, saveTexture.width, saveTexture.height, saveTexture.GetPixels());
            newTexture.Apply();
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName); //删除已经存在的文件
            //写入文件
            byte[] bytes = newTexture.EncodeToPNG();
            System.IO.File.WriteAllBytes(fileName, bytes);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save Texture to PNG : " + e.ToString());
        }
    }
    //复制一个图
    public static Texture2D CloneTexture2D(Texture2D srcTexture, float scale = 1f)
    {
        //复制数据
        Texture2D newTexture = new Texture2D(srcTexture.width, srcTexture.height, srcTexture.format, false);
        newTexture.SetPixels(0, 0, srcTexture.width, srcTexture.height, srcTexture.GetPixels());
        newTexture.Apply();
        //计算新尺寸
        if (scale != 1)
        {
            int newWidth = Mathf.FloorToInt(srcTexture.width * scale);
            int newHeight = Mathf.FloorToInt(srcTexture.height * scale);
            TextureScaler.Scale(newTexture, newWidth, newHeight);
            newTexture.Apply();
        }
        return newTexture;
    }


    #endregion

    #region  Text
    //文本是否包含中文
    public static bool HasChinese(string str)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
    }
    //把富文本中的格式符号去掉
    public static string GetPlainText(string richText)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        bool inAngleBracket = false; //在尖括号中
        foreach (var c in richText)
        {
            if (inAngleBracket == false)
            {//不在尖括号中
                if (c == '<')
                    inAngleBracket = true;
                else
                    sb.Append(c);
            }
            else
            {//在尖括号中
                if (c == '>')
                    inAngleBracket = false;
            }
        }
        return sb.ToString();
    }

    //根据文字长度预估阅读时间
    public static float GetGrossTextReadTime(string text)
    {
        float time = 0f;
        //先去富文本符号
        var plainText = GetPlainText(text);
        //区分中英文
        if (H.HasChinese(plainText))
        {//中文文字
            time = plainText.Length * 0.17f;
        }
        else
        {//英文文字 
            var words = plainText.Split(" ".ToCharArray());
            time = words.Length * 0.23f;
        }
        return time;
    }

    //把普通文字变成带颜色的超文本
    public static string ColoredText(string plainText, string colorStr)
    {
        return "<color=" + colorStr + ">" + plainText + "</color>";
    }
    #endregion
}

