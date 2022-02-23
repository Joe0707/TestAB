using System;
using UnityEngine;
public class SerialNumber{
	//生成6位序列号
	public static string Generate()
	{
		//生成一个随机的三位数是3的倍数
		//再生成一个三位数的7的倍数
		//将两个数的每一位拆开交叉起来组成一个6位数的序列号
		int firstNumber = UnityEngine.Random.Range(4, 334) * 3; //1000内的能被3整除的数字
		int secondNumber = UnityEngine.Random.Range(2, 143) * 7; //1000内能被7整除的数字
		string strFirstNumber = firstNumber.ToString("000");
		string strSecondNumber = secondNumber.ToString("000");
		string strResult = "";
		strResult += strFirstNumber[0];
		strResult += strSecondNumber[0];
		strResult += strFirstNumber[1];
		strResult += strSecondNumber[1];
		strResult += strFirstNumber[2];
		strResult += strSecondNumber[2];
		return strResult;
	}
	//校验序列号
	public static bool Check(string sn)
	{
		bool retValue = false;
		if(sn.Length == 6)
        {
            string strFirstNumber = "" + sn[0] + sn[2] + sn[4];
            string strSecondNumber = "" + sn[1] + sn[3] + sn[5];
            int firstNumber = System.Int32.Parse(strFirstNumber);
            int secondNumber = System.Int32.Parse(strSecondNumber);
            if (firstNumber % 3 == 0 && secondNumber % 7 == 0)
            {
                retValue = true;
            }
        }
		Debug.Log("SerialNumber.Check:" + sn + " " + retValue.ToString());
        return retValue;
    }
}