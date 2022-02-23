using UnityEngine.EventSystems;
using UnityEngine;
public class UIDragBase : UIBase, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   private bool isDrag = false;
   private Vector3 offset;
   private RectTransform mRectTransform;
   private Vector3 ogPosition;
   //重置原始位置
   protected void ResetOgPosition()
   {
      mRectTransform.position = ogPosition;
   }

   public override void Show()
   {
      base.Show();
      // ResetOgPosition();
   }

   protected override void Init()
   {
      base.Init();
      mRectTransform = transform.GetComponent<RectTransform>();
      ogPosition = mRectTransform.position;
   }

   public void OnBeginDrag(PointerEventData eventData)
   {
      isDrag = true;
      //计算偏移量
      Vector3 worldPosition;
      if (RectTransformUtility.ScreenPointToWorldPointInRectangle(mRectTransform, eventData.position, eventData.pressEventCamera, out worldPosition))
      {
         offset = mRectTransform.position - worldPosition;
      }
      OnUIBeginDrag(eventData);
   }

   protected virtual void OnUIBeginDrag(PointerEventData eventData)
   {

   }

   public void OnDrag(PointerEventData eventData)
   {
      SetDragObjPostion(eventData);
   }

   public void OnEndDrag(PointerEventData eventData)
   {
      isDrag = false;
   }

   void SetDragObjPostion(PointerEventData eventData)
   {

      Vector3 worldPosition;

      //判断是否点到UI图片上的时候
      if (RectTransformUtility.ScreenPointToWorldPointInRectangle(mRectTransform, eventData.position, eventData.pressEventCamera, out worldPosition))
      {
         if (isDrag)
         {
            mRectTransform.position = worldPosition + offset;
         }
      }
   }

}