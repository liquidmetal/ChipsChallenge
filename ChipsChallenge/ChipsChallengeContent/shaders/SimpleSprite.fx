sampler tex : register(s0);
sampler mask : register(s1);

float4 PixelShaderFunction(float2 uv: TEXCOORD0, float4 color : COLOR0) : COLOR0
{
	float4 ret;

	float4 currentColor = tex2D(tex, uv);
	if(tex2D(mask, uv).a>0)
		ret = currentColor;
	else
		ret = float4(0,0,0,0);

	return ret;
}

technique Technique1
{
    pass Pass1
    {
		ZEnable = TRUE;
		ZWriteEnable = TRUE;
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
