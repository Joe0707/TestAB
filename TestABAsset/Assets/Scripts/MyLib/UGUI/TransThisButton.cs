using UnityEngine;
using System.Collections;
//透明区域不响应的按钮

public class TransThisButton : MonoBehaviour {
    void  Start()
    {
        GetComponent<UnityEngine.UI.Image>().alphaHitTestMinimumThreshold = 0.05f;
    }
}