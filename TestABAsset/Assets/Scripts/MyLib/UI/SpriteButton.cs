using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SpriteButton : MonoBehaviour {

	static public int curHotControlState = 0;//当前起作用的按钮组
	public GameObject handlerObj;//响应对象
	public string onClickedMsg = "";
	public string msgParam = "";
	//如果curHotControlState!=0,hotControlState和curHotControlState相等，这个按钮才有作用
	public int hotControlState = 0;

	public bool isDisabled = false;
	public Sprite normalSprite;
	public Sprite downSprite;

	public float delayCreateCollider = 0f;
	public AudioClip clickSnd;
	[Tooltip("是否先检查UI物体")]
	public bool checkUIObjectFirst = true;

	private bool bIsDown = false;
	private Color oldColor;
	private SpriteRenderer spriteRenderer;
	private Collider buttonCollider;
	private AudioSource audioSource;
	public bool autoCheckInvisible = true; //自动检查是否可见
	public System.Action onClickAction = null; //附加的点击调用方式

	void Start () {
		Invoke("CreateCollider", delayCreateCollider);	
		if(spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			if(spriteRenderer == null)
				Debug.LogError("SpriteButton should be with a SpriteRenderer Component");
			oldColor = spriteRenderer.color;
		}
		if(isDisabled == true)
			spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
		if(clickSnd != null)
		{
			audioSource = gameObject.AddComponent<AudioSource>();
			audioSource.clip = clickSnd;
			audioSource.playOnAwake = false;
			SoundCtrl sndCtrl = gameObject.AddComponent<SoundCtrl>();
			sndCtrl.mSoundType = ESoundType.EST_Sound;
		}
		Invoke("CheckIsInScreen", 0.2f);
	}
	
	public void CheckIsInScreen()
	{
		if(spriteRenderer != null)
		{
			Vector3 edgeMaxInScreen = Camera.main.WorldToScreenPoint(spriteRenderer.bounds.max);
			Vector3 edgeMinInScreen = Camera.main.WorldToScreenPoint(spriteRenderer.bounds.min);

			if(edgeMaxInScreen.x < 0 || edgeMinInScreen.x > Camera.main.pixelWidth ||
					edgeMaxInScreen.y < 0 || edgeMinInScreen.y > Camera.main.pixelHeight)
				OnBecameInvisible();
			else
				OnBecameVisible();
		}
	}
	void OnMouseUpAsButton()
	{
		if(bIsDown == true)
		{
			bIsDown = false;
			//change color
			if(normalSprite != null)
				spriteRenderer.sprite = normalSprite;
			else
				spriteRenderer.color = oldColor;
			OnClicked();
		}
	}
	void OnMouseUp()
	{//release outside
		if(bIsDown == true)
		{
			//change color
			if(normalSprite != null)
				spriteRenderer.sprite = normalSprite;
			else
				spriteRenderer.color = oldColor;
		}
	}

	void OnMouseDown () 
	{
        if (checkUIObjectFirst && H.IsPointerOverUIObject())
            return;//鼠标点击到了UI上
        if (bIsDown == false && isDisabled == false)
        {
            bIsDown = true;
            if (downSprite != null)
            {
                spriteRenderer.sprite = downSprite;
            }
            else
			{
				Color tmpColor = oldColor;
				tmpColor.r -= 0.15f;
				tmpColor.g -= 0.15f;
				tmpColor.b -= 0.15f;
				spriteRenderer.color = tmpColor;
			}	
		}
	}

	void OnBecameInvisible()
	{
        if (autoCheckInvisible)
            if (buttonCollider != null)
                buttonCollider.enabled = false;
    }
    void OnBecameVisible()
    {
        if (autoCheckInvisible)
            if (buttonCollider != null)
                buttonCollider.enabled = true;
	}

	void OnClicked()
	{
		if (hotControlState != curHotControlState)
			return;
		if(handlerObj != null && handlerObj.activeInHierarchy == false)
			return;
		//点击音效
		if(audioSource != null)
			audioSource.Play();

		if(handlerObj != null && onClickedMsg != "")
		{
			handlerObj.SendMessage(onClickedMsg, msgParam);
		}
		if(onClickAction != null)
		{
			onClickAction();
		}
	}

	//触发点击
	public void InvokeClickMethod()
	{
		OnClicked();
	}

	public void SetDisabled(bool disable)
	{
		if(spriteRenderer == null)
		{
			spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			oldColor = spriteRenderer.color;
		}
		isDisabled = disable;
		if(isDisabled)
		{
			spriteRenderer.color = new Color(0.4f, 0.4f, 0.4f);
		}
		else
		{
			spriteRenderer.color = oldColor;
		}
	}

	void CreateCollider()
	{
		if(buttonCollider == null)
		{
			buttonCollider = gameObject.GetComponent<BoxCollider>();
			if(buttonCollider == null)
                buttonCollider = gameObject.AddComponent<BoxCollider>();
		}
	}

}
