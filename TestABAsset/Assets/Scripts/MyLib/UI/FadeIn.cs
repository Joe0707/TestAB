using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float m_FadeInDelay = 0f;
	public float m_FadeInTime = 1f;
	public float m_DestColorA = 1f; //目标透明度
	void Start () {
		
	}
	void OnEnable()
	{
		StartCoroutine(_FadeInProcess());
	}
	IEnumerator _FadeInProcess()
	{
        int type = 0;
		Color color = Color.white;
		var image = GetComponent<Image>();
		Text text = null;
		SpriteRenderer spriteRenderer = null;
		TextMesh textMesh = null;
		if(image != null)
		{
			type = 1;
			color = image.color;
			color.a = 0;
			image.color = color;
		}
		else if(GetComponent<Text>())
		{
			text = GetComponent<Text>();
			type = 2;
			color = text.color;
			color.a = 0;
			text.color = color;
		}
		else if(GetComponent<SpriteRenderer>())
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			type = 3;
			color = spriteRenderer.color;
			color.a = 0;
			spriteRenderer.color = color;
		}
		else if(GetComponent<TextMesh>())
		{
			textMesh = GetComponent<TextMesh>();
			type = 4;
			color = textMesh.color;
			color.a = 0;
			textMesh.color = color;
		}
		if(type == 0)
		{
			Debug.LogError("FadeIn: Didn't find supported component.");
			yield break;
		}
		//延时
		yield return new WaitForSeconds(m_FadeInDelay);
        // 淡入
        float speed = m_DestColorA / m_FadeInTime;
		while(color.a < m_DestColorA)
		{
			color.a = Mathf.Min(m_DestColorA, color.a + Time.deltaTime * speed);
			switch(type)
			{
				case 1:
					image.color = color;
					break;
				case 2:
					text.color = color;
					break;
				case 3:
					spriteRenderer.color = color;
					break;
				case 4:
					textMesh.color = color;
					break;
			}
			yield return null;
		}
	}
}
