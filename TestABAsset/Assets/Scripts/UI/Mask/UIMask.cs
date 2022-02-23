using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMask : MonoBehaviour, IPointerClickHandler
{
   public void OnPointerClick(PointerEventData pointerEventData)
   {
      if (pointerEventData.pointerCurrentRaycast.gameObject == gameObject)
      {
         if (gameObject.activeSelf == true)
         {
            gameObject.SetActive(false);
         }
      }
   }
}
