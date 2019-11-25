Shader "Custom/Shader"
{
    Properties
    {
		//_MainTex("Main Texture", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

       // sampler2D _MainTex;

        struct Input
        {
            float3 worldPos;
			float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        // world pos bad boy
		float2 modulo(float2 divident, float2 divisor)
		{
			float2 positiveDivident = divident % divisor + divisor;
			return positiveDivident % divisor;
		}
        // sin fun
        float random(float2 r)
        {
            //                                 |
           // sin madness    make it brighter V
            return  sin(sin(r.x)*3.14*5)*.5+.75;
        }
// big bad noise
        float rand(float2 co){
            return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453);
        }
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
			//o.Albedo.rgb = modulo(normalize(IN.worldPos.xyz),random(IN.worldPos.xyz));
			//o.Albedo.rg = random(float2(IN.worldPos.x,IN.worldPos.y), IN.worldPos.xy * 0.5 + 0.5);

            // albedo is based on sin * worldpos
            o.Albedo.rgb = float3(random(IN.worldPos.xy), random(IN.worldPos.yz), random(IN.worldPos.zx));
			//modf(random(float2(IN.worldPos.x,IN.worldPos.y), IN.worldPos.xy * 0.5 + 0.5));
            // Metallic and smoothness come from slider variables
			//o.Albedo.rgb = fmod(IN.worldPos.x*10, 1) < 0 ? 0 : tex2D(_MainTex, IN.uv_MainTex);
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
