using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShakePhoneEvent : MonoBehaviour {
	public const string ShakePhoneEventName = "ShakePhoneEvent";
	public float m_ShakeStrength = 1.5f;
	List<float> mValues = new List<float>();
	
	void Update () {
		 float value = Input.acceleration.magnitude;
		//算平均值
		if(mValues.Count > 0)
		{
            float averageValue = 0;
            foreach (var v in mValues)
                averageValue += v;
            averageValue /= mValues.Count;
            if (averageValue > 0 && value > averageValue * m_ShakeStrength)
            {
                EventMgr.FireEvent(ShakePhoneEventName, "");
                Debug.Log("Fire Event : ShakePhoneEvent");
            }
        }
        mValues.Add(value);
        while (mValues.Count > 5)
            mValues.RemoveAt(0);
    }
	void OnEnable()
	{
		mValues.Clear();
	}
}
