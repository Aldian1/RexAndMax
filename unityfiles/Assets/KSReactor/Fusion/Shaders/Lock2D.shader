/**
 * Vertex + pixel shader for sprites that renders a criss-cross pattern.
 */
Shader "KS/Lock2D"
{
    Properties
    {
        [HideInInspector]_MainTex ("Base (RGB)", 2D) = "white" {}

        m_crissCross ("Criss Cross", Range(0, 1)) = 0

        // Colour for the lines
        m_lineColour ("Color", Color) = (1,0,0,0.8)
        // Colour behind the lines
        [HideInInspector]m_backGroundColour ("Background Colour", Color) = (0,0,0,0.2)

        m_lineThickness ("Line Thickness", Range(0, 1)) = 0.2       // Line thickness
        m_lineSpacing ("Line Spacing", Range(0, 1)) = 0.8           // Space between lines
        m_rotationSpeed ("Speed", Range(0, 2)) = 0                  // Speed of stripe movement

        m_glowFrequency ("Glow Frequency", Range(0, 10)) = 2.0      // Frequency of glowing
        m_maxIntensity ("Max Glow Intensity", Range(0, 1)) = 0.8
        m_minIntensity ("Min Glow Intensity", Range(0, 1)) = 0.1

        [HideInInspector]m_time ("Time", Float) = 0
    }
    
    SubShader
    {
        Tags { "Queue" = "Transparent" } 
        Pass
        {
            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            
            float m_crissCross;
            fixed4 m_lineColour;
            fixed4 m_backGroundColour;
            float m_lineThickness;
            float m_lineSpacing;
            float m_time;
            float m_rotationSpeed;
            float m_glowFrequency;
            float m_maxIntensity;
            float m_minIntensity;
            
            #pragma vertex vertexShader
            #pragma fragment pixelShader
            #include "UnityCG.cginc"
            
            sampler2D _MainTex;
            
            /**
             * Vertex shader input
             */
            struct VertexInput
            {
                float4 pos : POSITION;
                float2 uv_MainTex : TEXCOORD0;
            };
            
            /**
             * Vertex shader output
             */
            struct VertexOutput
            {
                float4 svPos : SV_POSITION;
                float4 pos : TEXCOORD;
                float2 uv_MainTex : TEXCOORD1;
            };
            
            /**
             * Checks if we should use the stripe colour or not.
             *
             * @param  float val - position along axis perpindicular to stripes.
             * @return float 1 if we're inside a stripe, 0 otherwise.
             */
            float isStripe(float val)
            {
                float isPositive = step(0, val);
                val = val * isPositive + (m_lineThickness - val) * (1 - isPositive);
                val = val % (m_lineThickness + m_lineSpacing);
                return step(val, m_lineThickness);
            }
            
            /**
             * Vertex shader.
             *
             * @param  float4 pos - vertex position in world space.
             * @return float4 vectex position in render space.
             */
            VertexOutput vertexShader(VertexInput input)
            {
                VertexOutput output;
                input.pos = mul(UNITY_MATRIX_MVP, input.pos);
                output.svPos = input.pos;
                output.pos = input.pos;
                output.uv_MainTex = input.uv_MainTex;
                return output;
            }
            
            /**
             * Pixel shader.
             *
             * @return fixed4 colour to render.
             */
            fixed4 pixelShader(VertexOutput input) : SV_TARGET
            {
                fixed4 output;
                float scale = unity_OrthoParams.w * unity_OrthoParams.x;
                scale += step(-scale, 0);
                m_lineThickness /= scale;
                m_lineSpacing /= scale;
                m_rotationSpeed /= scale;
                
                input.pos.x *= _ScreenParams.x / _ScreenParams.y;
                m_crissCross = step(0.5, m_crissCross);
                float isLine = isStripe(input.pos.x + input.pos.y - m_time * m_rotationSpeed) 
                    + isStripe(input.pos.x - input.pos.y) * m_crissCross;
                isLine = min(isLine, 1);
                m_lineColour.a = (cos(m_time * m_glowFrequency) * (m_maxIntensity - m_minIntensity)
                    + (m_maxIntensity + m_minIntensity)) * 0.5;
                output =  m_lineColour * isLine + m_backGroundColour* (1 - isLine);
                half4 c = tex2D (_MainTex, input.uv_MainTex);
                output.a *= c.a;
                return output;
            }
            
            ENDCG
        }    
    }
    CustomEditor "LockMaterialInspector"
}