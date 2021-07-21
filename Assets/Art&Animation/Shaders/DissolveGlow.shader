Shader "Custom/Metanoia/IFriendsDissolve"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _DissolveTex("Dissolve Texture", 2D) = "white" {}
        _DissolveAmount("Dissolve Amount", Range(0, 1)) = 0
        _DissolveSize("Dissolve Size", Range(0.0, 1.0)) = 0.15
        _DissolveColMap("Dissolve Colours Map (RGB)", 2D) = "white" {}
        _DissolveVec("Dissolve Vector", vector) = (0, -1, 0, 0)
        _EmissionAmount("Emission Amount", Range(0, 1)) = 0
        _EmissionColour("Color", Color) = (0, 0, 0, 0)     
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _EmissionColour;
        sampler2D _DissolveTex, _DissolveColMap;
        float _DissolveAmount;
        half4 _DissolveVec;
        float _EmissionAmount;
        float _Emission;
        float _DissolveSize;

        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            float4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            float4 dissolveCol = tex2D(_DissolveTex, IN.uv_MainTex);
            float4 colour = _Color;
            half vec = (dot(IN.uv_MainTex, normalize(_DissolveVec)) + 1) / 2;
            clip((vec - _DissolveAmount));
            clip((dissolveCol - _DissolveAmount));
            half dissolveProgression = tex2D(_DissolveTex, IN.uv_MainTex).rgb - _DissolveAmount;
            clip(dissolveProgression);
            if (dissolveProgression < _DissolveSize && _DissolveAmount > 0) {
                o.Emission = tex2D(_DissolveColMap, float2(dissolveProgression * (1 / _DissolveSize), 0)) * _EmissionColour * _EmissionAmount;
                
            }


            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
