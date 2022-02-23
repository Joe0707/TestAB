using UnityEngine;
using System.Collections;

//细碎、生命周期不稳定的对象，如特效等。启动后会自动向DynamicObjMgr注册，销毁时会向DynamicObjMgr注销。
public class DynamicObj : MonoBehaviour {
    public string keyName = "";
	void Start ()
    {
        DynamicObjMgr.AddDynamicObj(keyName, gameObject);	
	}
	
    void OnDestroy()
    {
        DynamicObjMgr.RemoveDynamicObj(keyName, gameObject);
    }
}
