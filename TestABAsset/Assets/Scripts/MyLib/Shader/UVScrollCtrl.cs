using UnityEngine;
using System.Collections;

public class UVScrollCtrl : MonoBehaviour {

	public float speedX;
	public float speedY;
	private SpriteRenderer spriteRenderer;
	private float scrollPosX  = 0;//当前滚动到的位置 
	private float scrollPosY = 0;
	public bool stopped  = false;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(stopped == true)
			return;
		scrollPosX += speedX * Time.deltaTime;
		scrollPosY += speedY * Time.deltaTime;
		while(scrollPosX > 1.0)
			scrollPosX -= 1.0f;
		while(scrollPosX < - 1.0)
			scrollPosX += 1.0f;
		while(scrollPosY > 1.0)
			scrollPosY -= 1.0f;
		while(scrollPosY < - 1.0)
			scrollPosY += 1.0f;
		UpdateUV();
	}
	
	public void Stop(bool resetPos)
	{
		stopped = true;
		if(resetPos == true)
		{
			scrollPosX = 0f;
			scrollPosY = 0f;
		}
		UpdateUV();
	}
	
	public void Stop()
	{
		Stop(true);
	}
	
	void UpdateUV()
	{
		spriteRenderer.material.SetFloat("_ScrollX", scrollPosX);
		spriteRenderer.material.SetFloat("_ScrollY", scrollPosY);
	}

}
