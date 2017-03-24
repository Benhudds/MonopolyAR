Shader "Hidden/ColorPatternHighlight_add" 
{
	Properties 
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}		
	}

	SubShader 
	{
		Pass
		{
		
		CGPROGRAM
		#pragma vertex vert_img
		#pragma fragment frag
		#pragma target 3.0
		
		#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
		uniform sampler2D _Pattern;
		fixed4 _PatCol;		
		half _Range;
		half _HueRange;
		half _Strength;
		half _tilingX;
		half _tilingY;
		half _tilingShiftX;
		half _tilingShiftY;
		half _edgeCoef;
		
		float4 frag(v2f_img i) : COLOR
		{
			float4 c = tex2D(_MainTex, i.uv);
			
			half2 nuv;
			nuv.x = frac(i.uv.x * _tilingX + _tilingShiftX);
			nuv.y = frac(i.uv.y * _tilingY + _tilingShiftY);
			
			half hueDiff = abs(atan2(1.73205 * (c.g - c.b), 2 * c.r - c.g - c.b + 0.001) -  atan2(1.73205 * (_PatCol.g - _PatCol.b), 2 * _PatCol.r - _PatCol.g - _PatCol.b + 0.001));
														
			c.rgb =lerp(c.rgb,(c.rgb + tex2D(_Pattern,nuv) * _Strength),sqrt(saturate((1 - ((c.r - _PatCol.r)*(c.r - _PatCol.r) + (c.g - _PatCol.g)*(c.g - _PatCol.g) + (c.b - _PatCol.b)*(c.b - _PatCol.b)) / (_Range * _Range))*_edgeCoef) * saturate((1.0 - min(hueDiff,6.28319 - hueDiff)/(_HueRange * _HueRange))*_edgeCoef)));
			
			return c;		
		}

		ENDCG
		} 
	}
}