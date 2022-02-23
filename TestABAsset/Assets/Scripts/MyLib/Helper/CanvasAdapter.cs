using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAdapter : MonoBehaviour {

	void Start () {
        var canvasScaler = GetComponent<CanvasScaler>();
        if (canvasScaler != null)
        {//ipad尺寸

            if (IsWiderThanStandard())
                canvasScaler.matchWidthOrHeight = 1; //height
            else
                canvasScaler.matchWidthOrHeight = 0; //height
        }
    }

    //是否比2:3宽
    public static bool IsWiderThanStandard()
    {
        if ((Screen.width / (float)Screen.height) > 2 / 3.0f)
            return true;
        else
            return false;
    }
}
