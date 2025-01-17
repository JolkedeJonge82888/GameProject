﻿Shader "LeapMotion/TubeShader" {
  Properties{
    _Color("Color", Color) = (1,1,1,1)
    _Glossiness("Smoothness", Range(0,1)) = 0.5
    _Metallic("Metallic", Range(0,1)) = 0.0
     _Glow("Intensity", Range(0, 3)) = 1
  }
  SubShader{
    Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "Glowable"="True"}
    LOD 200

    CGPROGRAM
    #pragma surface surf Standard fullforwardshadows
    #pragma target 3.0

    struct Input {
      float4 color : COLOR;
    };

    half _Glossiness;
    half _Metallic;
    fixed4 _Color;
    half _Glow;

    void surf(Input IN, inout SurfaceOutputStandard o) {
     o.Albedo = (_Color + _Glow * IN.color).rgb;
      o.Metallic = _Metallic;
      o.Smoothness = _Glossiness;
    }
    ENDCG
  }
  FallBack "Diffuse"
}