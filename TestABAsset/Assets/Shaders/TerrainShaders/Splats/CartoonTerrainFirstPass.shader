// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Nature/Terrain/Cartoon" {
    Properties {
        // used in fallback on old cards & base map
        [HideInInspector] _MainTex ("BaseMap (RGB)", 2D) = "white" {}
        [HideInInspector] _Color ("Main Color", Color) = (1,1,1,1)
        [HideInInspector] _TerrainHolesTexture("Holes Map (RGB)", 2D) = "white" {}
        _Ramp ("Ramp Texture", 2D) = "white" {}
        _DiffuseIntensity("Diffuse Intensity",Range(-1,1)) = 0
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (0, 0.03)) = .005
    }

    CGINCLUDE
        #pragma surface surf ToonRamp vertex:SplatmapVert finalcolor:SplatmapFinalColor finalprepass:SplatmapFinalPrepass finalgbuffer:SplatmapFinalGBuffer addshadow fullforwardshadows
        #pragma instancing_options assumeuniformscaling nomatrices nolightprobe nolightmap forwardadd
        #pragma multi_compile_fog
        #include "TerrainSplatmapCommon.cginc"

        uniform sampler2D _Ramp;
        float _DiffuseIntensity;
        inline float3 ACES_Tonemapping(float3 x)
		{
				float a = 2.51f;
				float b = 0.03f;
				float c = 2.43f;
				float d = 0.59f;
				float e = 0.14f;
				float3 encode_color = saturate((x*(a*x + b)) / (x*(c*x + d) + e));
				return encode_color;
		}
        inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
        {
            #ifndef USING_DIRECTIONAL_LIGHT
            lightDir = normalize(lightDir);
            #endif
            // Wrapped lighting
            half d = dot (s.Normal, lightDir)* 0.5 + 0.5;
            d*=_DiffuseIntensity ;
            // d = d ;
            // Applied through ramp
            half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
            half4 c;
            c.rgb = s.Albedo * _LightColor0.rgb * ramp*atten;
            c.rgb = ACES_Tonemapping(c.rgb);
            c.a = 0;
            return c;
        }



        void surf(Input IN, inout SurfaceOutput o)
        {
            half4 splat_control;
            half weight;
            fixed4 mixedDiffuse;
            SplatmapMix(IN, splat_control, weight, mixedDiffuse, o.Normal);
            o.Albedo = mixedDiffuse.rgb;
            o.Alpha = weight;
        }
    ENDCG
    Category {
        Tags {
            "Queue" = "Geometry-99"
            "RenderType" = "Opaque"
        }
        // TODO: Seems like "#pragma target 3.0 _NORMALMAP" can't fallback correctly on less capable devices?
        // Use two sub-shaders to simulate different features for different targets and still fallback correctly.
        SubShader { // for sm3.0+ targets
            CGPROGRAM
                #pragma target 3.0
                #pragma multi_compile_local __ _ALPHATEST_ON
                #pragma multi_compile_local __ _NORMALMAP
            ENDCG
            UsePass "Toon/Basic Outline/OUTLINE"

            UsePass "Hidden/Nature/Terrain/Utilities/PICKING"
            UsePass "Hidden/Nature/Terrain/Utilities/SELECTION"
        }
        SubShader { // for sm2.0 targets
            CGPROGRAM
            ENDCG
        }
    }

    Dependency "AddPassShader"    = "Hidden/TerrainEngine/Splatmap/Diffuse-AddPass"
    Dependency "BaseMapShader"    = "Hidden/TerrainEngine/Splatmap/Diffuse-Base"
    Dependency "BaseMapGenShader" = "Hidden/TerrainEngine/Splatmap/Diffuse-BaseGen"
    Dependency "Details0"         = "Hidden/TerrainEngine/Details/Vertexlit"
    Dependency "Details1"         = "Hidden/TerrainEngine/Details/WavingDoublePass"
    Dependency "Details2"         = "Hidden/TerrainEngine/Details/BillboardWavingDoublePass"
    Dependency "Tree0"            = "Hidden/TerrainEngine/BillboardTree"

    Fallback "Diffuse"
}
