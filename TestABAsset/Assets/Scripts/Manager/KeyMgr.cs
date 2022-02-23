using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMgr : MonoBehaviour
{
   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyUp(KeyCode.Return))
      {
         //回车键监听
         EventMgr.FireEvent(KeyEventType.Enter, null);
      }
      else if (Input.GetKeyUp(KeyCode.Escape))
      {
         EventMgr.FireEvent(KeyEventType.ESC, null);
      }
      else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
      {
         EventMgr.FireEvent(KeyEventType.CtrlZ, null);
      }
   }
}
