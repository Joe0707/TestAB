using UnityEngine;
using System.Collections;
//自动控制其他对象的激活状态与自身同步
public class ControlObjectActive : MonoBehaviour {

	// Use this for initialization
	public GameObject[] objects;
	void OnEnable () {
		for(int i = 0; i < objects.Length; i++)
		{
			objects[i].SetActive(true);
		}
	}
	
	void OnDisable ()
	{
        for (int i = 0; i < objects.Length; i++)
		{
			objects[i].SetActive(false);
		}
	}
}
