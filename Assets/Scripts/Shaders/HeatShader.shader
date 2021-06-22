Shader "MyShaders/HeatingEffect"{

    Properties
    {
        noiseTex("Noise", 2D) = "white" {}
        filter("Filter", 2D) = "white" {}
        strength("Distort Strength", float) = 1.0
        velocity("Distort velocity", float) = 1.0
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "DisableBatching" = "True"
            }


            //Get Info from the background
            GrabPass
            {
                "_BackgroundTexture"
            }


            // Render the object with the texture generated above, and invert the colors
            Pass
            {
                ZTest Always

                CGPROGRAM
                #pragma vertex vertex
                #pragma fragment fragment
                #include "UnityCG.cginc"

                // Properties
                sampler2D noiseTex;
                sampler2D filter;
                sampler2D _BackgroundTexture;
                float     strength;
                float     velocity;

                struct vertexInput
                {
                    float4 vertex : POSITION;
                    float3 texCoord : TEXCOORD0;
                };

                struct vertexOutput
                {
                    float4 pos : SV_POSITION;
                    float4 grabPos : TEXCOORD0;
                };

                vertexOutput vertex(vertexInput input)
                {
                    
                    vertexOutput output;

                    //What the camera see
                    float4 pos = input.vertex;
                    pos = mul(UNITY_MATRIX_P, mul(UNITY_MATRIX_MV, float4(0, 0, 0, 1)) + float4(pos.x, pos.z, 0, 0));
                    output.pos = pos;

                    // ComputeGrabScreenPos from UnityCG.cginc
                    // Get Coordinates of textures
                    output.grabPos = ComputeGrabScreenPos(output.pos);

                    // distort based on noise & strength filter
                    float noise = tex2Dlod(noiseTex, float4(input.texCoord, 0)).rgb;
                    float3 filt = tex2Dlod(filter, float4(input.texCoord, 0)).rgb;
                    output.grabPos.x += cos(noise * _Time.x * velocity) * filt * strength;
                    output.grabPos.y += sin(noise * _Time.x * velocity) * filt * strength;

                    return output;
                    
                }

                float4 fragment(vertexOutput input) : COLOR
                {
                    return tex2Dproj(_BackgroundTexture, input.grabPos);
                    //return float4(1, 1, 1, 1);
                }

                ENDCG
            }

        }
}

//Jesus, i hate this so much