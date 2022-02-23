using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;  


//屏幕截图
public class ScreenCapture : MonoBehaviour {
	static ScreenCapture mInstance = null;
	string mFilePath = "";
	void OnEnable () {
		mInstance = this;
	#if UNITY_EDITOR
		mFilePath = Application.dataPath + "/../../../Screenshots/";
	#else
		mFilePath = Application.persistentDataPath + "/Screenshots/";
	#endif
	}
	void OnDisable()
	{
		mInstance = null;
	}

    //截屏保存 filename是文件名，不包含路径
    public static string Take(string fileName)
    {
		if(mInstance == null)
			return "";
		mInstance.StartCoroutine(mInstance._Capture(fileName));
		return mInstance.mFilePath + fileName;
    }

	IEnumerator _Capture(string fileName)
	{
		yield return new WaitForEndOfFrame();
        //需要正确设置好图片保存格式 
        Texture2D t = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        //按照设定区域读取像素；注意是以左下角为原点读取 
        t.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        t.Apply();
        try
        {//保存截屏
            //二进制转换 
            byte[] byt = t.EncodeToPNG();
            string filePathName = mFilePath + fileName;
            //创建目录
            if (System.IO.Directory.Exists(mFilePath) == false)
                System.IO.Directory.CreateDirectory(mFilePath);
            //检查文件名扩展名
            if (filePathName.EndsWith(".png") == false)
                filePathName += ".png";
            if (System.IO.File.Exists(filePathName))
                System.IO.File.Delete(filePathName);
            //写入文件
            System.IO.File.WriteAllBytes(filePathName, byt);
            Debug.Log("Screenshot Saved:" + filePathName);

#if UNITY_IOS && !UNITY_EDITOR
            //保存到相册
            PLSaveToPhotoAlbum(filePathName);
#endif
        }
        catch (System.Exception e)
        {
            Debug.LogError("Saving screenshot failed:" + e.ToString());
        }
    }


    //安卓系统调用 , 需要WRITE EXTRA STORAGE的权限
#if UNITY_ANDROID && !UNITY_EDITOR
    private const string MediaStoreImagesMediaClass = "android.provider.MediaStore$Images$Media";

    public static string SaveImageToGallery(Texture2D texture2D, string title, string description)
    {
        using (var mediaClass = new AndroidJavaClass(MediaStoreImagesMediaClass))
        {
            using (var cr = Activity.Call<AndroidJavaObject>("getContentResolver"))
            {
                var image = Texture2DToAndroidBitmap(texture2D);
                var imageUrl = mediaClass.CallStatic<string>("insertImage", cr, image, title, description);
                return imageUrl;
            }
        }
    }
    static AndroidJavaObject _activity;
    static AndroidJavaObject Activity
    {
        get
        {
            if (_activity == null)
            {
                var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                _activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return _activity;
        }
    }

    static AndroidJavaObject Texture2DToAndroidBitmap(Texture2D texture2D)
    {
        byte[] encoded = texture2D.EncodeToPNG();
        using (var bf = new AndroidJavaClass("android.graphics.BitmapFactory"))
        {
            return bf.CallStatic<AndroidJavaObject>("decodeByteArray", encoded, 0, encoded.Length);
        }
    }
#endif

    //iOS
#if UNITY_IOS// && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void _SavePhoto(string readAddr); 
    
    static void PLSaveToPhotoAlbum(string filePathName)
    {
        _SavePhoto(filePathName);
    }
    
#endif
}
