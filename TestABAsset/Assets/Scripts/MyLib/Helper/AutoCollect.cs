using UnityEngine;
using System.Collections;

public class AutoCollect : MonoBehaviour {

	float interval = 1.0f;
	void Start () 
	{
		StartCoroutine(Collect());
	}
	
	public IEnumerator Collect()
	{
		while(true)
		{
			yield return new WaitForSeconds(interval);
			System.GC.Collect();
		}
	}
}
