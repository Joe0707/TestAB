using UnityEngine;
using XLua;
using System;
public class ActorInputController : MonoBehaviour
{
   [CSharpCallLua]
   private delegate void LuaOnMouseDrag();
   [CSharpCallLua]
   private delegate void LuaOnMouseUp();

   private LuaOnMouseDrag mLuaOnMouseDrag;
   private LuaOnMouseUp mLuaOnMouseUp;
   // Start is called before the first frame update
   void Start()
   {
      var actorlua = GetComponent<LuaBehavior>() as LuaBehavior;
      mLuaOnMouseDrag = actorlua.Get<LuaOnMouseDrag>("OnMouseDrag");
      mLuaOnMouseUp = actorlua.Get<LuaOnMouseUp>("OnMouseUp");
   }

   // Update is called once per frame
   void Update()
   {

   }

   //    Vector3 MyScreenPointToWorldPoint(Vector3 ScreenPoint, Transform target)
   //    {
   //       //1 得到物体在主相机的xx方向
   //       Vector3 dir = (target.position - Camera.main.transform.position);
   //       //2 计算投影 (计算单位向量上的法向量)
   //       Vector3 norVec = Vector3.Project(dir, Camera.main.transform.forward);
   //       //返回世界空间
   //       return Camera.main.ViewportToWorldPoint
   //           (
   //              new Vector3(
   //                  ScreenPoint.x / Screen.width,
   //                  ScreenPoint.y / Screen.height,
   //                  norVec.magnitude
   //              )
   //           );

   //    }

   private bool ComputeRayPos(Vector3 mousePos, out Vector3 HitPos)
   {
      bool result = false;
      HitPos = Vector3.zero;
      Ray ray = Camera.main.ScreenPointToRay(mousePos);
      RaycastHit hit;
      //   hit.
      if (Physics.Raycast(ray, out hit))
      {
         result = true;
         HitPos = hit.point;
      }
      return result;
   }


   Vector3 startPos;
   Vector3 endPos;
   Vector3 offset;

   //    void OnMouseDown()
   //    {
   //       print("MouseDown");
   //    }

   void OnMouseDrag()
   {
      mLuaOnMouseDrag();
      // var mousepos = Input.mousePosition;
      //   Vector3 hitpos;
      //   if (ComputeRayPos(mousepos, out hitpos))
      //   {
      //      hitpos.y += 1;
      //      transform.position = hitpos;
      //   }
      //   print("MouseDrag");
   }

   void OnMouseUp()
   {
      mLuaOnMouseUp();
      //   print("MouseUp");
   }
}
