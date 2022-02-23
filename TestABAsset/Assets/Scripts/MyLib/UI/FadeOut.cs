using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {
	public float m_FadeOutDelay = 0f;
	public float m_FadeOutTime = 0f;
	public System.Action m_FinishAction;
	Coroutine mCoroutine = null;
	void Start () {
		
	}
	public void StartFadeOut(System.Action finishAction = null)
	{
        m_FinishAction = finishAction;
		if(mCoroutine == null)
		{
            mCoroutine = StartCoroutine(_FadeOutProcess());
            //查找子级别
			for(int i = 0; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i).GetComponent<FadeOut>();
				if(child != null && child.gameObject.activeInHierarchy)
					child.StartFadeOut();
			}
        }
	}

	IEnumerator _FadeOutProcess()
	{
		yield return new WaitForSeconds(m_FadeOutDelay);
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
			image.color = color;
		}
		else if(GetComponent<Text>())
		{
			text = GetComponent<Text>();
			type = 2;
			color = text.color;
			text.color = color;
		}
		else if(GetComponent<SpriteRenderer>())
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			type = 3;
			color = spriteRenderer.color;
			spriteRenderer.color = color;
		}
		else if(GetComponent<TextMesh>())
		{
			textMesh = GetComponent<TextMesh>();
			type = 4;
			color = textMesh.color;
			textMesh.color = color;
		}
		if(type == 0)
		{
			Debug.LogError("FadeOut: Didn't find supported component.");
			yield break;
		}
        // 淡出
        float speed = color.a / m_FadeOutTime;
		while(color.a > 0)
		{
			color.a = Mathf.Max(0f, color.a - Time.deltaTime * speed);
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
		mCoroutine = null;
		//触发回调
		if(m_FinishAction != null)
			m_FinishAction();
	}
}
