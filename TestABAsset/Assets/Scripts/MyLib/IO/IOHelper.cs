using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class IOHelper{
	//创建一个写的文件流
	public static BinaryWriter CreateFileStreamWriter(string filePathName, FileMode fm = FileMode.Create)
	{
		try{
            FileStream fs = new FileStream(filePathName, fm);
			var sw = new BinaryWriter(fs);
			return sw;
        }
		catch(Exception e)
		{
			Debug.LogError(e.ToString());
			return null;
		}
	}
	//创建一个读的文件流
	public static BinaryReader CreateFileStreamReader(string filePathName)
	{
        try
        {
            FileStream fs = new FileStream(filePathName, FileMode.Open);
			var sr = new BinaryReader(fs);
			return sr;
        }
		catch(Exception e)
		{
			Debug.LogError(e.ToString());
			return null;
		}	
	}
	//从资源中创建读取流
	public static BinaryReader CreateFileStreamReaderFromResources(string resourceName, string subFolderName)
	{
		try
        {
			var asset = H.GetResource(resourceName, subFolderName) as TextAsset;
			Stream s = new MemoryStream(asset.bytes);
            BinaryReader br = new BinaryReader(s);
            return br;
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
		}	
	}
}

namespace IO
{
    public interface ISerializable
    {
        //写到流
        void WriteToStream(BinaryWriter bw);
        //从流读取
        void ReadFromStream(BinaryReader br);
    }
}