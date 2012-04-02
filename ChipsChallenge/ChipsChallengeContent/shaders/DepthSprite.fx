sampler currentHeightMap : register(s0);
sampler heightBuffer : register(s1);

float2 position;
float2 bufferSize;
float2 texSize;

float4 PixelShaderFunction(float2 uv : TEXCOORD0, float4 col : COLOR0) : COLOR0
{
	float4 ret;

	float2 shifted;
	float2 shiftedUnnormalized;

	float3 bufferPos;
	float3 texturePos;

	shiftedUnnormalized = float2((position.x + uv.x*texSize.x), (position.y + uv.y*texSize.y));
	shifted = float2(shiftedUnnormalized.x/bufferSize.x, shiftedUnnormalized.y/bufferSize.y);

	float4 currentColor = tex2D(currentHeightMap, uv);
	float4 bufferColor = tex2D(heightBuffer, shifted);

	bufferPos = float3(shiftedUnnormalized.x, shiftedUnnormalized.y+bufferColor.r, bufferColor.r);
	texturePos = float3(uv.x*texSize.x, uv.y*texSize.y+currentColor.r, currentColor.r);

	float pyth;
	float thresh;

	//thresh = 2*(texturePos.z-bufferPos.z)*(texturePos.z-bufferPos.z);
	//pyth = (texturePos.z-bufferPos.z)*(texturePos.z-bufferPos.z) + ((texturePos.y+position.y)-bufferPos.y)*((texturePos.y+position.y)-bufferPos.y);

	if(bufferPos.y<=texturePos.y+position.y)
	{
		ret = currentColor;
		ret.a = 0;
	}
	else
	{
		ret = bufferColor;
		ret.a = 1;
	}
	

	return ret;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
