using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class WorldMap : MonoBehaviour, IScrollHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private WorldCameraCtrl worldCameraCtrl;
    // Start is called before the first frame update
    void Start()
    {
        worldCameraCtrl = FindObjectOfType<WorldCameraCtrl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnScroll(PointerEventData eventData)
    {
        if (eventData.scrollDelta.y == 1)
        {
            worldCameraCtrl.SetOrthographicSize(-10);
        }
        else if (eventData.scrollDelta.y == -1)
        {
            worldCameraCtrl.SetOrthographicSize(10);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        worldCameraCtrl.first = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        worldCameraCtrl.MapOnDrag(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        worldCameraCtrl.IsNeedMove = false;
    }
}
