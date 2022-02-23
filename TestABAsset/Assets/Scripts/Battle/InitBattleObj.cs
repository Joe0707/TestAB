using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBattleObj : MonoBehaviour
{
    void Awake()
    {
        var battleObj = Resources.Load<GameObject>("Battle/Scene/BattleObj");
        GameObject.Instantiate(battleObj);
        Destroy(gameObject);
    }
}
