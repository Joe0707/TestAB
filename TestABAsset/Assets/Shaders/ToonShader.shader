// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable

// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Toon Shading" {
	Properties {
		_Color ("Color Tint", Color) = (1, 1, 1, 1)
		_AmbientColor("Ambient Color",Color) = (0.1,0.1,0.1,1)
		_MainTex ("Main Tex", 2D) = "white" {}
		_Ramp ("Ramp Texture", 2D) = "white" {}
		_OutlineWidth ("Outline", Float) = 1
		_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
		_Specular ("Specular", Color) = (1, 1, 1, 1)
		_SpecularScale ("Specular Scale", Range(0, 0.1)) = 0
		_DiffuseIntensity("DiffuseIntensity",Range(0,1)) = 0
		_LightMapIntensity("Light Map Intensity",Float) = 1
	}
    SubShader {
		Tags { "RenderType"="Opaque" "Queue"="Geometry"}
		Pass{
			Cull Front
			CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile_fwdbase
				#pragma multi_compile_instancing
            	// make fog work
            	#pragma multi_compile_fog

				#include "UnityCG.cginc"

				float _OutlineWidth;
				half4 _OutlineColor;
				struct a2v{
					float4 position : POSITION;
					float2 normal : NORMAL;
					UNITY_VERTEX_INPUT_INSTANCE_ID
				};
				struct v2f{
					float4 position:POSITION;
					UNITY_FOG_COORDS(0)
					UNITY_VERTEX_INPUT_INSTANCE_ID
				};
				v2f vert(a2v a){
						v2f v;
						UNITY_SETUP_INSTANCE_ID(a); //这里第三步
                		UNITY_TRANSFER_INSTANCE_ID(a,v); //第三步
    					v.position = UnityObjectToClipPos(a.position);
    					float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, a.normal));
						float2 offset = normalize(clipNormal.xy) / _ScreenParams.xy * _OutlineWidth * v.position.w * 2;
						v.position.xy += offset;
						UNITY_TRANSFER_FOG(v,v.position);
						return v;
				}

				half4 frag(v2f i):SV_Target{
					UNITY_SETUP_INSTANCE_ID(i);
					// apply fog
					float4 finalcolor = _OutlineColor;
                	UNITY_APPLY_FOG(i.fogCoord, finalcolor);
					return finalcolor;
				}
			ENDCG
		}
		Pass {
			Tags { "LightMode"="ForwardBase" }
			
			Cull Back
		
			CGPROGRAM
		
			#pragma vertex vert
			#pragma fragment frag
			
			#pragma multi_compile_fwdbase
			#pragma multi_compile_instancing
			#pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON//开启LIGHTMAP_OFF LIGHTMAP_ON这两个宏。
            // make fog work
            #pragma multi_compile_fog
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#include "UnityShaderVariables.cginc"
			
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _Ramp;
			fixed4 _Specular;
			fixed _SpecularScale;
			fixed4 _AmbientColor;
			float _DiffuseIntensity;
			float _LightMapIntensity;
			#ifdef LIGHTMAP_ON 
        		// sampler2D unity_Lightmap;//Beast lightmap
        		// float4 unity_LightmapST; //scale & position of Beast lightmap
			#endif

			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				float4 tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			}; 
		
			struct v2f {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				SHADOW_COORDS(3)
                UNITY_FOG_COORDS(4)
				#ifdef LIGHTMAP_ON 
					float2 uv2: TEXCOORD5;
				#endif
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			v2f vert (appdata_full v) {
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v); //这里第三步
                UNITY_TRANSFER_INSTANCE_ID(v,o); //第三步
				o.pos = UnityObjectToClipPos( v.vertex);
				o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
				o.worldNormal  = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				#ifdef LIGHTMAP_ON 
					o.uv2 = v.texcoord1.xy*unity_LightmapST.xy+unity_LightmapST.zw;
				#endif
				TRANSFER_SHADOW(o);
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}
			
			float4 frag(v2f i) : SV_Target {
				UNITY_SETUP_INSTANCE_ID(i);
				fixed3 worldNormal = normalize(i.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
				fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
				fixed3 worldHalfDir = normalize(worldLightDir + worldViewDir);
				
				fixed4 c = tex2D (_MainTex, i.uv);
				fixed3 albedo = c.rgb * _Color.rgb;
				
				fixed3 ambient = _AmbientColor.xyz * albedo;
				
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
				
				fixed diff =  dot(worldNormal, worldLightDir)*_DiffuseIntensity;
				diff = (diff * 0.5 + 0.5) * atten;
				
				fixed3 diffuse = _LightColor0.rgb * albedo * tex2D(_Ramp, float2(diff, diff)).rgb;
				
				fixed spec = dot(worldNormal, worldHalfDir);
				fixed w = fwidth(spec) * 2.0;
				fixed3 specular = _Specular.rgb * lerp(0, 1, smoothstep(-w, w, spec + _SpecularScale - 1)) * step(0.0001, _SpecularScale);
				#ifdef LIGHTMAP_ON
					fixed3 lm = DecodeLightmap(UNITY_SAMPLE_TEX2D(unity_Lightmap,i.uv2))*_LightMapIntensity;
					diffuse += albedo*lm;
				#endif
				float3 finalcolor = ambient + diffuse + specular;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, finalcolor);
				return fixed4(finalcolor, 1.0);
			}
		
			ENDCG
		}
		Pass{
			Tags{"LightMode"="ForwardAdd"}
			Cull Back
			Blend One One
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile_fwdadd
			#pragma multi_compile_instancing		
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			#include "UnityShaderVariables.cginc"
			
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _Ramp;
			fixed4 _Specular;
			fixed _SpecularScale;
			fixed4 _AmbientColor;
			float _DiffuseIntensity;
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
				float4 tangent : TANGENT;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			}; 
		
			struct v2f {
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				SHADOW_COORDS(3)
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			v2f vert (a2v v) {
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v); //这里第三步
                UNITY_TRANSFER_INSTANCE_ID(v,o); //第三步
				o.pos = UnityObjectToClipPos( v.vertex);
				o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
				o.worldNormal  = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				
				TRANSFER_SHADOW(o);
				
				return o;
			}
			
			float4 frag(v2f i) : SV_Target { 
				UNITY_SETUP_INSTANCE_ID(i);
				fixed3 worldNormal = normalize(i.worldNormal);
				// fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
				half3 light_dir_point = normalize(_WorldSpaceLightPos0.xyz - i.worldPos);
				half3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
				worldLightDir = lerp(worldLightDir, light_dir_point, _WorldSpaceLightPos0.w);

				fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
				fixed3 worldHalfDir = normalize(worldLightDir + worldViewDir);
				
				fixed4 c = tex2D (_MainTex, i.uv);
				fixed3 albedo = c.rgb * _Color.rgb;
				
				fixed3 ambient = _AmbientColor.xyz * albedo;
				
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);
				
				fixed diff =  dot(worldNormal, worldLightDir)*_DiffuseIntensity;
				diff = (diff * 0.5 + 0.5) * atten;
				
				fixed3 diffuse = _LightColor0.rgb * albedo * tex2D(_Ramp, float2(diff, diff)).rgb;
				
				fixed spec = dot(worldNormal, worldHalfDir);
				fixed w = fwidth(spec) * 2.0;
				fixed3 specular = _Specular.rgb * lerp(0, 1, smoothstep(-w, w, spec + _SpecularScale - 1)) * step(0.0001, _SpecularScale);
				
				return fixed4(ambient + diffuse + specular, 1.0);
			}
			ENDCG
		}

	}
	FallBack "Diffuse"
}
