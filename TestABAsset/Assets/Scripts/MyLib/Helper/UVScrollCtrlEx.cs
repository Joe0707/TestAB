using UnityEngine;
using System.Collections;

public class UVScrollCtrlEx : MonoBehaviour {

	public float speedX;
	public float speedY;
	private SpriteRenderer spriteRenderer;
	private MeshRenderer meshRenderer;
	private Vector2 scrollVector = Vector2.zero;
	public bool stopped  = false;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (spriteRenderer == null) {
			meshRenderer = GetComponent<MeshRenderer> ();
		}
	}
	
	void Update () {
		if(stopped == true)
			return;
		scrollVector.x += speedX * Time.deltaTime;
		scrollVector.y += speedY * Time.deltaTime;
		while(scrollVector.x > 1.0)
			scrollVector.x -= 1.0f;
		while(scrollVector.x < - 1.0)
			scrollVector.x += 1.0f;
		while(scrollVector.y > 1.0)
			scrollVector.y -= 1.0f;
		while(scrollVector.y < - 1.0)
			scrollVector.y += 1.0f;
		UpdateUV();
	}
	
	public void Stop(bool resetPos)
	{
		stopped = true;
		if(resetPos == true)
		{
			scrollVector.x = 0f;
			scrollVector.y = 0f;
		}
		UpdateUV();
	}
	
	public void Stop()
	{
		Stop(true);
	}
	
	void UpdateUV()
	{
		if (spriteRenderer != null) {
			spriteRenderer.material.SetFloat ("_ScrollX", scrollVector.x);
			spriteRenderer.material.SetFloat ("_ScrollY", scrollVector.y);
		}
		if (meshRenderer != null) {
			meshRenderer.material.mainTextureOffset = scrollVector;
		}
	}

}
