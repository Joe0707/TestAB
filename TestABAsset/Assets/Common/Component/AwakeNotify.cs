using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AwakeNotify : MonoBehaviour
{
    public Action notifyAwake;
    void Awake()
    {
        if (notifyAwake != null)
        {
            notifyAwake();
        }
    }
}
