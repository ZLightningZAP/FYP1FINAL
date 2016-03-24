Shader "Custom/Tf2Shader" {
	Properties{
		_Color("Main Color", Color) = (1, 1, 1, 1)
		_RimColor("Rim Color", Color) = (0.97, 0.88, 1, 0.75)
		_RimPower("Rim Power", Float) = 2.5
		_SpecPower("Spec Power", Float) = 128.0
		_BumpPower("Bump Power", Float) = 1.0
		_MainTex("Diffuse (RGB) Alpha (A)", 2D) = "white" {}
		_NormalMap("Normal (Normal)", 2D) = "bump" {}
		_SpecularTex("Specular Level (R) Gloss (G) Rim Mask (B)", 2D) = "gray" {}
		_RampTex("Toon Ramp (RGB)", 2D) = "white" {}
		_Cutoff("Alphatest Cutoff", Range(0, 1)) = 0.5
	}

	SubShader{

			Tags{ "RenderType" = "Opaque" }

			CGPROGRAM
#pragma surface surf TF2 alphatest:_Cutoff
#pragma target 3.0

			struct Input
			{
				float2 uv_MainTex;
				float3 worldNormal;
				INTERNAL_DATA
			};

			//Exposed Variables that can be set from outside
			sampler2D _MainTex;
			sampler2D _SpecularTex;
			sampler2D _NormalMap;
			sampler2D _RampTex;

			float4 _RimColor;
			float _RimPower;
			float _SpecPower;
			float _BumpPower;

			inline fixed4 LightingTF2(SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed atten)
			{
				fixed3 h = normalize(lightDir + viewDir);
				fixed NdotL = dot(s.Normal, lightDir)  * 0.5 + 0.5;

				fixed3 ramp = tex2D(_RampTex, float2((NdotL * atten), (NdotL  * atten))).rgb;

				float nh = max(0, dot(s.Normal, h));
				float spec = pow(nh, s.Gloss * _SpecPower) * s.Specular;
				fixed4 c;
				c.rgb = ((s.Albedo * ramp * _LightColor0.rgb + _LightColor0.rgb * spec) * (atten * 2));
				c.a = s.Alpha;
				return c;
			}

			void surf(Input IN, inout SurfaceOutput o)
			{
				o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
				o.Alpha = tex2D(_MainTex, IN.uv_MainTex).a;
				o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
				o.Normal.z = o.Normal.z / _BumpPower;
				float3 specGloss = tex2D(_SpecularTex, IN.uv_MainTex).rgb;
				o.Specular = specGloss.r;
				o.Gloss = specGloss.g;
				half3 rim = pow(max(0, dot(float3(0, 1, 0), WorldNormalVector(IN, o.Normal))), _RimPower) * _RimColor.rgb * _RimColor.a * specGloss.b;
				o.Emission = rim;
			}

			ENDCG

		}
		Fallback "Bumped Specular"
}