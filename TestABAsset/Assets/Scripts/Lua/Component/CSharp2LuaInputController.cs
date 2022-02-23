using UnityEngine;
using XLua;
public class CSharp2LuaInputController : MonoBehaviour
{
    [CSharpCallLua]
    private delegate void LuaOnMouseDown();
    private LuaOnMouseDown mLuaOnMouseDown;
    void Start()
    {
        var actorlua = GetComponent<LuaBehavior>() as LuaBehavior;
        mLuaOnMouseDown = actorlua.Get<LuaOnMouseDown>("OnMouseDown");
    }
    void OnMouseDown()
    {
        mLuaOnMouseDown();
    }

}
