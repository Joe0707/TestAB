using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public float time = 1.0f;
	
	void Start () 
	{
		GameObject.Destroy(gameObject, time);	
	}
}
