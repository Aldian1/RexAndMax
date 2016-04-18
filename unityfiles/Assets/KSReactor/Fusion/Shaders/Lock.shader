/**
 * Vertex + pixel shader that renders a criss-cross pattern and shifts the vertices towards the camera along the
 * z-axis.
 */
Shader "KS/Lock"
{
    Properties
    {
        m_crissCross ("Criss Cross", Range(0, 1)) = 0

        // Colour for the lines
        m_lineColour ("Color", Color) = (1,0,0,0.8)
        // Colour behind the lines
        [HideInInspector]m_backGroundColour ("Background Colour", Color) = (0,0,0,0.2)

        m_lineThickness ("Line Thickness", Range(0, 1)) = 0.2       // Line thickness
        m_lineSpacing ("Line Spacing", Range(0, 1)) = 0.8           // Space between lines
        m_scrollSpeed ("Scroll Speed", Range(0, 2)) = 0             // Speed of strip movem
        m_glowFrequency ("Glow Frequency", Range(0, 10)) = 2.0      // Frequency of glowing
        m_maxIntensity ("Max Glow Intensity", Range(0, 1)) = 0.8
        m_minIntensity ("Min Glow Intensity", Range(0, 1)) = 0.1

        [HideInInspector]m_zShift ("Z Shift", Range(0, 1)) = 0.01   // Amount to shift vertexes along z-axis.
        [HideInInspector]m_time ("Time", Float) = 0
    }
    
    SubShader
    {
        Tags { "Queue" = "Transparent" } 
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            
            CGPROGRAM
            
            float m_crissCross;
            fixed4 m_lineColour;
            fixed4 m_backGroundColour;
            float m_zShift;
            float m_lineThickness;
            float m_lineSpacing;
            float m_time;
            float m_scrollSpeed;
            float m_glowFrequency;
            float m_maxIntensity;
            float m_minIntensity;
            
            #pragma vertex vertexShader
            #pragma fragment pixelShader
            
            /**
             * Vertex shader output
             */
            struct v2f
            {
                float4 svPos : SV_POSITION;
                float4 pos : TEXCOORD;
            };
            
            /**
             * Checks if we should use the stripe colour or not.
             *
             * @param	float val - position along axis perpindicular to stripes.
             * @return	float 1 if we're inside a stripe, 0 otherwise.
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
             * @param   float4 pos - vertex position in world space.
             * @return  float4 vectex position in render space.
             */
            v2f vertexShader(float4 pos : POSITION)
            {
                v2f output;
                pos = mul(UNITY_MATRIX_MVP, pos);
                pos.z -= (1.0 - unity_OrthoParams.w) * m_zShift / max(pos.z, 1);
                output.svPos = pos;
                output.pos = pos;
                return output;
            }
            
            /**
             * Pixel shader.
             *
             * @return  float4 colour to render.
             */
            fixed4 pixelShader(v2f input) : SV_TARGET
            {
                float scale = unity_OrthoParams.w * unity_OrthoParams.x;
                scale += step(-scale, 0);
                m_lineThickness /= scale;
                m_lineSpacing /= scale;
                m_scrollSpeed /= scale;
                
                input.pos.x *= _ScreenParams.x / _ScreenParams.y;
                m_crissCross = step(0.5, m_crissCross);
                float isLine = isStripe(input.pos.x + input.pos.y - m_time * m_scrollSpeed) 
                    + isStripe(input.pos.x - input.pos.y) * m_crissCross;
                isLine = min(isLine, 1);
                m_lineColour.a = (cos(m_time * m_glowFrequency) * (m_maxIntensity - m_minIntensity)
                    + (m_maxIntensity + m_minIntensity)) * 0.5;
                return m_lineColour * isLine + m_backGroundColour * (1 - isLine);
            }
            
            ENDCG
        }	
    } 
    CustomEditor "LockMaterialInspector"
}