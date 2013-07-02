Shader "Custom/OneMinusThenTint"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color("Main Color", Color) = (1,1,1)
	}
	SubShader
	{
		Pass
		{
	        SetTexture [_MainTex]
	        {
	        	Combine one - texture	        	
	        }
	        
	        SetTexture [_MainTex]
	        {
	        	Combine previous * constant ConstantColor[_Color]
        	}
		}
	}
}
