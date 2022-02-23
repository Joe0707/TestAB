using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using Levels;
public class SlotInputController : MonoBehaviour
{
    [CSharpCallLua]
    private delegate void LuaOnMouseDown();
    private LuaOnMouseDown mLuaOnMouseDown;
    public int slotindex = -1;
    // Start is called before the first frame update
    void Start()
    {
        var actorlua = GetComponent<LuaBehavior>() as LuaBehavior;
        mLuaOnMouseDown = actorlua.Get<LuaOnMouseDown>("OnMouseDown");
    }


    void Update()
    {
        if (slotindex == -1)
        {
            //添加测试代码显示格子索引
            var slotLuaBehavior = GetComponent<LuaBehavior>() as LuaBehavior;
            var slotconfig = slotLuaBehavior.GetValue("mSlotData") as SlotConfig;
            slotindex = slotconfig.Index;
        }
    }

    void OnMouseDown()
    {
        mLuaOnMouseDown();
    }


}
