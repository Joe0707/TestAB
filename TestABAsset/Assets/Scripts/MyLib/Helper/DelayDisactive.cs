using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自动失活
public class DelayDisactive : MonoBehaviour {
	public float m_DelayTime = 1f;
	void OnEnable () {
		Invoke("DisableObj", m_DelayTime);
	}
	
	void DisableObj()
	{
		gameObject.SetActive(false);
	}
}
