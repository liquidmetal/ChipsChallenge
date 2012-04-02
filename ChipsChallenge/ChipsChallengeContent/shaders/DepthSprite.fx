sampler currentHeightMap : register(s0);
sampler heightBuffer : register(s1);

float2 position;
float2 bufferSize;
float2 texSize;

float4 PixelShaderFunction(float2 uv : TEXCOORD0, float4 col : COLOR0) : COLOR0
{
	float4 ret;

	float2 newPosition;
	float newHeight;

	float2 shifted;

	float2 existingPosition;
	float existingHeight;

	float separation;
	float pyth;
	float thresh;
	
	//newHeight = tex2D(currentHeightMap, uv);
	//newPosition = float2(uv.x, uv.y - newHeight);

	
	shifted = float2((uv.x*texSize.x + position.x)/bufferSize.x, (uv.y*texSize.y + position.y)/bufferSize.y);
	//existingHeight = tex2D(heightBuffer, shifted);
	//existingPosition = float2(uv.x, uv.y - existingHeight);

	//separation = (existingPosition.y-position.y) - newPosition.y;

	//pyth = (separation*separation) + (existingHeight-newHeight)*(existingHeight-newHeight);
	//thresh = (existingHeight-newHeight)*(existingHeight-newHeight) + (existingHeight-newHeight)*(existingHeight-newHeight);

	/*if(pyth>=thresh)
	{
		ret.rgba = tex2D(currentHeightMap, uv);

		return ret;
	}*/

	ret.rgb = tex2D(currentHeightMap, uv)*col;
	ret.a=tex2D(currentHeightMap, uv).a;
	return ret;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
