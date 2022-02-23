using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteProgress : MonoBehaviour
{
    float mValue = 0;
    Material mMaterial = null;
    void Start()
    {
        UpdatePercentToMaterial();
    }

    //更新显示
    void UpdatePercentToMaterial()
    {
        if(mMaterial == null)    
        {
            var renderer = GetComponent<SpriteRenderer>();
            if(renderer != null)
                mMaterial = renderer.material;
        }
        if(mMaterial != null)
        {
            mMaterial.SetFloat("_Percent", mValue);
        }
    }

    //设定值
    public float Value{
        get{
            return mValue;
        }
        set{
            mValue = value;
            mValue = Mathf.Min(mValue, 1);
            mValue = Mathf.Max(mValue, 0);
            UpdatePercentToMaterial();
        }
    }
}
