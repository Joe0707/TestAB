using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkUIText : MonoBehaviour {
	private Text text = null;
	private float blinkCnt = 0f;
	private float blinkInterval = 1f;
	private float timeElapsed = 0f;
	void Start () 
	{
		text = GetComponent<Text>();
	}
	
	void Update () 
	{
		if(blinkCnt > 0)
		{
			timeElapsed += Time.deltaTime;
			if(timeElapsed >= blinkInterval)
			{
				timeElapsed = 0f;
				text.enabled = !text.enabled;
				if(text.enabled == true)
				{
					blinkCnt --;
				}
			}
		}
	}
	
	public void Blink(float vblinkCnt, float vblinkInterval)
	{
		if(text == null)
			text = GetComponent<Text>();
		if(text == null)
			return;
		blinkCnt = vblinkCnt;
		blinkInterval = vblinkInterval;
		timeElapsed = vblinkInterval;
	}
}
