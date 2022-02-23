// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable

// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/None" {
	Properties {
		_Color ("Color Tint", Color) = (1, 1, 1, 1)
		_AmbientColor("Ambient Color",Color) = (0.1,0.1,0.1,1)
		_MainTex ("Main Tex", 2D) = "white" {}
		_Ramp ("Ramp Texture", 2D) = "white" {}
		_Outline ("Outline", Float) = 6
		_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
		_Specular ("Specular", Color) = (1, 1, 1, 1)
		_SpecularScale ("Specular Scale", Range(0, 0.1)) = 0
		_DiffuseIntensityValue("DiffuseIntensity",Range(0,10)) = 1
	}
    SubShader {
		Tags { "RenderType"="Transparent" "Queue"="Transparent+1"}
		Pass{
			Tags { "LightMode"="ForwardBase" }
			ZWrite Off
			Cull Back
			Blend Zero One
			// Cull Front
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fwdbase
				#pragma multi_compile_instancing
				#include "UnityCG.cginc"
				float _Outline;
				half4 _OutlineColor;
				struct a2v{
					float4 position : POSITION;
					UNITY_VERTEX_INPUT_INSTANCE_ID
				};
				struct v2f{
					float4 position:POSITION;
					UNITY_VERTEX_INPUT_INSTANCE_ID
				};
				v2f vert(a2v a){
						v2f v;
						UNITY_SETUP_INSTANCE_ID(a); //这里第三步
                		UNITY_TRANSFER_INSTANCE_ID(a,v); //第三步
    					v.position = UnityObjectToClipPos(a.position);
						return v;
				}

				half4 frag(v2f i):SV_Target{
					UNITY_SETUP_INSTANCE_ID(i);
					return (1,1,1,0);
				}
			ENDCG
		}
	}
	// FallBack "Diffuse"
}
