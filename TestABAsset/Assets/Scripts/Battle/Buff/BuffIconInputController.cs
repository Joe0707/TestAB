using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using Levels;
public class BuffIconInputController : MonoBehaviour
{
    [CSharpCallLua]
    private delegate void LuaOnMouseDown();
    private LuaOnMouseDown mLuaOnMouseDown;
    // Start is called before the first frame update
    void Start()
    {
        var actorlua = GetComponent<LuaBehavior>() as LuaBehavior;
        mLuaOnMouseDown = actorlua.Get<LuaOnMouseDown>("OnMouseDown");
    }

    public void OnMouseDown()
    {
        mLuaOnMouseDown();
    }


}
