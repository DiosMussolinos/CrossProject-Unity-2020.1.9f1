Shader "MyShaders/Fickering"{
	// variables
	Properties{
		_MainTex("Texture", 2D) = "white" {}
	}
		// actual shader code
		SubShader{

			Cull Off
			ZWrite Off
			ZTest Always

			Pass{
				CGPROGRAM
				#pragma vertex MyVertexProgram
				#pragma fragment MyFragmentProgram

				#include "UnityCG.cginc"

				struct VertexData {
					float4 position : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct VertexToFragment {
					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;


				// calculate the data for the VertexToFragment struct
				// that is then passed on to the Fragment function
				VertexToFragment MyVertexProgram(VertexData vertex)
				{
					VertexToFragment v2f;

					v2f.position = UnityObjectToClipPos(vertex.position);
					v2f.uv = vertex.uv * _MainTex_ST.xy + _MainTex_ST.zw;

					return v2f;
				}

				float4 MyFragmentProgram(VertexToFragment v2f) : SV_TARGET
				{
					float4 color = tex2D(_MainTex, v2f.uv);

					return (color * float4(100, 100, 100, 1));
				}
				ENDCG
			}
	}
}