Shader "ObjectShader"{
	SubShader{
		Tags {"Queue" = "Geometry"}
		Lighting Off
		Pass{
			

			CGPROGRAM
			
			#pragma vertex vert 
			#pragma fragment frag

			float4 vert(float4 vertexPos : POSITION) : SV_POSITION       {
            return UnityObjectToClipPos(vertexPos);       
			}

			float4 frag(void) : COLOR {
            return float4(1, 1, 1, 1.0);               
			}

			ENDCG
			}
		}
	}