using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class DragImage : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action<GameObject> onPointerClick;
    public Action<GameObject> onBeginDrag;
    public Action<GameObject> onDrag;
    public Action<GameObject> onEndDrag;
    public Action<GameObject> onPointerDown;
    public Action<GameObject> onPointerUp;
    public void OnPointerClick(PointerEventData eventData)
    {
        onPointerClick?.Invoke(eventData.pointerEnter);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDrag?.Invoke(eventData.pointerEnter);
    }
    public void OnDrag(PointerEventData eventData)
    {
        onDrag?.Invoke(eventData.pointerEnter);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        onEndDrag?.Invoke(eventData.pointerEnter);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown?.Invoke(eventData.pointerEnter);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp?.Invoke(eventData.pointerEnter);
    }

}
