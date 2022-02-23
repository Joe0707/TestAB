using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputNavigator : MonoBehaviour
{
   //在面板中隐藏
   [HideInInspector]
   public InputTabChangeGroup group;
   private InputField inputField;
   void Start()
   {
      inputField = GetComponent<InputField>();
   }
   public void SetSelect()
   {
      EventSystem.current.SetSelectedGameObject(gameObject);
   }

   void Update()
   {
      if (Input.GetKeyUp(KeyCode.Tab) && inputField.isFocused)
      {
         group.Change2NextInputField(this);
      }
   }
   //    public void OnSelect(BaseEventData eventData)
   //    {
   //       _isSelect = true;
   //       print("选中" + gameObject.name);
   //    }

   //    public void OnDeselect(BaseEventData eventData)
   //    {
   //       _isSelect = false;
   //       print("没选中" + gameObject.name);
   //    }
}