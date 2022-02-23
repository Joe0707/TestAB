using UnityEngine;
using System.Collections;
public delegate void OnScrollValueChangedCallBack(float value);

public class ScrollControl : MonoBehaviour {
	public GameObject scrollObj;
	public bool isVertical = true;
	public float maxScrollDistance= 0f;
	public float scrollSpeedRadio= 0.015f; 
	public bool disabled = false;
	public Transform initTransform;
	
	public GameObject touchAreaMask;	//在滚动面板的时候，启用这个遮罩，防止滚动的操作产生点击面板上的按钮的误操作
	public bool autoUpdateChildObjVisibility = true;

	private Rect touchRect;
	private bool mouseDown = false;
	private bool autoScrolling = false;
	private Vector3 mouseOldPos = Vector3.zero;
	private Vector3 mouseDownPos = Vector3.zero;
	private float deltaMove = 0f;
	private float initialPos = 0f;
	private float scrollRatioByScreen = 2f;
	
	private bool mbMobileDevice = false;
	private float mTouchMaskActiveDistance = 2f;//当手指移动距离超过这个时，就认为是滑动，则激活防误点击的遮挡

	public OnScrollValueChangedCallBack onScrollValueChangedCallBack = null;
	void Start () 
	{
		if(touchAreaMask != null)
			touchAreaMask.SetActive(false);	
		SpriteRenderer sprRenderer = gameObject.GetComponent<SpriteRenderer>();
		if(sprRenderer != null)
			sprRenderer.color = new Color(1.0f,1.0f,1.0f,0f);//隐藏
		UpdateTouchRect();
		if(isVertical)
		{
			initialPos = initTransform.localPosition.y;
			scrollRatioByScreen = 800.0f / Camera.main.pixelHeight;//最初是按照800高屏幕调整得，根据屏幕得尺寸，再适配一下
		}
		else
		{
			initialPos = initTransform.localPosition.x;
			scrollRatioByScreen = 480.0f / Camera.main.pixelWidth;//最初是按照800高屏幕调整得，根据屏幕得尺寸，再适配一下
		}
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
			mbMobileDevice = true;
		else
			mbMobileDevice = false;
		mTouchMaskActiveDistance = mTouchMaskActiveDistance * (1600f / Camera.main.pixelHeight); //屏幕越大，此值越小
	}
	
	void OnDisable()
	{
		autoScrolling = false;
		mouseDown = false;
	}
	
	private float moveDeltaSpeed = 0f;
	private int moveDir = 0;
	private bool bouncing = false;//反弹
	private float bounceSpeed = 2f;
	private float bounceMaxDist = 1f;//反弹最大距离
	
	void Update () 
	{	
		if(disabled)
		{
			mouseDown = false;
			bouncing = false;
			autoScrolling = false;
			if(touchAreaMask != null)
				touchAreaMask.SetActive(false);
			return;
		}
		if(false == mbMobileDevice)
		{
			if(mouseDown == false && Input.GetMouseButtonDown(0) == true && true == touchRect.Contains(Input.mousePosition))
			{
				mouseDown = true;
				autoScrolling = false;
				mouseOldPos = Input.mousePosition;
				mouseDownPos = Input.mousePosition;
				bouncing = false;
				moveDir = 0;
				moveDeltaSpeed = 0f;
			}
			else if(Input.GetMouseButtonUp(0) == true && mouseDown == true)
			{
				mouseDown = false;
				autoScrolling = true;
				moveDeltaSpeed = (Mathf.Abs(deltaMove / Time.deltaTime) + moveDeltaSpeed) / 2.0f;
				Vector3 newPos = scrollObj.transform.localPosition;
				if(isVertical)
				{
					if(newPos.y - initialPos >=  maxScrollDistance)
					{
						moveDir = -1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
					if(newPos.y <= initialPos)
					{
						moveDir = 1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
				}
				else
				{
					if(initialPos - newPos.x >=  maxScrollDistance)
					{
						moveDir = 1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
					if(newPos.x >= initialPos)
					{
						moveDir = -1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
				}
			}
		}
		else
		{
			if(mouseDown == false && Input.touchCount > 0 && touchRect.Contains(Input.GetTouch(0).position))
			{
				mouseDown = true;
				autoScrolling = false;
				mouseOldPos = Input.GetTouch(0).position;
				mouseDownPos = Input.GetTouch(0).position;
				bouncing = false;
				moveDir = 0;
				moveDeltaSpeed = 0f;
			}
			else if(mouseDown == true && Input.touchCount == 0)
			{
				mouseDown = false;
				autoScrolling = true;
				moveDeltaSpeed = (Mathf.Abs(deltaMove / Time.deltaTime) + moveDeltaSpeed) / 2.0f;
				Vector3 newPos = scrollObj.transform.localPosition;
				if(isVertical)
				{
					if(newPos.y - initialPos >=  maxScrollDistance)
					{
						moveDir = -1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
					if(newPos.y <= initialPos)
					{
						moveDir = 1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
				}
				else
				{
					if(initialPos - newPos.x >=  maxScrollDistance)
					{
						moveDir = 1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
					if(newPos.x >= initialPos)
					{
						moveDir = -1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
				}
			}
		}
		if(mouseDown && bouncing == false)
		{
			Vector3 curMousePos = Input.mousePosition;
			if(mbMobileDevice && Input.touchCount > 0)
				curMousePos = Input.GetTouch(0).position;
			
			if(isVertical)
			{
				if(Mathf.Abs(curMousePos.y - mouseDownPos.y) > mTouchMaskActiveDistance)
				{
					if(touchAreaMask != null)
						touchAreaMask.SetActive(true);	
				}
				if(Mathf.Abs(curMousePos.y - mouseDownPos.y) > Mathf.Abs(curMousePos.x - mouseDownPos.x))
				{
					deltaMove = (curMousePos.y - mouseOldPos.y) * scrollSpeedRadio * scrollRatioByScreen; 
					ApplyDeltaMoveY();
				}
			}
			else
			{
				if(Mathf.Abs(curMousePos.x - mouseDownPos.x) > mTouchMaskActiveDistance)
				{
					if(touchAreaMask != null)
						touchAreaMask.SetActive(true);	
				}
				if(Mathf.Abs(curMousePos.y - mouseDownPos.y) < Mathf.Abs(curMousePos.x - mouseDownPos.x))
				{
					deltaMove = (curMousePos.x - mouseOldPos.x) * scrollSpeedRadio * scrollRatioByScreen; 
					ApplyDeltaMoveX();
				}
				else if(Mathf.Abs(curMousePos.y - mouseDownPos.y) > 1)
				{//横向时，如果纵向移动距离过长，则停止横向移动
					mouseDown = false;
					//计算是否需要反弹
					if(initialPos - scrollObj.transform.localPosition.x >=  maxScrollDistance)
					{
						moveDir = 1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
					if(scrollObj.transform.localPosition.x >= initialPos)
					{
						moveDir = -1;
						moveDeltaSpeed = bounceSpeed;
						bouncing = true;
					}
				}
			}
			
			mouseOldPos = curMousePos;
			if(bouncing == false)
			{
				if(deltaMove != 0)
					moveDeltaSpeed = (Mathf.Abs(deltaMove / Time.deltaTime) + moveDeltaSpeed) / 2.0f;
				if(deltaMove > 0)
					moveDir = 1;
				else if(deltaMove < 0)
					moveDir = -1;
			}
		}
		if(autoScrolling == true && mouseDown == false)
		{
			if(bouncing == false)
			{
				float speedDelta = moveDeltaSpeed * 3f;
				speedDelta = Mathf.Max(15f, speedDelta);
				moveDeltaSpeed -= speedDelta * Time.deltaTime;
				moveDeltaSpeed = Mathf.Max(0f, moveDeltaSpeed);
			}
			if(moveDeltaSpeed == 0)
			{
				deltaMove = 0;
				autoScrolling = false;
				DeactiveTouchMask();
			}
			else
			{
				if(moveDir > 0)
				{
					deltaMove = Mathf.Min(20f, moveDeltaSpeed) * Time.deltaTime;
				}
				else if(moveDir	< 0)
				{
					deltaMove = - Mathf.Min(20f, moveDeltaSpeed) * Time.deltaTime;
				}
			}	
			if(isVertical)
				ApplyDeltaMoveY();
			else
				ApplyDeltaMoveX();
		}
	}
	
	void ApplyDeltaMoveY()
	{
		if(disabled == true)
			return;
		
		Vector3 newPos = scrollObj.transform.localPosition;
		newPos.y += deltaMove;
		if(bouncing == false)
		{	
			if(newPos.y - initialPos >=  maxScrollDistance + bounceMaxDist)
			{
				newPos.y = initialPos + maxScrollDistance + bounceMaxDist;
				moveDir = -1;
				moveDeltaSpeed = bounceSpeed;
				mouseDown = false;
				autoScrolling = true;
				bouncing = true;
			}
			if(newPos.y <= initialPos - bounceMaxDist)
			{
				newPos.y = initialPos - bounceMaxDist;
				moveDir = 1;
				moveDeltaSpeed = bounceSpeed;
				mouseDown = false;
				autoScrolling = true;
				bouncing = true;
			}
		}
		else
		{
			if(moveDir > 0 && newPos.y - initialPos >=  0 )
			{
				newPos.y = initialPos;  
				bouncing = false;
				moveDeltaSpeed = 0;
			}
			else if(moveDir < 0 && newPos.y <= initialPos + maxScrollDistance)
			{
				newPos.y = initialPos + maxScrollDistance ;
				bouncing = false;
				moveDeltaSpeed = 0;
			}
		}
		scrollObj.transform.localPosition =  newPos;
		UpdateChildVisibility();
		if(onScrollValueChangedCallBack != null)
		{
			float percent = (newPos.y - initialPos) / maxScrollDistance;
			if(percent > 1.0f)
				percent = 1.0f;
			else if(percent < 0)
				percent = 0f;
			onScrollValueChangedCallBack(percent);
		}
	}
	
	void ApplyDeltaMoveX()
	{
		if(disabled == true)
			return;

		Vector3 newPos = scrollObj.transform.localPosition;
		newPos.x += deltaMove;
		if(bouncing == false)
		{	
			if(initialPos - newPos.x  >=  maxScrollDistance + bounceMaxDist)
			{
				newPos.x = initialPos - maxScrollDistance - bounceMaxDist;
				moveDir = 1;
				moveDeltaSpeed = bounceSpeed;
				mouseDown = false;
				autoScrolling = true;
				bouncing = true;
			}
			if(newPos.x >= initialPos + bounceMaxDist)
			{
				newPos.x = initialPos + bounceMaxDist;
				moveDir = -1;
				moveDeltaSpeed = bounceSpeed;
				mouseDown = false;
				autoScrolling = true;
				bouncing = true;
			}
		}
		else
		{
			if(moveDir > 0 && newPos.x + maxScrollDistance - initialPos >=  0 )
			{
				newPos.x = initialPos - maxScrollDistance;  
				bouncing = false;
				moveDeltaSpeed = 0;
			}
			else if(moveDir < 0 && newPos.x <= initialPos)
			{
				newPos.x = initialPos;
				bouncing = false;
				moveDeltaSpeed = 0;
			}
		}
		scrollObj.transform.localPosition =  newPos;
		UpdateChildVisibility();
		if(onScrollValueChangedCallBack != null)
		{
			float percent = (newPos.x - initialPos) / maxScrollDistance;
			if(percent > 1.0f)
				percent = 1.0f;
			else if(percent < 0)
				percent = 0f;
			onScrollValueChangedCallBack(percent);
		}
	}
	
	void ResetPos()
	{
		Vector3 oldPos = scrollObj.transform.localPosition;
		if(isVertical)
			oldPos.y = initialPos;
		else
			oldPos.x = initialPos;
		scrollObj.transform.localPosition =  oldPos;
	}
	void DeactiveTouchMask()
	{
		if(touchAreaMask != null)
			touchAreaMask.SetActive(false);
	}
	
	void UpdateTouchRect()
	{
        SpriteRenderer sprRenderer = GetComponent<SpriteRenderer>();
        if (sprRenderer != null)
        {
            Vector3 edgeMaxPos = Camera.main.WorldToScreenPoint(sprRenderer.bounds.max);
            Vector3 edgeMinPos = Camera.main.WorldToScreenPoint(sprRenderer.bounds.min);
            touchRect.x = edgeMinPos.x;
            touchRect.y = edgeMinPos.y;
            touchRect.width = edgeMaxPos.x - edgeMinPos.x;
            touchRect.height = edgeMaxPos.y - edgeMinPos.y;
        }
	}
	
	void UpdateChildVisibility()
	{
		if(autoUpdateChildObjVisibility == false)
			return;
		int cnt = scrollObj.transform.childCount;
		Vector3 edgeMaxPos;
		Vector3 edgeMinPos;
		SpriteRenderer sprRenderer;
		for(var i = 0; i < cnt; i++)
		{
			GameObject obj = scrollObj.transform.GetChild(i).gameObject;		
			if(obj == null)
				continue;
			if(obj.tag == "NoDynamicUpdateVisibility")
				continue;
			sprRenderer = obj.GetComponent<SpriteRenderer>();
			if(sprRenderer == null)
				continue;
			edgeMaxPos = Camera.main.WorldToScreenPoint(sprRenderer.bounds.max);
			edgeMinPos = Camera.main.WorldToScreenPoint(sprRenderer.bounds.min);
			
			if(obj.activeInHierarchy)
			{
				if(edgeMinPos.x > touchRect.x + touchRect.width ||
				   edgeMinPos.y > touchRect.y + touchRect.height ||
				   edgeMaxPos.x < touchRect.x ||
				   edgeMaxPos.y < touchRect.y)
					obj.SetActive(false);
			}
			else
			{
				if(!(edgeMinPos.x > touchRect.x + touchRect.width ||
				     edgeMinPos.y > touchRect.y + touchRect.height ||
				     edgeMaxPos.x < touchRect.x ||
				     edgeMaxPos.y < touchRect.y))
					obj.SetActive(true);
			}
		}
	}
	

}
