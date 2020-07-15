Shader "Unlit/CanvasShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _Paint ("Paint", 2D) = "white" {}
        _DiscOn ("Show discontinuities", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _Paint;
            float4 _MainTex_ST;
            float _DiscOn;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 paint = tex2D(_Paint, i.uv);
                
                float range = 0.01;
                fixed4 n = abs(paint - tex2D(_Paint, i.uv + float3(0, -range, 0)));
                fixed4 no = abs(paint - tex2D(_Paint, i.uv + float3(-range, -range, 0)));
                fixed4 o = abs(paint - tex2D(_Paint, i.uv + float3(-range, 0, 0)));
                fixed4 so = abs(paint - tex2D(_Paint, i.uv + float3(-range, range, 0)));
                fixed4 s = abs(paint - tex2D(_Paint, i.uv + float3(0, range, 0)));
                fixed4 se = abs(paint - tex2D(_Paint, i.uv + float3(range, range, 0)));
                fixed4 e = abs(paint - tex2D(_Paint, i.uv + float3(range, 0, 0)));
                fixed4 ne = abs(paint - tex2D(_Paint, i.uv + float3(range, -range, 0)));
                fixed4 diff = (n + no + o + so + s + se + e + ne) / 8.0 * 10;
                fixed luma = (diff.r + diff.g + diff.b) / 3;
                
                if (_DiscOn == 1.0) {
                    return luma;
                    if (luma > 0.3) {
                        return 1;
                    } else {
                        return 0;
                    }
                }
                
                if (_DiscOn == 2.0) {
                    if (luma > 0.3) {
                        return 0;
                    } else {
                        return 1 - paint;
                    }
                }
                
                return 1 - paint;
            }
            ENDCG
        }
    }
}
