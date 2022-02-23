using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShadowController : MonoBehaviour
{
    void Awake()
    {
        var light = GetComponent<Light>();
        LightBakingOutput output = new LightBakingOutput();
        output.mixedLightingMode = MixedLightingMode.Shadowmask;
        output.lightmapBakeType = LightmapBakeType.Mixed;
        output.isBaked = true;
        light.bakingOutput = output;
        light.lightShadowCasterMode = LightShadowCasterMode.NonLightmappedOnly;
    }
}
